using Common.Constant;
using Common.Model;
using Common.Services;
using EasyClip.Infrastructure.Config;
using EasyClip.Infrastructure.Project;
using EasyClip.Services;
using EasyClip.View.DialogMessage;
using Lib;
using Lib.VoiceServices.ElevenLabs;
using Lib.VoiceServices.ElevenLabs.V1;
using Lib.VoiceServices.ElevenLabs.V1.Model;
using Lib.VoiceServices.ElevenLabs.V1.Services;
using Lib.VoiceServices.GoogleTTS;
using LibCommon.Common;
using Newtonsoft.Json.Linq;
using ReviewMovie.Infrastructure.Config;
using ReviewMovie.Infrastructure.Project;
using ReviewMovie.Model;
using ReviewMovie.Services;
using SubtitlesParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReviewMovie
{
    public partial class FormMain : Form
    {
        private readonly IClipPlayerService _clipPlayerService = new ClipPlayerService();

        private readonly IProjectDataService _projectService;
        private readonly IConfigDataService _configService;
        private readonly LoadConfigDataServices _loadConfig;
        private readonly RenderDataSyncService _renderSyncService;

        private readonly AudioConvertService _audioConvertService;
        private AudioConvertContextModel _audioConvertContext;

        // Khởi tạo (chỉ 1 lần)
        private readonly LoadingService _loadingService = new LoadingService(() => new FormLoadingCancel());


        private readonly IAudioRecordService _audioRecordService;
        private readonly IAudioDownloadService _audioDownloadService;

        #region Const_Variable

        const string ERR_PROJECT_EMPTY = "Nhập Đường Dẫn & Khởi Tạo Project !";
        const string ERR_ROW_INDEX = "Chọn 1 Row để nạp thông tin !";

        const long MAX_SIZE_BYTES = 1 * 1024 * 1024; // 1 MB = 1,048,576 bytes

        private ToolTip toolTipPL;

        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 15); // Giới hạn số lượng nhóm được render đồng thời
        private int renderedVideoCount = 0; // Biến đếm số lượng video đã được render
        private int InsertInfoSubtitleCount = 0;

        public static ConfigModel _progCOnf = new ConfigModel();
        public InfoProject _infoProject = new InfoProject();

        public static List<InfoRenderVd> _allInfoRender = new List<InfoRenderVd>();
        public static BindingList<InfoMainView> _listdata = new BindingList<InfoMainView>();
        public static List<InfoMainView> _listSubtitleData;
        public static List<Voice> _listVoice = new List<Voice>();
        public static VoiceSettings _voiceSetting = new VoiceSettings();

        bool _isSwithProject;
        private EffectTypeSelect _effectType;
        private ModeTypeSelect _modeType;
        private ManualSelect _manualSelected;
        private string _previousText;

        private string _projectName;
        private string _vdquality;
        private string _zoomQuality;
        private decimal _zoomRatio;
        private string _voiceCode;

        private bool isCheckedState = false;
        private bool _statusZoom;
        private bool _statusFlip;
        private bool _statusFlipRandom;
        private bool _statusRotate;
        private bool _statusLayerRandomMoveX;
        private bool _statusMuted;
        private bool _statusOpenPlayer;

        private double _extentTimeAudio = 0.05;
        public int _indexRowMax = 0;
        public int _indexRowSelect = -1;
        private bool _videoShort = false;
        private bool _checkrecord = false;

        private const decimal _speechRatioDefault = 0.5m;

        private decimal _speechratioElevenlab = 0.5m;
        private const decimal _speechratioFptAI = 0.5m;
        private const decimal _speechratioVbee = 1.0m;
        private const decimal _speechratioGoogleTTS = 0.5m;

        private Thread _thread_ConvertSpeech;
        private Thread _theart_videotheostt;
        private Thread _thread_rendervideo;
        private Thread _thread_downloadaudio;

        private string _projectPath;
        private string _audioPath;
        private string _mediaPath;
        private string _mergeVideoPath;
        private string _audioTempPath;
        private string _videoRenderPath;
        private string _tempPath;
        private string _outputPath;

        private string _appcode;
        private string _apikey;

        private string _videoMerge;
        private bool _sessionMerge;
        #endregion

        #region Main_Init
        public FormMain(string appcode, string apikey)
        {
            InitializeComponent();
            this.toolTipPL = new ToolTip();
            this.Text = "EasyClip || " + "TPMEDIA";

            _appcode = appcode;
            _apikey = apikey;

            _sessionMerge = false;
            _clipPlayerService.ListenForClipPlayerMessages(HandleClipPlayerMessage);

            // Khởi tạo Project Services
            _projectService = new ProjectDataService();
            _configService = new ConfigDataService();
            _renderSyncService = new RenderDataSyncService(_projectService);
            _audioConvertService = new AudioConvertService();
            _audioRecordService = new AudioRecordService();
            _audioDownloadService = new AudioDownloadService();


            // Khởi tạo config nếu chưa có (chưa chứa project)
            _loadConfig = new LoadConfigDataServices(_configService, _projectService);
            _loadConfig.InitOrUpdateBaseConfig(_apikey, txtAppID.Text, txtAppID.Text, txtToken.Text);
            
            Init();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //CreateProjectPath();  // bỏ tạo project tại thư mục gốc
            ActiveProject.ActiveGroupBoxSetting(tlpView, grbConfigVoice, grbConfigRender, grbActionRender, false);

            scView.Panel2Collapsed = true;
            dgvMainView.AutoGenerateColumns = false;    // tạo các cột tùy chỉnh cho DataGridView  => ko có là lỗi
            _statusZoom = true; // Khai báo cờ check
            _statusOpenPlayer = true;
        }
        private void Init()
        {
            //Load data vào Object cục bộ
            LoadProjectListData();
            DisplayItemDefault();
            loadApiKey();
        }
        private void LoadProjectListData()
        {
            _progCOnf = _configService.GetItem(1);

            var listProjectName = new List<ProjectName>
            {
                new ProjectName { ProjectPath = string.Empty } // Item blank ở đầu danh sách
            };

            var listProject = _progCOnf?.ProjectNames?
                .OrderByDescending(p => p.date)
                .Select(p => new ProjectName
                {
                    ID = p.ID,
                    ProjectPath = p.ProjectPath
                });

            if (listProject != null)
            {
                listProjectName.AddRange(listProject);
            }

            var comboItems = listProjectName.Select(p => new ComboboxModel
            {
                Display = p.ProjectPath,
                Value = p.ID.ToString()
            }).ToList();

            ComboBoxFuncion.CbBlinding(cbProjectName, comboItems, 0);
        }

        private void ReloadProjectList()
        {
            RestoreDeafautDataGridView();
            LoadProjectListData();
            _projectName = string.Empty;
        }
        private void RestoreDeafautDataGridView()
        {
            _listdata = new BindingList<InfoMainView>();
            dgvMainView.DataSource = null;
            dgvMainView.Refresh();
        }

        private async Task LoadSubtitleAsync(CancellationToken token)
        {
            bool isSubtitleError = true;
            var oldListData = _listdata;
            var oldListSubtitleData = _listSubtitleData;
            var oldAllInfoRender = _allInfoRender; // Hàm này cần lưu ý chỉ sử dụng trong 1 session, cần lưu ý khi muốn sử dụng nhiều thread chạy song song.
            var countFileError = 0;

            try
            {
                _listSubtitleData = new List<InfoMainView>();
                _listdata = new BindingList<InfoMainView>();
                _allInfoRender = new List<InfoRenderVd>();

                token.ThrowIfCancellationRequested();

                var subtitleValue = SubtitleReaderV2.ReadSubtitle(_infoProject.InforSubtitleFile.SubtitleFile,ref isSubtitleError);
                if(!isSubtitleError)
                {
                    RestoreOldData(oldListData, oldListSubtitleData, oldAllInfoRender);
                    ShowMessage("File SubTitle sai định dạng!", "Thông báo");
                    return;
                }   
                
                _indexRowMax = subtitleValue.Count;
                string filePathTtile = _infoProject.InforSubtitleFile.SubtitleFile;

                if(_indexRowMax == 0 || !File.Exists(filePathTtile))
                {
                    RestoreOldData(oldListData, oldListSubtitleData, oldAllInfoRender);
                    ShowMessage("File SubTitle không có dữ liệu!", "Thông báo");
                    return;
                }    

                bool hasVideoZero = false;
                string checkZeroFile = CFuncion.FindFullNameMediaPath(_infoProject.InforSubtitleFile.FolderSubtileMediaFile, "0");

                if (!string.IsNullOrEmpty(checkZeroFile) && CFuncion.CheckMediaType(checkZeroFile))
                {
                    _indexRowMax += 1;
                    hasVideoZero = true;
                }

                //for (int i = 0; i < subtitleValue.Count; i++)
                //{
                //    var filePath = CFuncion.FindFullNameMediaPath(_infoProject.InforSubtitleFile.FolderSubtileMediaFile, (i + 1).ToString());
                //    if (!string.IsNullOrEmpty(filePath) && CFuncion.CheckMediaType(filePath))
                //    {
                //        PrepareSubtitleData(i, string.Join(",", subtitleValue[i].InlineTextList), filePath);
                //    }
                //    else
                //    {
                //        PrepareSubtitleData(i, string.Join(",", subtitleValue[i].InlineTextList), string.Empty);
                //    }
                //}

                for (int i = 0; i < _indexRowMax; i++)
                {
                    token.ThrowIfCancellationRequested();

                    string filePath;
                    string subtitleText;

                    if (i == 0)
                    {
                        filePath = checkZeroFile;

                        if (hasVideoZero)
                        {
                            subtitleText = string.Empty; // Media 0, không có subtitle
                        }
                        else
                        {
                            // Sử dụng video số 1 nếu video số 0 không tồn tại  -> liên quan QUAN TRỌNG đến tool cut video
                            filePath = CFuncion.FindFullNameMediaPath(_infoProject.InforSubtitleFile.FolderSubtileMediaFile, "1");

                            if (!CFuncion.CheckMediaType(filePath))
                            {
                                countFileError++;
                            }    
                            subtitleText = string.Join(",", subtitleValue[0].InlineTextList);
                        }
                    }
                    else
                    {
                        // Xử lý các dòng còn lại
                        int subtitleIndex = hasVideoZero ? i - 1 : i; // Điều chỉnh index nếu có video số 0

                        filePath = CFuncion.FindFullNameMediaPath(_infoProject.InforSubtitleFile.FolderSubtileMediaFile, (i + (hasVideoZero ? 0 : 1)).ToString());

                        if(!CFuncion.CheckMediaType(filePath))
                        {
                            countFileError++;
                        }     
                        subtitleText = string.Join(",", subtitleValue[subtitleIndex].InlineTextList);
                    }

                    PrepareSubtitleData(i, subtitleText, filePath);
                }

                // Đếm số lượng file Split video chưa đúng
                if (countFileError == _indexRowMax)
                {
                    RestoreOldData(oldListData, oldListSubtitleData, oldAllInfoRender);
                    ShowMessage("Chọn thư mục chứa media . Không Chọn file !", "Thông báo");
                    return;
                }

                // CHọn file không đúng định dạng
                if (countFileError > 0)
                {
                    ShowMessage($"Thư mục có {countFileError} file không đúng định dạng!", "Thông báo");
                }

                // Clear trước khi load mới
                _listdata.Clear();

                foreach (var item in _listSubtitleData)
                    _listdata.Add(item);

                dgvMainView.DataSource = null;
                dgvMainView.DataSource = _listdata;
                dgvMainView.Refresh();

                txtTextInput.ReadOnly = true;

                if (_listdata.Count > 0)
                {
                    List<int> listRender = RVFuncion.GenerateList(_indexRowMax);
                    await Pr_InsertAllInfoMeida(listRender, _indexRowMax, token);
                }

                // Đồng bộ lại vào project
                _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
        }

        // Hàm phục hồi dữ liệu cũ
        private void RestoreOldData(BindingList<InfoMainView> oldListData, List<InfoMainView> oldListSubtitleData, List<InfoRenderVd> oldAllInfoRender)
        {
            _listdata = oldListData;
            _listSubtitleData = oldListSubtitleData;
            _allInfoRender = oldAllInfoRender;
        }

        // Hàm gọi show message Thông báo
        private void ShowMessage(string message, string tileMessage)
        {
            MessageBox.Show(message, tileMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PrepareSubtitleData(int i, string textCmt, string mediaFilePath)
        {
            var addEmptydata = new InfoMainView
            {
                check = false,
                id = i,
                idxnumber = i.ToString(),
                textlength = null,
                audiolink = null,
                audiotime = null,
                audiostatus = null,
                filemediapath = mediaFilePath,
                timevideo = null,
                renderstatus = string.Empty,
                inputtext = textCmt
            };
            _listSubtitleData.Add(addEmptydata);
            _allInfoRender.Add(new InfoRenderVd()
            {
                NoID = i,
                MediaFilePath = mediaFilePath,
                TextInput = textCmt
            });
        }

        private void HandleClipPlayerMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message) || !File.Exists(message))
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show("ClipPlayer trả về đường dẫn không tồn tại:\n" + message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _sessionMerge = false;
                }));
                return;
            }

            this.Invoke((Action)(() =>
            {
                _videoMerge = message;
                _sessionMerge = true;

                MessageBox.Show("VideoMerge:\n" + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InSertInputMediaData(_videoMerge, _indexRowSelect);
            }));
        }



        private async Task Pr_InsertAllInfoMeida(List<int> listNumber, int totalIdx, CancellationToken token)
        {
            InsertInfoSubtitleCount = 1;
            //int totalIndex = _indexRowMax - 1;
            //List<int> listLine = RVFuncion.GenerateList(_indexRowMax);

            // Chia danh sách video thành các nhóm số video:Numprocess trong mỗi nhóm
            var lineGroups = RVFuncion.Partition(listNumber, (int)nbThread.Value);

            // Render video theo từng nhóm
            var tasks = new List<Task>();
            foreach (var lineGroup in lineGroups)
            {
                tasks.Add(GrAsync_InsertAllinfoMedia(lineGroup, totalIdx, token));
            }

            // Đợi tất cả các nhóm video hoàn thành
            await Task.WhenAll(tasks);
            UIThreadHelper.SetLabelText(lblstatus, "Cập nhật TimeVideo xong !", Color.Green);
        }

        private async Task GrAsync_InsertAllinfoMedia(List<int> listLine, int totalIdx, CancellationToken token)
        {
            var tasks = new List<Task>();
            // Sử dụng SemaphoreSlim để giới hạn số lượng nhóm được render đồng thời
            await semaphore.WaitAsync(token);
            try
            {
                // Render video từng cái một trong nhóm
                foreach (var index in listLine)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        token.ThrowIfCancellationRequested();
                        var reloadFilePath = dgvMainView.Rows[index].Cells["Column_filemediapath"].Value?.ToString();
                        InSertInputMediaData(reloadFilePath, index);
                        UIThreadHelper.SetLabelText(lblstatus, $"Đang Reload Line {InsertInfoSubtitleCount}/{totalIdx} Subtitle.", Color.Red);
                        Interlocked.Increment(ref InsertInfoSubtitleCount);
                    }, token));
                }

                // Đợi tất cả các video trong nhóm hoàn thành render
                await Task.WhenAll(tasks);
            }
            finally
            {
                // Giải phóng SemaphoreSlim để cho phép các nhóm video khác được render
                semaphore.Release();
            }
        }

        private void loadApiKey()
        {
            var reloadConfig = _configService.GetItem(1);
            if (_manualSelected == ManualSelect.FptAI)
            {
                if (!string.IsNullOrEmpty(reloadConfig.FptAIKey)) txtAppID.Text = reloadConfig.FptAIKey;
            }
            else if (_manualSelected == ManualSelect.Google)
            {
                if (!string.IsNullOrEmpty(reloadConfig.GoogleTTSKey)) txtAppID.Text = reloadConfig.GoogleTTSKey;
            }
            else if (_manualSelected == ManualSelect.Elevenlab)
            {
                if (!string.IsNullOrEmpty(reloadConfig.ElevenlabKey)) txtAppID.Text = reloadConfig.ElevenlabKey;
            }
            else if (_manualSelected == ManualSelect.Vbee)
            {
                if (!string.IsNullOrEmpty(reloadConfig.VbeeAppId)) txtAppID.Text = reloadConfig.VbeeAppId;
                if (!string.IsNullOrEmpty(reloadConfig.VbeeAppToken)) txtToken.Text = reloadConfig.VbeeAppToken;
            }
        }
        private void LoadOtherData(InfoProject info, bool stdefault)
        {
            var valEffectSettup = info.EffectSettup;  // Chuyển vào phần chọn Project list
            if (valEffectSettup != null && valEffectSettup.Active)
            {
                // load % ZoomUp 
                ComboBoxFuncion.CbBlinding(cbZoomRatio
                             , ComboboxZoomRatio.ZoomRatioTemplate().ToList()
                             , ComboboxZoomRatio.ZoomRatioTemplate()
                                                .FindIndex(x => x.Display.Equals(stdefault ? ZoomRatiotName.ZoomRatio10_Des : valEffectSettup.SzoomRatio)));

                // load % ZQuality
                ComboBoxFuncion.CbBlinding(cbZoomQuality
                            , ComboboxZoomQuality.ZoomQualityTemplate().ToList()
                            , ComboboxZoomQuality.ZoomQualityTemplate()
                                                  .FindIndex(x => x.Display.Equals(stdefault ? ZoomQualitytName.ZoomQuality_Medium_Des : valEffectSettup.SzoomQuality)));

                // load Chất lượng
                ComboBoxFuncion.CbBlinding(cbxVideoQuality
                    , ComboboxSizeVideo.SizeVideoTemplate().ToList()
                    , ComboboxSizeVideo.SizeVideoTemplate()
                                        .FindIndex(x => x.Display.Equals(stdefault ? SizeVideo.Quality1080_Des : valEffectSettup.SvideoQuality)));

                // load Cmode : Dạng của Chất lượng
                var modeTypeTemplate = valEffectSettup.SvideoShort
                                        ? ComboboxMode.ModeTypeTemplate().Where(x => x.Type == ModeName.ShortType).ToList()
                                        : ComboboxMode.ModeTypeTemplate().Where(x => x.Type == ModeName.WideType).ToList();
                ComboBoxFuncion.CbBlinding(cbMode
                    , modeTypeTemplate
                    , stdefault ? 0
                                : modeTypeTemplate.FindIndex(x => x.Display.Equals(valEffectSettup.Smode)));

                // load Hiệu ứng
                ComboBoxFuncion.CbBlinding(cbEffectType
                                , ComboboxEffectType.EffectTypeTemplate().ToList()
                                , ComboboxEffectType.EffectTypeTemplate().FindIndex(x => x.Display.Equals(stdefault ? EffectName.EffectRandom_Des : valEffectSettup.SeffectType)));

                nFPS.Value = stdefault ? 30 : valEffectSettup.Sfps;
                nbThread.Value = stdefault ? 2 : valEffectSettup.Sthread;
                nbVolumnOrigin.Value = stdefault ? (decimal)0.2 : valEffectSettup.SvolumnOrigin;

                string sr = valEffectSettup.SspeechRatio;
                nbSpeechRatio.Value = decimal.TryParse(sr, out var r) ? r : _speechRatioDefault;

                nScaleAudioRangeStart.Value = stdefault ? (decimal)1.1 : valEffectSettup.SscaleAudioRangeStart;
                nScaleAudioRangeEnd.Value = stdefault ? (decimal)1.2 : valEffectSettup.SscaleAudioRangeEnd;

                CkZoom.Checked = stdefault ? true
                                            : valEffectSettup.SckZoom ? true : true;
                ckRotate.Checked = stdefault ? false
                                            : valEffectSettup.SckRotate ? true : false;
                ckHflip.Checked = stdefault ? false
                                            : valEffectSettup.SckHflip ? true : false;
                ckHflipRandom.Checked = stdefault ? false
                                                    : valEffectSettup.SckHflipRandom ? true : false;
                ckRandomMoveLeftRight.Checked = stdefault ? false
                                                            : valEffectSettup.SrandomMoveLeftRight ? true : false;
                ckNotUseAudio.Checked = stdefault ? false
                                                    : valEffectSettup.SckNotUseAudio ? true : false;
            }
        }
        private void PrepareData(List<InfoRenderVd> allInfoRender, ref BindingList<InfoMainView> listdata)
        {
            try
            {
                listdata.Clear(); // rất quan trọng nếu bạn dùng ref listdata

                foreach (var infovd in allInfoRender.OrderBy(x => x.NoID))
                {
                    var data = new InfoMainView
                    {
                        check = false,
                        id = infovd.NoID,
                        idxnumber = infovd.NoID.ToString(),
                        textlength = infovd.Textlength,
                        audiolink = infovd.AudioLink,
                        audiotime = string.Format("{0}s", infovd.Audiotime?.ToString("0.000") ?? "0"),
                        audiostatus = infovd.AudioStatus,
                        filemediapath = infovd.MediaFilePath,
                        timevideo = infovd.TimeOfMediaPart.HasValue
                                    ? string.Format("{0}s", infovd.TimeOfMediaPart?.ToString("0.000"))
                                    : infovd.LblVdtime,
                        renderstatus = infovd.RenderStatus,
                        inputtext = infovd.TextInput
                    };
                    listdata.Add(data);
                }

                dgvMainView.DataSource = null;
                dgvMainView.DataSource = listdata;
                dgvMainView.Refresh();

                _indexRowMax = listdata.Count > 0 ? listdata.Max(x => x.id) + 1 : 0;

                LoadColorDatagrid(allInfoRender, listdata.Count);
                LoadDataGridInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi dữ liệu cũ, hãy xóa đi!\n" + ex.Message);
            }
        }

        private void LoadColorDatagrid(List<InfoRenderVd> allInfoRender, int allcount)
        {
            for (int i = 0; i < allcount; i++)
            {
                var infovd = allInfoRender.Find(x => x.NoID == i);
                if (infovd != null && infovd.MediaMiss)
                {
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, i, "Column_filemediapath", infovd.MediaFilePath, Color.Red);
                }
            }
        }
        private void LoadDataGridInit()
        {
            if (dgvMainView.RowCount > 0)
            {
                _indexRowSelect = 0;
                txtTextInput.Text = dgvMainView.Rows[_indexRowSelect].Cells["Column_inputtext"].Value?.ToString();
                txtImPortMedia.Text = dgvMainView.Rows[_indexRowSelect].Cells["Column_filemediapath"].Value?.ToString();
            }
        }
        private void DisplayItemDefault()
        {
            // load % ZoomUp 
            ComboBoxFuncion.CbBlinding(cboSiteNguon, AISiteSource.VoiceSiteSelectTemplate().ToList(), 0);

            // load % ZoomUp 
            ComboBoxFuncion.CbBlinding(cbZoomRatio
                         , ComboboxZoomRatio.ZoomRatioTemplate().ToList()
                         , ComboboxZoomRatio.ZoomRatioTemplate().FindIndex(x => x.Display.Equals(ZoomRatiotName.ZoomRatio50_Des)));

            // load % ZQuality
            ComboBoxFuncion.CbBlinding(cbZoomQuality
                        , ComboboxZoomQuality.ZoomQualityTemplate().ToList()
                        , ComboboxZoomQuality.ZoomQualityTemplate().FindIndex(x => x.Display.Equals(ZoomQualitytName.ZoomQuality_Normal_Des)));

            // load Chất lượng
            ComboBoxFuncion.CbBlinding(cbxVideoQuality
                , ComboboxSizeVideo.SizeVideoTemplate().ToList()
                , ComboboxSizeVideo.SizeVideoTemplate().FindIndex(x => x.Display.Equals(SizeVideo.Quality1080_Des)));

            // load Hiệu ứng
            ComboBoxFuncion.CbBlinding(cbEffectType
                            , ComboboxEffectType.EffectTypeTemplate().ToList()
                            , ComboboxEffectType.EffectTypeTemplate().FindIndex(x => x.Display.Equals(EffectName.EffectRandom_Des)));

            // Load Cấu Hình Mẫu / Tùy chỉnh
            ComboBoxFuncion.CbBlinding(cbSettingTemplate
                           , EffectConfig.EffectConfigTemplate().ToList()
                           , EffectConfig.EffectConfigTemplate().ToList().FindIndex(x => x.Value.Equals(EffectConfigName.CUSTOM_Val)));
        }

        private void CreateProjectPath()
        {
            var folders = new[]
            {
                _projectPath,
                _audioPath,
                _mediaPath,
                _mergeVideoPath,
                _audioTempPath,
                _videoRenderPath,
                _tempPath,
                _outputPath
            };

            foreach (var path in folders)
            {
                Directory.CreateDirectory(path);
            }
        }

        private bool SaveEffectSetting()
        {
            if (_infoProject == null) return false;

            _infoProject.EffectSettup = new EffectSetting
            {
                Active = true,
                SzoomRatio = cbZoomRatio?.Text ?? string.Empty,
                SzoomQuality = cbZoomQuality?.Text ?? string.Empty,
                Sfps = (int)nFPS.Value,
                Sthread = (int)nbThread.Value,
                SvideoQuality = cbxVideoQuality?.Text ?? string.Empty,
                SvideoShort = _videoShort,
                Smode = cbMode?.Text ?? string.Empty,
                SeffectType = cbEffectType?.Text ?? string.Empty,
                SckZoom = _statusZoom,
                SckRotate = _statusRotate,
                SckHflip = _statusFlip,
                SckHflipRandom = _statusFlipRandom,
                SrandomMoveLeftRight = _statusLayerRandomMoveX,
                SvolumnOrigin = nbVolumnOrigin.Value,
                SscaleAudioRangeStart = nScaleAudioRangeStart.Value,
                SscaleAudioRangeEnd = nScaleAudioRangeEnd.Value,
                SspeechRatio = nbSpeechRatio.Value.ToString("0.0"),
                SckNotUseAudio = _statusMuted,
                SlanguageSelect = cbLanguageSelect?.Text ?? string.Empty,
                SspeechType = cbxSpeechType?.Text ?? string.Empty
            };

            return _projectService.InsertInfoProjectList(_infoProject);
        }

        #endregion

        #region FucNormal

        #region ConvertText2Speech
        private CancellationTokenSource _convertAllCTS;
        private CancellationTokenSource _convertSelectedCTS;
        private CancellationTokenSource _convertSingleCTS;

        private bool _isConvertingAll = false;
        private bool _isConvertingSelected = false;
        private bool _isConvertingSingle = false;

        private void PrepareAudioConvertContext()
        {
            _audioConvertContext = new AudioConvertContextModel
            {
                ProjectName = _projectName,
                AllInfoRender = _allInfoRender,
                InfoProject = _infoProject,
                ManualSelected = _manualSelected,
                VoiceSetting = new VoiceSettings
                {
                    Stability = (float)nbSpeechRatio.Value,
                    SimilarityBoost = _voiceSetting.SimilarityBoost,
                    Style = _voiceSetting.Style,
                    SpeakerBoost = _voiceSetting.SpeakerBoost
                },
                VoiceCode = _voiceCode,
                SpeechRatio = nbSpeechRatio.Value,
                AudioTempPath = _audioTempPath,
                AppID = txtAppID.Text,
                Token = txtToken.Text,

                // Lấy text input từ row index
                GetInputTextByIndex = idx =>
                {
                    if (idx < 0 || idx >= dgvMainView.Rows.Count)
                        return string.Empty;
                    return dgvMainView.Rows[idx].Cells["Column_inputtext"].Value?.ToString() ?? string.Empty;
                },

                // Cập nhật từng row (DataGridView, model, ... tùy app)
                UpdateRowCallback = (idx, audiolink, audiostatus, inputtext) =>
                {
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, idx, "Column_audiolink", audiolink, Color.White);
                    Color color = audiostatus == "Converted" ? Color.GreenYellow
                                : audiostatus == "Converting..." ? Color.Yellow
                                : audiostatus == "Đã huỷ" ? Color.Red
                                : Color.OrangeRed;
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, idx, "Column_audiostatus", audiostatus, color);

                    var info = _allInfoRender.FirstOrDefault(c => c.NoID == idx);
                    if (info != null)
                    {
                        info.TextInput = inputtext;
                        info.AudioLink = audiolink;
                        info.AudioStatus = audiostatus;
                    }
                },

                // Cập nhật trạng thái tổng thể (label, status bar)
                SetStatusCallback = (text, color) =>
                {
                    UIThreadHelper.SetLabelText(lblstatus, text, color);
                },

                // Thông báo (show MessageBox) khi batch khác đang chạy
                ShowAlertCallback = msg =>
                {
                    MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                },

                // Lưu vào database mỗi lần convert xong 1 dòng
                OnAfterRowConverted = (idx, audiolink, audiostatus, inputtext) =>
                {
                    // Nếu cần có thể thêm kiểm tra điều kiện update ở đây
                    _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
                }
            };
        }
        private async void btnConvertAudio_Click(object sender, EventArgs e)
        {
            if (_indexRowSelect < 0 || string.IsNullOrEmpty(_projectName))
            {
                MessageBox.Show(ERR_ROW_INDEX);
                return;
            }

            if (_isConvertingSingle)
            {
                _convertSingleCTS?.Cancel();
                return;
            }

            PrepareAudioConvertContext();
            _isConvertingSingle = true;
            _convertSingleCTS = new CancellationTokenSource();
            UIThreadHelper.SetButtonText(btnConvertAudio, "Stop", Color.Black);
            await Task.Delay(50);

            try
            {
                await _audioConvertService.ConvertText2SpeechAsync(_indexRowSelect, _audioConvertContext, _convertSingleCTS.Token);
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, "Đã huỷ convert dòng.", Color.OrangeRed);
            }
            finally
            {
                _isConvertingSingle = false;
                _convertSingleCTS?.Dispose();
                _convertSingleCTS = null;
                UIThreadHelper.SetButtonText(btnConvertAudio, "Convert Audio", Color.Black);
            }
        }
        private async void ConvertTex2SpeechAll_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            PrepareAudioConvertContext();

            await _audioConvertService.ConvertTextToSpeechBatchAsync(
                modeLabel: "Toàn bộ",
                isOtherRunning: () => _isConvertingSelected, // Nếu batch select đang chạy thì báo alert
                getTargetIndexes: () => Enumerable.Range(0, _indexRowMax).ToArray(),
                getIsRunning: () => _isConvertingAll,
                setIsRunning: val => _isConvertingAll = val,
                getCTS: () => _convertAllCTS,
                setCTS: val => _convertAllCTS = val,
                setTextAction: text => Invoke(new Action(() => menuItem.Text = text)),
                startText: "Chọn Hết",
                cancelText: "Huỷ Chọn Hết",
                context: _audioConvertContext
            );
        }
        private async void ConvertTex2SpeechSelect_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            PrepareAudioConvertContext();

            await _audioConvertService.ConvertTextToSpeechBatchAsync(
                modeLabel: "Dòng đã chọn",
                isOtherRunning: () => _isConvertingAll, // Nếu batch all đang chạy thì báo alert
                getTargetIndexes: () =>
                {
                    return dgvMainView.SelectedRows
                        .Cast<DataGridViewRow>()
                        .Select(row => Convert.ToInt32(row.Cells["Column_index"].Value))
                        .ToArray();
                },
                getIsRunning: () => _isConvertingSelected,
                setIsRunning: val => _isConvertingSelected = val,
                getCTS: () => _convertSelectedCTS,
                setCTS: val => _convertSelectedCTS = val,
                setTextAction: text => Invoke(new Action(() => menuItem.Text = text)),
                startText: "Chọn Nhóm",
                cancelText: "Huỷ Chọn Nhóm",
                context: _audioConvertContext
            );
        }

        #endregion

        #region Record_DownloadAudio
        private CancellationTokenSource _downloadSingleCTS;
        private CancellationTokenSource _downloadAllCTS;
        private CancellationTokenSource _downloadSelectedCTS;
        private CancellationTokenSource _recordCTS;

        private bool _isDownloadingSingle = false;
        private bool _isDownloadingAll = false;
        private bool _isDownloadingSelected = false;
        private bool _isRecording = false;

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (_indexRowSelect < 0 || string.IsNullOrEmpty(_projectName))
            {
                MessageBox.Show(ERR_ROW_INDEX);
                return;
            }

            if (!_isRecording)
            {
                _recordCTS = new CancellationTokenSource();
                _isRecording = true;

                // Tạo context model truyền các delegate xử lý UI, dữ liệu, DB
                var context = new AudioRecordContextModel
                {
                    RowIndex = _indexRowSelect,
                    AudioTempPath = _audioTempPath,
                    UpdateRowCallback = (idx, audiolink, audiostatus) =>
                    {
                        FuncDataGridView.UpdateDataGridViewCell(dgvMainView, idx, "Column_audiolink", audiolink, Color.White);

                        Color color = audiostatus == "End Record" ? Color.GreenYellow
                                    : audiostatus == "Start Recording ..." ? Color.Yellow
                                    : audiostatus == "Đã huỷ" ? Color.Red
                                    : Color.OrangeRed;

                        FuncDataGridView.UpdateDataGridViewCell(dgvMainView, idx, "Column_audiostatus", audiostatus, color);

                        var info = _allInfoRender.FirstOrDefault(c => c.NoID == idx);
                        if (info != null)
                        {
                            info.AudioLink = audiolink;
                            info.AudioStatus = audiostatus;
                        }
                    },
                    SetStatusCallback = (text, color) =>
                    {
                        UIThreadHelper.SetLabelText(lblstatus, text, color);
                    },
                    ShowAlertCallback = msg =>
                    {
                        MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    },
                    OnAfterRecord = (idx, audiolink, audiostatus) =>
                    {
                        _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);

                        // Nếu record thành công, download audio luôn
                        if (!string.IsNullOrEmpty(audiolink) && File.Exists(audiolink))
                        {
                            _ = CallDownloadAudioAsync(audiolink, idx, false, CancellationToken.None);
                        }

                        // Reset lại trạng thái ghi âm và nút bấm UI
                        Action resetUI = () =>
                        {
                            _isRecording = false;
                            UIThreadHelper.SetButtonText(btnRecord, "Record", Color.Black);
                        };

                        if (this.InvokeRequired)
                            this.Invoke(resetUI);
                        else
                            resetUI();
                    }
                };

                UIThreadHelper.SetButtonText(btnRecord, "Stop", Color.Yellow);
                _audioRecordService.StartRecord(context, _recordCTS.Token);
            }
            else
            {
                _audioRecordService.StopRecord();
                // Không reset ngay, chờ OnAfterRecord callback sẽ reset UI/flag
            }
        }

        private async void btnSaveAudio_Click(object sender, EventArgs e)
        {
            if (_indexRowSelect < 0 || string.IsNullOrEmpty(_projectName))
            {
                MessageBox.Show(ERR_ROW_INDEX);
                return;
            }

            if (_isDownloadingSingle)
            {
                _downloadSingleCTS?.Cancel();
                return;
            }

            _isDownloadingSingle = true;
            _downloadSingleCTS = new CancellationTokenSource();
            UIThreadHelper.SetButtonText(btnSaveAudio, "Stop", Color.Black);
            await Task.Delay(50);

            try
            {
                await theart_SaveSpeechAsync(_indexRowSelect, _downloadSingleCTS.Token);
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, "Đã huỷ download audio dòng.", Color.OrangeRed);
            }
            finally
            {
                _isDownloadingSingle = false;
                _downloadSingleCTS?.Dispose();
                _downloadSingleCTS = null;
                UIThreadHelper.SetButtonText(btnSaveAudio, "Save Audio", Color.Black);
            }
        }

        private async void DownAudioAll_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (_isDownloadingAll)
            {
                _downloadAllCTS?.Cancel();
                return;
            }

            _isDownloadingAll = true;
            _downloadAllCTS = new CancellationTokenSource();
            UIThreadHelper.SetMenuItemText(menuItem, "Hủy Chọn Hết", Color.Red);
            await Task.Delay(50);

            try
            {
                for (int i = 0; i < _indexRowMax; i++)
                {
                    _downloadAllCTS.Token.ThrowIfCancellationRequested();
                    await theart_SaveSpeechAsync(i, _downloadAllCTS.Token);
                    await Task.Delay(500, _downloadAllCTS.Token);
                }
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, "Đã huỷ tải toàn bộ audio.", Color.OrangeRed);
            }
            finally
            {
                _isDownloadingAll = false;
                _downloadAllCTS?.Dispose();
                _downloadAllCTS = null;
                UIThreadHelper.SetMenuItemText(menuItem, "Chọn Hết", Color.Black);
            }
        }

        private async void DownAudioAllSelect_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (_isDownloadingSelected)
            {
                _downloadSelectedCTS?.Cancel();
                return;
            }

            _isDownloadingSelected = true;
            _downloadSelectedCTS = new CancellationTokenSource();
            UIThreadHelper.SetMenuItemText(menuItem, "Hủy Chọn Nhóm", Color.Red);
            await Task.Delay(50);

            try
            {
                foreach (DataGridViewRow row in dgvMainView.SelectedRows)
                {
                    _downloadSelectedCTS.Token.ThrowIfCancellationRequested();
                    int id = Convert.ToInt32(row.Cells["Column_index"].Value);
                    await theart_SaveSpeechAsync(id, _downloadSelectedCTS.Token);
                    await Task.Delay(500, _downloadSelectedCTS.Token);
                }
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, "Đã huỷ tải những dòng audio đã chọn.", Color.OrangeRed);
            }
            finally
            {
                _isDownloadingSelected = false;
                _downloadSelectedCTS?.Dispose();
                _downloadSelectedCTS = null;
                UIThreadHelper.SetMenuItemText(menuItem, "Chọn Nhóm", Color.Black);
            }
        }

        private async Task theart_SaveSpeechAsync(int index, CancellationToken token)
        {
            var dataGridRowSelect = dgvMainView.Rows[index];

            FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_audiostatus", "Start Download ...", Color.Yellow);
            UIThreadHelper.SetLabelText(lblstatus, string.Format("Download part thứ {0}/{1}", index, dgvMainView.RowCount), Color.Green);

            token.ThrowIfCancellationRequested();

            if (_manualSelected == ManualSelect.FptAI)
                await DownloadAudio_FptAIAsync(btnSaveAudio, index, dataGridRowSelect, token);
            else if (_manualSelected == ManualSelect.Google)
                await DownloadAudio_GoogleTTSAsync(btnSaveAudio, index, dataGridRowSelect, token);
            else if (_manualSelected == ManualSelect.Elevenlab)
                await DownloadAudio_ElevenLabAsync(btnSaveAudio, index, dataGridRowSelect, token);
            else if (_manualSelected == ManualSelect.Vbee)
                await DownloadAudio_VbeeAsync(btnSaveAudio, index, dataGridRowSelect, token);

            var saveInfo = _allInfoRender.FirstOrDefault(c => c.NoID == index);
            if (saveInfo != null)
                saveInfo.AudioStatus = dataGridRowSelect.Cells["Column_audiostatus"].Value?.ToString();

            _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
        }

        private async Task DownloadAudio_VbeeAsync(Button ibtn, int index, DataGridViewRow dataGridRowSelect, CancellationToken token)
        {
            ApiVbee api = new ApiVbee();

            var input = new GetaudioModelInput
            {
                linksite = "https://vbee.vn/api/v1/tts",
                token = txtToken.Text,
                requestID = dataGridRowSelect.Cells["Column_audiolink"].Value?.ToString()
            };

            var output = await api.GetLinkaudioAsync(input);

            token.ThrowIfCancellationRequested(); // kiểm tra cancel sau await

            if (output?.result?.audio_link != null)
            {
                await CallDownloadAudioAsync(output.result.audio_link, index, false, token);
            }
            else
            {
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_audiostatus", "Không Tải được Audio !", Color.Red);
            }

            UIThreadHelper.SetButtonText(ibtn, "Save Audio", Color.Black);
        }

        private async Task DownloadAudio_ElevenLabAsync(Button ibtn, int index, DataGridViewRow dataGridRowSelect, CancellationToken token)
        {
            var historyID = dataGridRowSelect.Cells["Column_audiolink"].Value?.ToString();
            if (!string.IsNullOrEmpty(historyID))
            {
                await CallDownloadAudioAsync(historyID, index, false, token);
                UIThreadHelper.SetButtonText(ibtn, "Save Audio", Color.Black);
            }
            else
            {
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_audiostatus", "Không Có HistoryID", Color.Red);
            }
        }

        private async Task DownloadAudio_FptAIAsync(Button ibtn, int index, DataGridViewRow dataGridRowSelect, CancellationToken token)
        {
            var urlaudio = dataGridRowSelect.Cells["Column_audiolink"].Value?.ToString();
            if (!string.IsNullOrEmpty(urlaudio))
            {
                await CallDownloadAudioAsync(urlaudio, index, false, token);
                UIThreadHelper.SetButtonText(ibtn, "Save Audio", Color.Black);
            }
            else
            {
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_audiostatus", "Không Có Link Convert Speech !", Color.Red);
            }
        }
    
        private async Task DownloadAudio_GoogleTTSAsync(Button ibtn, int index, DataGridViewRow dataGridRowSelect, CancellationToken token)
        {
            var urlaudio = dataGridRowSelect.Cells["Column_audiolink"].Value?.ToString();
            if (!string.IsNullOrEmpty(urlaudio))
            {
                await CallDownloadAudioAsync(urlaudio, index, false, token);
                UIThreadHelper.SetButtonText(ibtn, "Save Audio", Color.Black);
            }
            else
            {
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_audiostatus", "Không Có Link File Download !", Color.Red);
            }
        }

        private async Task CallDownloadAudioAsync(string addressLink, int index, bool recordStatus, CancellationToken token)
        {
            var context = new AudioDownloadContextModel
            {
                RowIndex = index,
                AddressLink = addressLink,
                AudioPath = _audioPath,
                ScaleAudioRangeStart = (decimal)nScaleAudioRangeStart.Value,
                ScaleAudioRangeEnd = (decimal)nScaleAudioRangeEnd.Value,
                ManualSelected = _manualSelected,
                AppId = txtAppID.Text,

                GetDataGridViewRow = idx => dgvMainView.Rows[idx],
                GetInfoRenderByRowIndex = idx => _allInfoRender.FirstOrDefault(c => c.NoID == idx),

                UpdateCellCallback = (idx, column, value, color) =>
                {
                    // Chỉ cần gọi lại hàm cũ, không cần check invoke ở ngoài vì đã check bên trong rồi!
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, idx, column, value, color);
                },
                UpdateAudioTimeCallback = (idx, timeaudio) =>
                {
                    var info = _allInfoRender.FirstOrDefault(c => c.NoID == idx);
                    if (info != null) info.Audiotime = timeaudio;
                }
            };

            await _audioDownloadService.DownloadAudioAsync(context, recordStatus, token);
        }
        #endregion

        #region RenderVideo
        private CancellationTokenSource _renderVideoCTS;
        private CancellationTokenSource _renderAllCTS;
        private CancellationTokenSource _renderSelectCTS;
        private bool _isRenderingSingle = false;
        private bool _isRenderingAll = false;
        private bool _isRenderingSelected = false;

        private async void btnRenderVideoPart_Click(object sender, EventArgs e)
        {
            if (_indexRowSelect < 0 || string.IsNullOrEmpty(_projectName))
            {
                MessageBox.Show(ERR_ROW_INDEX);
                return;
            }

            if (!_isRenderingSingle)
            {
                _renderVideoCTS = new CancellationTokenSource();
                _isRenderingSingle = true;

                SaveEffectSetting();
                UIThreadHelper.SetButtonText(btnRenderVideoPart, "Stop", Color.Black);
                UIThreadHelper.SetLabelText(lblstatus, $"Render part thứ {_indexRowSelect + 1}/{dgvMainView.RowCount}", Color.Black);

                try
                {
                    await Task.Run(() =>
                    {
                        ThreadRenderVideoPart(_indexRowSelect, _renderVideoCTS.Token);
                    }, _renderVideoCTS.Token);
                }
                catch (OperationCanceledException)
                {
                    UIThreadHelper.SetLabelText(lblstatus, $"Đã huỷ render video part {_indexRowSelect}.", Color.OrangeRed);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi render: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _isRenderingSingle = false;
                    _renderVideoCTS?.Dispose();
                    _renderVideoCTS = null;
                    UIThreadHelper.SetButtonText(btnRenderVideoPart, "Render Part", Color.Black);
                }
            }
            else
            {
                _renderVideoCTS?.Cancel();
            }
        }

        private async void PartRenderAll_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (_isRenderingAll)
            {
                _renderAllCTS?.Cancel();
                return;
            }

            if (dgvMainView.RowCount <= 0) return;

            _isRenderingAll = true;
            _renderAllCTS = new CancellationTokenSource();
            UIThreadHelper.SetMenuItemText(menuItem, "Hủy Chọn Hết", Color.Red);
            await Task.Delay(50);

            try
            {
                List<int> listRender = RVFuncion.GenerateList(_indexRowMax);
                await Pr_RenderAll(listRender, _indexRowMax, _renderAllCTS.Token);
                UIThreadHelper.SetLabelText(lblstatus, "Render xong tất cả đoạn video!", Color.Green);
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, "Đã huỷ render toàn bộ.", Color.OrangeRed);
            }
            finally
            {
                _isRenderingAll = false;
                _renderAllCTS?.Dispose();
                _renderAllCTS = null;
                UIThreadHelper.SetMenuItemText(menuItem, "Chọn Hết", Color.Black);
            }
        }

        private async void PartRenderSelect_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;

            if (_isRenderingSelected)
            {
                _renderSelectCTS?.Cancel();
                return;
            }

            if (dgvMainView.RowCount <= 0) return;

            List<int> listNumber = new List<int>();
            foreach (DataGridViewRow row in dgvMainView.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells["Column_index"].Value);
                listNumber.Add(id);
            }

            if (listNumber.Count == 0)
            {
                MessageBox.Show("Không có dòng nào được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isRenderingSelected = true;
            _renderSelectCTS = new CancellationTokenSource();
            UIThreadHelper.SetMenuItemText(menuItem, "Hủy Chọn Nhóm", Color.Red);
            await Task.Delay(50);

            try
            {
                await Pr_RenderAll(listNumber, listNumber.Count, _renderSelectCTS.Token);
                UIThreadHelper.SetLabelText(lblstatus, "Render xong các dòng đã chọn!", Color.Green);
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, "Đã huỷ render nhóm chọn.", Color.OrangeRed);
            }
            finally
            {
                _isRenderingSelected = false;
                _renderSelectCTS?.Dispose();
                _renderSelectCTS = null;
                UIThreadHelper.SetMenuItemText(menuItem, "Chọn Nhóm", Color.Black);
            }
        }

        private async Task Pr_RenderAll(List<int> listNumber, int totalIdx, CancellationToken token)
        {
            renderedVideoCount = 1;
            //List<int> listRender = RVFuncion.GenerateList(_indexRowMax);
            // Chia danh sách video thành các nhóm số video:Numprocess trong mỗi nhóm
            var videoGroups = RVFuncion.Partition(listNumber, (int)nbThread.Value);
            // Render video theo từng nhóm
            var tasks = new List<Task>();

            foreach (var group in videoGroups)
            {
                tasks.Add(GrAsync_RenderListVideo(group, totalIdx, token));
            }

            // Đợi tất cả các nhóm video hoàn thành
            await Task.WhenAll(tasks);
        }

        private async Task GrAsync_RenderListVideo(List<int> listVideo, int totalIdx, CancellationToken token)
        {
            var tasks = new List<Task>();
            // Sử dụng SemaphoreSlim để giới hạn số lượng nhóm được render đồng thời
            await semaphore.WaitAsync(token);

            try
            {
                // Render video từng cái một trong nhóm
                foreach (var index in listVideo)
                {
                    //token.ThrowIfCancellationRequested();
                    tasks.Add(Task.Run(() =>
                    {
                        token.ThrowIfCancellationRequested();

                        //if (token.IsCancellationRequested) return;
                        UIThreadHelper.SetLabelText(lblstatus, $"Đang Render Part {renderedVideoCount}/{totalIdx} videos.", Color.Red);
                        ThreadRenderVideoPart(index, token);
                        // Tăng giá trị của biến đếm video đã được render
                        Interlocked.Increment(ref renderedVideoCount);
                    }, token));
                }

                // Đợi tất cả các video trong nhóm hoàn thành render
                await Task.WhenAll(tasks);
            }
            finally
            {
                // Giải phóng SemaphoreSlim để cho phép các nhóm video khác được render
                semaphore.Release();
            }
        }

        private void ThreadRenderVideoPart(int index, CancellationToken token)
        {
            if (token.IsCancellationRequested || index < 0 || index >= dgvMainView.Rows.Count) return;

            var row = dgvMainView.Rows[index];
            if (row.IsNewRow) return;

            // Lấy NoID từ Column_index
            if (!int.TryParse(row.Cells["Column_index"].Value?.ToString(), out int noId)) return;
            var renderInfo = _allInfoRender.FirstOrDefault(c => c.NoID == noId);
            if (renderInfo == null) return;

            var audioFilePath = _audioPath + $"{noId}.mp3";
            var saveFilePath = _videoRenderPath + $"{noId}.mp4";

            // Cập nhật TimeOfMediaPart nếu có giá trị từ UI
            if (decimal.TryParse(row.Cells["Column_timevideo"].Value?.ToString()?.Trim('s'), out decimal timemedia))
            {
                renderInfo.TimeOfMediaPart = timemedia;
            }

            if (!File.Exists(audioFilePath) && !ckNotUseAudio.Checked)
            {
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_renderstatus", "Thiếu Audio , Render part Lỗi !", Color.Red);
                return;
            }

            if (!File.Exists(renderInfo.MediaPath))
            {
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_renderstatus", "Thiếu Video , Render part Lỗi !", Color.Red);
                return;
            }

            try
            {
                token.ThrowIfCancellationRequested();

                var input = new RenderInfoDto
                {
                    AppCode = _appcode,
                    Index = noId,
                    AudioFile = audioFilePath,
                    MediaFile = renderInfo.MediaPath,
                    SaveFile = saveFilePath,
                    AtempoValue = renderInfo.CurrentTimeOfMediaPart.Value / renderInfo.TimeOfMediaPart.Value,
                    PTSvalue = renderInfo.TimeOfMediaPart.Value / renderInfo.CurrentTimeOfMediaPart.Value,
                    TimeOfPart = renderInfo.TimeOfMediaPart.Value,
                    Muted = _statusMuted,
                    CkZoom = _statusZoom,
                    ZoomRatio = (renderInfo.TimeOfMediaPart < 2.5m && _zoomRatio > Convert.ToDecimal(ZoomRatiotName.ZoomRatio25_Val))
                        ? Convert.ToDecimal(ZoomRatiotName.ZoomRatio10_Val)
                        : _zoomRatio,
                    ZoomQuality = _zoomQuality,
                    Fps = Convert.ToInt32(nFPS.Value),
                    CkRotate = _statusRotate,
                    CkHflip = _statusFlipRandom ? LibRandom.GetRandomBoolean() : _statusFlip,
                    CkLayerRandomMoveX = _statusLayerRandomMoveX,
                    VdSizeOutput = _vdquality,
                    VdSizeInput = new VideoProperties
                    {
                        Width = renderInfo.Width,
                        Height = renderInfo.Height
                    },
                    ModeType = _modeType,
                    EffectType = _effectType,
                    VolumnOrigin = nbVolumnOrigin.Value.ToString()
                };

                Rendervideo(input, token);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch
            {
                UIThreadHelper.SetLabelText(lblstatus, "Lỗi, Kiểm Tra Hoặc Nhập lại Media ", Color.Red);
            }

            // Cập nhật render status chính xác bằng NoID
            var updatedRow = dgvMainView.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => Convert.ToInt32(r.Cells["Column_index"].Value) == noId);
            if (updatedRow != null)
            {
                var status = updatedRow.Cells["Column_renderstatus"].Value?.ToString();
                if (!string.IsNullOrEmpty(status))
                    renderInfo.RenderStatus = status;
            }

            // Đồng bộ lại vào project
            _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
        }

        /// <summary>
        /// Khong dung Async vi dang bị out luong
        /// </summary>
        /// <param name="input"></param>
        /// <param name="token"></param>
        private void Rendervideo(RenderInfoDto input, CancellationToken token)
        {
            string message = string.Empty;
            try
            {
                token.ThrowIfCancellationRequested();

                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input?.Index ?? -1, "Column_renderstatus", "...", Color.Yellow);

                if (input == null)
                {
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, -1, "Column_renderstatus", "Input Error", Color.Red);
                    return;
                }

                if (!File.Exists(input.MediaFile))
                {
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", "Video Missing", Color.Red);
                    return;
                }

                var mtime = _allInfoRender?.Find(c => c.NoID == input.Index);
                if (mtime == null || mtime.Audiotime == null)
                {
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", "Audio Missing", Color.Red);
                    return;
                }

                MediaType checkMedia = CheckMedia.GetMediaType(input.MediaFile);

                var sizeOut = input.VdSizeOutput.Split('x').ToList();

                StringBuilder builder = new StringBuilder();
                // volumn set ok is : 1-3
                string mutedParam = string.Empty;

                // Tính thời gian im lặng ở hai đầu 
                decimal silentDuration = input.Muted
                                        ? 0
                                        : (input.TimeOfPart - mtime.Audiotime.Value) / 2;
                decimal silentDurationMs = silentDuration * 1000; // Chuyển đổi sang milliseconds
                decimal etempValue = input.AtempoValue < (decimal)0.5 ? (decimal)0.5 : input.AtempoValue; //atempo range [0.5, 100.0]

                builder.Append(" -y");
                switch (checkMedia)
                {
                    case MediaType.Picture:
                        builder.Append(input.Muted ? mutedParam : string.Format(" -i \"{0}\"", input.AudioFile));
                        builder.Append(string.Format(" -loop 1 -t {0} -i \"{1}\"", input.TimeOfPart, input.MediaFile));
                        builder.Append(" -filter_complex \"");

                        //builder.Append(input.Muted ? mutedParam : "[0:a]volume=2[aOut];");  // cũ

                        // chèn âm thanh ở giữa video ảnh
                        builder.Append(input.Muted ? mutedParam : $"[0:a]apad=pad_dur={silentDuration}[a1];");
                        builder.Append(input.Muted ? mutedParam : $"[a1]adelay={silentDurationMs}|{silentDurationMs}[a2];");
                        builder.Append(input.Muted ? mutedParam : $"[a2]apad=pad_dur={silentDuration}[aOut];");
                        break;
                    case MediaType.Video:
                        builder.Append(input.Muted ? mutedParam : string.Format(" -i \"{0}\"", input.AudioFile));
                        builder.Append(string.Format(" -i \"{0}\"", input.MediaFile));
                        builder.Append(" -filter_complex \"");
                        builder.Append(input.Muted
                            ?
                            string.Format("[0:a]atempo={0},volume=2[aCopy];", etempValue)
                            :
                            string.Format("[0:a]adelay = 10 | 10,volume=2[a1]; "
                                        + "[1:a]atempo={0},volume=enable='between(t,0.1,{1})':volume={2},volume=0.8,volume = {2}[a2]; "
                                        + "[a2][a1]amix=inputs=2:duration=longest[aOut];"
                                        , etempValue
                                        , mtime.Audiotime.Value + (decimal)_extentTimeAudio
                                        , input.VolumnOrigin));
                        break;
                }

                //////////// USE old Lib - START ///////////
                //var effectVd = new Effectvideo(new InputParamZoomV2
                //{
                //    Index = input.Muted ? 0 : 1,
                //    ZoomValueInput = new InputZoomFactor
                //    {
                //        EffectZoom = input.CkZoom,
                //        ZoomEnd = input.ZoomRatio,
                //        Time = input.TimeOfPart,
                //        Fps = input.Fps,
                //    },
                //    ZoomQualityInput = input.ZoomQuality,
                //    DelayValue = input.TimeOfPart,
                //    Size = new VideoProperties
                //    {
                //        Width = input.VdSizeInput.Width,
                //        Height = input.VdSizeInput.Height
                //    },
                //    Hflip = input.CkHflip,
                //    Rotate = input.CkRotate,
                //    LayerRandomMoveX = input.CkLayerRandomMoveX,
                //    SizeOutPut = new VideoProperties
                //    {
                //        Width = Convert.ToInt32(sizeOut[0]),
                //        Height = Convert.ToInt32(sizeOut[1])
                //    },
                //    ModeType = input.ModeType,
                //    Fps = input.Fps,
                //    PTS = input.PTSvalue,
                //    MediaSelect = checkMedia
                //});
                //eff = effectVd.SettingZoom_Option1(input.EffectType);
                //builder.Append(eff);
                //////////// USE old Lib - END ///////////

                /////////// USE Request Server - START ///////////
                var client = new Common.Services.ApiClientRequest(LibConst.UrlServer, _apikey);
                var zoomParams = new InputParamZoomV2Request
                {
                    AppCode = input.AppCode,
                    Index = input.Muted ? 0 : 1,
                    ZoomValueInput = new InputZoomFactor
                    {
                        EffectZoom = input.CkZoom,
                        ZoomEnd = input.ZoomRatio,
                        Time = input.TimeOfPart,
                        Fps = input.Fps,
                    },
                    ZoomQualityInput = input.ZoomQuality,
                    DelayValue = input.TimeOfPart,
                    Size = new VideoProperties
                    {
                        Width = input.VdSizeInput.Width,
                        Height = input.VdSizeInput.Height
                    },
                    Hflip = input.CkHflip,
                    Rotate = input.CkRotate,
                    LayerRandomMoveX = input.CkLayerRandomMoveX,
                    SizeOutPut = new VideoProperties
                    {
                        Width = Convert.ToInt32(sizeOut[0]),
                        Height = Convert.ToInt32(sizeOut[1])
                    },
                    ModeType = input.ModeType,
                    Fps = input.Fps,
                    PTS = input.PTSvalue,
                    MediaSelect = checkMedia,
                    EffectType = input.EffectType
                };

                try
                {
                    CreateZoomResponse response = client.CreateZoomEffect(zoomParams);
                    if (response.IsSuccess)
                    {
                        builder.Append(response.Message);
                    }
                    else
                    {
                        message = "Server Error !";
                        FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", message, Color.Red);
                        return;
                    }
                }
                catch
                {
                    message = "Server Error !";
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", message, Color.Red);
                    return;
                }
                /////////// USE Request Server - END ///////////
                token.ThrowIfCancellationRequested();

                builder.Append(input.Muted ? mutedParam : string.Format("; [ov][0:a]concat=n=1:v=1:a=1[vout]", input.AudioFile));
                builder.Append(string.Format(" \" {0} {1} -vcodec libx264 -pix_fmt yuv420p -r {2} -acodec libmp3lame -b:a 128k -ar 44100 -preset veryfast -s \"{3}\" -t {4} \"{5}\" "
                                                           , input.Muted ? (checkMedia == MediaType.Picture ? mutedParam : "-map \"[aCopy]\"") : "-map \"[aOut]\""
                                                           , input.Muted ? "-map \"[ov]\"" : "-map \"[vout]\""
                                                           , input.Fps
                                                           , input.VdSizeOutput
                                                           , input.TimeOfPart
                                                           , input.SaveFile));

                string argRender = builder.ToString();

                bool result = CFuncion.RunFFmpeg(Funcion.selectffmpegversion() + "\\ffmpeg.exe", argRender, token);
                message = result ? "Done" : "Fail";
                Color color = result ? Color.GreenYellow : Color.Red;

                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", message, color);
            }
            catch (OperationCanceledException)
            {
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", "Đã huỷ", Color.OrangeRed);
            }
            catch
            {
                message = "Setting Fail !";
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", message, Color.Red);
            }
        }


        #endregion

        #region ReloadVideoTime
        private CancellationTokenSource _reloadAllCTS;
        private CancellationTokenSource _reloadSelectedCTS;
        private bool _isReloadingAll = false;
        private bool _isReloadingSelected = false;
        private async void ReloadVideoTimeAll(object sender, EventArgs e)
        {
            if (_isReloadingAll)
            {
                // Đang chạy → nhấn lại để hủy
                _reloadAllCTS?.Cancel();
                return;
            }

            if (dgvMainView.RowCount > 0)
            {
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn reload toàn bộ dữ liệu?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _isReloadingAll = true;
                        _reloadAllCTS = new CancellationTokenSource();
                        tsMAll.Text = "Hủy Chọn Hết";

                        List<int> listRender = RVFuncion.GenerateList(_indexRowMax);
                        await Pr_InsertAllInfoMeida(listRender, _indexRowMax, _reloadAllCTS.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        // TBD
                    }
                    catch
                    {
                        // TBD
                    }
                    finally
                    {
                        _isReloadingAll = false;
                        _reloadAllCTS?.Dispose();
                        _reloadAllCTS = null;
                        tsMAll.Text = "Chọn Hết";
                    }
                }
                // Nếu chọn No thì không làm gì cả
            }
        }
        private async void ReloadVideoTimeSelect(object sender, EventArgs e)
        {
            if (_isReloadingSelected)
            {
                _reloadSelectedCTS?.Cancel();
                return;
            }

            if (dgvMainView.RowCount > 0 && dgvMainView.SelectedRows.Count > 0)
            {
                List<int> listNumber = new List<int>();

                foreach (DataGridViewRow row in dgvMainView.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["Column_index"].Value);
                    listNumber.Add(id);
                    //Thread.Sleep(100);
                }

                // Nếu chọn nhiều hơn 1 dòng thì hỏi xác nhận
                if (listNumber.Count > 1)
                {
                    var result = MessageBox.Show(
                        "Bạn có chắc chắn muốn reload nhiều dòng đã chọn?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return; // Nhấn No -> không làm gì
                }

                // Đặt trạng thái đang reload
                _isReloadingSelected = true;
                _reloadSelectedCTS = new CancellationTokenSource();
                tsMSelected.Text = "Hủy Chọn Nhóm";

                // Nếu chỉ chọn 1 dòng, hoặc đã xác nhận Yes
                try
                {
                    await Pr_InsertAllInfoMeida(listNumber, listNumber.Count, _reloadSelectedCTS.Token);
                }
                catch (OperationCanceledException)
                {
                    // TBD
                }
                catch
                {
                    // TBD
                }
                finally
                {
                    _isReloadingSelected = false;
                    _reloadSelectedCTS?.Dispose();
                    _reloadSelectedCTS = null;
                    tsMSelected.Text = "Chọn Nhóm";
                }
            }
        }
        #endregion

        private void tsMenuDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMainView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa.");
                    return;
                }

                var selectedRow = dgvMainView.SelectedRows[0];

                if (!int.TryParse(selectedRow.Cells["Column_index"].Value?.ToString(), out int noIdToDelete))
                {
                    MessageBox.Show("Không lấy được ID dòng cần xóa.");
                    return;
                }

                if (noIdToDelete != _indexRowMax - 1)
                {
                    MessageBox.Show("Chỉ được xóa dòng cuối cùng.");
                    return;
                }

                // Xóa khỏi danh sách
                var rowToDelete = _listdata.FirstOrDefault(item => item.id == noIdToDelete);
                if (rowToDelete != null)
                    _listdata.Remove(rowToDelete);

                _allInfoRender.RemoveAll(item => item.NoID == noIdToDelete);
                _indexRowMax--;

                _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);

                // Focus dòng cuối
                if (_listdata.Count > 0)
                {
                    int newIndex = _listdata.Count - 1;
                    dgvMainView.ClearSelection();
                    dgvMainView.Rows[newIndex].Selected = true;
                    dgvMainView.CurrentCell = dgvMainView.Rows[newIndex].Cells[0];
                    _indexRowSelect = newIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dòng: {ex.Message}");
            }
        }
        private void txtTextInput_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_projectName) && dgvMainView.RowCount > 0)
            {
                if (_indexRowSelect >= 0)
                {
                    // Lưu vị trí con trỏ trước khi thay đổi
                    int cursorPosition = txtTextInput.SelectionStart;

                    // Gọi phương thức để loại bỏ ký tự xuống dòng và nối các dòng lại
                    string processedText = RemoveNewLineChars(txtTextInput.Text);

                    // Cập nhật nội dung của TextBox
                    txtTextInput.Text = processedText;

                    // Khôi phục vị trí con trỏ
                    txtTextInput.SelectionStart = cursorPosition;

                    int lengt = processedText.Length;
                    string[] chars = processedText.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    string textlength = string.Format("{0} 'Ký Tự' | {1} Chữ ", lengt.ToString(), chars.Length.ToString());

                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, _indexRowSelect, "Column_inputtext", txtTextInput.Text, Color.White);
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, _indexRowSelect, "Column_textlength", textlength, Color.White);
                }
                else
                {
                    MessageBox.Show(ERR_ROW_INDEX);
                }
            }
            //else
            //{
            //    //MessageBox.Show(ERR_PROJECT_EMPTY);
            //}
        }
        private async void txtTextInput_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null && _indexRowSelect >= 0)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    // Xử lý kéo-thả file audio, recordStatus = false
                    await CallDownloadAudioAsync(fileNames[0], _indexRowSelect, false, CancellationToken.None);
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, _indexRowSelect, "Column_audiolink", fileNames[0], Color.White);
                }
            }
            else
            {
                MessageBox.Show(ERR_ROW_INDEX);
            }
        }

        private string RemoveNewLineChars(string input)
        {
            // Loại bỏ ký tự xuống dòng và nối các dòng lại với khoảng trắng
            // Nhưng đảm bảo chỉ có một khoảng trắng giữa các dòng
            return Regex.Replace(input, @"(\r\n|\n|\r)", " ");
        }

        private void txtTextInput_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void txtImPortMedia_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null && _indexRowSelect >= 0)
            {
                var fileNames = data as string[];
                if (fileNames?.Length > 0)
                {
                    // Gọi background thread
                    Task.Run(() =>
                    {
                        try
                        {
                            InSertInputMediaData(fileNames[0], _indexRowSelect);
                        }
                        catch (Exception ex)
                        {
                            // Gọi lại UI thread nếu cần show lỗi
                            this.Invoke((Action)(() =>
                            {
                                MessageBox.Show($"Lỗi: {ex.Message}", "Import Media", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }
            }
            else
            {
                MessageBox.Show(ERR_ROW_INDEX);
            }
        }

        private void txtImPortMedia_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void InSertInputMediaData(string fileNames, int index)
        {
            var info = _allInfoRender.FirstOrDefault(c => c.NoID == index);

            if (CheckMedia.IsImageExtension(fileNames) || CheckMedia.IsVideoExtension(fileNames))
            {
                var dataGridrow = dgvMainView.Rows[index];
                int newWidth = 0;
                int newHeight = 0;
                string mediaStatus = string.Empty;
                decimal timeOfpart = 0;
                string outputMedia = string.Empty;

                MediaType checkMedia = CheckMedia.GetMediaType(fileNames);
                decimal timeVideo = 0m;

                // CHỈ gọi FFmpeg cho video, và bắt lỗi
                if (checkMedia == MediaType.Video)
                {
                    try
                    {
                        timeVideo = FFmpegFuncion.timeOfVideoPart(fileNames);
                    }
                    catch
                    {
                        // File giả / FFmpeg lỗi => xử lý như Media Missing
                        SetMediaError(info, index, "Media Error!");

                        // Đồng bộ lại vào project giống luồng bình thường
                        _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
                        _sessionMerge = false;
                        return;
                    }
                }

                switch (checkMedia)
                {
                    case MediaType.Picture:
                        //outputMedia = CheckMedia.CreateNewExtensionMedia(fileNames, _mediaPath, "jpg");
                        outputMedia = CheckMedia.CreateNewExtensionMedia(fileNames, _mediaPath, "jpg", index.ToString()); // Save file with index to import media
                        timeOfpart = info?.Audiotime ?? 5;
                        break;

                    case MediaType.Video:
                        //outputMedia = CheckMedia.CreateNewExtensionMedia(fileNames, _mediaPath, "mp4");
                        outputMedia = CheckMedia.CreateNewExtensionMedia(fileNames, _mediaPath, "mp4", index.ToString()); // Save file with index to import media

                        // Lỗi chưa xác định
                        //decimal valuetime = RVFuncion.GetMediaTime(fileNames);
                        //decimal timeVideo = index < 6 ? (valuetime + 41) / 1000 : valuetime / 1000;  // đang so sánh giữ FFmpeg với MediaInfoDotnet
                        //timeOfpart = info?.Audiotime.Value > timeVideo ? info.Audiotime.Value : timeVideo;
                        decimal audioTime = info?.Audiotime ?? 0;
                        timeOfpart = _statusMuted
                                        ? timeVideo
                                        : audioTime > timeVideo ? audioTime : timeVideo;
                        break;

                    default:
                        break;
                }

                bool resized = FormatImage(ref newWidth, ref newHeight, ref mediaStatus, fileNames, outputMedia);
                if (File.Exists(outputMedia) && resized)
                {
                    if (!_sessionMerge)
                    {
                        TextboxInThread(txtImPortMedia, fileNames);
                        FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_filemediapath", fileNames, Color.White);
                    }

                    string vlvideotime = string.Format("{0}s", timeOfpart.ToString("0.000"));
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_timevideo", vlvideotime, Color.White);

                    if (info != null)
                    {
                        info.LblVdtime = vlvideotime;
                        info.CurrentTimeOfMediaPart = Convert.ToDecimal(timeOfpart);
                        info.TimeOfMediaPart = Convert.ToDecimal(timeOfpart);
                        info.MediaPath = outputMedia;
                        info.Width = newWidth;
                        info.Height = newHeight;
                    }
                }
                else
                {
                    TextboxInThread(txtImPortMedia, string.Empty);

                    //FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_filemediapath", mediaStatus, Color.Red); // file lỗi , ko có file chuyển màu Đỏ
                    SetMediaError(info, index, mediaStatus);
                }

                if (info != null)
                {
                    info.LblVdtime = dataGridrow.Cells["Column_timevideo"].Value?.ToString();
                    info.MediaFilePath = dataGridrow.Cells["Column_filemediapath"].Value?.ToString();
                }
            }
            else
            {
                //MessageBox.Show("Nhập vào phải là Ảnh hoặc Video. ");
                SetMediaError(info, index, "Media Missing!");
            }

            // Đồng bộ lại vào project
            _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);

            _sessionMerge = false;
        }

        private void SetMediaError(InfoRenderVd info, int index,string msgerror)
        {
            string mediaStatus = msgerror;
            FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_filemediapath", mediaStatus, Color.Red);

            if (info != null)
            {
                info.LblVdtime = "0";
                info.MediaFilePath = mediaStatus;
                info.MediaMiss = true;
            }
        }

        private void lblaudio_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void lblaudio_DragDrop(object sender, DragEventArgs e)
        {
            Label ilbl = (Label)sender;
            if (ilbl != null)
            {
                string countname = ilbl.Name.Replace("lblchar", "");
                var data = e.Data.GetData(DataFormats.FileDrop);
                if (data != null)
                {
                    var fileNames = data as string[];
                    if (fileNames.Length > 0 & (CheckMedia.IsAudioExtension(fileNames[0])))
                    {
                        ilbl.Text = fileNames[0];

                        var mediaInputInfo = _allInfoRender.FirstOrDefault(c => c.NoID == Convert.ToInt32(countname));
                        if (mediaInputInfo != null)
                        {
                            mediaInputInfo.AudioLink = ilbl.Text;
                        }

                        // Đồng bộ lại vào project
                        _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
                    }
                    else
                    {
                        MessageBox.Show("Nhập vào phải là File âm thanh !");
                    }
                }
            }
        }

        private void TextboxInThread(TextBox itextbox, string message)
        {
            // Kiểm tra xem luồng gọi có đang chạy trên luồng UI chính không
            if (itextbox.InvokeRequired)
            {
                // Nếu không, sử dụng Invoke để gọi lại hàm này trên luồng UI chính
                itextbox.Invoke(new Action(() =>
                {
                    itextbox.Text = message;
                }));
            }
            else
            {
                // Nếu đang chạy trên luồng UI chính, cập nhật trực tiếp
                itextbox.Text = message;
            }
        }
        #endregion

        #region Addvideo
        private bool FormatImage(ref int newWidth, ref int newHeight, ref string failStatus, string inputImagePath, string outputImagePath)
        {
            try
            {
                bool checkwebp = false;
                bool checkVideoHasSound = false;
                if (inputImagePath.ToLower().Contains(".webp"))
                {
                    checkwebp = true;
                    WebP webp = new WebP();
                    try
                    {
                        Bitmap bitmap = webp.Load(inputImagePath);
                        bitmap.SaveJPG(outputImagePath, 100);
                    }
                    catch
                    {
                        failStatus = "Picture Error !";
                        newWidth = 0;
                        newHeight = 0;
                        return false;
                    }
                };

                if (CheckMedia.IsImageExtension(inputImagePath))
                {
                    using (var inputImage = Image.FromFile(checkwebp ? outputImagePath : inputImagePath))
                    {
                        newWidth = inputImage.Width;
                        newHeight = inputImage.Height;
                    }
                }
                else if (CheckMedia.IsVideoExtension(inputImagePath))
                {
                    checkVideoHasSound = FFmpegFuncion.CheckIfVideoHasAudio(inputImagePath);
                    VideoProperties size = Funcion.GetVideoSizeV2(inputImagePath);
                    newWidth = size.Width;
                    newHeight = size.Height;
                };

                if (!checkwebp && checkVideoHasSound)  // khác ảnh webp  hoặc video có âm thanh
                    File.Copy(inputImagePath, outputImagePath, true);
                else if (!checkVideoHasSound)  // video không có âm thanh
                {
                    bool checkAddNoise = CFuncion.AddSilentAudio(inputImagePath, outputImagePath);
                    if (checkAddNoise)
                        return true;
                    else
                    {
                        failStatus = "Video Error!";
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                failStatus = "Picture Error !";
                newWidth = 0;
                newHeight = 0;
                return false;
            }
        }
        private void GhepvideoTheoSTT()
        {
            if (!Directory.Exists(Application.StartupPath + "\\data"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\data");
            }
            try
            {
                btnAddAll.Text = "Start";
                if (btnAddAll.Text == "Start")
                {
                    btnAddAll.Text = "Stop";
                    this._theart_videotheostt = new Thread(new ThreadStart(this.theart_ghepvideoTheoSTT));
                    this._theart_videotheostt.Start();
                }
                else
                {
                    btnAddAll.Text = "Start";
                    _theart_videotheostt.Abort();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Progam is stop", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void theart_ghepvideoTheoSTT()
        {
            ghepvdTheoStt();
            Invoke(new MethodInvoker(delegate ()
            {
                btnAddAll.Text = "Start";
            }));
        }
        private void convertvideo()
        {
            string[] files = Directory.GetFiles(_videoRenderPath);
            int num = 0;
            foreach (string str in files)
            {
                object[] args = new object[] { str, _vdquality, this.nameConvertPath(str) };
                string str2 = string.Format(" -y -i \"{0}\" -vcodec libx264 -pix_fmt yuv420p -r 25 -acodec libmp3lame -b:a 128k -ar 44100 -preset veryfast -s \"{1}\" -y \"{2}\"", args);

                Process process = new Process();
                ProcessStartInfo info = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = Funcion.selectffmpegversion() + "\\ffmpeg.exe",
                    Arguments = str2
                };
                process.StartInfo = info;
                try
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        lblstatus.Text = string.Format("Đang xử lý {0}/{1} videos.", num++, files.Length);
                    }));
                    process.Start();
                    process.WaitForExit();
                    Invoke(new MethodInvoker(delegate ()
                    {
                        lblstatus.Text = string.Format("Xử lý hoàn tất {0}/{1} videos.", num, files.Length);
                    }));
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            Invoke(new MethodInvoker(delegate ()
            {
                lblstatus.Text = "Convert Done";
            }));
        }
        private void ghepvdTheoStt()
        {
            string[] files = Directory.GetFiles(_videoRenderPath);
            string filetext = Application.StartupPath + "\\data\\" + "datalink.txt";
            Dictionary<string, int> fileList = new Dictionary<string, int>();
            if (!File.Exists(filetext))
            {
                File.Create(filetext).Dispose();
            }
            File.WriteAllText(filetext, "");
            foreach (var file in files)
            {
                try
                {
                    var result = Path.GetFileNameWithoutExtension(file);
                    fileList.Add(file, int.Parse(result));
                }
                catch
                {
                    MessageBox.Show("Kiểm tra File đã đổi tên thành số chưa ?");
                }
            }
            List<string> sortListfile = new List<string>();
            foreach (KeyValuePair<string, int> author in fileList.OrderBy(key => key.Value))
            {
                sortListfile.Add(author.Key);
            }

            foreach (string str in sortListfile)
            {
                using (StreamWriter w = File.AppendText(filetext))
                {
                    w.WriteLine("file '" + str + "'");
                    w.Close();
                }
            }
            object[] args = new object[] { filetext, nameAllmerger("VideoAll") };
            string str2 = string.Format(" -y -f concat -safe 0 -i \"{0}\" -c copy -vcodec libx264 -pix_fmt yuv420p -preset superfast \"{1}\" ", args);

            Process process = new Process();
            ProcessStartInfo info = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = Funcion.selectffmpegversion() + "\\ffmpeg.exe",
                Arguments = str2
            };
            process.StartInfo = info;
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    lblstatus.Text = "Đang ghép các đoạn video ...";
                }));
                process.Start();
                process.WaitForExit();
                Invoke(new MethodInvoker(delegate ()
                {
                    lblstatus.Text = "Ghép Done";
                }));
                File.WriteAllText(filetext, "");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
        private string nameAllmerger(string string_0)
        {
            string str = string_0 + "_ok.mp4";
            return (_outputPath + "\\" + str);
        }
        private string nameConvertPath(string string_0)
        {
            string str = Path.GetFileNameWithoutExtension(string_0) + Path.GetExtension(string_0);
            return (_tempPath + "\\" + str);
        }
        #endregion

        #region Button

        private void DefaultProjectData()
        {
            _listdata = new BindingList<InfoMainView>();
            _allInfoRender = new List<InfoRenderVd>();
            _indexRowMax = 0;
            _indexRowSelect = 0;

            ClearTextInput();
        }
        private void ClearTextInput()
        {
            txtTextInput.Text = string.Empty;
            txtTextInput.ReadOnly = true;
            txtImPortMedia.Text = string.Empty;
        }

        private bool _isCheckingAndCancelingProjectChange = false;

        private async void cbProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;

            // Chặn gọi liên tục khi đang xử lý
            if (_isCheckingAndCancelingProjectChange) return;
            _isCheckingAndCancelingProjectChange = true;
            try
            {
                if (cbProjectName.SelectedIndex <= -1)
                    return;

                // ==== 1. Đóng player và chuẩn bị reset ====
                _clipPlayerService.CloseClipPlayer();
                _isSwithProject = true;

                // ==== 1.5. Check AllRunning Tasks (giống nút destroy) ====
                await CheckAndCancelAllRunningTasksAsync(false);

                // ==== 2. Lưu lại dữ liệu dòng hiện tại trước khi chuyển ====
                if (dgvMainView.CurrentRow != null)
                    SaveCurrentRowData(dgvMainView.CurrentRow.Index);

                if (!string.IsNullOrEmpty(_projectName) && _infoProject != null)
                {
                    // Cập nhật vào project
                    _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
                }

                // ==== 3. Lấy thông tin project mới được chọn từ combo ====
                var selectedItem = (ComboboxModel)cbProjectName.SelectedItem;
                string selectID = selectedItem.Value;
                string selectPath = selectedItem.Display;

                if (string.IsNullOrEmpty(selectPath))
                {
                    ClearTextInput();
                    ReloadProjectList();
                    ActiveProject.ActiveGroupBoxSetting(tlpView, grbConfigVoice, grbConfigRender, grbActionRender, false);
                    return;
                }

                // ==== 4. Load project mới từ DB ====
                var tempProject = _projectService.GetProjectDetail(Guid.Parse(selectID), selectPath);

                if (tempProject.IsEmpty)
                {
                    MessageBox.Show("Không Tìm thấy Project !");
                    var result = MessageBox.Show($"Bạn Xóa Project này ? \n Project : {selectPath}", "Thông Báo !", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        _previousText = string.Empty;
                        _configService.DeleteProjectName(Guid.Parse(selectID));
                        ReloadProjectList();
                    }
                    else if (result == DialogResult.No)
                    {
                        // Rollback về project cũ
                        cbProjectName.Text = _previousText;
                    }
                    return;
                }

                // ==== 5. Mở project nếu người dùng xác nhận ====
                if (MessageBox.Show($"Bạn muốn mở Project này ? \n Project : {selectPath}", "Thông Báo !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _infoProject = tempProject;
                    DefaultProjectData();
                    _projectName = _infoProject.ProjectPath;
                    CkZoom.Checked = _infoProject.ChkZoomvideo;
                    ActiveProject.ActiveGroupBoxSetting(tlpView, grbConfigVoice, grbConfigRender, grbActionRender, true);

                    var voiceSite = _infoProject.VoiceSelect;

                    if (_infoProject?.InfoRenders != null && _infoProject.InfoRenders.Count > 0)
                    {
                        _allInfoRender = _infoProject.InfoRenders.ToList();
                        PrepareData(_allInfoRender, ref _listdata);

                        _indexRowMax = _allInfoRender.Max(r => r.NoID) + 1;

                        if (dgvMainView.RowCount > 0)
                        {
                            dgvMainView.CurrentCell = dgvMainView.Rows[0].Cells[0];
                            dgvMainView.Rows[0].Selected = true;
                        }

                        GenProjectData();
                        LoadOtherData(_infoProject, false);

                        _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
                    }
                    else
                    {
                        addRow(_infoProject);
                    }

                    if (!string.IsNullOrEmpty(voiceSite))
                    {
                        ComboBoxFuncion.CbBlinding(
                            cboSiteNguon,
                            AISiteSource.VoiceSiteSelectTemplate().ToList(),
                            AISiteSource.VoiceSiteSelectTemplate().FindIndex(x =>
                                string.Equals(x.Value, voiceSite, StringComparison.OrdinalIgnoreCase))
                        );
                    }

                    _configService.UpdateProjectNameDate(Guid.Parse(selectID));
                }
                else // User không muốn mở → gợi ý xóa
                {
                    var result = MessageBox.Show($"Bạn Xóa Project này ? \n Project : {selectPath}", "Thông Báo !", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        _previousText = string.Empty;
                        DefaultProjectData();
                        _configService.DeleteProjectName(Guid.Parse(selectID));
                        ReloadProjectList();
                        ActiveProject.ActiveGroupBoxSetting(tlpView, grbConfigVoice, grbConfigRender, grbActionRender, false);
                    }
                    else if (result == DialogResult.No)
                    {
                        // Rollback về project cũ
                        cbProjectName.Text = _previousText;
                    }
                }
            }
            finally
            {
                // Chỉ cập nhật lại _previousText sau khi đã xác nhận mở project mới thành công
                _previousText = cbProjectName.Text;
                _isCheckingAndCancelingProjectChange = false;
            }
        }



        private void cbLanguageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ckSetting = _infoProject?.EffectSettup;
                if (_manualSelected == ManualSelect.FptAI)
                {
                    switch (cbLanguageSelect.Text)
                    {
                        case FptAIVoiceLanguage.VietNam_Des:
                            ComboBoxFuncion.CbBlinding(cbxSpeechType
                                , ApiFptAI.FptAIVoiceCodeTemplate().ToList()
                                , !string.IsNullOrEmpty(ckSetting?.SspeechType)
                                    ? ApiFptAI.FptAIVoiceCodeTemplate().ToList().FindIndex(x => x.Display.Equals(ckSetting.SspeechType))
                                    : 0);
                            break;
                        default:
                            break;
                    }
                }
                else if (_manualSelected == ManualSelect.Google)
                {
                    ComboboxModel selectedItem = (ComboboxModel)cbLanguageSelect.SelectedItem;
                    string languageCode = selectedItem?.Value;

                    GoogleTTSVoiceTemplate serviceGoogleTTS = new GoogleTTSVoiceTemplate(txtAppID.Text);

                    //ComboBoxFuncion.CbBlinding(cbxSpeechType, serviceGoogleTTS.GetVoicesByLanguage(languageCode), 0);
                    ComboBoxFuncion.CbBlinding(cbxSpeechType
                              , serviceGoogleTTS.GetVoicesByLanguage(languageCode)
                              , !string.IsNullOrEmpty(ckSetting?.SspeechType)
                                  ? serviceGoogleTTS.GetVoicesByLanguage(languageCode).ToList().FindIndex(x => x.Display.Equals(ckSetting.SspeechType))
                                  : 0);
                }
                else if (_manualSelected == ManualSelect.Elevenlab)
                {
                    //ComboBoxFuncion.CbBlinding(cbxSpeechType, GetVoiceTemplate.SearchVoicesByLanguageAccent(_listVoice, cbLanguageSelect.Text), 0);
                    ComboBoxFuncion.CbBlinding(cbxSpeechType
                           , GetVoiceTemplate.SearchVoicesByLanguageAccent(_listVoice, cbLanguageSelect.Text)
                           , !string.IsNullOrEmpty(ckSetting?.SspeechType)
                               ? GetVoiceTemplate.SearchVoicesByLanguageAccent(_listVoice, cbLanguageSelect.Text).ToList().FindIndex(x => x.Display.Equals(ckSetting.SspeechType))
                               : 0);
                }
                else if (_manualSelected == ManualSelect.Vbee)
                {
                    ComboboxModel selectedItem = (ComboboxModel)cbLanguageSelect.SelectedItem;
                    string languageCode = selectedItem?.Value;

                    var vietnamVoices = ApiVbee.VbeeVoiceTemplate().Where(x => x.Language == languageCode).ToList();

                    //ComboBoxFuncion.CbBlinding(cbxSpeechType, vietnamVoices, 0);
                    ComboBoxFuncion.CbBlinding(cbxSpeechType
                          , vietnamVoices
                          , !string.IsNullOrEmpty(ckSetting?.SspeechType)
                              ? vietnamVoices.FindIndex(x => x.Display.Equals(ckSetting.SspeechType))
                              : 0);
                }
            }
            catch {}
        }
        private void cbxSpeechType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _voiceCode = cbxSpeechType.SelectedValue?.ToString();
            if (_manualSelected == ManualSelect.Elevenlab)
            {
                _voiceSetting = new VoiceSettings();
                _voiceSetting = GetVoiceTemplate.GetVoiceSettingByVoiceId(_listVoice, _voiceCode);
                _speechratioElevenlab = _voiceSetting != null ? (decimal)_voiceSetting.Stability : _speechratioElevenlab;

                nbSpeechRatio.Value = _speechratioElevenlab;
            }
        }
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_projectName) && _infoProject != null)
            {
                addRow(_infoProject);
            }
            else
            {
                MessageBox.Show(ERR_PROJECT_EMPTY);
            }
        }
        private void addRow(InfoProject infoProject)
        {
            txtTextInput.ReadOnly = false;

            // Lưu lại chỉ số dòng đang focus (nếu có)
            int currentSelectedIndex = dgvMainView.CurrentRow?.Index ?? -1;

            var newMainView = new InfoMainView
            {
                check = false,
                id = _indexRowMax,
                idxnumber = _indexRowMax.ToString(),
                textlength = null,
                audiolink = null,
                audiotime = null,
                audiostatus = null,
                filemediapath = null,
                timevideo = null,
                renderstatus = string.Empty,
                inputtext = null
            };
            _listdata.Add(newMainView);

            var newRender = new InfoRenderVd
            {
                NoID = _indexRowMax,
                TimeOfMediaPart = 0
            };
            _allInfoRender.Add(newRender);

            _indexRowMax++;

            // Gán DataSource nếu chưa gán
            if (dgvMainView.DataSource == null || dgvMainView.DataSource != _listdata)
            {
                dgvMainView.DataSource = _listdata;
            }

            // Gán lại focus nếu hợp lệ
            if (currentSelectedIndex >= 0 && currentSelectedIndex < dgvMainView.Rows.Count)
            {
                dgvMainView.ClearSelection();
                dgvMainView.Rows[currentSelectedIndex].Selected = true;
                dgvMainView.CurrentCell = dgvMainView.Rows[currentSelectedIndex].Cells[0];
            }

            // Cập nhật vào project
            _renderSyncService.UpdateProjectRenderList(infoProject, _infoProject.InfoRenders, _allInfoRender);
        }
        private void ResetProjectState()
        {
            _listdata = new BindingList<InfoMainView>();
            _allInfoRender = new List<InfoRenderVd>();
            _indexRowMax = 0;
            dgvMainView.DataSource = null;
        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            string projectPath = cbProjectName.Text.Trim();
            if (string.IsNullOrEmpty(projectPath))
            {
                MessageBox.Show("Mục Nhập 'Project' không được trống !");
                return;
            }

            try
            {
                if (_loadConfig.IsDuplicate(projectPath))
                {
                    MessageBox.Show("Project đã tồn tại. Vui lòng chọn tên khác hoặc kiểm tra danh sách!");
                    return;
                }

                // Reset lại state trước khi tạo project mới
                ResetProjectState();

                _loadConfig.EnsureDirectory(projectPath);

                var newProject = _loadConfig.CreateNewProject(projectPath, _manualSelected.ToString(), nbSpeechRatio.Value.ToString("0.0"), CkZoom.Checked);
                _projectName = projectPath;

                _loadConfig.AddProjectToConfig(newProject);
                _loadConfig.SaveToDatabase(newProject);


                ActiveProject.ActiveGroupBoxSetting(tlpView, grbConfigVoice, grbConfigRender, grbActionRender, true);
                GenProjectData();

                //addRow(newProject);

                _infoProject = _projectService.GetProjectDetail(newProject.ID, projectPath);
                DefaultProjectData();
                MessageBox.Show("Tạo Project Thành Công !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo project:\r\n" + ex.Message);
            }
        }
        private void GenProjectData()
        {
            _projectPath = Path.Combine(_projectName, "Project\\");
            _audioPath = Path.Combine(_projectPath, "Audio\\");
            _mediaPath = Path.Combine(_projectPath, "MediaImport\\");
            _mergeVideoPath = Path.Combine(_projectPath, "VideoMerge\\");
            _audioTempPath = Path.Combine(_projectPath, "AudioTemp\\");
            _videoRenderPath = Path.Combine(_projectPath, "VideoRender\\");
            _tempPath = Path.Combine(_projectPath, "Temp\\");
            _outputPath = Path.Combine(_projectPath, "Output\\");

            CreateProjectPath();
        }
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            lblstatus.Text = "...";
            if (!string.IsNullOrEmpty(_projectName))
            {
                GhepvideoTheoSTT();
                Funcion.OpenFolder(_outputPath);
            }
            else
            {
                MessageBox.Show(ERR_PROJECT_EMPTY);
            }
        }

        private FormLoadingCancel _formLoadingCancel;

        private void ShowCancelLoadingDialog()
        {
            if (_formLoadingCancel != null && !_formLoadingCancel.IsDisposed)
                return;

            Task.Run(() =>
            {
                var form = new FormLoadingCancel
                {
                    TopMost = true,
                    StartPosition = FormStartPosition.CenterScreen
                };

                _formLoadingCancel = form;

                Application.Run(form); // chạy form trên thread riêng
            });
        }

        private void CloseCancelLoadingDialog()
        {
            if (_formLoadingCancel == null || _formLoadingCancel.IsDisposed)
                return;

            // Đợi handle được tạo ra nếu cần
            while (!_formLoadingCancel.IsHandleCreated)
            {
                Thread.Sleep(50); // nhỏ thôi
            }

            try
            {
                _formLoadingCancel.Invoke(new Action(() =>
                {
                    _formLoadingCancel.Close();
                }));
            }
            catch (InvalidOperationException)
            {
                // Nếu bị dispose trước khi invoke
            }
            finally
            {
                _formLoadingCancel = null;
            }
        }

        private CancellationTokenSource _subtitleLoadCTS;
        private bool _isLoadingSubtitle = false;
        private async void btnImportSubtitle_Click(object sender, EventArgs e)
        {
            // Nếu có tiến trình nền nào đang chạy → xác nhận
            if (!await CheckAndCancelAllRunningTasksAsync(false))
                return;

            if (_isLoadingSubtitle)
            {
                // Đang loading → đổi nút thành Cancel
                _subtitleLoadCTS?.Cancel();

                ShowCancelLoadingDialog(); // Hiện dialog loading trên thread riêng

                // Chờ thực sự _isLoadingSubtitle thành false
                await Task.Run(() =>
                {
                    while (_isLoadingSubtitle)
                    {
                        Thread.Sleep(200);
                    }
                });

                CloseCancelLoadingDialog(); // Tắt dialog khi đã huỷ xong
                return;
            }

            if (string.IsNullOrEmpty(_projectName))
            {
                MessageBox.Show(ERR_PROJECT_EMPTY);
                return;
            }

            // Bắt đầu trạng thái loading
            _isLoadingSubtitle = true;
            _subtitleLoadCTS = new CancellationTokenSource();

            btnImportSubtitle.Text = "Stop Loading";
            btnAddRow.Enabled = false;
            btnAddAll.Enabled = false;
            btnOpenProject.Enabled = false;
            cbProjectName.Enabled = false;
            bool isLoadDataGridInit = true;

            try
            {
                string subtitleFile;
                string subtitleMediaPath = string.Empty;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Chọn File Subtitle để Split video !";
                openFileDialog.Filter = "Subtitle (*.srt)|*.srt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    subtitleFile = openFileDialog.FileName;
                    // Kiểm tra dung lượng file (<= 1 MB)
                    long fileSize = new System.IO.FileInfo(subtitleFile).Length;

                    if (fileSize > MAX_SIZE_BYTES)
                    {
                        ShowMessage("File subtitle vượt quá 1MB! Vui lòng chọn file nhỏ hơn.", "Thông báo");
                        return;
                    }
                    using (OpenFileDialog openFolderDialog = new OpenFileDialog()) // Không dùng FolderBrowserDialog vì nó hạn chế giao diện lựa chọn
                    {
                        openFolderDialog.Title = "Chọn thư mục media";
                        openFolderDialog.CheckFileExists = false;
                        openFolderDialog.CheckPathExists = false;
                        openFolderDialog.FileName = "Folder Selection";

                        if (openFolderDialog.ShowDialog() == DialogResult.OK)
                        {
                            string potentialPath = openFolderDialog.FileName;
                            if (Directory.Exists(potentialPath))
                            {
                                subtitleMediaPath = potentialPath;
                            }
                            else
                            {
                                subtitleMediaPath = Path.GetDirectoryName(potentialPath);
                            }

                            var files = System.IO.Directory.GetFiles(subtitleMediaPath);
                            if (files.Length == 0)
                            {
                                ShowMessage("Thư mục không có media . Hãy chọn lại !", "Thông báo");
                                return;
                            }
                        }
                        else
                        {
                            ShowMessage("Chưa chọn thư mục chứa media. Hãy chọn lại !", "Thông báo");
                            return;
                        }
                    }
                    _infoProject.InforSubtitleFile = new InforSubtitleFile
                    {
                        SubtitleFile = subtitleFile,
                        FolderSubtileMediaFile = subtitleMediaPath
                    };

                    await LoadSubtitleAsync(_subtitleLoadCTS.Token);
                    LoadDataGridInit();
                }
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, "Đã huỷ tải phụ đề.", Color.Red);
            }
            catch
            {
                UIThreadHelper.SetLabelText(lblstatus, "Lỗi luồng hoạt động.", Color.Red);
            }
            finally
            {
                _isLoadingSubtitle = false;
                _subtitleLoadCTS?.Dispose();
                _subtitleLoadCTS = null;

                btnImportSubtitle.Text = "Import Subtitle";
                btnImportSubtitle.Enabled = true;
                btnAddRow.Enabled = true;
                btnAddAll.Enabled = true;
                btnOpenProject.Enabled = true;
                cbProjectName.Enabled = true;
            }

        }
        private async Task<bool> CheckAndCancelAllRunningTasksAsync(bool msgNoneTaskRun = true)
        {
            var runningTasks = new List<(string name, Func<bool> isRunning, CancellationTokenSource cts)>
            {
                ("Reload Media: Dòng Được chọn.", () => _isReloadingSelected, _reloadSelectedCTS),
                ("Reload Media: Toàn bộ Danh sách.", () => _isReloadingAll, _reloadAllCTS),

                ("Convert Text2Speech: Toàn bộ Danh sách.", () => _isConvertingAll, _convertAllCTS),
                ("Convert Text2Speech: Dòng Được chọn.", () => _isConvertingSelected, _convertSelectedCTS),
                ("Convert Text2Speech: (Only) Dòng Được chọn.", () => _isConvertingSingle, _convertSingleCTS),

                ("Download Audio: Toàn bộ Danh sách.", () => _isDownloadingAll, _downloadAllCTS),
                ("Download Audio: Dòng Được chọn.", () => _isDownloadingSelected, _downloadSelectedCTS),
                ("Download Audio: (Only) Dòng Được chọn.", () => _isDownloadingSingle, _downloadSingleCTS),

                ("Record Audio: (Only) Dòng Được chọn.", () => _isRecording, _recordCTS),

                ("Render Part Video: Toàn bộ Danh sách.", () => _isRenderingAll, _renderAllCTS),
                ("Render Part Video: Dòng Được chọn.", () => _isRenderingSelected, _renderSelectCTS),
                ("Render Part Video: (Only) Dòng Được chọn.", () => _isRenderingSingle, _renderVideoCTS),
            };

            var initialActive = runningTasks.Where(t => t.isRunning()).ToList();
            if (initialActive.Count == 0)
            {
                if (msgNoneTaskRun)
                {
                    UIThreadHelper.ShowMessageBoxSafe(
                    this,
                    "Không có tiến trình nào đang chạy!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }

                return true;
            }

            string activeNames = string.Join("\n- ", initialActive.Select(t => t.name));

            DialogResult confirm = UIThreadHelper.ShowMessageBoxSafe(
                this,
                $"Các tiến trình sau đang chạy:\n- {activeNames}\n\nBạn có muốn huỷ tất cả không?",
                "Xác nhận huỷ tiến trình",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return false;

            // Huỷ tất cả tiến trình còn đang chạy
            foreach (var task in runningTasks)
            {
                if (task.isRunning())
                    task.cts?.Cancel();
            }

            // Show loading popup modeless
            BlockUIShowPopup();
            _loadingService.Show("Đang huỷ tiến trình!");

            // Chờ tiến trình thật sự kết thúc (flag + token)
            bool finished = await WaitUntilAllTasksStoppedAsync(runningTasks, timeoutMs: 15000);

            // Đóng popup loading
            _loadingService.Close();
            AcessUIShowPopup();

            if (!finished)
            {
                UIThreadHelper.ShowMessageBoxSafe(
                    this,
                    "Một số tiến trình vẫn chưa kết thúc (có thể bị treo). Vui lòng kiểm tra lại!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }


        private void BlockUIShowPopup()
        {
            scMain.Enabled = false;
        }

        private void AcessUIShowPopup()
        {
            scMain.Enabled = true;
        }

        /// <summary>
        /// Đợi tới khi tất cả flag và token đều kết thúc, hoặc hết timeout.
        /// </summary>
        private async Task<bool> WaitUntilAllTasksStoppedAsync(
            List<(string name, Func<bool> isRunning, CancellationTokenSource cts)> tasks, int timeoutMs = 10000, int checkInterval = 200)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                // Kiểm tra còn task nào đang chạy không
                bool anyRunning = tasks.Any(t => t.isRunning() || (t.cts != null && !t.cts.IsCancellationRequested && !t.cts.Token.IsCancellationRequested));
                if (!anyRunning)
                    return true;

                await Task.Delay(checkInterval);
            }

            // Hết thời gian chờ mà vẫn còn task
            return false;
        }

        private void btnSaveVoiceSource_Click(object sender, EventArgs e)
        {
            SaveInfoVoiceSoucre();
        }
        private async void cboSiteNguon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkSaveST = _infoProject?.EffectSettup;
            ComboboxModel selectedItem = (ComboboxModel)cboSiteNguon.SelectedItem;
            switch (selectedItem.Value)
            {
                case ListVoiceSite.FptAI:
                    _manualSelected = ManualSelect.FptAI;
                    break;
                case ListVoiceSite.Vbee:
                    _manualSelected = ManualSelect.Vbee;
                    break;
                case ListVoiceSite.GoogleTTS:
                    _manualSelected = ManualSelect.Google;
                    break;
                case ListVoiceSite.Elevenlab:
                    _manualSelected = ManualSelect.Elevenlab;
                    break;
            }
            cbxSpeechType.DataSource = null;
            cbxSpeechType.DisplayMember = string.Empty;

            loadApiKey();
            if (_manualSelected == ManualSelect.FptAI)
            {
                lblapi.Text = "ApiKey";
                txtAppID.Size = new Size(247, 90);
                lblToken.Visible = false;
                txtToken.Visible = false;

                nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioFptAI ? nbSpeechRatio.Value : _speechratioFptAI;

                ComboBoxFuncion.CbBlinding(cbLanguageSelect
                                            , ApiFptAI.FptAILanguageTemplate().ToList()
                                            , !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                                                ? ApiFptAI.FptAILanguageTemplate().ToList().FindIndex(x => x.Display.Equals(checkSaveST.SlanguageSelect))
                                                : 0);

                //cbLanguageSelect.DataSource = ApiFptAI.FptAILanguageTemplate().ToList();
                //cbLanguageSelect.DisplayMember = "Display";
                //cbLanguageSelect.ValueMember = "Value";
            }
            else if (_manualSelected == ManualSelect.Elevenlab)
            {
                lblapi.Text = "Elevenlab";
                txtAppID.Size = new Size(247, 90);
                lblToken.Visible = false;
                txtToken.Visible = false;

                nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioElevenlab ? nbSpeechRatio.Value : _speechratioElevenlab;

                VoicesEndpoint voiceServices = new VoicesEndpoint(txtAppID.Text);
                var listVoice = await voiceServices.GetAllVoicesAsync();
                _listVoice = listVoice?.ToList();

                ComboBoxFuncion.CbBlinding(cbLanguageSelect
                            , _listVoice != null ? GetVoiceTemplate.ElevenLabsLanguageTemplate(_listVoice).ToList() : null
                            , _listVoice != null && !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                                ? GetVoiceTemplate.ElevenLabsLanguageTemplate(_listVoice).ToList().FindIndex(x => x.Display.Equals(checkSaveST.SlanguageSelect))
                                : 0);

                //cbLanguageSelect.DataSource = _listVoice != null ? GetVoiceTemplate.ElevenLabsLanguageTemplate(_listVoice).ToList() : null;
                //cbLanguageSelect.DisplayMember = "Display";
                //cbLanguageSelect.ValueMember = "Value";
            }
            else if (_manualSelected == ManualSelect.Google)
            {
                lblapi.Text = "Json Data";
                txtAppID.Size = new Size(247, 90);
                lblToken.Visible = false;
                txtToken.Visible = false;

                nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioGoogleTTS ? nbSpeechRatio.Value : _speechratioGoogleTTS;

                GoogleTTSVoiceTemplate serviceGoogleTTS = new GoogleTTSVoiceTemplate(txtAppID.Text);
                if (serviceGoogleTTS.CheckClient())
                {
                    var listlanguage = serviceGoogleTTS.GetListLanguage()?.ToList();
                    //cbLanguageSelect.DataSource = listlanguage;

                    ComboBoxFuncion.CbBlinding(cbLanguageSelect
                                          , listlanguage
                                          , !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                                              ? listlanguage.ToList().FindIndex(x => x.Display.Equals(checkSaveST.SlanguageSelect))
                                              : 0);
                }
                else
                {
                    MessageBox.Show("JsonData bị lỗi !");
                    cbLanguageSelect.DataSource = null;
                }
                //cbLanguageSelect.DisplayMember = "Display";
                //cbLanguageSelect.ValueMember = "Value";
            }
            else if (_manualSelected == ManualSelect.Vbee)
            {
                lblapi.Text = "AppID"; 
                txtAppID.Size = new Size(247, 40);
                lblToken.Visible = true;
                txtToken.Visible = true;

                nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioVbee ? nbSpeechRatio.Value : _speechratioVbee;

                ComboBoxFuncion.CbBlinding(cbLanguageSelect
                                          , ApiVbee.VbeeLanguageTemplate().ToList()
                                          , !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                                              ? ApiVbee.VbeeLanguageTemplate().ToList().FindIndex(x => x.Display.Equals(checkSaveST.SlanguageSelect))
                                              : 0);

                //cbLanguageSelect.DataSource = ApiVbee.VbeeLanguageTemplate().ToList();
                //cbLanguageSelect.DisplayMember = "Display";
                //cbLanguageSelect.ValueMember = "Value";
            }
            UpdateVoiceSourceSelect();
        }
        private void UpdateVoiceSourceSelect()
        {
            if (!string.IsNullOrEmpty(_projectName))
            {
                _infoProject.VoiceSelect = _manualSelected.ToString();

                // Đồng bộ lại vào project
                _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
            }
        }
        private void SaveInfoVoiceSoucre()
        {
            var progCOnf = _configService.GetItem(1);
            if (progCOnf.ID > 0)
            {
                string fptAIkey = string.Empty;
                string googleTTSkey = string.Empty;
                string evelenlabKey = string.Empty;
                string vbeeId = string.Empty;
                string vbeeToken = string.Empty;

                // Lấy giá trị từ _manualSelected của btnOpenProject_Click
                ManualSelect manualSelected = _manualSelected;

                // Đảm bảo rằng txtAppID.Text được gán đúng cho fptAIkey hoặc vbeeId
                if (manualSelected == ManualSelect.FptAI
                    || manualSelected == ManualSelect.Vbee
                    || manualSelected == ManualSelect.Google
                    || manualSelected == ManualSelect.Elevenlab)
                {
                    fptAIkey = txtAppID.Text;
                    googleTTSkey = txtAppID.Text;
                    evelenlabKey = txtAppID.Text;
                    vbeeId = txtAppID.Text; // Cả hai đều lấy từ txtAppID.Text
                };

                if (manualSelected == ManualSelect.Vbee)
                {
                    vbeeToken = txtToken.Text;
                };

                // Cập nhật cấu hình bằng cách gọi UpdateConfig với manualSelected được truyền vào
                var check = _configService.UpdateConfig(new ConfigVoiceDto
                {
                    FptAIkey = fptAIkey,
                    EvelenlabKey = evelenlabKey,
                    GoogleTTSkey = googleTTSkey,
                    VbeeId = vbeeId,
                    VbeeToken = vbeeToken,
                    ManualSelected = manualSelected
                });
                if (check) MessageBox.Show("Lưu Key Thành Công! ");
            }
        }
        private void cbZoomRatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbZoomRatio.Text)
            {
                case ZoomRatiotName.ZoomRatio0_Des:
                    _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio0_Val);
                    break;
                case ZoomRatiotName.ZoomRatio10_Des:
                    _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio10_Val);
                    break;
                case ZoomRatiotName.ZoomRatio25_Des:
                    _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio25_Val);
                    break;
                case ZoomRatiotName.ZoomRatio50_Des:
                    _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio50_Val);
                    break;
                case ZoomRatiotName.ZoomRatio75_Des:
                    _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio75_Val);
                    break;
                case ZoomRatiotName.ZoomRatio100_Des:
                    _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio100_Val);
                    break;
                case ZoomRatiotName.ZoomRatio125_Des:
                    _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio125_Val);
                    break;
                case ZoomRatiotName.ZoomRatio150_Des:
                    _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio150_Val);
                    break;
                default:
                    break;
            }
        }
        private void cbZoomQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbZoomQuality.Text)
            {
                case ZoomQualitytName.ZoomQuality_Low_Des:
                    _zoomQuality = ZoomQualitytName.ZoomQuality_Low_Val;
                    break;
                case ZoomQualitytName.ZoomQuality_Normal_Des:
                    _zoomQuality = ZoomQualitytName.ZoomQuality_Normal_Val;
                    break;
                case ZoomQualitytName.ZoomQuality_Medium_Des:
                    _zoomQuality = ZoomQualitytName.ZoomQuality_Medium_Val;
                    break;
                case ZoomQualitytName.ZoomQuality_High_Des:
                    _zoomQuality = ZoomQualitytName.ZoomQuality_High_Val;
                    break;
                default:
                    break;
            }
        }
        private void cbxVideoQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            _videoShort = false;
            switch (cbxVideoQuality.Text)
            {
                case SizeVideo.Quality240_Des:
                    _vdquality = SizeVideo.Quality240_Value;
                    _videoShort = false;
                    break;
                case SizeVideo.Quality240Short_Des:
                    _vdquality = SizeVideo.Quality240Short_Value;
                    _videoShort = true;
                    break;
                case SizeVideo.Quality360_Des:
                    _vdquality = SizeVideo.Quality360_Value;
                    _videoShort = false;
                    break;
                case SizeVideo.Quality360Short_Des:
                    _vdquality = SizeVideo.Quality360Short_Value;
                    _videoShort = true;
                    break;
                case SizeVideo.Quality480_Des:
                    _vdquality = SizeVideo.Quality480_Value;
                    _videoShort = false;
                    break;
                case SizeVideo.Quality480Short_Des:
                    _vdquality = SizeVideo.Quality480Short_Value;
                    _videoShort = true;
                    break;
                case SizeVideo.Quality720_Des:
                    _vdquality = SizeVideo.Quality720_Value;
                    _videoShort = false;
                    break;
                case SizeVideo.Quality720Short_Des:
                    _vdquality = SizeVideo.Quality720Short_Value;
                    _videoShort = true;
                    break;
                case SizeVideo.Quality1080_Des:
                    _vdquality = SizeVideo.Quality1080_Value;
                    _videoShort = false;
                    break;
                case SizeVideo.Quality1080Short_Des:
                    _vdquality = SizeVideo.Quality1080Short_Value;
                    _videoShort = true;
                    break;
                default:
                    _videoShort = false;
                    break;
            }

            ComboBoxFuncion.CbBlinding(cbMode
                       , _videoShort
                           ? ComboboxMode.ModeTypeTemplate().Where(x => x.Type == ModeName.ShortType).ToList()
                           : ComboboxMode.ModeTypeTemplate().Where(x => x.Type == ModeName.WideType).ToList()
                       , ComboboxMode.ModeTypeTemplate().FindIndex(x => x.Display.Equals(ModeName.Mode_ScaleAll_Des)));
        }
        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbMode?.SelectedValue.ToString())
            {
                case nameof(ModeTypeSelect.ScaleAll):
                    _modeType = ModeTypeSelect.ScaleAll;
                    break;
                case nameof(ModeTypeSelect.InputShortOrigin):
                    _modeType = ModeTypeSelect.InputShortOrigin;
                    break;
                case nameof(ModeTypeSelect.InputWideSpecial):
                    _modeType = ModeTypeSelect.InputWideSpecial;
                    break;
                default:
                    _modeType = ModeTypeSelect.ScaleAll;
                    break;
            }
        }
        private void cbEffectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbEffectType?.SelectedValue.ToString())
            {
                case nameof(EffectTypeSelect.RandomAll):
                    _effectType = EffectTypeSelect.RandomAll;
                    break;
                case nameof(EffectTypeSelect.RandomInOut):
                    _effectType = EffectTypeSelect.RandomInOut;
                    break;
                case nameof(EffectTypeSelect.RandomMove):
                    _effectType = EffectTypeSelect.RandomMove;
                    break;
                case nameof(EffectTypeSelect.ZoomIn):
                    _effectType = EffectTypeSelect.ZoomIn;
                    break;
                case nameof(EffectTypeSelect.ZoomOut):
                    _effectType = EffectTypeSelect.ZoomOut;
                    break;
                case nameof(EffectTypeSelect.MoveX):
                    _effectType = EffectTypeSelect.MoveX;
                    break;
                case nameof(EffectTypeSelect.MoveY):
                    _effectType = EffectTypeSelect.MoveY;
                    break;
                default:
                    _effectType = EffectTypeSelect.RandomAll;
                    break;
            }
        }
        private void CkZoom_CheckedChanged(object sender, EventArgs e)
        {
            _statusZoom = CkZoom.Checked ? true : false;
        }
        private void ckRotate_CheckedChanged(object sender, EventArgs e)
        {
            _statusRotate = ckRotate.Checked ? true : false;
        }
        private void ckHflip_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHflip.Checked) { ckHflipRandom.Checked = false; }
            _statusFlip = ckHflip.Checked ? true : false;
        }
        private void ckHflipRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHflipRandom.Checked) { ckHflip.Checked = false; }
            _statusFlipRandom = ckHflipRandom.Checked ? true : false;
        }
        private void ckRandomMoveLeftRight_CheckedChanged(object sender, EventArgs e)
        {
            _statusLayerRandomMoveX = ckRandomMoveLeftRight.Checked ? true : false;
        }
        private void ckOpenPlayer_CheckedChanged(object sender, EventArgs e)
        {
            _statusOpenPlayer = ckOpenPlayer.Checked ? true : false;
        }
        private void ckMuted_CheckedChanged(object sender, EventArgs e)
        {
            _statusMuted = ckNotUseAudio.Checked ? true : false;
        }
        private void dgvMainView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            //if (rowIndex >= 0 && rowIndex != _indexRowSelect)
            if (rowIndex >= 0)
            {
                _isSwithProject = false;
                _indexRowSelect = rowIndex;
                txtTextInput.ReadOnly = false;
                txtTextInput.Text = dgvMainView.CurrentRow.Cells["Column_inputtext"].Value?.ToString();
                txtImPortMedia.Text = dgvMainView.CurrentRow.Cells["Column_filemediapath"].Value?.ToString();

                if (_infoProject.InfoRenders?.Count == _listdata.Count)
                {
                    _allInfoRender = _infoProject.InfoRenders.ToList();
                }
                if (_allInfoRender?.Count > 0 && _statusOpenPlayer)
                {
                    ShowPlayer(_allInfoRender, rowIndex);
                }
            }
        }

        private void ShowPlayer(List<InfoRenderVd> allInfoRender, int rowIndex)
        {
            try
            {
                InfoRenderVd infovd = allInfoRender.Find(x => x.NoID == rowIndex);

                string videoPath = $"{infovd.MediaFilePath},{_mergeVideoPath},{rowIndex}";
                _clipPlayerService.StartClipPlayer(videoPath, this.Left, this.Top, this.Width, this.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCurrentRowData(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvMainView.Rows.Count)
            {
                var idCell = dgvMainView.Rows[rowIndex].Cells["Column_id"].Value;

                if (idCell != null && int.TryParse(idCell.ToString(), out int actualId))
                {
                    var info = _allInfoRender.FirstOrDefault(c => c.NoID == actualId);
                    if (info != null)
                    {
                        info.TextInput = dgvMainView.Rows[rowIndex].Cells["Column_inputtext"].Value?.ToString();
                        info.Textlength = dgvMainView.Rows[rowIndex].Cells["Column_textlength"].Value?.ToString();
                        info.AudioStatus = dgvMainView.Rows[rowIndex].Cells["Column_audiostatus"].Value?.ToString();
                        info.LblVdtime = dgvMainView.Rows[rowIndex].Cells["Column_timevideo"].Value?.ToString();
                    }
                }
            }
        }

        private void dgvMainView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            btnRenderVideoPart.Text = "Render Part";
            btnConvertAudio.Text = "Convert Audio";
            btnSaveAudio.Text = "Save Audio";

            SaveCurrentRowAndProject();
        }

        private void SaveCurrentRowAndProject()
        {
            if (_isSwithProject || string.IsNullOrEmpty(_projectName) || _infoProject == null)
                return;

            var currentRow = dgvMainView.CurrentRow;
            if (currentRow == null || currentRow.IsNewRow)
                return;

            int rowIndex = currentRow.Index;
            if (rowIndex < 0 || rowIndex >= dgvMainView.Rows.Count)
                return;

            SaveCurrentRowData(rowIndex);

            // Đồng bộ lại danh sách render
            _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
        }


        private void dgvMainView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //DataGridView dataGridView = (DataGridView)sender;

            //// Lấy thông tin lỗi từ đối tượng DataGridViewDataErrorEventArgs
            //string errorMessage = e.Exception.Message;

            //// Lấy tên của cột có lỗi
            //string columnName = dataGridView.Columns[e.ColumnIndex].HeaderText;

            //// Lấy số hàng có lỗi
            //int rowIndex = e.RowIndex;

            //// Hiển thị thông báo lỗi cho người dùng
            //MessageBox.Show($"Lỗi: {errorMessage} trong cột {columnName}, hàng {rowIndex + 1}");

            // Đánh dấu lỗi đã được xử lý
            e.ThrowException = false;
        }
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            btnExpand.Visible = true;
            btnExpand.Focus();
            btnCollapse.Visible = false;
            scMain.Panel2Collapsed = true;
            scView.Panel2Collapsed = false;
        }
        private void btnExpand_Click(object sender, EventArgs e)
        {
            btnCollapse.Visible = true;
            btnCollapse.Focus();
            btnExpand.Visible = false;
            scMain.Panel2Collapsed = false;
            scView.Panel2Collapsed = true;
        }

        // start ----- action checkall
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            ToggleAllCheckBoxes(dgvMainView, "Column_check");
        }
        public void ToggleAllCheckBoxes(DataGridView dtGridView, string columnName)
        {
            for (int rowIndex = 0; rowIndex < dtGridView.Rows.Count; rowIndex++)
            {
                FuncDataGridView.UpdateDataGridViewCell(dtGridView, rowIndex, columnName, isCheckedState, null);
            }
            isCheckedState = !isCheckedState;
        }
        // end ----- action checkall

        private void txtAppID_TextChanged(object sender, EventArgs e)
        {
            // Lưu vị trí con trỏ trước khi thay đổi
            int cursorPosition = txtAppID.SelectionStart;

            // Gọi phương thức để loại bỏ ký tự xuống dòng và nối các dòng lại
            string processedText = RemoveNewLineChars(txtAppID.Text);

            // Cập nhật nội dung của TextBox
            txtAppID.Text = processedText;

            // Khôi phục vị trí con trỏ
            txtAppID.SelectionStart = cursorPosition;
        }
        private void btnSaveEffectSetting_Click(object sender, EventArgs e)
        {
            var check = SaveEffectSetting();
            if (check) MessageBox.Show("Lưu Cấu Hình Hiệu Ứng Thành Công! ");
        }
        private void cbSettingTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxModel selectedItem = (ComboboxModel)cbSettingTemplate.SelectedItem;
            string settingName = selectedItem?.Value;

            bool checkDefault;
            if (settingName == EffectConfigName.DEFAULT_Val)
                checkDefault = true;
            else
            {
                checkDefault = false;
            }
            LoadOtherData(_infoProject, checkDefault);
        }

        #region Setting Combobox ProjectList 
        // define SETTING
        // private ToolTip toolTipPL;
        // this.toolTipPL = new ToolTip();
        // this.cbProjectName.DrawMode = DrawMode.OwnerDrawFixed;
        // this.cbProjectName.FormattingEnabled = true;
        // this.cbProjectName.DropDownHeight = 200;

        private void cbProjectName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboboxModel item = (ComboboxModel)cbProjectName.Items[e.Index];
            string fullText = item.Display;

            int maxWidth = cbProjectName.DropDownWidth - 10;

            SizeF fullTextSize = e.Graphics.MeasureString(fullText, e.Font);
            string displayText = fullText;

            if (fullTextSize.Width > maxWidth)
            {
                for (int i = 0; i < fullText.Length; i++)
                {
                    string subString = "..." + fullText.Substring(i);
                    SizeF subStringSize = e.Graphics.MeasureString(subString, e.Font);

                    if (subStringSize.Width <= maxWidth)
                    {
                        displayText = subString;
                        break;
                    }
                }
            }

            e.DrawBackground();
            e.Graphics.DrawString(displayText, e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
        private void cbProjectName_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = cbProjectName.ItemHeight; // Đặt chiều cao mục tùy chỉnh
        }
        private void cbProjectName_MouseMove(object sender, MouseEventArgs e)
        {
            if (cbProjectName.DroppedDown)
            {
                int index = GetIndexUnderMouse(cbProjectName, e.Location);

                if (index >= 0 && index < cbProjectName.Items.Count)
                {
                    string text = cbProjectName.Items[index].ToString();
                    toolTipPL.SetToolTip(cbProjectName, text);
                }
                else
                {
                    toolTipPL.SetToolTip(cbProjectName, string.Empty);
                }
            }
        }
        private int GetIndexUnderMouse(ComboBox comboBox, Point mouseLocation)
        {
            // Lấy tọa độ của ComboBox trên màn hình
            Point comboBoxLocation = comboBox.PointToScreen(Point.Empty);
            // Tính toán vị trí tương đối của chuột so với ComboBox
            int relativeY = mouseLocation.Y - comboBoxLocation.Y - comboBox.ItemHeight; // Trừ chiều cao của mục hiện tại

            // Tính toán chỉ số mục dựa trên vị trí Y tương đối của chuột
            if (relativeY >= 0)
            {
                int index = relativeY / comboBox.ItemHeight;
                return index;
            }

            return -1;
        }

        private bool _isCheckingAndCancelingOnClose = false;
        private async void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isCheckingAndCancelingOnClose)
                return;

            _isCheckingAndCancelingOnClose = true;
            try
            {
                // TRUE = mọi task đã đóng, hoặc không có task chạy, có thể thoát app
                // FALSE = user bấm "No" khi hỏi, hoặc có task treo chưa đóng được
                bool canClose = await CheckAndCancelAllRunningTasksAsync(false);

                if (!canClose)
                {
                    e.Cancel = true;   // Không cho đóng form
                    return;
                }

                // Chỉ khi đã cancel xong (hoặc không có task) mới lưu và thoát
                SaveCurrentRowAndProject();
            }
            finally
            {
                _isCheckingAndCancelingOnClose = false;
            }
        }


        private bool _isCheckingAndCanceling = false;
        private async void btnDestroyAction_Click(object sender, EventArgs e)
        {
            if (_isCheckingAndCanceling) return; // Bỏ qua nếu đang chạy

            _isCheckingAndCanceling = true;
            try
            {
                if (!await CheckAndCancelAllRunningTasksAsync())
                    return;
            }
            finally
            {
                _isCheckingAndCanceling = false;
            }
        }

        #endregion

        #endregion

        //private void btnView_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string videoPath = @"C:\Users\WIN10\Desktop\3321\2.mp4,C:\Users\WIN10\Desktop\3321\out1.mp4";
        //        _clipPlayerService.StartClipPlayer(videoPath, this.Left, this.Top, this.Width, this.Height);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}