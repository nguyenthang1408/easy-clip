using Common.Constant;
using EasyClip.Base;
using EasyClip.Infrastructure.Config;
using EasyClip.Infrastructure.Project;
using EasyClip.Services;
using EasyClip.View.DialogMessage;
using Lib;
using Lib.VoiceServices.ElevenLabs;
using Lib.VoiceServices.ElevenLabs.V1;
using Lib.VoiceServices.ElevenLabs.V1.Model;
using Lib.VoiceServices.ElevenLabs.V1.Services;
// [V2-UPDATE] Thêm using cho V2 services
using Lib.VoiceServices.ElevenLabs.V2.Services;
using Lib.VoiceServices.GoogleTTS;
using LibCommon.Common;
using LibCommon.Lib.Model.Package;
using LibCommon.Lib.Security;
using ReviewMovie.Base;
using ReviewMovie.Infrastructure.Config;
using ReviewMovie.Infrastructure.Project;
using ReviewMovie.Localization;
using ReviewMovie.Model;
using ReviewMovie.Services;
using SubtitlesParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReviewMovie
{
    public partial class FormMain : Form, ILocalizable
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

        // GPU Detection Service
        private readonly GpuDetectionService _gpuDetectionService;

        private readonly IAudioRecordService _audioRecordService;
        private readonly IAudioDownloadService _audioDownloadService;

        private Common.Services.ApiClientRequest _apiRequest;

        #region Const_Variable

        static string ERR_PROJECT_EMPTY => LanguageManager.Get(LangKeys.Main_ErrProjectEmpty);
        static string ERR_ROW_INDEX => LanguageManager.Get(LangKeys.Main_ErrRowIndex);

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
        private bool _isInternalTextChange = false;

        private bool _isAddingRow = false;
        private DateTime _lastAddRowClickTime = DateTime.MinValue;
        private readonly TimeSpan _addRowClickCooldown = TimeSpan.FromMilliseconds(350);

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

        // Video merge configuration and services
        private bool _skipCorruptedVideos = true; // Mặc định skip video lỗi và ghép tiếp
        private CancellationTokenSource _mergeCancellationTokenSource; // CancellationToken cho merge
        private bool _isMerging = false; // Flag đang merge
        private readonly VideoValidationService _videoValidationService;
        private readonly VideoMergeService _videoMergeService;

        private string _appcode;
        private string _appSlugID;
        private string _apikey;

        private string _videoMerge;
        private bool _sessionMerge;

        // Package and Voice Source Info
        //private PackageService _packageService;
        private GetVersionResponse _packageInfo;
        private GetVoiceSourceResponse _voiceSourceInfo;
        private PackageType _currentPackageType = PackageType.Trial;
        private bool _isInitializing = false; // Flag để track quá trình initialization

        // Cache GoogleTTSVoiceTemplate để tránh tạo lại mỗi lần đổi nguồn (network call nặng)
        private GoogleTTSVoiceTemplate _cachedGoogleTTS;
        private string _cachedGoogleTTSKey;
        #endregion

        #region Main_Init
        public FormMain(string appcode, string appSlugID, string apikey, GetVersionResponse loginResponse = null)
        {
            InitializeComponent();
            this.toolTipPL = new ToolTip();
            this.Text = "EasyClip || " + "TPMEDIA";

            _appcode = appcode;
            _apikey = apikey;
            _appSlugID = appSlugID;
            _packageInfo = loginResponse;

            _apiRequest = new Common.Services.ApiClientRequest(LibConst.UrlServer, _apikey);

            // Initialize video services
            _videoValidationService = new VideoValidationService(VideoMergeConfig.MAX_PARALLEL_VALIDATION_THREADS);
            _videoMergeService = new VideoMergeService();
            _gpuDetectionService = new GpuDetectionService();

            // Fix cứng màn hình
            this.MaximizeBox = false;

            // Tắt tạm button Checkbox chọn tác vụ
            btnSelectAll.Enabled = false;

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
            _loadConfig.InitOrUpdateBaseConfig(_apikey, (_voiceSourceInfo != null ? _voiceSourceInfo.VoiceKey : "???"), (_voiceSourceInfo != null ? _voiceSourceInfo.VoiceKey : "???"), txtToken.Text);

            // Subscribe language change and apply
            LanguageManager.LanguageChanged += ApplyLanguage;
            ApplyLanguage();

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

            // Mặc định chọn CPU
            rbCPUused.Checked = true;

            // Đăng ký event handlers cho radio buttons
            rbGPUused.CheckedChanged += rbGPUused_CheckedChanged;
            rbCPUused.CheckedChanged += rbCPUused_CheckedChanged;

            // Auto-detect GPU và đề xuất nếu có
            InitializeGPUDetection();
        }

        /// <summary>
        /// Event handler khi user chọn GPU
        /// </summary>
        private void rbGPUused_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGPUused.Checked)
            {
                // Validate GPU khi user chọn
                ValidateGPUSelection();
            }
        }

        /// <summary>
        /// Event handler khi user chọn CPU
        /// </summary>
        private void rbCPUused_CheckedChanged(object sender, EventArgs e)
        {
            // Không cần validate gì khi chọn CPU
        }

        /// <summary>
        /// Khởi tạo và auto-detect GPU
        /// </summary>
        private void InitializeGPUDetection()
        {
            try
            {
                if (_gpuDetectionService.CheckGpuAvailability())
                {
                    // GPU khả dụng - đề xuất sử dụng
                    var result = MsgBox.Show(
                        GpuDetectionMessages.DETECT_GPU_AVAILABLE_MESSAGE,
                        GpuDetectionMessages.DETECT_GPU_AVAILABLE_TITLE,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        rbGPUused.Checked = true;
                    }
                }
            }
            catch
            {
                // Nếu có lỗi, giữ nguyên CPU (default)
            }
        }

        /// <summary>
        /// Validate GPU khi user chọn
        /// </summary>
        private bool ValidateGPUSelection()
        {
            if (rbGPUused.Checked)
            {
                if (!_gpuDetectionService.CheckGpuAvailability())
                {
                    // Lấy thông báo lỗi chi tiết từ service
                    string errorMessage = _gpuDetectionService.GetUserFriendlyErrorMessage();

                    MsgBox.Show(
                        errorMessage,
                        GpuDetectionMessages.VALIDATE_GPU_FAILED_TITLE,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    // Chuyển về CPU
                    rbCPUused.Checked = true;
                    return false;
                }
            }
            return true;
        }

        public void ApplyLanguage()
        {
            // Settings panel
            grboxSetting.Text = LanguageManager.Get(LangKeys.Main_Settings);
            label2.Text = LanguageManager.Get(LangKeys.Main_Project);
            btnOpenProject.Text = LanguageManager.Get(LangKeys.Main_Create);
            grbConfigVoice.Text = LanguageManager.Get(LangKeys.Main_VoiceSettings);
            label1.Text = LanguageManager.Get(LangKeys.Main_VoiceSource);
            btnSaveVoiceSource.Text = LanguageManager.Get(LangKeys.Common_Save);

            // Effect settings
            grbConfigRender.Text = LanguageManager.Get(LangKeys.Main_EffectSettings);
            label9.Text = LanguageManager.Get(LangKeys.Main_ZoomUp);
            label11.Text = LanguageManager.Get(LangKeys.Main_ZQuality);
            label7.Text = LanguageManager.Get(LangKeys.Main_Quality);
            label6.Text = LanguageManager.Get(LangKeys.Main_VoiceType);
            label5.Text = LanguageManager.Get(LangKeys.Main_SpeechSpeed);
            label10.Text = LanguageManager.Get(LangKeys.Main_FpsInput);
            label13.Text = LanguageManager.Get(LangKeys.Main_Thread);
            label12.Text = LanguageManager.Get(LangKeys.Main_SelectionMode);
            label8.Text = LanguageManager.Get(LangKeys.Main_EffectType);
            CkZoom.Text = LanguageManager.Get(LangKeys.Main_ZoomVideo);
            ckRotate.Text = LanguageManager.Get(LangKeys.Main_RotateVideo);
            ckHflip.Text = LanguageManager.Get(LangKeys.Main_FlipVideo);
            ckHflipRandom.Text = LanguageManager.Get(LangKeys.Main_FlipRandom);
            ckRandomMoveLeftRight.Text = LanguageManager.Get(LangKeys.Main_LayerAutoMove);
            label14.Text = LanguageManager.Get(LangKeys.Main_AudioScale);
            label4.Text = LanguageManager.Get(LangKeys.Main_OriginalVolume);
            ckNotUseAudio.Text = LanguageManager.Get(LangKeys.Main_NoAudio);
            label16.Text = LanguageManager.Get(LangKeys.Main_Language);
            label17.Text = LanguageManager.Get(LangKeys.Main_Config);
            ckOpenPlayer.Text = LanguageManager.Get(LangKeys.Main_AutoOpenPlayer);
            btnSaveEffectSetting.Text = LanguageManager.Get(LangKeys.Common_Save);

            // Rebind comboboxes that have localized Display text
            RebindComboBoxPreserveSelection(cbEffectType, ComboboxEffectType.EffectTypeTemplate().ToList());
            RebindComboBoxPreserveSelection(cbxVideoQuality, ComboboxSizeVideo.SizeVideoTemplate().ToList());
            RebindComboBoxPreserveSelection(cbZoomQuality, ComboboxZoomQuality.ZoomQualityTemplate().ToList());

            // Render section
            grbActionRender.Text = LanguageManager.Get(LangKeys.Main_PublishVideo);
            btnAddAll.Text = LanguageManager.Get(LangKeys.Main_MergeClips);
            rbCPUused.Text = LanguageManager.Get(LangKeys.Main_UseCPU);
            rbGPUused.Text = LanguageManager.Get(LangKeys.Main_UseGPU);

            // Action buttons - respect running state
            btnRecord.Text = _isRecording
                ? LanguageManager.Get(LangKeys.Main_Stop)
                : LanguageManager.Get(LangKeys.Main_Record);
            btnConvertAudio.Text = _isConvertingSingle
                ? LanguageManager.Get(LangKeys.Main_Stop)
                : LanguageManager.Get(LangKeys.Main_ConvertAudio);
            btnSaveAudio.Text = _isDownloadingSingle
                ? LanguageManager.Get(LangKeys.Main_Stop)
                : LanguageManager.Get(LangKeys.Main_SaveAudio);
            btnRenderVideoPart.Text = _renderingRows.Count > 0
                ? LanguageManager.Get(LangKeys.Main_Stop)
                : LanguageManager.Get(LangKeys.Main_RenderPart);

            // Content header
            grViewHeader.Text = LanguageManager.Get(LangKeys.Main_MicIn);
            lbHeaderInputMedia.Text = LanguageManager.Get(LangKeys.Main_DragDropMedia);
            lbHeaderText.Text = LanguageManager.Get(LangKeys.Main_InputTextHeader);

            // Toolbar
            lbTitle.Text = LanguageManager.Get(LangKeys.Main_SelectTask);
            btnSelectAll.Text = LanguageManager.Get(LangKeys.Main_SelectDeselectAll);
            btnAddRow.Text = LanguageManager.Get(LangKeys.Main_AddNewRow);
            btnImportSubtitle.Text = LanguageManager.Get(LangKeys.Main_ImportSubtitle);
            btnDestroyAction.Text = LanguageManager.Get(LangKeys.Main_CancelAllOps);
            txtTim.ToolTipText = LanguageManager.Get(LangKeys.Main_SearchTooltip);

            // Context menu
            MenuItemConvertTex2Speech.Text = LanguageManager.Get(LangKeys.Main_ConvertText2Voice);
            MenuItemDownAudio.Text = LanguageManager.Get(LangKeys.Main_DownloadConvertedAudio);
            MenuItemPartRender.Text = LanguageManager.Get(LangKeys.Main_CreateVideoFromMedia);
            MenuItemReloadVideoTime.Text = LanguageManager.Get(LangKeys.Main_ReloadVideoTime);
            tsMenuDeleteRow.Text = LanguageManager.Get(LangKeys.Main_DeleteSelectedRows);

            // Context menu sub-items - respect running state
            ConvertTex2SpeechAll.Text = _isConvertingAll
                ? LanguageManager.Get(LangKeys.Common_CancelSelectAll)
                : LanguageManager.Get(LangKeys.Common_SelectAll);
            ConvertTex2SpeechSelect.Text = _isConvertingSelected
                ? LanguageManager.Get(LangKeys.Common_CancelSelectGroup)
                : LanguageManager.Get(LangKeys.Common_SelectGroup);
            DownAudioAll.Text = _isDownloadingAll
                ? LanguageManager.Get(LangKeys.Common_CancelSelectAll)
                : LanguageManager.Get(LangKeys.Common_SelectAll);
            DownAudioAllSelect.Text = _isDownloadingSelected
                ? LanguageManager.Get(LangKeys.Common_CancelSelectGroup)
                : LanguageManager.Get(LangKeys.Common_SelectGroup);
            PartRenderAll.Text = _isRenderingAll
                ? LanguageManager.Get(LangKeys.Common_CancelSelectAll)
                : LanguageManager.Get(LangKeys.Common_SelectAll);
            PartRenderSelect.Text = _isRenderingSelected
                ? LanguageManager.Get(LangKeys.Common_CancelSelectGroup)
                : LanguageManager.Get(LangKeys.Common_SelectGroup);
            tsMAll.Text = LanguageManager.Get(LangKeys.Common_SelectAll);
            tsMSelected.Text = LanguageManager.Get(LangKeys.Common_SelectGroup);

            // Update title
            UpdateAppTitle();
        }

        private void RebindComboBoxPreserveSelection(ComboBox cb, object dataSource)
        {
            var selectedValue = cb.SelectedValue?.ToString();
            ComboBoxFuncion.CbBlinding(cb, dataSource, 0);
            if (!string.IsNullOrEmpty(selectedValue))
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    if (cb.Items[i] is ComboboxModel item && item.Value == selectedValue)
                    {
                        cb.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private async void Init()
        {
            // Set flag để prevent event handlers chạy trước khi init xong
            _isInitializing = true;

            //Load data vào Object cục bộ
            LoadProjectListData();

            // Load package info từ server
            await LoadPackageInfoAsync();

            // Load voice source info từ server
            await LoadVoiceSourceInfoAsync();

            // Cập nhật title với thông tin character usage ngay sau khi có _voiceSourceInfo
            UpdateAppTitle();

            DisplayItemDefault();
            // Không gọi loadApiKey() ở đây để giữ nguyên API KEY từ đăng nhập
            // Keys sẽ được load khi user chọn voice source khác

            // Clear flag sau khi init xong
            _isInitializing = false;

            // Trigger chuỗi init cho voice source đã chọn
            // (set _manualSelected, populate cbLanguageSelect/cbxSpeechType, set _voiceCode)
            cboSiteNguon_SelectedIndexChanged(cboSiteNguon, EventArgs.Empty);
        }

        /// <summary>
        /// Load thông tin gói từ server (hoặc dùng dữ liệu từ login nếu đã có)
        /// </summary>
        private async Task LoadPackageInfoAsync()
        {
            try
            {
                // Nếu chưa có _packageInfo (không truyền từ login), gọi API
                if (_packageInfo == null)
                {
                    _packageInfo = await _apiRequest.EasyClipVersionAsync(_appcode, _appSlugID);
                }

                if (_packageInfo != null && _packageInfo.IsSuccess)
                {
                    // Validate dữ liệu trả về có đầy đủ không
                    if (!_packageInfo.IsDataValid())
                    {
                        MsgBox.Show(
                            LanguageManager.Get(LangKeys.Main_InvalidServerData),
                            LanguageManager.Get(LangKeys.Main_InvalidServerDataTitle),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        Environment.Exit(0);
                        return;
                    }

                    // Xác định package type
                    _currentPackageType = PackageTypeHelper.GetPackageType(_packageInfo.PackageId);

                    // Update title app
                    UpdateAppTitle();
                }
                else
                {
                    MsgBox.Show(
                        LanguageManager.Get(LangKeys.Main_AuthFailed),
                        LanguageManager.Get(LangKeys.Main_AuthFailedTitle),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return;
                }
            }
            catch (Exception)
            {
                MsgBox.Show(
                    LanguageManager.Get(LangKeys.Main_ConnectionError),
                    LanguageManager.Get(LangKeys.Main_ConnectionErrorTitle),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Environment.Exit(0);
                return;
            }
        }

        /// <summary>
        /// Load thông tin voice source từ server và giải mã voiceKey
        /// </summary>
        private async Task LoadVoiceSourceInfoAsync()
        {
            try
            {
                _voiceSourceInfo = await _apiRequest.GetVoiceSourceEnumAsync(_appcode, _appSlugID);

                if (_voiceSourceInfo == null || !_voiceSourceInfo.IsSuccess)
                {
                    MsgBox.Show(
                        LanguageManager.Get(LangKeys.Main_CannotLoadVoiceSource),
                        LanguageManager.Get(LangKeys.Main_InvalidServerDataTitle),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return;
                }
            }
            catch (Exception)
            {
                MsgBox.Show(
                    LanguageManager.Get(LangKeys.Main_VoiceSourceError),
                    LanguageManager.Get(LangKeys.Main_VoiceSourceErrorTitle),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Environment.Exit(0);
                return;
            }
        }

        /// <summary>
        /// Decrypt voiceKey on-the-fly cho T2Psoft, không lưu lại decrypted key
        /// </summary>
        private string GetDecryptedVoiceKey()
        {
            if (_voiceSourceInfo == null
                || string.IsNullOrEmpty(_voiceSourceInfo.VoiceKey)
                || !_voiceSourceInfo.KeyTs.HasValue
                || _packageInfo == null
                || string.IsNullOrEmpty(_packageInfo.Email))
                return null;

            return VoiceKeyDecryptor.Decrypt(
                _voiceSourceInfo.VoiceKey,
                _packageInfo.Email,
                _voiceSourceInfo.KeyTs.Value);
        }

        /// <summary>
        /// Update title của app hiển thị thông tin gói
        /// </summary>
        private void UpdateAppTitle()
        {
            if (_packageInfo != null && _packageInfo.IsSuccess)
            {
                string version = !string.IsNullOrEmpty(_packageInfo.Version) ? _packageInfo.Version : "---";
                string title = $"EasyClip v{version} || TPMEDIA";

                // Thêm email từ server
                if (!string.IsNullOrEmpty(_packageInfo.Email))
                {
                    title += $" - {_packageInfo.Email}";
                }

                // Thêm package type kèm số tháng (VD: "Basic - 3 tháng", "Trial")
                if (!string.IsNullOrEmpty(_packageInfo.PackageType))
                {
                    string packageDisplay = PackageTypeHelper.GetPackageDisplayName(
                        _packageInfo.PackageType, _packageInfo.PackageId);
                    title += $" ({packageDisplay})";
                }

                // Thêm số ngày còn lại (tính từ expiryDate - ngày hiện tại)
                if (_packageInfo.ExpiryDate.HasValue)
                {
                    int daysRemaining = _packageInfo.GetDaysRemaining();
                    if (daysRemaining > 0)
                    {
                        title += " - " + LanguageManager.GetFormat(LangKeys.Main_DaysRemaining, daysRemaining);
                    }
                    else if (daysRemaining == 0)
                    {
                        title += " - " + LanguageManager.Get(LangKeys.Main_ExpiryToday);
                    }
                    else
                    {
                        title += " - " + LanguageManager.Get(LangKeys.Main_Expired);
                    }
                }

                // Thêm thông tin character usage (nếu có từ _voiceSourceInfo)
                if (_voiceSourceInfo != null && _voiceSourceInfo.CharacterLimit.HasValue && _voiceSourceInfo.CharacterLimit.Value > 0)
                {
                    title += $" | " + LanguageManager.GetFormat(LangKeys.Main_Characters, _voiceSourceInfo.CharacterUsed.ToString("N0"), _voiceSourceInfo.CharacterLimit.Value.ToString("N0"));
                }

                // Thêm daily character usage (nếu gói có giới hạn daily)
                if (_voiceSourceInfo != null && _voiceSourceInfo.DailyCharacterLimit.HasValue && _voiceSourceInfo.DailyCharacterLimit.Value > 0)
                {
                    title += $" | " + LanguageManager.GetFormat(LangKeys.Main_Today, _voiceSourceInfo.DailyCharacterUsed.ToString("N0"), _voiceSourceInfo.DailyCharacterLimit.Value.ToString("N0"));
                }

                this.Text = title;
            }
        }

        /// <summary>
        /// Callback xử lý khi TTS usage API trả về thành công:
        /// - Cập nhật characterUsed/characterLimit vào _voiceSourceInfo
        /// - Rotate key in-memory nếu server trả key mới
        /// - Update title hiển thị
        /// </summary>
        private void HandleTtsUsageUpdated(TtsUsageResponse usageResponse)
        {
            if (usageResponse == null || _voiceSourceInfo == null)
                return;

            // Cập nhật character usage (tổng + daily)
            _voiceSourceInfo.CharacterUsed = usageResponse.CharacterUsed;
            if (usageResponse.CharacterLimit.HasValue)
                _voiceSourceInfo.CharacterLimit = usageResponse.CharacterLimit;
            _voiceSourceInfo.DailyCharacterUsed = usageResponse.DailyCharacterUsed;
            _voiceSourceInfo.DailyCharacterLimit = usageResponse.DailyCharacterLimit;

            // Rotate key in-memory nếu server trả key mới
            if (!string.IsNullOrEmpty(usageResponse.VoiceKey)
                && (usageResponse.VoiceKey != _voiceSourceInfo.VoiceKey
                    || usageResponse.KeyTs != _voiceSourceInfo.KeyTs))
            {
                _voiceSourceInfo.VoiceKey = usageResponse.VoiceKey;
                _voiceSourceInfo.KeyTs = usageResponse.KeyTs;
                _voiceSourceInfo.KeyVersion = usageResponse.KeyVersion;
            }

            // Update title trên UI thread
            if (this.InvokeRequired)
                this.Invoke(new Action(() => UpdateAppTitle()));
            else
                UpdateAppTitle();
        }

        /// <summary>
        /// Lấy danh sách voice sources theo package type
        /// </summary>
        private List<ComboboxModel> GetVoiceSourcesByPackageType()
        {
            var voiceSources = new List<ComboboxModel>();

            // Luôn có T2Psoft.com cho tất cả các gói
            voiceSources.Add(new ComboboxModel
            {
                Display = ListVoiceSite.T2Psoft_Des,
                Value = ListVoiceSite.T2Psoft
            });

            // Nếu là Premium, thêm các nguồn khác
            if (_currentPackageType == PackageType.Premium)
            {
                voiceSources.Add(new ComboboxModel
                {
                    Display = ListVoiceSite.FptAI_Des,
                    Value = ListVoiceSite.FptAI
                });

                voiceSources.Add(new ComboboxModel
                {
                    Display = ListVoiceSite.GoogleTTS_Des,
                    Value = ListVoiceSite.GoogleTTS
                });

                voiceSources.Add(new ComboboxModel
                {
                    Display = ListVoiceSite.Elevenlabs_Des,
                    Value = ListVoiceSite.Elevenlab
                });

                voiceSources.Add(new ComboboxModel
                {
                    Display = ListVoiceSite.Vbee_Des,
                    Value = ListVoiceSite.Vbee
                });
            }

            return voiceSources;
        }

        /// <summary>
        /// Lấy hoặc tạo GoogleTTSVoiceTemplate với cache (tránh gọi network lặp lại)
        /// Chạy constructor trên background thread để không block UI
        /// </summary>
        private async Task<GoogleTTSVoiceTemplate> GetOrCreateGoogleTTSAsync(string apiKey)
        {
            // Chỉ dùng cache nếu client valid VÀ đã load được voice list
            if (!string.IsNullOrEmpty(apiKey) && _cachedGoogleTTS != null && _cachedGoogleTTSKey == apiKey
                && _cachedGoogleTTS.GetListLanguage() != null)
                return _cachedGoogleTTS;

            var service = await Task.Run(() => new GoogleTTSVoiceTemplate(apiKey));
            if (service.CheckClient() && service.GetListLanguage() != null)
            {
                _cachedGoogleTTS = service;
                _cachedGoogleTTSKey = apiKey;
            }
            return service;
        }

        /// <summary>
        /// Xử lý khi chọn T2Psoft voice source
        /// </summary>
        private async Task HandleT2PsoftVoiceSource(EffectSetting checkSaveST)
        {
            try
            {
                // Hiển thị API Key đăng nhập và disable khi chọn T2Psoft
                lblapi.Visible = true;
                lblapi.Text = "API KEY";
                txtAppID.Visible = true;
                txtAppID.Text = _apikey;
                txtAppID.Enabled = false;
                txtAppID.Size = new Size(239, 90);
                lblToken.Visible = false;
                txtToken.Visible = false;

                cbxSpeechType.DataSource = null;
                cbxSpeechType.DisplayMember = string.Empty;

                // Kiểm tra voiceSourceInfo
                if (_voiceSourceInfo == null || !_voiceSourceInfo.IsSuccess)
                {
                    _loadingService.Close();
                    MsgBox.Show(LanguageManager.Get(LangKeys.Main_CannotLoadVoiceSource));
                    return;
                }

                // Kiểm tra character limits trước khi load voice
                // Khi hết quota, server trả voiceType rỗng + voiceKey null
                bool isDailyLimitExceeded = _voiceSourceInfo.DailyCharacterLimit.HasValue
                    && _voiceSourceInfo.DailyCharacterUsed >= _voiceSourceInfo.DailyCharacterLimit.Value;

                bool isTotalLimitExceeded = _voiceSourceInfo.CharacterLimit.HasValue
                    && _voiceSourceInfo.CharacterLimit.Value > 0
                    && _voiceSourceInfo.CharacterUsed >= _voiceSourceInfo.CharacterLimit.Value;

                if (isDailyLimitExceeded || isTotalLimitExceeded)
                {
                    string limitMsg = isDailyLimitExceeded
                        ? LanguageManager.GetFormat(LangKeys.Main_DailyLimitExceeded, _voiceSourceInfo.DailyCharacterUsed.ToString("N0"), _voiceSourceInfo.DailyCharacterLimit.Value.ToString("N0"))
                        : LanguageManager.GetFormat(LangKeys.Main_TotalLimitExceeded, _voiceSourceInfo.CharacterUsed.ToString("N0"), _voiceSourceInfo.CharacterLimit.Value.ToString("N0"));

                    string tooltipDetail = LanguageManager.GetFormat(LangKeys.Main_TotalChars, _voiceSourceInfo.CharacterUsed.ToString("N0"), _voiceSourceInfo.CharacterLimit.HasValue ? _voiceSourceInfo.CharacterLimit.Value.ToString("N0") : LanguageManager.Get(LangKeys.Main_Unlimited))
                        + (_voiceSourceInfo.DailyCharacterLimit.HasValue
                            ? "\n" + LanguageManager.GetFormat(LangKeys.Main_TodayChars, _voiceSourceInfo.DailyCharacterUsed.ToString("N0"), _voiceSourceInfo.DailyCharacterLimit.Value.ToString("N0"))
                            : "");

                    UIThreadHelper.SetLabelText(lblstatus, limitMsg, Color.OrangeRed, toolTipPL, tooltipDetail);
                    UpdateAppTitle();
                    return;
                }

                // Xác định _manualSelected dựa trên voiceType từ server
                if (!string.IsNullOrEmpty(_voiceSourceInfo.VoiceType))
                {
                    if (_voiceSourceInfo.VoiceType.Contains("Google"))
                    {
                        _manualSelected = ManualSelect.Google;
                        await HandleT2PsoftGoogleTTS(checkSaveST);
                    }
                    else if (_voiceSourceInfo.VoiceType.Contains("FPT"))
                    {
                        _manualSelected = ManualSelect.FptAI;
                        HandleT2PsoftFptAI(checkSaveST);
                    }
                    else if (_voiceSourceInfo.VoiceType.Contains("Evenlab"))
                    {
                        _manualSelected = ManualSelect.Elevenlab;
                        await HandleT2PsoftElevenLab(checkSaveST);
                    }
                    else
                    {
                        // Default to Google TTS
                        _manualSelected = ManualSelect.Google;
                        await HandleT2PsoftGoogleTTS(checkSaveST);
                    }
                }

                UpdateVoiceSourceSelect();
            }
            catch (Exception ex)
            {
                _loadingService.Close();
                MsgBox.Show(LanguageManager.GetFormat(LangKeys.Main_T2PsoftVoiceError, ex.Message));
            }
        }

        /// <summary>
        /// Xử lý T2Psoft với Google TTS
        /// </summary>
        private async Task HandleT2PsoftGoogleTTS(EffectSetting checkSaveST)
        {
            nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioGoogleTTS ? nbSpeechRatio.Value : _speechratioGoogleTTS;

            string decryptedKey = GetDecryptedVoiceKey();
            if (!string.IsNullOrEmpty(decryptedKey))
            {
                var serviceGoogleTTS = await GetOrCreateGoogleTTSAsync(decryptedKey);
                if (serviceGoogleTTS.CheckClient())
                {
                    var allLanguages = serviceGoogleTTS.GetListLanguage()?.ToList();

                    // Filter theo allowedLanguages nếu là gói Trial
                    var filteredLanguages = FilterLanguagesByPackage(allLanguages);

                    if (filteredLanguages == null || filteredLanguages.Count == 0)
                    {
                        _loadingService.Close();
                        MsgBox.Show(LanguageManager.Get(LangKeys.Main_CannotLoadVoices), LanguageManager.Get(LangKeys.Main_CannotLoadVoicesTitle), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbLanguageSelect.DataSource = null;
                        return;
                    }

                    // Tạm unsubscribe event để tránh cascading trigger network call
                    cbLanguageSelect.SelectedIndexChanged -= cbLanguageSelect_SelectedIndexChanged;
                    ComboBoxFuncion.CbBlinding(cbLanguageSelect,
                        filteredLanguages,
                        !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                            ? Math.Max(filteredLanguages.FindIndex(x => x.Value.Equals(checkSaveST.SlanguageSelect) || x.Display.Equals(checkSaveST.SlanguageSelect)), 0)
                            : 0);
                    cbLanguageSelect.SelectedIndexChanged += cbLanguageSelect_SelectedIndexChanged;

                    // Gọi lại cbLanguageSelect handler để load voices cho language được chọn
                    cbLanguageSelect_SelectedIndexChanged(cbLanguageSelect, EventArgs.Empty);
                }
                else
                {
                    _loadingService.Close();
                    MsgBox.Show(LanguageManager.Get(LangKeys.Main_VoiceKeyError));
                    cbLanguageSelect.DataSource = null;
                }
            }
        }

        /// <summary>
        /// Xử lý T2Psoft với FPT AI
        /// </summary>
        private void HandleT2PsoftFptAI(EffectSetting checkSaveST)
        {
            nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioFptAI ? nbSpeechRatio.Value : _speechratioFptAI;

            var allLanguages = ApiFptAI.FptAILanguageTemplate().ToList();

            // Filter theo allowedLanguages nếu là gói Trial
            var filteredLanguages = FilterLanguagesByPackage(allLanguages);

            ComboBoxFuncion.CbBlinding(cbLanguageSelect,
                filteredLanguages,
                !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                    ? Math.Max(filteredLanguages.FindIndex(x => x.Value.Equals(checkSaveST.SlanguageSelect) || x.Display.Equals(checkSaveST.SlanguageSelect)), 0)
                    : 0);
        }

        /// <summary>
        /// Xử lý T2Psoft với ElevenLab
        /// </summary>
        private async Task HandleT2PsoftElevenLab(EffectSetting checkSaveST)
        {
            nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioElevenlab ? nbSpeechRatio.Value : _speechratioElevenlab;

            string decryptedKey = GetDecryptedVoiceKey();
            if (!string.IsNullOrEmpty(decryptedKey))
            {
                // [V2-UPDATE] Chuyển sang VoicesV2Endpoint (API /v2/voices) thay cho VoicesEndpoint (API /v1/voices)
                // V1 VoicesEndpoint vẫn giữ nguyên, không ảnh hưởng các chỗ khác
                VoicesV2Endpoint voiceServices = new VoicesV2Endpoint(decryptedKey);
                var listVoice = await voiceServices.GetAllVoicesAsync();

                if (listVoice == null)
                {
                    cbLanguageSelect.SelectedIndexChanged -= cbLanguageSelect_SelectedIndexChanged;
                    cbLanguageSelect.DataSource = null;
                    cbLanguageSelect.SelectedIndex = -1;
                    cbLanguageSelect.SelectedIndexChanged += cbLanguageSelect_SelectedIndexChanged;
                    _loadingService.Close();
                    MsgBox.Show(LanguageManager.Get(LangKeys.Main_ElevenlabError), LanguageManager.Get(LangKeys.Main_ElevenlabErrorTitle), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    _listVoice = listVoice?.ToList();

                    var allLanguages = _listVoice != null ? GetVoiceTemplate.ElevenLabsLanguageTemplate(_listVoice).ToList() : null;

                    // ElevenLabs: chưa hỗ trợ filter language theo allowedLanguages (format khác Google TTS code)
                    ComboBoxFuncion.CbBlinding(cbLanguageSelect,
                        allLanguages,
                        allLanguages != null && !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                            ? Math.Max(allLanguages.FindIndex(x => x.Value.Equals(checkSaveST.SlanguageSelect) || x.Display.Equals(checkSaveST.SlanguageSelect)), 0)
                            : 0);
                }
            }
        }

        /// <summary>
        /// Filter ngôn ngữ theo package type
        /// Server trả về allowedLanguages dùng Google TTS code làm chuẩn (vi-VN, en-GB, ar-XA...)
        /// Google TTS, Vbee, FptAI đều dùng chung format này → exact match
        /// </summary>
        private List<ComboboxModel> FilterLanguagesByPackage(List<ComboboxModel> allLanguages)
        {
            if (allLanguages == null)
                return null;

            // Nếu unlimit = true, hiển thị tất cả ngôn ngữ (mọi gói)
            if (_voiceSourceInfo != null && _voiceSourceInfo.Unlimit)
            {
                return allLanguages;
            }

            // Nếu unlimit = false, filter theo allowedLanguages (mọi gói kể cả Premium)
            if (_voiceSourceInfo != null &&
                _voiceSourceInfo.AllowedLanguages != null &&
                _voiceSourceInfo.AllowedLanguages.Count > 0)
            {
                var allowedCodes = new HashSet<string>(
                    _voiceSourceInfo.AllowedLanguages.Select(x => x.LanguageCode),
                    StringComparer.OrdinalIgnoreCase);
                return allLanguages.Where(lang => allowedCodes.Contains(lang.Value)).ToList();
            }

            // Default: trả về tất cả
            return allLanguages;
        }

        /// <summary>
        /// Giới hạn số lượng voices theo package type
        /// Chỉ phụ thuộc vào allowedTotalVoices, không phụ thuộc vào unlimit
        /// </summary>
        private List<ComboboxModel> LimitVoicesByPackage(List<ComboboxModel> allVoices)
        {
            if (allVoices == null)
                return null;

            // Nếu unlimit = true, không giới hạn (mọi gói)
            if (_voiceSourceInfo != null && _voiceSourceInfo.Unlimit)
            {
                return allVoices;
            }

            // Nếu unlimit = false, giới hạn theo allowedTotalVoices (mọi gói kể cả Premium)
            if (_voiceSourceInfo != null && _voiceSourceInfo.AllowedTotalVoices > 0)
            {
                return allVoices.Take(_voiceSourceInfo.AllowedTotalVoices).ToList();
            }

            // Default: trả về tất cả
            return allVoices;
        }

        /// <summary>
        /// Giới hạn số lượng voices cho Vbee theo package type
        /// Giới hạn dựa vào unlimit flag từ server
        /// </summary>
        private List<ComboboxVbeeModel> LimitVbeeVoicesByPackage(List<ComboboxVbeeModel> allVoices)
        {
            if (allVoices == null)
                return null;

            // Nếu unlimit = true, không giới hạn (mọi gói)
            if (_voiceSourceInfo != null && _voiceSourceInfo.Unlimit)
            {
                return allVoices;
            }

            // Nếu unlimit = false, giới hạn theo allowedTotalVoices (mọi gói kể cả Premium)
            if (_voiceSourceInfo != null && _voiceSourceInfo.AllowedTotalVoices > 0)
            {
                return allVoices.Take(_voiceSourceInfo.AllowedTotalVoices).ToList();
            }

            // Default: trả về tất cả
            return allVoices;
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
                    ShowMessage(LanguageManager.Get(LangKeys.Main_SubtitleFormatError), LanguageManager.Get(LangKeys.Common_Notice));
                    return;
                }   
                
                _indexRowMax = subtitleValue.Count;
                string filePathTtile = _infoProject.InforSubtitleFile.SubtitleFile;

                if(_indexRowMax == 0 || !File.Exists(filePathTtile))
                {
                    RestoreOldData(oldListData, oldListSubtitleData, oldAllInfoRender);
                    ShowMessage(LanguageManager.Get(LangKeys.Main_SubtitleNoData), LanguageManager.Get(LangKeys.Common_Notice));
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
                    ShowMessage(LanguageManager.Get(LangKeys.Main_SelectMediaFolder), LanguageManager.Get(LangKeys.Common_Notice));
                    return;
                }

                // CHọn file không đúng định dạng
                if (countFileError > 0)
                {
                    ShowMessage(LanguageManager.GetFormat(LangKeys.Main_FileFormatError, countFileError), LanguageManager.Get(LangKeys.Common_Notice));
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
            MsgBox.Show(message, tileMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MsgBox.Show(LanguageManager.Get(LangKeys.Main_ClipPlayerPathError) + message, LanguageManager.Get(LangKeys.Common_Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _sessionMerge = false;
                }));
                return;
            }

            this.Invoke((Action)(() =>
            {
                _videoMerge = message;
                _sessionMerge = true;

                MsgBox.Show("VideoMerge:\n" + message, LanguageManager.Get(LangKeys.Common_Notice), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_UpdateTimeVideoDone), Color.Green);
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
                        UIThreadHelper.SetLabelText(lblstatus, LanguageManager.GetFormat(LangKeys.Main_ReloadingSubtitle, InsertInfoSubtitleCount, totalIdx), Color.Red);
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

        private async Task loadApiKeyAsync()
        {
            var reloadConfig = await Task.Run(() => _configService.GetItem(1));

            // Load key từ database vào textbox cho các voice source thật (không phải T2PSOFT)
            // T2PSOFT luôn lấy key từ server nên không cần load
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
            DisableSettingEvents();
            var valEffectSettup = info.EffectSettup;  // Chuyển vào phần chọn Project list
            if (valEffectSettup != null && valEffectSettup.Active)
            {
                // load % ZoomUp
                var zoomRatioList = ComboboxZoomRatio.ZoomRatioTemplate().ToList();
                int zoomRatioDefaultIdx = Math.Max(zoomRatioList.FindIndex(x => x.Value.Equals(ZoomRatiotName.ZoomRatio10_Val)), 0);
                int zoomRatioIdx = zoomRatioDefaultIdx;
                if (!stdefault)
                {
                    // Try match by Value first (new format), then by Display (old format)
                    zoomRatioIdx = zoomRatioList.FindIndex(x => x.Value.Equals(valEffectSettup.SzoomRatio));
                    if (zoomRatioIdx < 0)
                        zoomRatioIdx = zoomRatioList.FindIndex(x => x.Display.Equals(valEffectSettup.SzoomRatio));
                    if (zoomRatioIdx < 0)
                        zoomRatioIdx = zoomRatioDefaultIdx;
                }
                ComboBoxFuncion.CbBlinding(cbZoomRatio, zoomRatioList, zoomRatioIdx);

                // load % ZQuality
                var zoomQualityList = ComboboxZoomQuality.ZoomQualityTemplate();
                int zoomQualityDefaultIdx = Math.Max(zoomQualityList.FindIndex(x => x.Display.Equals(ZoomQualitytName.ZoomQuality_Medium_Des)), 0);
                int zoomQualityIdx = zoomQualityDefaultIdx;
                if (!stdefault)
                {
                    // Try match by Value first (new format), then by Display (old format)
                    zoomQualityIdx = zoomQualityList.FindIndex(x => x.Value.Equals(valEffectSettup.SzoomQuality));
                    if (zoomQualityIdx < 0)
                        zoomQualityIdx = zoomQualityList.FindIndex(x => x.Display.Equals(valEffectSettup.SzoomQuality));
                    if (zoomQualityIdx < 0)
                        zoomQualityIdx = zoomQualityDefaultIdx;
                }
                ComboBoxFuncion.CbBlinding(cbZoomQuality, zoomQualityList.ToList(), zoomQualityIdx);

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
                var effectTypeList = ComboboxEffectType.EffectTypeTemplate().ToList();
                int effectTypeDefaultIdx = Math.Max(effectTypeList.FindIndex(x => x.Value.Equals(EffectName.EffectRandom_Val)), 0);
                int effectTypeIdx = effectTypeDefaultIdx;
                if (!stdefault)
                {
                    // Try match by Value first (new format), then by Display (old format)
                    effectTypeIdx = effectTypeList.FindIndex(x => x.Value.Equals(valEffectSettup.SeffectType));
                    if (effectTypeIdx < 0)
                        effectTypeIdx = effectTypeList.FindIndex(x => x.Display.Equals(valEffectSettup.SeffectType));
                    if (effectTypeIdx < 0)
                        effectTypeIdx = effectTypeDefaultIdx;
                }
                ComboBoxFuncion.CbBlinding(cbEffectType, effectTypeList, effectTypeIdx);

                nFPS.Value = stdefault ? 30 : valEffectSettup.Sfps;
                nbThread.Value = stdefault ? 2 : valEffectSettup.Sthread;
                nbVolumnOrigin.Value = stdefault ? (decimal)0.2 : valEffectSettup.SvolumnOrigin;

                string sr = valEffectSettup.SspeechRatio;
                nbSpeechRatio.Value = decimal.TryParse(sr, out var r) ? r : _speechRatioDefault;

                nScaleAudioRangeStart.Value = stdefault ? (decimal)1.1 : valEffectSettup.SscaleAudioRangeStart;
                nScaleAudioRangeEnd.Value = stdefault ? (decimal)1.2 : valEffectSettup.SscaleAudioRangeEnd;

                CkZoom.Checked = stdefault ? true
                                            : valEffectSettup.SckZoom ? true : false;
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
            EnableSettingEvents();

            // Set cấu hình sau khi load xong
            cbSettingTemplate.SelectedIndex = (stdefault || !IsSettingChanged()) ? 0 : 1;
        }

        public static class DefaultEffectSetting
        {
            public const string ZoomRatio = ZoomRatiotName.ZoomRatio10_Des;
            public static string ZoomQuality => ZoomQualitytName.ZoomQuality_Medium_Des;
            public const string VideoQuality = SizeVideo.Quality1080_Des;
            public const string Effect = EffectName.EffectRandom_Des;
            public const string Mode = ModeName.Mode_ScaleAll_Des;

            public const int FPS = 30;
            public const int Thread = 2;

            public const double Volume = 0.2;
            public const double ScaleStart = 1.1;
            public const double ScaleEnd = 1.2;

            public const bool Zoom = true;
            public const bool Rotate = false;
            public const bool Flip = false;
            public const bool FlipRandom = false;
            public const bool RandomMove = false;
            public const bool NotUseAudio = false;
        }

        private bool IsSettingChanged()
        {
            if (cbZoomRatio.Text != DefaultEffectSetting.ZoomRatio) return true;
            if (cbZoomQuality.Text != DefaultEffectSetting.ZoomQuality) return true;
            if (cbxVideoQuality.Text != DefaultEffectSetting.VideoQuality) return true;
            if (cbEffectType.Text != DefaultEffectSetting.Effect) return true;
            if (cbMode.Text != DefaultEffectSetting.Mode) return true;

            if (nFPS.Value != DefaultEffectSetting.FPS) return true;
            if (nbThread.Value != DefaultEffectSetting.Thread) return true;
            if (nbVolumnOrigin.Value != (decimal)DefaultEffectSetting.Volume) return true;
            if (nScaleAudioRangeStart.Value != (decimal)DefaultEffectSetting.ScaleStart) return true;
            if (nScaleAudioRangeEnd.Value != (decimal)DefaultEffectSetting.ScaleEnd) return true;

            if (CkZoom.Checked != DefaultEffectSetting.Zoom) return true;
            if (ckRotate.Checked != DefaultEffectSetting.Rotate) return true;
            if (ckHflip.Checked != DefaultEffectSetting.Flip) return true;
            if (ckHflipRandom.Checked != DefaultEffectSetting.FlipRandom) return true;
            if (ckRandomMoveLeftRight.Checked != DefaultEffectSetting.RandomMove) return true;
            if (ckNotUseAudio.Checked != DefaultEffectSetting.NotUseAudio) return true;

            return false;
        }

        private void OnAnySettingChanged(object sender, EventArgs e)
        {
            // Cache kết quả để tránh gọi IsSettingChanged() nhiều lần
            bool isChanged = IsSettingChanged();
            int newIndex = isChanged ? 1 : 0;

            // Chỉ update nếu index thay đổi, và luôn detach event để tránh trigger cascade
            if (cbSettingTemplate.SelectedIndex != newIndex)
            {
                cbSettingTemplate.SelectedIndexChanged -= cbSettingTemplate_SelectedIndexChanged;
                cbSettingTemplate.SelectedIndex = newIndex;
                cbSettingTemplate.SelectedIndexChanged += cbSettingTemplate_SelectedIndexChanged;
            }
        }

        private void BindSettingEvents()
        {
            // Unsubscribe trước để tránh event leak khi gọi nhiều lần
            cbZoomRatio.SelectedIndexChanged -= OnAnySettingChanged;
            cbZoomQuality.SelectedIndexChanged -= OnAnySettingChanged;
            cbxVideoQuality.SelectedIndexChanged -= OnAnySettingChanged;
            cbMode.SelectedIndexChanged -= OnAnySettingChanged;
            cbEffectType.SelectedIndexChanged -= OnAnySettingChanged;

            nFPS.ValueChanged -= OnAnySettingChanged;
            nbThread.ValueChanged -= OnAnySettingChanged;
            nbVolumnOrigin.ValueChanged -= OnAnySettingChanged;
            nScaleAudioRangeStart.ValueChanged -= OnAnySettingChanged;
            nScaleAudioRangeEnd.ValueChanged -= OnAnySettingChanged;

            CkZoom.CheckedChanged -= OnAnySettingChanged;
            ckRotate.CheckedChanged -= OnAnySettingChanged;
            ckHflip.CheckedChanged -= OnAnySettingChanged;
            ckHflipRandom.CheckedChanged -= OnAnySettingChanged;
            ckRandomMoveLeftRight.CheckedChanged -= OnAnySettingChanged;
            ckNotUseAudio.CheckedChanged -= OnAnySettingChanged;

            // Subscribe lại
            cbZoomRatio.SelectedIndexChanged += OnAnySettingChanged;
            cbZoomQuality.SelectedIndexChanged += OnAnySettingChanged;
            cbxVideoQuality.SelectedIndexChanged += OnAnySettingChanged;
            cbMode.SelectedIndexChanged += OnAnySettingChanged;
            cbEffectType.SelectedIndexChanged += OnAnySettingChanged;

            nFPS.ValueChanged += OnAnySettingChanged;
            nbThread.ValueChanged += OnAnySettingChanged;
            nbVolumnOrigin.ValueChanged += OnAnySettingChanged;
            nScaleAudioRangeStart.ValueChanged += OnAnySettingChanged;
            nScaleAudioRangeEnd.ValueChanged += OnAnySettingChanged;

            CkZoom.CheckedChanged += OnAnySettingChanged;
            ckRotate.CheckedChanged += OnAnySettingChanged;
            ckHflip.CheckedChanged += OnAnySettingChanged;
            ckHflipRandom.CheckedChanged += OnAnySettingChanged;
            ckRandomMoveLeftRight.CheckedChanged += OnAnySettingChanged;
            ckNotUseAudio.CheckedChanged += OnAnySettingChanged;
        }

        private void DisableSettingEvents()
        {
            cbZoomRatio.SelectedIndexChanged -= OnAnySettingChanged;
            cbZoomQuality.SelectedIndexChanged -= OnAnySettingChanged;
            cbxVideoQuality.SelectedIndexChanged -= OnAnySettingChanged;
            cbMode.SelectedIndexChanged -= OnAnySettingChanged;
            cbEffectType.SelectedIndexChanged -= OnAnySettingChanged;

            nFPS.ValueChanged -= OnAnySettingChanged;
            nbThread.ValueChanged -= OnAnySettingChanged;
            nbVolumnOrigin.ValueChanged -= OnAnySettingChanged;
            nScaleAudioRangeStart.ValueChanged -= OnAnySettingChanged;
            nScaleAudioRangeEnd.ValueChanged -= OnAnySettingChanged;

            CkZoom.CheckedChanged -= OnAnySettingChanged;
            ckRotate.CheckedChanged -= OnAnySettingChanged;
            ckHflip.CheckedChanged -= OnAnySettingChanged;
            ckHflipRandom.CheckedChanged -= OnAnySettingChanged;
            ckRandomMoveLeftRight.CheckedChanged -= OnAnySettingChanged;
            ckNotUseAudio.CheckedChanged -= OnAnySettingChanged;
        }

        private void EnableSettingEvents()
        {
            BindSettingEvents(); // gắn lại toàn bộ
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
                MsgBox.Show(LanguageManager.Get(LangKeys.Main_DataError) + ex.Message);
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
            // Load Voice Sources theo package type
            var voiceSources = GetVoiceSourcesByPackageType();
            int defaultIndex = 0;

            // Nếu là Premium, chọn T2PSOFT làm mặc định
            if (_currentPackageType == PackageType.Premium)
            {
                int t2psoftIndex = voiceSources.FindIndex(x => x.Value == ListVoiceSite.T2Psoft);
                if (t2psoftIndex >= 0)
                {
                    defaultIndex = t2psoftIndex;
                }
            }

            ComboBoxFuncion.CbBlinding(cboSiteNguon, voiceSources, defaultIndex);

            // load % ZoomUp 
            ComboBoxFuncion.CbBlinding(cbZoomRatio
                         , ComboboxZoomRatio.ZoomRatioTemplate().ToList()
                         , ComboboxZoomRatio.ZoomRatioTemplate().FindIndex(x => x.Display.Equals(ZoomRatiotName.ZoomRatio10_Des)));

            // load % ZQuality
            var defaultZoomQuality = ComboboxZoomQuality.ZoomQualityTemplate();
            ComboBoxFuncion.CbBlinding(cbZoomQuality
                        , defaultZoomQuality.ToList()
                        , Math.Max(defaultZoomQuality.FindIndex(x => x.Display.Equals(ZoomQualitytName.ZoomQuality_Medium_Des)), 0));

            // load Chất lượng
            ComboBoxFuncion.CbBlinding(cbxVideoQuality
                , ComboboxSizeVideo.SizeVideoTemplate().ToList()
                , ComboboxSizeVideo.SizeVideoTemplate().FindIndex(x => x.Display.Equals(SizeVideo.Quality1080_Des)));

            // load Cmode : Dạng của Chất lượng
            var modeTypeTemplate = ComboboxMode.ModeTypeTemplate().Where(x => x.Type == ModeName.WideType).ToList();
            ComboBoxFuncion.CbBlinding(cbMode, modeTypeTemplate, 0);

            // load Hiệu ứng
            ComboBoxFuncion.CbBlinding(cbEffectType
                            , ComboboxEffectType.EffectTypeTemplate().ToList()
                            , ComboboxEffectType.EffectTypeTemplate().FindIndex(x => x.Display.Equals(EffectName.EffectRandom_Des)));

            // Load Cấu Hình Mẫu / Tùy chỉnh
            ComboBoxFuncion.CbBlinding(cbSettingTemplate
                           , EffectConfig.EffectConfigTemplate().ToList()
                           , EffectConfig.EffectConfigTemplate().ToList().FindIndex(x => x.Value.Equals(EffectConfigName.CUSTOM_Val)));

            // Hiển thị API KEY khi load app lần đầu
            lblapi.Visible = true;
            lblapi.Text = "API KEY";
            txtAppID.Visible = true;
            txtAppID.Text = _apikey;
            txtAppID.Enabled = false;
            txtAppID.Size = new Size(239, 90);
            lblToken.Visible = false;
            txtToken.Visible = false;

            SetDefaultEffectControls();
        }

        // Thiết lập toàn bộ giá trị mặc định cho các Control liên quan đến cấu hình.
        private void SetDefaultEffectControls()
        {
            // --- Numeric Defaults ---
            nFPS.Value = 30;
            nbThread.Value = 2;
            nbSpeechRatio.Value = _speechRatioDefault;
            nScaleAudioRangeStart.Value = (decimal)1.1;
            nScaleAudioRangeEnd.Value = (decimal)1.2;

            // --- Checkbox Defaults ---
            CkZoom.Checked = true;
            ckRotate.Checked = false;
            ckHflip.Checked = false;
            ckHflipRandom.Checked = false;
            ckRandomMoveLeftRight.Checked = false;
            ckNotUseAudio.Checked = false;

            // --- Setting Template Default ---
            cbSettingTemplate.SelectedValue = EffectConfigName.DEFAULT_Val;
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

        /// <summary>
        /// Lấy AppId/Key dựa trên voice source được chọn
        /// - T2PSOFT: lấy từ server (_voiceSourceInfo.VoiceKey)
        /// - FPT/Google/ElevenLabs/Vbee: lấy từ textbox (txtAppID.Text)
        /// </summary>
        private string GetCurrentAppId()
        {
            ComboboxModel selectedVoiceSource = (ComboboxModel)cboSiteNguon.SelectedItem;

            // Nếu chọn T2Psoft, decrypt key từ server on-the-fly
            if (selectedVoiceSource?.Value == ListVoiceSite.T2Psoft)
            {
                string decryptedKey = GetDecryptedVoiceKey();
                if (!string.IsNullOrEmpty(decryptedKey))
                    return decryptedKey;
            }

            // Ngược lại, lấy từ textbox
            return txtAppID.Text;
        }

        private bool SaveEffectSetting()
        {
            if (_infoProject == null) return false;

            _infoProject.EffectSettup = new EffectSetting
            {
                Active = true,
                SzoomRatio = cbZoomRatio?.SelectedValue?.ToString() ?? string.Empty,
                SzoomQuality = cbZoomQuality?.SelectedValue?.ToString() ?? string.Empty,
                Sfps = (int)nFPS.Value,
                Sthread = (int)nbThread.Value,
                SvideoQuality = cbxVideoQuality?.Text ?? string.Empty,
                SvideoShort = _videoShort,
                Smode = cbMode?.Text ?? string.Empty,
                SeffectType = cbEffectType?.SelectedValue?.ToString() ?? string.Empty,
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
                SlanguageSelect = (cbLanguageSelect?.SelectedItem as ComboboxModel)?.Value ?? string.Empty,
                SspeechType = cbxSpeechType?.SelectedValue?.ToString() ?? string.Empty
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
            // Đảm bảo các object nền không bị null
            if (_allInfoRender == null)
                _allInfoRender = new List<InfoRenderVd>();

            if (_infoProject == null)
                _infoProject = new InfoProject();

            if (_infoProject.InfoRenders == null)
                _infoProject.InfoRenders = new List<InfoRenderVd>();

            // Nếu _voiceSetting chưa được khởi tạo thì tạo default để tránh NullReferenceException
            var safeVoiceSetting = _voiceSetting ?? new VoiceSettings();

            // Xác định AppID: nếu chọn T2Psoft thì decrypt voiceKey, ngược lại dùng txtAppID.Text
            string appIdToUse = txtAppID.Text;
            ComboboxModel selectedVoiceSource = (ComboboxModel)cboSiteNguon.SelectedItem;
            if (selectedVoiceSource?.Value == ListVoiceSite.T2Psoft)
            {
                string decryptedKey = GetDecryptedVoiceKey();
                if (!string.IsNullOrEmpty(decryptedKey))
                    appIdToUse = decryptedKey;
            }

            _audioConvertContext = new AudioConvertContextModel
            {
                ProjectName = _projectName,
                AllInfoRender = _allInfoRender,
                InfoProject = _infoProject,
                ManualSelected = _manualSelected,
                VoiceSetting = new VoiceSettings
                {
                    Stability = (float)nbSpeechRatio.Value,
                    SimilarityBoost = safeVoiceSetting.SimilarityBoost,
                    Style = safeVoiceSetting.Style,
                    SpeakerBoost = safeVoiceSetting.SpeakerBoost
                },
                VoiceCode = _voiceCode,
                SpeechRatio = nbSpeechRatio.Value,
                AudioTempPath = _audioTempPath,
                AppID = appIdToUse,
                Token = txtToken.Text,

                // TTS Usage Tracking
                IsT2Psoft = selectedVoiceSource?.Value == ListVoiceSite.T2Psoft,
                AppCode = _appcode,
                ProductSlug = _appSlugID,
                ApiRequest = _apiRequest,
                OnTtsUsageUpdated = HandleTtsUsageUpdated,

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
                    Color color = audiostatus == LanguageManager.Get(LangKeys.Svc_Converted) ? Color.GreenYellow
                                : audiostatus == LanguageManager.Get(LangKeys.Svc_Converting) ? Color.Yellow
                                : audiostatus == LanguageManager.Get(LangKeys.Svc_ConvertCancelledCell) ? Color.OrangeRed
                                : audiostatus == LanguageManager.Get(LangKeys.Main_Cancelled) ? Color.Red
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

                // Cập nhật trạng thái kèm tooltip chi tiết
                SetStatusWithTooltipCallback = (text, color, tooltipText) =>
                {
                    UIThreadHelper.SetLabelText(lblstatus, text, color, toolTipPL, tooltipText);
                },

                // Thông báo (show MessageBox) khi batch khác đang chạy
                ShowAlertCallback = msg =>
                {
                    MsgBox.Show(msg, LanguageManager.Get(LangKeys.Common_Notice), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                },

                // Lưu vào database mỗi lần convert xong 1 dòng
                OnAfterRowConverted = (idx, audiolink, audiostatus, inputtext) =>
                {
                    // Nếu cần có thể thêm kiểm tra điều kiện update ở đây
                    _renderSyncService.UpdateProjectRenderList(
                        _infoProject,
                        _infoProject.InfoRenders,
                        _allInfoRender);
                }
            };
        }

        private async void btnConvertAudio_Click(object sender, EventArgs e)
        {
            if (_indexRowSelect < 0 || string.IsNullOrEmpty(_projectName))
            {
                MsgBox.Show(ERR_ROW_INDEX);
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
            UIThreadHelper.SetButtonText(btnConvertAudio, LanguageManager.Get(LangKeys.Main_Stop), Color.Black);
            await Task.Delay(50);

            try
            {
                await Task.Run(async () =>
                {
                    await _audioConvertService.ConvertText2SpeechAsync(_indexRowSelect, _audioConvertContext, _convertSingleCTS.Token);
                });
            }
            catch (OperationCanceledException) when (_convertSingleCTS?.IsCancellationRequested == true)
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_CancelledConvertRow), Color.OrangeRed);
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_ConvertTimeout), Color.OrangeRed);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_NetworkErrorConvert), Color.OrangeRed);
            }
            finally
            {
                _isConvertingSingle = false;
                _convertSingleCTS?.Dispose();
                _convertSingleCTS = null;
                UIThreadHelper.SetButtonText(btnConvertAudio, LanguageManager.Get(LangKeys.Main_ConvertAudio), Color.Black);
            }
        }

        private async void ConvertTex2SpeechAll_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            PrepareAudioConvertContext();

            await _audioConvertService.ConvertTextToSpeechBatchAsync(
                modeLabel: LanguageManager.Get(LangKeys.Main_BatchAll),
                isOtherRunning: () => _isConvertingSelected, // Nếu batch select đang chạy thì báo alert
                getTargetIndexes: () => Enumerable.Range(0, _indexRowMax).ToArray(),
                getIsRunning: () => _isConvertingAll,
                setIsRunning: val => _isConvertingAll = val,
                getCTS: () => _convertAllCTS,
                setCTS: val => _convertAllCTS = val,
                setTextAction: text => Invoke(new Action(() => menuItem.Text = text)),
                startText: LanguageManager.Get(LangKeys.Common_SelectAll),
                cancelText: LanguageManager.Get(LangKeys.Common_CancelSelectAll),
                context: _audioConvertContext
            );
        }

        private async void ConvertTex2SpeechSelect_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            PrepareAudioConvertContext();

            await _audioConvertService.ConvertTextToSpeechBatchAsync(
                modeLabel: LanguageManager.Get(LangKeys.Main_BatchSelected),
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
                startText: LanguageManager.Get(LangKeys.Common_SelectGroup),
                cancelText: LanguageManager.Get(LangKeys.Common_CancelSelectGroup),
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
                MsgBox.Show(ERR_ROW_INDEX);
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

                        Color color = audiostatus == LanguageManager.Get(LangKeys.Svc_EndRecord) ? Color.GreenYellow
                                    : audiostatus == LanguageManager.Get(LangKeys.Svc_StartRecording) ? Color.Yellow
                                    : audiostatus == LanguageManager.Get(LangKeys.Main_Cancelled) ? Color.Red
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
                        MsgBox.Show(msg, LanguageManager.Get(LangKeys.Common_Notice), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            UIThreadHelper.SetButtonText(btnRecord, LanguageManager.Get(LangKeys.Main_Record), Color.Black);
                        };

                        if (this.InvokeRequired)
                            this.Invoke(resetUI);
                        else
                            resetUI();
                    }
                };

                UIThreadHelper.SetButtonText(btnRecord, LanguageManager.Get(LangKeys.Main_Stop), Color.Yellow);
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
                MsgBox.Show(ERR_ROW_INDEX);
                return;
            }

            if (_isDownloadingSingle)
            {
                _downloadSingleCTS?.Cancel();
                return;
            }

            _isDownloadingSingle = true;
            _downloadSingleCTS = new CancellationTokenSource();
            UIThreadHelper.SetButtonText(btnSaveAudio, LanguageManager.Get(LangKeys.Main_Stop), Color.Black);
            await Task.Delay(50);

            try
            {
                await theart_SaveSpeechAsync(_indexRowSelect, _downloadSingleCTS.Token);
            }
            catch (OperationCanceledException) when (_downloadSingleCTS?.IsCancellationRequested == true)
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_CancelledDownloadRow), Color.OrangeRed);
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_DownloadTimeout), Color.OrangeRed);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_NetworkErrorDownload), Color.OrangeRed);
            }
            finally
            {
                _isDownloadingSingle = false;
                _downloadSingleCTS?.Dispose();
                _downloadSingleCTS = null;
                UIThreadHelper.SetButtonText(btnSaveAudio, LanguageManager.Get(LangKeys.Main_SaveAudio), Color.Black);
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
            UIThreadHelper.SetMenuItemText(menuItem, LanguageManager.Get(LangKeys.Common_CancelSelectAll), Color.Red);
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
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_CancelledDownloadAll), Color.OrangeRed);
            }
            finally
            {
                _isDownloadingAll = false;
                _downloadAllCTS?.Dispose();
                _downloadAllCTS = null;
                UIThreadHelper.SetMenuItemText(menuItem, LanguageManager.Get(LangKeys.Common_SelectAll), Color.Black);
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
            UIThreadHelper.SetMenuItemText(menuItem, LanguageManager.Get(LangKeys.Common_CancelSelectGroup), Color.Red);
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
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_CancelledDownloadSelected), Color.OrangeRed);
            }
            finally
            {
                _isDownloadingSelected = false;
                _downloadSelectedCTS?.Dispose();
                _downloadSelectedCTS = null;
                UIThreadHelper.SetMenuItemText(menuItem, LanguageManager.Get(LangKeys.Common_SelectGroup), Color.Black);
            }
        }

        private async Task theart_SaveSpeechAsync(int index, CancellationToken token)
        {
            // === Pre-capture UI control values trên UI thread ===
            var dataGridRowSelect = dgvMainView.Rows[index];
            string audioLink = dataGridRowSelect.Cells["Column_audiolink"].Value?.ToString();
            string appIdToUse = GetCurrentAppId();
            decimal scaleStart = (decimal)nScaleAudioRangeStart.Value;
            decimal scaleEnd = (decimal)nScaleAudioRangeEnd.Value;
            string vbeeToken = txtToken.Text;
            int rowCount = dgvMainView.RowCount;
            ManualSelect provider = _manualSelected;

            FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_audiostatus", LanguageManager.Get(LangKeys.Main_StartDownload), Color.Yellow);
            UIThreadHelper.SetLabelText(lblstatus, LanguageManager.GetFormat(LangKeys.Main_DownloadingPart, index, rowCount), Color.Green);

            token.ThrowIfCancellationRequested();

            // === Chạy download I/O trên background thread để không đơ UI ===
            await Task.Run(async () =>
            {
                string downloadAddress = null;
                string errorMessage = null;

                if (provider == ManualSelect.Vbee)
                {
                    var api = new ApiVbee();
                    var input = new GetaudioModelInput
                    {
                        linksite = "https://vbee.vn/api/v1/tts",
                        token = vbeeToken,
                        requestID = audioLink
                    };
                    var output = await api.GetLinkaudioAsync(input, token);
                    token.ThrowIfCancellationRequested();
                    downloadAddress = output?.result?.audio_link;
                    if (downloadAddress == null) errorMessage = LanguageManager.Get(LangKeys.Main_CannotDownloadAudio);
                }
                else if (provider == ManualSelect.FptAI)
                {
                    downloadAddress = audioLink;
                    if (string.IsNullOrEmpty(downloadAddress)) errorMessage = LanguageManager.Get(LangKeys.Main_NoConvertLink);
                }
                else if (provider == ManualSelect.Google)
                {
                    downloadAddress = audioLink;
                    if (string.IsNullOrEmpty(downloadAddress)) errorMessage = LanguageManager.Get(LangKeys.Main_NoDownloadLink);
                }
                else if (provider == ManualSelect.Elevenlab)
                {
                    downloadAddress = audioLink;
                    if (string.IsNullOrEmpty(downloadAddress)) errorMessage = LanguageManager.Get(LangKeys.Main_NoHistoryID);
                }

                if (!string.IsNullOrEmpty(downloadAddress))
                {
                    var context = new AudioDownloadContextModel
                    {
                        RowIndex = index,
                        AddressLink = downloadAddress,
                        AudioPath = _audioPath,
                        ScaleAudioRangeStart = scaleStart,
                        ScaleAudioRangeEnd = scaleEnd,
                        ManualSelected = provider,
                        AppId = appIdToUse,

                        GetDataGridViewRow = idx => dgvMainView.Rows[idx],
                        GetInfoRenderByRowIndex = idx => _allInfoRender.FirstOrDefault(c => c.NoID == idx),

                        UpdateCellCallback = (idx, column, value, color) =>
                        {
                            FuncDataGridView.UpdateDataGridViewCell(dgvMainView, idx, column, value, color);
                        },
                        UpdateAudioTimeCallback = (idx, timeaudio) =>
                        {
                            var info = _allInfoRender.FirstOrDefault(c => c.NoID == idx);
                            if (info != null) info.Audiotime = timeaudio;
                        }
                    };

                    await _audioDownloadService.DownloadAudioAsync(context, false, token);
                }
                else if (errorMessage != null)
                {
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_audiostatus", errorMessage, Color.Red);
                }

                UIThreadHelper.SetButtonText(btnSaveAudio, LanguageManager.Get(LangKeys.Main_SaveAudio), Color.Black);
            });

            var saveInfo = _allInfoRender.FirstOrDefault(c => c.NoID == index);
            if (saveInfo != null)
                saveInfo.AudioStatus = dataGridRowSelect.Cells["Column_audiostatus"].Value?.ToString();

            _renderSyncService.UpdateProjectRenderList(_infoProject, _infoProject.InfoRenders, _allInfoRender);
        }

        private async Task CallDownloadAudioAsync(string addressLink, int index, bool recordStatus, CancellationToken token)
        {
            // Xác định AppId: nếu chọn T2Psoft thì dùng voiceKey từ server, ngược lại dùng txtAppID.Text
            string appIdToUse = GetCurrentAppId();

            var context = new AudioDownloadContextModel
            {
                RowIndex = index,
                AddressLink = addressLink,
                AudioPath = _audioPath,
                ScaleAudioRangeStart = (decimal)nScaleAudioRangeStart.Value,
                ScaleAudioRangeEnd = (decimal)nScaleAudioRangeEnd.Value,
                ManualSelected = _manualSelected,
                AppId = appIdToUse,

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

        private Dictionary<int, CancellationTokenSource> _renderingRows = new Dictionary<int, CancellationTokenSource>();
        private CancellationTokenSource _renderAllCTS;
        private CancellationTokenSource _renderSelectCTS;
        private bool _isRenderingAll = false;
        private bool _isRenderingSelected = false;

        private async void btnRenderVideoPart_Click(object sender, EventArgs e)
        {
            if (_indexRowSelect < 0 || string.IsNullOrEmpty(_projectName))
            {
                MsgBox.Show(ERR_ROW_INDEX);
                return;
            }

            // Validate GPU trước khi render
            if (!ValidateGPUSelection())
            {
                return;
            }

            // QUAN TRỌNG: Capture row index vào local variable để tránh bị thay đổi khi user click vào row khác
            int rowIndex = _indexRowSelect;

            CancellationTokenSource cts = null;
            bool isAlreadyRendering = false;

            // Kiểm tra nếu row này đang render thì stop, nếu không thì start
            lock (_renderingRows)
            {
                if (_renderingRows.ContainsKey(rowIndex))
                {
                    // Row đang render -> cancel nó
                    _renderingRows[rowIndex]?.Cancel();
                    isAlreadyRendering = true;
                }
                else
                {
                    // Bắt đầu render row này
                    cts = new CancellationTokenSource();
                    _renderingRows[rowIndex] = cts;
                }
            }

            if (isAlreadyRendering)
                return;

            SaveEffectSetting();
            UIThreadHelper.SetButtonText(btnRenderVideoPart, LanguageManager.Get(LangKeys.Main_Stop), Color.Black);
            UIThreadHelper.SetLabelText(lblstatus, LanguageManager.GetFormat(LangKeys.Main_RenderingPart, rowIndex + 1, dgvMainView.RowCount), Color.Black);

            try
            {
                await Task.Run(() =>
                {
                    ThreadRenderVideoPart(rowIndex, cts.Token);
                }, cts.Token);
            }
            catch (OperationCanceledException)
            {
                // Task.Run bị cancel trước khi bắt đầu (token đã cancel lúc start)
            }
            catch (Exception ex)
            {
                MsgBox.Show(LanguageManager.GetFormat(LangKeys.Main_RenderError, ex.Message), LanguageManager.Get(LangKeys.Common_Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Hiển thị cancel message nếu đã bị hủy
                if (cts.IsCancellationRequested)
                {
                    UIThreadHelper.SetLabelText(lblstatus, LanguageManager.GetFormat(LangKeys.Main_CancelledRenderPart, rowIndex), Color.OrangeRed);
                }

                // Xóa row khỏi dictionary khi hoàn thành (dùng rowIndex local, không dùng _indexRowSelect)
                lock (_renderingRows)
                {
                    if (_renderingRows.ContainsKey(rowIndex))
                    {
                        _renderingRows[rowIndex]?.Dispose();
                        _renderingRows.Remove(rowIndex);
                    }
                }
                UIThreadHelper.SetButtonText(btnRenderVideoPart, LanguageManager.Get(LangKeys.Main_RenderPart), Color.Black);
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

            // Validate GPU trước khi render
            if (!ValidateGPUSelection())
            {
                return;
            }

            _isRenderingAll = true;
            _renderAllCTS = new CancellationTokenSource();
            UIThreadHelper.SetMenuItemText(menuItem, LanguageManager.Get(LangKeys.Common_CancelSelectAll), Color.Red);
            await Task.Delay(50);

            try
            {
                List<int> listRender = RVFuncion.GenerateList(_indexRowMax);
                await Pr_RenderAll(listRender, _indexRowMax, _renderAllCTS.Token);

                if (_renderAllCTS.IsCancellationRequested)
                    UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_CancelledRenderAll), Color.OrangeRed);
                else
                    UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_RenderAllDone), Color.Green);
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_CancelledRenderAll), Color.OrangeRed);
            }
            finally
            {
                _isRenderingAll = false;
                _renderAllCTS?.Dispose();
                _renderAllCTS = null;
                UIThreadHelper.SetMenuItemText(menuItem, LanguageManager.Get(LangKeys.Common_SelectAll), Color.Black);
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
                MsgBox.Show(LanguageManager.Get(LangKeys.Main_NoRowSelected)
                    , LanguageManager.Get(LangKeys.Common_Notice)
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate GPU trước khi render
            if (!ValidateGPUSelection())
            {
                return;
            }

            _isRenderingSelected = true;
            _renderSelectCTS = new CancellationTokenSource();
            UIThreadHelper.SetMenuItemText(menuItem, LanguageManager.Get(LangKeys.Common_CancelSelectGroup), Color.Red);
            await Task.Delay(50);

            try
            {
                await Pr_RenderAll(listNumber, listNumber.Count, _renderSelectCTS.Token);

                if (_renderSelectCTS.IsCancellationRequested)
                    UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_CancelledRenderSelected), Color.OrangeRed);
                else
                    UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_RenderSelectedDone), Color.Green);
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_CancelledRenderSelected), Color.OrangeRed);
            }
            finally
            {
                _isRenderingSelected = false;
                _renderSelectCTS?.Dispose();
                _renderSelectCTS = null;
                UIThreadHelper.SetMenuItemText(menuItem, LanguageManager.Get(LangKeys.Common_SelectGroup), Color.Black);
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
                        UIThreadHelper.SetLabelText(lblstatus, LanguageManager.GetFormat(LangKeys.Main_RenderingPart, renderedVideoCount, totalIdx), Color.Red);
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
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_renderstatus", LanguageManager.Get(LangKeys.Main_MissingAudio), Color.Red);
                return;
            }

            if (!File.Exists(renderInfo.MediaPath))
            {
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, index, "Column_renderstatus", LanguageManager.Get(LangKeys.Main_MissingVideo), Color.Red);
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
                // Rendervideo đã cập nhật cell với cancel status, không cần throw
            }
            catch
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_ErrorCheckMedia), Color.Red);
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

                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input?.Index ?? -1, "Column_renderstatus", RwConstant.STATUS_DEFAULT, Color.Yellow);

                if (input == null)
                {
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, -1, "Column_renderstatus", LanguageManager.Get(LangKeys.Main_RenderInputError), Color.Red);
                    return;
                }

                if (!File.Exists(input.MediaFile))
                {
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", LanguageManager.Get(LangKeys.Main_RenderVideoMissing), Color.Red);
                    return;
                }

                var mtime = _allInfoRender?.Find(c => c.NoID == input.Index);
                if ((mtime == null || mtime.Audiotime == null) && !input.Muted)
                {
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", LanguageManager.Get(LangKeys.Main_RenderAudioMissing), Color.Red);
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
                    ProductSlug = _appSlugID,
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
                        message = !string.IsNullOrEmpty(response.Message) ? response.Message : LanguageManager.Get(LangKeys.Main_RenderServerError);
                        UIThreadHelper.SetLabelText(lblstatus, message, Color.Red);
                        FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", message, Color.Red);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    message = !string.IsNullOrEmpty(ex.Message) ? ex.Message : LanguageManager.Get(LangKeys.Main_RenderServerError);
                    UIThreadHelper.SetLabelText(lblstatus, message, Color.Red);
                    FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", message, Color.Red);
                    return;
                }
                /////////// USE Request Server - END ///////////
                token.ThrowIfCancellationRequested();

                builder.Append(input.Muted ? mutedParam : string.Format("; [ov][0:a]concat=n=1:v=1:a=1[vout]", input.AudioFile));

                // Chọn codec dựa trên radio button
                string videoCodec = VideoMergeConfig.VIDEO_CODEC_CPU;
                string preset = "veryfast";
                try
                {
                    if (InvokeRequired)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            if (rbGPUused.Checked)
                            {
                                videoCodec = VideoMergeConfig.VIDEO_CODEC_GPU;
                                preset = VideoMergeConfig.FFMPEG_PRESET_GPU;
                            }
                        }));
                    }
                    else
                    {
                        if (rbGPUused.Checked)
                        {
                            videoCodec = VideoMergeConfig.VIDEO_CODEC_GPU;
                            preset = VideoMergeConfig.FFMPEG_PRESET_GPU;
                        }
                    }
                }
                catch { }

                builder.Append(string.Format(" \" {0} {1} -vcodec {6} -pix_fmt yuv420p -r {2} -acodec libmp3lame -b:a 128k -ar 44100 -preset {7} -s \"{3}\" -t {4} \"{5}\" "
                                                           , input.Muted ? (checkMedia == MediaType.Picture ? mutedParam : "-map \"[aCopy]\"") : "-map \"[aOut]\""
                                                           , input.Muted ? "-map \"[ov]\"" : "-map \"[vout]\""
                                                           , input.Fps
                                                           , input.VdSizeOutput
                                                           , input.TimeOfPart
                                                           , input.SaveFile
                                                           , videoCodec
                                                           , preset));

                string argRender = builder.ToString();

                // Callback để hiển thị tốc độ render
                Action<string> progressCallback = (speed) =>
                {
                    try
                    {
                        UIThreadHelper.SetLabelText(lblstatus, LanguageManager.GetFormat(LangKeys.Main_RenderProgress, input.Index + 1, speed), Color.Blue);
                    }
                    catch { }
                };

                bool result = CFuncion.RunFFmpeg(Funcion.selectffmpegversion() + "\\ffmpeg.exe", argRender, token, progressCallback);

                // Kiểm tra cancel sau khi RunFFmpeg trả về (RunFFmpeg trả false khi cancel)
                token.ThrowIfCancellationRequested();

                message = result ? LanguageManager.Get(LangKeys.Main_RenderDone) : LanguageManager.Get(LangKeys.Main_RenderFail);
                Color color = result ? Color.GreenYellow : Color.Red;

                if (result)
                    UIThreadHelper.SetLabelText(lblstatus, LanguageManager.GetFormat(LangKeys.Main_RenderPartCompleted, input.Index + 1), Color.DarkGreen);
                else
                    UIThreadHelper.SetLabelText(lblstatus, LanguageManager.GetFormat(LangKeys.Main_RenderPartFailed, input.Index + 1), Color.Red);

                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", message, color);
            }
            catch (OperationCanceledException)
            {
                FuncDataGridView.UpdateDataGridViewCell(dgvMainView, input.Index, "Column_renderstatus", LanguageManager.Get(LangKeys.Svc_RenderCancelledCell), Color.OrangeRed);
            }
            catch
            {
                message = LanguageManager.Get(LangKeys.Main_RenderSettingFail);
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
                var result = MsgBox.Show(
                    LanguageManager.Get(LangKeys.Main_ConfirmReloadAll),
                    LanguageManager.Get(LangKeys.Common_Confirm),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _isReloadingAll = true;
                        _reloadAllCTS = new CancellationTokenSource();
                        tsMAll.Text = LanguageManager.Get(LangKeys.Common_CancelSelectAll);

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
                        tsMAll.Text = LanguageManager.Get(LangKeys.Common_SelectAll);
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
                    var result = MsgBox.Show(
                        LanguageManager.Get(LangKeys.Main_ConfirmReloadSelected),
                        LanguageManager.Get(LangKeys.Common_Confirm),
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return; // Nhấn No -> không làm gì
                }

                // Đặt trạng thái đang reload
                _isReloadingSelected = true;
                _reloadSelectedCTS = new CancellationTokenSource();
                tsMSelected.Text = LanguageManager.Get(LangKeys.Common_CancelSelectGroup);

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
                    tsMSelected.Text = LanguageManager.Get(LangKeys.Common_SelectGroup);
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
                    MsgBox.Show(LanguageManager.Get(LangKeys.Main_SelectRowToDelete));
                    return;
                }

                var selectedRow = dgvMainView.SelectedRows[0];

                if (!int.TryParse(selectedRow.Cells["Column_index"].Value?.ToString(), out int noIdToDelete))
                {
                    MsgBox.Show(LanguageManager.Get(LangKeys.Main_CannotGetRowId));
                    return;
                }

                if (noIdToDelete != _indexRowMax - 1)
                {
                    MsgBox.Show(LanguageManager.Get(LangKeys.Main_OnlyDeleteLastRow));
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
                MsgBox.Show(LanguageManager.GetFormat(LangKeys.Main_DeleteRowError, ex.Message));
            }
        }

        private void txtTextInput_TextChanged(object sender, EventArgs e)
        {
            if (_isInternalTextChange)
                return;

            if (string.IsNullOrEmpty(_projectName) || dgvMainView.RowCount <= 0)
                return;

            if (_indexRowSelect < 0)
            {
                MsgBox.Show(ERR_ROW_INDEX);
                return;
            }

            int cursor = txtTextInput.SelectionStart;

            // Gọi hàm chung
            bool wasTrimmed;
            string processed = TextProcessUtil.ProcessText(txtTextInput.Text, RwConstant.MaxLengthText, out wasTrimmed);

            // Gán lại Text nếu có thay đổi
            if (txtTextInput.Text != processed)
            {
                _isInternalTextChange = true;
                txtTextInput.Text = processed;
                txtTextInput.SelectionStart = Math.Min(cursor, processed.Length);
                _isInternalTextChange = false;

                // Chỉ báo message 1 lần
                if (wasTrimmed)
                {
                    MsgBox.Show(
                        LanguageManager.GetFormat(LangKeys.Main_TextTooLong, RwConstant.MaxLengthText),
                        LanguageManager.Get(LangKeys.Common_Notice),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }

            // Update UI
            int len = processed.Length;
            string[] words = processed.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string textlength = LanguageManager.GetFormat(LangKeys.Main_CharWordCount, len, words.Length);

            FuncDataGridView.UpdateDataGridViewCell(dgvMainView, _indexRowSelect, "Column_inputtext", processed, Color.White);
            FuncDataGridView.UpdateDataGridViewCell(dgvMainView, _indexRowSelect, "Column_textlength", textlength, Color.White);
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
                MsgBox.Show(ERR_ROW_INDEX);
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
                                MsgBox.Show(LanguageManager.GetFormat(LangKeys.Lib_ErrorFormat, ex.Message), LanguageManager.Get(LangKeys.Main_ImportMediaTitle), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }
            }
            else
            {
                MsgBox.Show(ERR_ROW_INDEX);
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
                        SetMediaError(info, index, LanguageManager.Get(LangKeys.Main_MediaError));

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
                //MsgBox.Show("Nhập vào phải là Ảnh hoặc Video. ");
                SetMediaError(info, index, LanguageManager.Get(LangKeys.Main_MediaMissing));
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
                        MsgBox.Show(LanguageManager.Get(LangKeys.Main_InputMustBeAudio));
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
                        failStatus = LanguageManager.Get(LangKeys.Main_PictureError);
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
                        failStatus = LanguageManager.Get(LangKeys.Main_VideoError);
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                failStatus = LanguageManager.Get(LangKeys.Main_PictureError);
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
                // Nếu đang merge → Cancel
                if (_isMerging)
                {
                    _mergeCancellationTokenSource?.Cancel();
                    btnAddAll.Text = LanguageManager.Get(LangKeys.Main_MergeCancellingBtn);
                    btnAddAll.Enabled = false;
                    return;
                }

                // Bắt đầu merge mới
                _isMerging = true;
                btnAddAll.Text = LanguageManager.Get(LangKeys.Main_CancelMerge);
                _mergeCancellationTokenSource = new CancellationTokenSource();

                this._theart_videotheostt = new Thread(new ThreadStart(this.theart_ghepvideoTheoSTT));
                this._theart_videotheostt.Start();
            }
            catch (Exception ex)
            {
                MsgBox.Show(LanguageManager.GetFormat(LangKeys.Lib_ErrorFormat, ex.Message), LanguageManager.Get(LangKeys.Common_Warning), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ResetMergeButton();
            }
        }

        private void theart_ghepvideoTheoSTT()
        {
            try
            {
                ghepvdTheoStt(_mergeCancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    lblstatus.Text = LanguageManager.Get(LangKeys.Main_MergeCancelled);
                    MsgBox.Show(LanguageManager.Get(LangKeys.Main_MergeCancelled)
                        , LanguageManager.Get(LangKeys.Common_Notice)
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            catch (Exception ex)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    lblstatus.Text = LanguageManager.Get(LangKeys.Main_StatusError);
                    MsgBox.Show(LanguageManager.GetFormat(LangKeys.Lib_ErrorFormat, ex.Message)
                        , LanguageManager.Get(LangKeys.Common_Error)
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
            finally
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    ResetMergeButton();
                }));
            }
        }

        private void ResetMergeButton()
        {
            _isMerging = false;
            btnAddAll.Text = LanguageManager.Get(LangKeys.Main_MergeVideoBtn);
            btnAddAll.Enabled = true;
        }
        private void convertvideo()
        {
            // Chọn codec dựa trên radio button
            string videoCodec = rbGPUused.Checked ? VideoMergeConfig.VIDEO_CODEC_GPU : VideoMergeConfig.VIDEO_CODEC_CPU;
            string preset = rbGPUused.Checked ? VideoMergeConfig.FFMPEG_PRESET_GPU : "veryfast";

            string[] files = Directory.GetFiles(_videoRenderPath);
            int num = 0;
            foreach (string str in files)
            {
                string str2 = string.Format(" -y -i \"{0}\" -vcodec {3} -pix_fmt yuv420p -r 25 -acodec libmp3lame -b:a 128k -ar 44100 -preset {4} -s \"{1}\" -y \"{2}\"",
                    str, _vdquality, this.nameConvertPath(str), videoCodec, preset);

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
                        lblstatus.Text = LanguageManager.GetFormat(LangKeys.Main_ProcessingVideo, num++, files.Length);
                    }));
                    process.Start();
                    process.WaitForExit();
                    Invoke(new MethodInvoker(delegate ()
                    {
                        lblstatus.Text = LanguageManager.GetFormat(LangKeys.Main_ProcessingComplete, num, files.Length);
                    }));
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            Invoke(new MethodInvoker(delegate ()
            {
                lblstatus.Text = LanguageManager.Get(LangKeys.Main_ConvertDone);
            }));
        }
        private void ghepvdTheoStt(CancellationToken cancellationToken)
        {
            string[] files = Directory.GetFiles(_videoRenderPath);
            string filetext = Application.StartupPath + "\\data\\" + "datalink.txt";
            Dictionary<string, int> fileList = new Dictionary<string, int>();

            if (!File.Exists(filetext))
            {
                File.Create(filetext).Dispose();
            }
            File.WriteAllText(filetext, "");

            if (files == null || files.Length == 0)
            {
                this.Invoke(new Action(() =>
                {
                    MsgBox.Show(
                        this,
                        LanguageManager.Get(LangKeys.Main_MergeNoVideo),
                        LanguageManager.Get(LangKeys.Common_Notice),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    UIThreadHelper.SetLabelText(lblstatus, RwConstant.STATUS_DEFAULT, Color.Black);
                }));
                return; // dừng ghép
            }

            // Bước 1: Lọc và sắp xếp files theo số thứ tự
            foreach (var file in files)
            {
                try
                {
                    var result = Path.GetFileNameWithoutExtension(file);
                    fileList.Add(file, int.Parse(result));
                }
                catch
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        MsgBox.Show(LanguageManager.Get(LangKeys.Main_CheckFileRenamed));
                    }));
                    return;
                }
            }

            List<string> sortListfile = new List<string>();
            foreach (KeyValuePair<string, int> author in fileList.OrderBy(key => key.Value))
            {
                sortListfile.Add(author.Key);
            }

            int totalVideos = sortListfile.Count;
            List<string> validVideoList;
            List<string> corruptedVideos;

            // Bước 2: Validate video (nếu bật chế độ skip video lỗi)
            if (_skipCorruptedVideos)
            {
                _videoValidationService.ValidateVideosParallel(
                    sortListfile,
                    out validVideoList,
                    out corruptedVideos,
                    cancellationToken,
                    (current, total) =>
                    {
                        try
                        {
                            Invoke(new MethodInvoker(delegate ()
                            {
                                lblstatus.Text = LanguageManager.GetFormat(LangKeys.Main_CheckingVideo, current, total);
                            }));
                        }
                        catch { }
                    });
            }
            else
            {
                // Không validate, sử dụng tất cả video
                validVideoList = sortListfile;
                corruptedVideos = new List<string>();
            }

            // Check cancellation sau validation
            cancellationToken.ThrowIfCancellationRequested();

            int validVideos = validVideoList.Count;

            // Kiểm tra có video hợp lệ nào không
            if (validVideos == 0)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    lblstatus.Text = LanguageManager.Get(LangKeys.Main_NoValidVideoToMerge);
                    string errorReport = LanguageManager.Get(LangKeys.Main_AllVideoCorrupt);
                    errorReport += string.Join(", ", corruptedVideos.Take(5));
                    if (corruptedVideos.Count > 5)
                    {
                        errorReport += "...";
                    }
                    MsgBox.Show(errorReport, LanguageManager.Get(LangKeys.Main_MergeErrorTitle), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                return;
            }

            // Bước 3: Nếu có video lỗi, hỏi user có muốn tiếp tục merge không
            if (corruptedVideos.Count > 0)
            {
                bool shouldContinue = false;
                Invoke(new MethodInvoker(delegate ()
                {
                    string confirmMessage = LanguageManager.GetFormat(LangKeys.Main_CorruptedVideoHeader, corruptedVideos.Count);
                    confirmMessage += string.Join(", ", corruptedVideos.Take(10));
                    if (corruptedVideos.Count > 10)
                    {
                        confirmMessage += LanguageManager.GetFormat(LangKeys.Main_CorruptedVideoMore, corruptedVideos.Count - 10);
                    }
                    confirmMessage += LanguageManager.GetFormat(LangKeys.Main_ValidVideoCount, validVideos, totalVideos);
                    confirmMessage += LanguageManager.GetFormat(LangKeys.Main_ContinueMergeQuestion, validVideos);

                    DialogResult result = MsgBox.Show(
                        confirmMessage,
                        LanguageManager.Get(LangKeys.Main_MergeConfirmTitle),
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    shouldContinue = (result == DialogResult.Yes);
                }));

                if (!shouldContinue)
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        lblstatus.Text = LanguageManager.Get(LangKeys.Main_MergeCancelled);
                    }));
                    return; // User chọn NO, kết thúc
                }
            }

            // Bước 4: Tạo file danh sách video hợp lệ cho ffmpeg
            _videoMergeService.CreateConcatFile(filetext, validVideoList);

            // Bước 5: Ghép video bằng ffmpeg với progress tracking
            // Check cancellation trước khi start ffmpeg
            cancellationToken.ThrowIfCancellationRequested();

            Invoke(new MethodInvoker(delegate ()
            {
                lblstatus.Text = LanguageManager.GetFormat(LangKeys.Main_MergingValidVideos, validVideos);
            }));

            // Tạo subfolder với tên datetime: output_20250611_143052/
            string dateTimeStr = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string outputFolderName = $"output_{dateTimeStr}";
            string outputFolder = Path.Combine(_outputPath, outputFolderName);

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Tạo đường dẫn video trong subfolder
            string outputFileName = $"output_{dateTimeStr}.mp4";
            string outputVideoPath = Path.Combine(outputFolder, outputFileName);

            // Chọn codec dựa trên radio button
            string videoCodec = rbGPUused.Checked ? VideoMergeConfig.VIDEO_CODEC_GPU : VideoMergeConfig.VIDEO_CODEC_CPU;
            string preset = rbGPUused.Checked ? VideoMergeConfig.FFMPEG_PRESET_GPU : VideoMergeConfig.FFMPEG_PRESET_CPU;

            string ffmpegPath = Funcion.selectffmpegversion() + "\\ffmpeg.exe";
            string arguments = $"-y -f concat -safe 0 -i \"{filetext}\" -c copy -vcodec {videoCodec} -pix_fmt yuv420p -preset {preset} \"{outputVideoPath}\"";

            int exitCode = _videoMergeService.RunFFmpegMerge(
                ffmpegPath,
                arguments,
                validVideos,
                cancellationToken,
                (status) =>
                {
                    try
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            lblstatus.Text = status;
                        }));
                    }
                    catch { }
                });

            try
            {
                if (exitCode == 0)
                {
                    // Bước 6: Ghi log file nếu có video lỗi (trong cùng subfolder)
                    if (corruptedVideos.Count > 0)
                    {
                        string logFileName = $"output_{dateTimeStr}_log.txt";
                        string logFilePath = Path.Combine(outputFolder, logFileName);

                        _videoMergeService.WriteErrorLog(
                            logFilePath,
                            outputFolderName,
                            outputFileName,
                            outputVideoPath,
                            totalVideos,
                            validVideos,
                            corruptedVideos);
                    }

                    // Bước 7: Báo cáo kết quả
                    Invoke(new MethodInvoker(delegate ()
                    {
                        lblstatus.Text = LanguageManager.Get(LangKeys.Main_MergeDone);

                        // Tạo báo cáo
                        string report = LanguageManager.GetFormat(LangKeys.Main_MergeReport, totalVideos, validVideos, corruptedVideos.Count, outputFolderName, outputFileName);

                        if (corruptedVideos.Count > 0)
                        {
                            report += LanguageManager.GetFormat(LangKeys.Main_MergeReportLog, $"output_{dateTimeStr}_log.txt");
                        }

                        MessageBoxIcon icon = corruptedVideos.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information;
                        MsgBox.Show(report, LanguageManager.Get(LangKeys.Main_MergeResultTitle), MessageBoxButtons.OK, icon);

                        // Mở subfolder output sau khi thành công
                        Funcion.OpenFolder(outputFolder);
                    }));
                }
                else if (exitCode == -1)
                {
                    // Cancelled hoặc error
                    if (cancellationToken.IsCancellationRequested)
                    {
                        // Đã cancel - throw exception để catch block xử lý
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    else
                    {
                        // Error chứ không phải cancel
                        Invoke(new MethodInvoker(delegate ()
                        {
                            lblstatus.Text = LanguageManager.Get(LangKeys.Main_MergeFailedStatus);
                            MsgBox.Show(LanguageManager.Get(LangKeys.Main_MergeFfmpegError),
                                          LanguageManager.Get(LangKeys.Common_Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
                else
                {
                    // FFmpeg failed với exit code khác 0
                    Invoke(new MethodInvoker(delegate ()
                    {
                        lblstatus.Text = LanguageManager.Get(LangKeys.Main_MergeFailedStatus);
                        MsgBox.Show(LanguageManager.GetFormat(LangKeys.Main_MergeFfmpegExitCode, exitCode),
                                      LanguageManager.Get(LangKeys.Common_Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }

                File.WriteAllText(filetext, "");
            }
            catch (OperationCanceledException)
            {
                // Re-throw để theart_ghepvideoTheoSTT() catch và xử lý
                throw;
            }
            catch (Exception exception)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    lblstatus.Text = LanguageManager.Get(LangKeys.Main_StatusError);
                    MsgBox.Show(LanguageManager.GetFormat(LangKeys.Lib_ErrorFormat, exception.Message), LanguageManager.Get(LangKeys.Common_Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                Console.WriteLine(exception.Message);
            }
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
                    DisplayItemDefault();
                    UIThreadHelper.SetLabelText(lblstatus, RwConstant.STATUS_DEFAULT, Color.Black);
                    return;
                }

                // ==== 4. Load project mới từ DB ====
                var tempProject = _projectService.GetProjectDetail(Guid.Parse(selectID), selectPath);

                if (tempProject.IsEmpty)
                {
                    string warnMsg = LanguageManager.Get(LangKeys.Main_ProjectNotFound)
                        + "\n\n"
                        + LanguageManager.GetFormat(LangKeys.Main_ConfirmDeleteProject, selectPath);
                    var result = MsgBox.Show(warnMsg, LanguageManager.Get(LangKeys.Common_Warning), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                if (MsgBox.Show(LanguageManager.GetFormat(LangKeys.Main_ConfirmOpenProject, selectPath), LanguageManager.Get(LangKeys.Common_Notice), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _infoProject = tempProject;
                    DefaultProjectData();
                    _projectName = _infoProject.ProjectPath;
                    CkZoom.Checked = _infoProject.EffectSettup.SckZoom;
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

                    // Load voice source
                    var voiceSources = GetVoiceSourcesByPackageType();
                    int selectedIndex = 0;

                    if (!string.IsNullOrEmpty(voiceSite))
                    {
                        int savedIndex = voiceSources.FindIndex(x =>
                            string.Equals(x.Value, voiceSite, StringComparison.OrdinalIgnoreCase));
                        if (savedIndex >= 0)
                        {
                            selectedIndex = savedIndex;
                        }
                    }

                    ComboBoxFuncion.CbBlinding(cboSiteNguon, voiceSources, selectedIndex);

                    _configService.UpdateProjectNameDate(Guid.Parse(selectID));
                }
                else // User không muốn mở → gợi ý xóa
                {
                    var result = MsgBox.Show(LanguageManager.GetFormat(LangKeys.Main_ConfirmDeleteProject, selectPath), LanguageManager.Get(LangKeys.Common_Warning), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                UIThreadHelper.SetLabelText(lblstatus, RwConstant.STATUS_DEFAULT, Color.Black);
            }
        }

        private async void cbLanguageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ckSetting = _infoProject?.EffectSettup;
                if (_manualSelected == ManualSelect.FptAI)
                {
                    if (cbLanguageSelect.Text == FptAIVoiceLanguage.VietNam_Des)
                    {
                        var fptVoices = ApiFptAI.FptAIVoiceCodeTemplate().ToList();
                        var limitedFptVoices = LimitVoicesByPackage(fptVoices);

                        int fptIdx = 0;
                        if (!string.IsNullOrEmpty(ckSetting?.SspeechType))
                        {
                            // Try match by Value first (new format), then by Display (old format)
                            fptIdx = limitedFptVoices.FindIndex(x => x.Value.Equals(ckSetting.SspeechType));
                            if (fptIdx < 0)
                                fptIdx = limitedFptVoices.FindIndex(x => x.Display.Equals(ckSetting.SspeechType));
                            if (fptIdx < 0)
                                fptIdx = 0;
                        }
                        ComboBoxFuncion.CbBlinding(cbxSpeechType, limitedFptVoices, fptIdx);
                    }
                }
                else if (_manualSelected == ManualSelect.Google)
                {
                    ComboboxModel selectedItem = (ComboboxModel)cbLanguageSelect.SelectedItem;
                    string languageCode = selectedItem?.Value;

                    // Lấy key: nếu đang chọn T2PSOFT thì từ server, ngược lại từ textbox
                    ComboboxModel selectedVoiceSource = (ComboboxModel)cboSiteNguon.SelectedItem;
                    string apiKey = selectedVoiceSource?.Value == ListVoiceSite.T2Psoft ? GetDecryptedVoiceKey() : txtAppID.Text;

                    // Dùng cache + Task.Run để không block UI thread
                    var serviceGoogleTTS = await GetOrCreateGoogleTTSAsync(apiKey);
                    var googleVoices = serviceGoogleTTS.GetVoicesByLanguage(languageCode);
                    var limitedGoogleVoices = LimitVoicesByPackage(googleVoices);

                    int googleIdx = 0;
                    if (limitedGoogleVoices != null && !string.IsNullOrEmpty(ckSetting?.SspeechType))
                    {
                        // Try match by Value first (new format), then by Display (old format)
                        googleIdx = limitedGoogleVoices.FindIndex(x => x.Value.Equals(ckSetting.SspeechType));
                        if (googleIdx < 0)
                            googleIdx = limitedGoogleVoices.FindIndex(x => x.Display.Equals(ckSetting.SspeechType));
                        if (googleIdx < 0)
                            googleIdx = 0;
                    }
                    ComboBoxFuncion.CbBlinding(cbxSpeechType, limitedGoogleVoices, googleIdx);
                }
                else if (_manualSelected == ManualSelect.Elevenlab)
                {
                    // ElevenLabs: chưa hỗ trợ limit voices theo package
                    var elevenLabVoices = GetVoiceTemplate.SearchVoicesByLanguageAccent(_listVoice, cbLanguageSelect.Text);

                    int elevenIdx = 0;
                    if (!string.IsNullOrEmpty(ckSetting?.SspeechType))
                    {
                        // Try match by Value first (new format), then by Display (old format)
                        elevenIdx = elevenLabVoices.FindIndex(x => x.Value.Equals(ckSetting.SspeechType));
                        if (elevenIdx < 0)
                            elevenIdx = elevenLabVoices.FindIndex(x => x.Display.Equals(ckSetting.SspeechType));
                        if (elevenIdx < 0)
                            elevenIdx = 0;
                    }
                    ComboBoxFuncion.CbBlinding(cbxSpeechType, elevenLabVoices, elevenIdx);
                }
                else if (_manualSelected == ManualSelect.Vbee)
                {
                    ComboboxModel selectedItem = (ComboboxModel)cbLanguageSelect.SelectedItem;
                    string languageCode = selectedItem?.Value;

                    var vietnamVoices = ApiVbee.VbeeVoiceTemplate().Where(x => x.Language == languageCode).ToList();
                    var limitedVbeeVoices = LimitVbeeVoicesByPackage(vietnamVoices);

                    int vbeeIdx = 0;
                    if (!string.IsNullOrEmpty(ckSetting?.SspeechType))
                    {
                        // Try match by Value first (new format), then by Display (old format)
                        vbeeIdx = limitedVbeeVoices.FindIndex(x => x.Value.Equals(ckSetting.SspeechType));
                        if (vbeeIdx < 0)
                            vbeeIdx = limitedVbeeVoices.FindIndex(x => x.Display.Equals(ckSetting.SspeechType));
                        if (vbeeIdx < 0)
                            vbeeIdx = 0;
                    }
                    ComboBoxFuncion.CbBlinding(cbxSpeechType, limitedVbeeVoices, vbeeIdx);
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
            var now = DateTime.UtcNow;
            if (now - _lastAddRowClickTime < _addRowClickCooldown)
            {
                return;
            }

            if (_isAddingRow)
            {
                return;
            }

            try
            {
                _lastAddRowClickTime = now;
                _isAddingRow = true;
                btnAddRow.Enabled = false;

                if (!string.IsNullOrEmpty(_projectName) && _infoProject != null)
                {
                    addRow(_infoProject);
                }
                else
                {
                    MsgBox.Show(ERR_PROJECT_EMPTY);
                }
            }
            finally
            {
                btnAddRow.Enabled = true;
                _isAddingRow = false;
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
                MsgBox.Show(LanguageManager.Get(LangKeys.Main_ProjectInputEmpty));
                return;
            }

            try
            {
                if (_loadConfig.IsDuplicate(projectPath))
                {
                    MsgBox.Show(LanguageManager.Get(LangKeys.Main_ProjectExists));
                    return;
                }

                // Reset lại state trước khi tạo project mới
                ResetProjectState();

                _loadConfig.EnsureDirectory(projectPath);

                var newProject = _loadConfig.CreateNewProject(projectPath, _manualSelected.ToString(), nbSpeechRatio.Value.ToString("0.0"), CkZoom.Checked);
                _projectName = projectPath;

                var isSuccess = _loadConfig.AddProjectToConfig(newProject);
                if(!isSuccess)
                {
                    MsgBox.Show(LanguageManager.Get(LangKeys.Main_CriticalDataError), LanguageManager.Get(LangKeys.Main_CriticalErrorTitle), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                _loadConfig.SaveToDatabase(newProject);


                ActiveProject.ActiveGroupBoxSetting(tlpView, grbConfigVoice, grbConfigRender, grbActionRender, true);
                GenProjectData();

                //addRow(newProject);

                _infoProject = _projectService.GetProjectDetail(newProject.ID, projectPath);
                DefaultProjectData();

                // Load Project Name
                SelectProjectByName(cbProjectName, projectPath);
                CkZoom.Checked = true;
                _statusZoom = true; // Khai báo cờ check
                DisplayItemDefault();
                SaveEffectSetting();
                UIThreadHelper.SetLabelText(lblstatus, RwConstant.STATUS_DEFAULT, Color.Black);
                MsgBox.Show(LanguageManager.Get(LangKeys.Main_CreateProjectSuccess));
            }
            catch (Exception ex)
            {
                MsgBox.Show(LanguageManager.GetFormat(LangKeys.Main_CreateProjectError, ex.Message));
            }
        }

        private void SelectProjectByName(ComboBox combo, string projectName)
        {
            _previousText = projectName;
            // 1. Lấy config từ DB
            var config = _configService.GetItem(1);

            // 2. Tạo danh sách project (có item trống đầu tiên)
            var projectList = new List<ProjectName>
            {
                new ProjectName { ProjectPath = string.Empty } // Blank item
            };

            if (config?.ProjectNames != null)
            {
                // Sắp xếp theo date giảm dần và thêm vào danh sách
                projectList.AddRange(config.ProjectNames
                    .OrderByDescending(p => p.date)
                    .Select(p => new ProjectName
                    {
                        ID = p.ID,
                        ProjectPath = p.ProjectPath
                    }));
            }

            // 3. Chuyển sang danh sách bind cho ComboBox
            var comboItems = projectList
                .Select(p => new ComboboxModel
                {
                    Display = p.ProjectPath,
                    Value = p.ID.ToString()
                })
                .ToList();

            // 4. Tìm index cần chọn theo projectName
            int selectedIndex = 0; // default chọn item đầu tiên
            if (!string.IsNullOrEmpty(projectName))
            {
                int idx = comboItems.FindIndex(c => c.Display.Equals(projectName, StringComparison.OrdinalIgnoreCase));
                if (idx >= 0)
                {
                    selectedIndex = idx;
                }
            }

            // Tạm tắt event
            combo.SelectedIndexChanged -= cbProjectName_SelectedIndexChanged;

            // 5. Bind ComboBox và chọn index
            ComboBoxFuncion.CbBlinding(combo, comboItems, selectedIndex);

            // Bật lại event
            combo.SelectedIndexChanged += cbProjectName_SelectedIndexChanged;
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
            lblstatus.Text = RwConstant.STATUS_DEFAULT;
            if (!string.IsNullOrEmpty(_projectName))
            {
                // Validate GPU trước khi merge video
                if (!ValidateGPUSelection())
                {
                    return;
                }

                GhepvideoTheoSTT();
            }
            else
            {
                MsgBox.Show(ERR_PROJECT_EMPTY);
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
                MsgBox.Show(ERR_PROJECT_EMPTY);
                return;
            }

            // Bắt đầu trạng thái loading
            _isLoadingSubtitle = true;
            _subtitleLoadCTS = new CancellationTokenSource();

            btnImportSubtitle.Text = LanguageManager.Get(LangKeys.Main_StopLoading);
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
                openFileDialog.Title = LanguageManager.Get(LangKeys.Main_SelectSubtitleFile);
                openFileDialog.Filter = "Subtitle (*.srt)|*.srt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    subtitleFile = openFileDialog.FileName;
                    // Kiểm tra dung lượng file (<= 1 MB)
                    long fileSize = new System.IO.FileInfo(subtitleFile).Length;

                    if (fileSize > MAX_SIZE_BYTES)
                    {
                        ShowMessage(LanguageManager.Get(LangKeys.Main_SubtitleTooLarge), LanguageManager.Get(LangKeys.Common_Notice));
                        return;
                    }
                    using (OpenFileDialog openFolderDialog = new OpenFileDialog()) // Không dùng FolderBrowserDialog vì nó hạn chế giao diện lựa chọn
                    {
                        openFolderDialog.Title = LanguageManager.Get(LangKeys.Main_SelectMediaFolderTitle);
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
                                ShowMessage(LanguageManager.Get(LangKeys.Main_SelectMediaFolder), LanguageManager.Get(LangKeys.Common_Notice));
                                return;
                            }
                        }
                        else
                        {
                            ShowMessage(LanguageManager.Get(LangKeys.Main_SelectMediaFolder), LanguageManager.Get(LangKeys.Common_Notice));
                            return;
                        }
                    }
                    _infoProject.InforSubtitleFile = new InforSubtitleFile
                    {
                        SubtitleFile = subtitleFile,
                        FolderSubtileMediaFile = subtitleMediaPath
                    };

                    // Xóa tất cả video files cũ trong thư mục MediaImport và VideoRender trước khi import subtitle mới
                    ClearVideoFilesInFolder(_mediaPath);
                    ClearVideoFilesInFolder(_videoRenderPath);

                    await LoadSubtitleAsync(_subtitleLoadCTS.Token);
                    LoadDataGridInit();
                }
            }
            catch (OperationCanceledException)
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_SubtitleCancelled), Color.Red);
            }
            catch
            {
                UIThreadHelper.SetLabelText(lblstatus, LanguageManager.Get(LangKeys.Main_ThreadError), Color.Red);
            }
            finally
            {
                _isLoadingSubtitle = false;
                _subtitleLoadCTS?.Dispose();
                _subtitleLoadCTS = null;

                btnImportSubtitle.Text = LanguageManager.Get(LangKeys.Main_ImportSubtitle);
                btnImportSubtitle.Enabled = true;
                btnAddRow.Enabled = true;
                btnAddAll.Enabled = true;
                btnOpenProject.Enabled = true;
                cbProjectName.Enabled = true;
            }

        }

        /// <summary>
        /// Xóa tất cả video files trong thư mục được chỉ định
        /// </summary>
        private void ClearVideoFilesInFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                return;

            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                if (CheckMedia.IsVideoExtension(file))
                {
                    File.Delete(file);
                }
            }
        }

        private async Task<bool> CheckAndCancelAllRunningTasksAsync(bool msgNoneTaskRun = true)
        {
            var runningTasks = new List<(string name, Func<bool> isRunning, CancellationTokenSource cts)>
            {
                (LanguageManager.Get(LangKeys.Main_TaskReloadSelected), () => _isReloadingSelected, _reloadSelectedCTS),
                (LanguageManager.Get(LangKeys.Main_TaskReloadAll), () => _isReloadingAll, _reloadAllCTS),

                (LanguageManager.Get(LangKeys.Main_TaskConvertAll), () => _isConvertingAll, _convertAllCTS),
                (LanguageManager.Get(LangKeys.Main_TaskConvertSelected), () => _isConvertingSelected, _convertSelectedCTS),
                (LanguageManager.Get(LangKeys.Main_TaskConvertSingle), () => _isConvertingSingle, _convertSingleCTS),

                (LanguageManager.Get(LangKeys.Main_TaskDownloadAll), () => _isDownloadingAll, _downloadAllCTS),
                (LanguageManager.Get(LangKeys.Main_TaskDownloadSelected), () => _isDownloadingSelected, _downloadSelectedCTS),
                (LanguageManager.Get(LangKeys.Main_TaskDownloadSingle), () => _isDownloadingSingle, _downloadSingleCTS),

                (LanguageManager.Get(LangKeys.Main_TaskRecord), () => _isRecording, _recordCTS),

                (LanguageManager.Get(LangKeys.Main_TaskRenderAll), () => _isRenderingAll, _renderAllCTS),
                (LanguageManager.Get(LangKeys.Main_TaskRenderSelected), () => _isRenderingSelected, _renderSelectCTS),
            };

            // Thêm các row đang render riêng lẻ vào danh sách
            lock (_renderingRows)
            {
                foreach (var kvp in _renderingRows.ToList())
                {
                    int rowIndex = kvp.Key;
                    var cts = kvp.Value;
                    runningTasks.Add((LanguageManager.GetFormat(LangKeys.Main_TaskRenderRow, rowIndex + 1), () => _renderingRows.ContainsKey(rowIndex), cts));
                }
            }

            var initialActive = runningTasks.Where(t => t.isRunning()).ToList();
            if (initialActive.Count == 0)
            {
                if (msgNoneTaskRun)
                {
                    UIThreadHelper.ShowMessageBoxSafe(
                    this,
                    LanguageManager.Get(LangKeys.Main_NoRunningProcesses),
                    LanguageManager.Get(LangKeys.Common_Notice),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }

                return true;
            }

            string activeNames = string.Join("\n- ", initialActive.Select(t => t.name));

            DialogResult confirm = UIThreadHelper.ShowMessageBoxSafe(
                this,
                LanguageManager.GetFormat(LangKeys.Main_CancelAllConfirm, activeNames),
                LanguageManager.Get(LangKeys.Main_CancelAllTitle),
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
            _loadingService.Show(LanguageManager.Get(LangKeys.Main_CancellingProcesses));

            // Chờ tiến trình thật sự kết thúc (flag + token)
            bool finished = await WaitUntilAllTasksStoppedAsync(runningTasks, timeoutMs: 15000);

            // Đóng popup loading
            _loadingService.Close();
            AcessUIShowPopup();

            if (!finished)
            {
                UIThreadHelper.ShowMessageBoxSafe(
                    this,
                    LanguageManager.Get(LangKeys.Main_TasksStillRunning),
                    LanguageManager.Get(LangKeys.Common_Warning),
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
            // Skip nếu đang trong quá trình initialization
            if (_isInitializing)
                return;

            var checkSaveST = _infoProject?.EffectSettup;
            ComboboxModel selectedItem = (ComboboxModel)cboSiteNguon.SelectedItem;

            // Check null hoặc không có value -> chọn T2Psoft mặc định
            if (selectedItem == null || string.IsNullOrEmpty(selectedItem.Value))
            {
                // Tìm index của T2Psoft trong combobox
                var voiceSources = GetVoiceSourcesByPackageType();
                int t2psoftIndex = voiceSources.FindIndex(x => x.Value == ListVoiceSite.T2Psoft);

                if (t2psoftIndex >= 0 && cboSiteNguon.SelectedIndex != t2psoftIndex)
                {
                    // Set flag tạm để tránh trigger event lại
                    _isInitializing = true;
                    cboSiteNguon.SelectedIndex = t2psoftIndex;
                    _isInitializing = false;

                    // Gọi trực tiếp handler cho T2Psoft
                    selectedItem = voiceSources[t2psoftIndex];
                }
                else
                {
                    return; // Không có T2Psoft hoặc đã được chọn rồi
                }
            }

            // Hiện loading và disable combobox để tránh user thao tác khi đang tải
            cboSiteNguon.Enabled = false;
            _loadingService.Show(LanguageManager.Get(LangKeys.Main_LoadingVoice));
            try
            {
                switch (selectedItem.Value)
                {
                    case ListVoiceSite.T2Psoft:
                        // Xử lý T2Psoft - sử dụng voiceType từ server
                        await HandleT2PsoftVoiceSource(checkSaveST);
                        return; // Return sớm để không chạy logic cũ
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

                await loadApiKeyAsync();

                // Tạm unsubscribe event cbLanguageSelect để tránh cascading trigger network call
                cbLanguageSelect.SelectedIndexChanged -= cbLanguageSelect_SelectedIndexChanged;

                if (_manualSelected == ManualSelect.FptAI)
                {
                    // Hiển thị và enable lại txtAppID và txtToken cho voice source thật
                    lblapi.Visible = true;
                    txtAppID.Visible = true;
                    txtAppID.Enabled = true;
                    txtToken.Enabled = true;

                    lblapi.Text = "ApiKey";
                    txtAppID.Size = new Size(239, 90);
                    lblToken.Visible = false;
                    txtToken.Visible = false;

                    nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioFptAI ? nbSpeechRatio.Value : _speechratioFptAI;

                    var allLanguages = ApiFptAI.FptAILanguageTemplate().ToList();
                    var filteredLanguages = FilterLanguagesByPackage(allLanguages);

                    ComboBoxFuncion.CbBlinding(cbLanguageSelect
                                                , filteredLanguages
                                                , !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                                                    ? Math.Max(filteredLanguages.FindIndex(x => x.Value.Equals(checkSaveST.SlanguageSelect) || x.Display.Equals(checkSaveST.SlanguageSelect)), 0)
                                                    : 0);
                }
                else if (_manualSelected == ManualSelect.Elevenlab)
                {
                    // Hiển thị và enable lại txtAppID và txtToken cho voice source thật
                    lblapi.Visible = true;
                    txtAppID.Visible = true;
                    txtAppID.Enabled = true;
                    txtToken.Enabled = true;

                    lblapi.Text = "Elevenlab";
                    txtAppID.Size = new Size(239, 90);
                    lblToken.Visible = false;
                    txtToken.Visible = false;

                    nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioElevenlab ? nbSpeechRatio.Value : _speechratioElevenlab;

                    // Lấy key từ textbox (vì đây là voice source khác T2PSOFT)
                    // [V2-UPDATE] Chuyển sang VoicesV2Endpoint (API /v2/voices) thay cho VoicesEndpoint (API /v1/voices)
                    VoicesV2Endpoint voiceServices = new VoicesV2Endpoint(txtAppID.Text);
                    var listVoice = await voiceServices.GetAllVoicesAsync();
                    if(listVoice == null)
                    {
                        cbLanguageSelect.DataSource = null;
                        cbLanguageSelect.SelectedIndex = -1;
                    }
                    else
                    {
                        _listVoice = listVoice?.ToList();

                        var allLanguages = _listVoice != null ? GetVoiceTemplate.ElevenLabsLanguageTemplate(_listVoice).ToList() : null;

                        // ElevenLabs: chưa hỗ trợ filter language theo allowedLanguages (format khác Google TTS code)
                        ComboBoxFuncion.CbBlinding(cbLanguageSelect
                                    , allLanguages
                                    , allLanguages != null && !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                                        ? Math.Max(allLanguages.FindIndex(x => x.Value.Equals(checkSaveST.SlanguageSelect) || x.Display.Equals(checkSaveST.SlanguageSelect)), 0)
                                        : 0);
                    }
                }
                else if (_manualSelected == ManualSelect.Google)
                {
                    // Hiển thị và enable lại txtAppID và txtToken cho voice source thật
                    lblapi.Visible = true;
                    txtAppID.Visible = true;
                    txtAppID.Enabled = true;
                    txtToken.Enabled = true;

                    lblapi.Text = "Json Data";
                    txtAppID.Size = new Size(239, 90);
                    lblToken.Visible = false;
                    txtToken.Visible = false;

                    nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioGoogleTTS ? nbSpeechRatio.Value : _speechratioGoogleTTS;

                    // Dùng cache + Task.Run để không block UI thread
                    var serviceGoogleTTS = await GetOrCreateGoogleTTSAsync(txtAppID.Text);
                    if (serviceGoogleTTS.CheckClient())
                    {
                        var listlanguage = serviceGoogleTTS.GetListLanguage()?.ToList();
                        var filteredLanguages = FilterLanguagesByPackage(listlanguage);

                        if (filteredLanguages == null || filteredLanguages.Count == 0)
                        {
                            _loadingService.Close();
                            MsgBox.Show(LanguageManager.Get(LangKeys.Main_CannotLoadVoices), LanguageManager.Get(LangKeys.Main_CannotLoadVoicesTitle), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cbLanguageSelect.DataSource = null;
                        }
                        else
                        {
                            ComboBoxFuncion.CbBlinding(cbLanguageSelect
                                                  , filteredLanguages
                                                  , !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                                                      ? Math.Max(filteredLanguages.FindIndex(x => x.Value.Equals(checkSaveST.SlanguageSelect) || x.Display.Equals(checkSaveST.SlanguageSelect)), 0)
                                                      : 0);
                        }
                    }
                    else
                    {
                        _loadingService.Close();
                        MsgBox.Show(LanguageManager.Get(LangKeys.Main_JsonDataError));
                        cbLanguageSelect.DataSource = null;
                    }
                }
                else if (_manualSelected == ManualSelect.Vbee)
                {
                    // Hiển thị và enable lại txtAppID và txtToken cho voice source thật
                    lblapi.Visible = true;
                    txtAppID.Visible = true;
                    txtAppID.Enabled = true;
                    txtToken.Enabled = true;

                    lblapi.Text = "AppID";
                    txtAppID.Size = new Size(239, 40);
                    lblToken.Visible = true;
                    txtToken.Visible = true;

                    nbSpeechRatio.Value = nbSpeechRatio.Value != _speechratioVbee ? nbSpeechRatio.Value : _speechratioVbee;

                    var allLanguages = ApiVbee.VbeeLanguageTemplate().ToList();
                    var filteredLanguages = FilterLanguagesByPackage(allLanguages);

                    ComboBoxFuncion.CbBlinding(cbLanguageSelect
                                              , filteredLanguages
                                              , !string.IsNullOrEmpty(checkSaveST?.SlanguageSelect)
                                                  ? Math.Max(filteredLanguages.FindIndex(x => x.Value.Equals(checkSaveST.SlanguageSelect) || x.Display.Equals(checkSaveST.SlanguageSelect)), 0)
                                                  : 0);
                }

                // Resubscribe event cbLanguageSelect và trigger thủ công 1 lần để load voices
                cbLanguageSelect.SelectedIndexChanged += cbLanguageSelect_SelectedIndexChanged;
                cbLanguageSelect_SelectedIndexChanged(cbLanguageSelect, EventArgs.Empty);

                UpdateVoiceSourceSelect();
            }
            catch (TaskCanceledException)
            {
                _loadingService.Close();
                MsgBox.Show(LanguageManager.Get(LangKeys.Main_ConnectionTimeout)
                    , LanguageManager.Get(LangKeys.Main_ConnectionErrorTitle)
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                _loadingService.Close();
                MsgBox.Show(LanguageManager.Get(LangKeys.Main_ConnectionError)
                    , LanguageManager.Get(LangKeys.Main_ConnectionErrorTitle)
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                _loadingService.Close();
                cboSiteNguon.Enabled = true;
            }
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

                // Lấy key từ textbox cho các voice source thật (không phải T2PSOFT)
                if (manualSelected == ManualSelect.FptAI)
                {
                    fptAIkey = txtAppID.Text;
                }
                else if (manualSelected == ManualSelect.Google)
                {
                    googleTTSkey = txtAppID.Text;
                }
                else if (manualSelected == ManualSelect.Elevenlab)
                {
                    evelenlabKey = txtAppID.Text;
                }
                else if (manualSelected == ManualSelect.Vbee)
                {
                    vbeeId = txtAppID.Text;
                    vbeeToken = txtToken.Text;
                }

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
                if (check) MsgBox.Show(LanguageManager.Get(LangKeys.Main_SaveKeySuccess));
            }
        }

        private void cbZoomRatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            var zoomText = cbZoomRatio.Text;
            if (zoomText == ZoomRatiotName.ZoomRatio0_Des)
                _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio0_Val);
            else if (zoomText == ZoomRatiotName.ZoomRatio10_Des)
                _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio10_Val);
            else if (zoomText == ZoomRatiotName.ZoomRatio25_Des)
                _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio25_Val);
            else if (zoomText == ZoomRatiotName.ZoomRatio50_Des)
                _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio50_Val);
            else if (zoomText == ZoomRatiotName.ZoomRatio75_Des)
                _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio75_Val);
            else if (zoomText == ZoomRatiotName.ZoomRatio100_Des)
                _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio100_Val);
            else if (zoomText == ZoomRatiotName.ZoomRatio125_Des)
                _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio125_Val);
            else if (zoomText == ZoomRatiotName.ZoomRatio150_Des)
                _zoomRatio = Convert.ToDecimal(ZoomRatiotName.ZoomRatio150_Val);
        }

        private void cbZoomQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            var qualityText = cbZoomQuality.Text;
            if (qualityText == ZoomQualitytName.ZoomQuality_Low_Des)
                _zoomQuality = ZoomQualitytName.ZoomQuality_Low_Val;
            else if (qualityText == ZoomQualitytName.ZoomQuality_Normal_Des)
                _zoomQuality = ZoomQualitytName.ZoomQuality_Normal_Val;
            else if (qualityText == ZoomQualitytName.ZoomQuality_Medium_Des)
                _zoomQuality = ZoomQualitytName.ZoomQuality_Medium_Val;
            else if (qualityText == ZoomQualitytName.ZoomQuality_High_Des)
                _zoomQuality = ZoomQualitytName.ZoomQuality_High_Val;
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
                MsgBox.Show(ex.Message, LanguageManager.Get(LangKeys.Common_Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnRenderVideoPart.Text = LanguageManager.Get(LangKeys.Main_RenderPart);
            btnConvertAudio.Text = LanguageManager.Get(LangKeys.Main_ConvertAudio);
            btnSaveAudio.Text = LanguageManager.Get(LangKeys.Main_SaveAudio);

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
            //MsgBox.Show($"Lỗi: {errorMessage} trong cột {columnName}, hàng {rowIndex + 1}");

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
            // Check if _voiceSourceInfo is null before accessing
            if (_voiceSourceInfo == null || string.IsNullOrEmpty(_voiceSourceInfo.VoiceKey))
            {
                return;
            }

            // Lưu vị trí con trỏ trước khi thay đổi
            int cursorPosition = txtAppID.SelectionStart;

            // Gọi phương thức để loại bỏ ký tự xuống dòng và nối các dòng lại
            string processedText = RemoveNewLineChars(_voiceSourceInfo.VoiceKey);

            // Cập nhật nội dung của TextBox
            _voiceSourceInfo.VoiceKey = processedText;

            // Khôi phục vị trí con trỏ
            txtAppID.SelectionStart = cursorPosition;
        }

        private void btnSaveEffectSetting_Click(object sender, EventArgs e)
        {
            var valEffectSettup = _infoProject.EffectSettup;
            if (valEffectSettup != null && valEffectSettup.Active)
            {
                var dialog = MsgBox.Show(
                    LanguageManager.Get(LangKeys.Main_ConfirmChangeConfig),
                    LanguageManager.Get(LangKeys.Common_Confirm),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Nếu người dùng chọn Không → thoát, không save
                if (dialog == DialogResult.No)
                    return;
            }
            var check = SaveEffectSetting();
            if (check)
            {
                MsgBox.Show(LanguageManager.Get(LangKeys.Main_SaveEffectSuccess)
                    , LanguageManager.Get(LangKeys.Common_Success)
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MsgBox.Show(LanguageManager.Get(LangKeys.Main_SaveEffectError)
                    , LanguageManager.Get(LangKeys.Common_Error)
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSettingTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxModel selectedItem = (ComboboxModel)cbSettingTemplate.SelectedItem;
            string settingName = selectedItem?.Value;

            bool checkDefault;
            if(settingName == EffectConfigName.DEFAULT_Val)
            {
                checkDefault = true;
            }
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
                    string subString = RwConstant.STATUS_DEFAULT + fullText.Substring(i);
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

                // Unsubscribe language change
                LanguageManager.LanguageChanged -= ApplyLanguage;

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
    }
}