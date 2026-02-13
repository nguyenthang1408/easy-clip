using Common.Services;
using Lib;
using Lib.VoiceServices.ElevenLabs;
using Lib.VoiceServices.ElevenLabs.V1;
using Lib.VoiceServices.ElevenLabs.V1.Model;
using Lib.VoiceServices.ElevenLabs.V1.Services;
using LibCommon.Lib.Model.Package;
using ReviewMovie.Infrastructure.Project;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReviewMovie.Model
{
    public class AudioConvertContextModel
    {
        public string ProjectName { get; set; }
        public List<InfoRenderVd> AllInfoRender { get; set; }
        public InfoProject InfoProject { get; set; }
        public ManualSelect ManualSelected { get; set; }
        public VoiceSettings VoiceSetting { get; set; }
        public string VoiceCode { get; set; }
        public decimal SpeechRatio { get; set; }
        public string AudioTempPath { get; set; }
        public string AppID { get; set; }
        public string Token { get; set; }

        // --- TTS Usage Tracking (chỉ dùng khi IsT2Psoft = true) ---

        /// <summary>
        /// True nếu đang dùng nguồn T2Psoft (cần gọi usage API trước khi convert)
        /// </summary>
        public bool IsT2Psoft { get; set; }

        /// <summary>
        /// App code (hard disk serial) để gửi lên server
        /// </summary>
        public string AppCode { get; set; }

        /// <summary>
        /// Product slug (VD: "easy-clip101") để gửi lên server
        /// </summary>
        public string ProductSlug { get; set; }

        /// <summary>
        /// ApiClientRequest instance để gọi API server
        /// </summary>
        public ApiClientRequest ApiRequest { get; set; }

        /// <summary>
        /// Callback khi usage API trả về thành công: cập nhật characterUsed/characterLimit + rotate key
        /// </summary>
        public Action<TtsUsageResponse> OnTtsUsageUpdated { get; set; }

        /// <summary>
        /// Truy xuất input text theo index dòng (index => inputText)
        /// </summary>
        public Func<int, string> GetInputTextByIndex { get; set; }

        /// <summary>
        /// Cập nhật trạng thái dòng: (index, audiolink, audiostatus, inputtext)
        /// </summary>
        public Action<int, string, string, string> UpdateRowCallback { get; set; }

        /// <summary>
        /// Cập nhật status tổng thể (text, color)
        /// </summary>
        public Action<string, Color> SetStatusCallback { get; set; }

        /// <summary>
        /// (Tùy chọn) Cập nhật text cho button/label nếu muốn
        /// </summary>
        public Action<string> SetButtonTextCallback { get; set; }

        /// <summary>
        /// Callback để báo alert (show message box, toast, v.v)
        /// </summary>
        public Action<string> ShowAlertCallback { get; set; }

        /// <summary>
        /// Được gọi sau mỗi lần update row thành công. (index, audiolink, audiostatus, inputtext)
        /// </summary>
        public Action<int, string, string, string> OnAfterRowConverted { get; set; }
    }

    public class AudioRecordContextModel
    {
        public int RowIndex { get; set; }
        public string AudioTempPath { get; set; }

        // Update cell trạng thái record
        public Action<int, string, string> UpdateRowCallback { get; set; }
        // Set status tổng thể (label, status bar,...)
        public Action<string, Color> SetStatusCallback { get; set; }
        // Alert/MessageBox (nếu cần)
        public Action<string> ShowAlertCallback { get; set; }
        // Lưu vào DB mỗi lần xong/hủy/lỗi
        public Action<int, string, string> OnAfterRecord { get; set; }
    }

    public class AudioDownloadContextModel
    {
        // Dữ liệu cơ bản để xác định dòng, link audio và nơi lưu file
        public int RowIndex { get; set; }
        public string AddressLink { get; set; }
        public string AudioPath { get; set; }

        // Tham số random scale cho xử lý time
        public decimal ScaleAudioRangeStart { get; set; }
        public decimal ScaleAudioRangeEnd { get; set; }

        // Dùng để xác định loại download và appID (tuỳ nhà cung cấp dịch vụ)
        public ManualSelect ManualSelected { get; set; }
        public string AppId { get; set; }

        // --- Các delegate truy cập dữ liệu hoặc cập nhật UI ---

        // Lấy row trong gridview (WinForms), có thể bỏ với WPF
        public Func<int, DataGridViewRow> GetDataGridViewRow { get; set; }

        // Lấy object InfoRenderVd (model logic ứng dụng)
        public Func<int, InfoRenderVd> GetInfoRenderByRowIndex { get; set; }

        /// <summary>
        /// Cập nhật một ô (cell) trong DataGridView
        /// idx: row index, columnName: tên cột, value: giá trị, color: màu nền
        /// </summary>
        public Action<int, string, object, Color?> UpdateCellCallback { get; set; }

        /// <summary>
        /// Callback khi muốn cập nhật lại AudioTime trong model
        /// </summary>
        public Action<int, decimal> UpdateAudioTimeCallback { get; set; }
    }


}
