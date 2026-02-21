using System.Collections.Generic;

namespace ReviewMovie.Localization.Resources
{
    public static class Lang_vi
    {
        public static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            // ========== Common ==========
            { LangKeys.Common_Notice, "Thông báo" },
            { LangKeys.Common_Error, "Lỗi" },
            { LangKeys.Common_Warning, "Cảnh báo" },
            { LangKeys.Common_Save, "Lưu" },
            { LangKeys.Common_Cancel, "Hủy" },
            { LangKeys.Common_SelectAll, "Chọn Hết" },
            { LangKeys.Common_SelectGroup, "Chọn Nhóm" },
            { LangKeys.Common_CancelSelectAll, "Hủy Chọn Hết" },
            { LangKeys.Common_CancelSelectGroup, "Hủy Chọn Nhóm" },

            // ========== Program.cs ==========
            { LangKeys.Program_AlreadyRunning, "Ứng dụng đã chạy. Bạn có muốn mở thêm một phiên bản không?" },

            // ========== Login Form ==========
            { LangKeys.Login_Title, "REVIEW_MOVIE LOGIN" },
            { LangKeys.Login_AppCode, "APP CODE" },
            { LangKeys.Login_ApiKey, "API KEY" },
            { LangKeys.Login_BtnLogin, "ĐĂNG NHẬP" },
            { LangKeys.Login_Help, "Trợ Giúp" },
            { LangKeys.Login_Register, "Đăng Ký" },
            { LangKeys.Login_EnterApiKey, "Vui lòng nhập API Key!" },
            { LangKeys.Login_Success, "Đăng nhập thành công!" },
            { LangKeys.Login_CannotGetKey, "Không thể lấy được T2PKey: " },
            { LangKeys.Login_VersionUpdate, "Bạn đang sử dụng phiên bản {0}. Phiên bản mới nhất là {1}. Bạn có muốn cập nhật không?" },
            { LangKeys.Login_VersionUpdateTitle, "Cập nhật phiên bản" },
            { LangKeys.Login_ConnectionFailed, "Không Kết nối Được, API cần được Kích Hoạt!" },
            { LangKeys.Login_SelectLanguage, "Ngôn ngữ" },

            // ========== Main Form - Settings ==========
            { LangKeys.Main_Settings, "Cài Đặt " },
            { LangKeys.Main_Project, "Dự Án" },
            { LangKeys.Main_Create, "Tạo Mới" },
            { LangKeys.Main_VoiceSettings, "Cài Đặt Voice" },
            { LangKeys.Main_VoiceSource, "Nguồn Voice" },

            // ========== Main Form - Effect Settings ==========
            { LangKeys.Main_EffectSettings, "Lựa Chọn Hiệu Ứng" },
            { LangKeys.Main_ZoomUp, "% ZoomUp :" },
            { LangKeys.Main_ZQuality, "% ZQuality :" },
            { LangKeys.Main_Quality, "Chất lượng :" },
            { LangKeys.Main_VoiceType, "Giọng Đọc :" },
            { LangKeys.Main_SpeechSpeed, "Tốc Độ Đọc :" },
            { LangKeys.Main_FpsInput, "FPS (InPut) :" },
            { LangKeys.Main_Thread, "Thread :" },
            { LangKeys.Main_SelectionMode, "Lựa Chọn :" },
            { LangKeys.Main_EffectType, "Hiệu ứng :" },
            { LangKeys.Main_ZoomVideo, "Zoom video" },
            { LangKeys.Main_RotateVideo, "Xoay video" },
            { LangKeys.Main_FlipVideo, "Lật Video" },
            { LangKeys.Main_FlipRandom, "Lật Random" },
            { LangKeys.Main_LayerAutoMove, "Layer Tự Động Di Chuyển Trái <-> Phải" },
            { LangKeys.Main_AudioScale, "Tốc độ âm :" },
            { LangKeys.Main_OriginalVolume, "Volumn gốc :" },
            { LangKeys.Main_NoAudio, "Ko dùng Audio" },
            { LangKeys.Main_Language, "Ngôn Ngữ :" },
            { LangKeys.Main_Config, "Cấu Hình :" },
            { LangKeys.Main_AutoOpenPlayer, "Tự động Mở Player" },

            // ========== Main Form - Render ==========
            { LangKeys.Main_PublishVideo, "Xuất Bản Video" },
            { LangKeys.Main_MergeClips, "GHÉP CÁC ĐOẠN" },

            // ========== Main Form - Action Buttons ==========
            { LangKeys.Main_Record, "Thu Âm" },
            { LangKeys.Main_ConvertAudio, "Chuyển Đổi Audio" },
            { LangKeys.Main_SaveAudio, "Lưu Audio" },
            { LangKeys.Main_RenderPart, "Render Đoạn" },
            { LangKeys.Main_UseCPU, "Dùng CPU" },
            { LangKeys.Main_UseGPU, "Dùng GPU" },

            // ========== Main Form - Content Header ==========
            { LangKeys.Main_MicIn, "Mic In" },
            { LangKeys.Main_DragDropMedia, "Kéo Thả (Ảnh , Video)" },
            { LangKeys.Main_InputTextHeader, "Nhập Text | Hoặc Kéo Audio File Vào !" },

            // ========== Main Form - Toolbar ==========
            { LangKeys.Main_SelectTask, "Chọn Tác Vụ" },
            { LangKeys.Main_SelectDeselectAll, "Chọn/Không chọn tất cả" },
            { LangKeys.Main_AddNewRow, "Thêm Dòng Mới" },
            { LangKeys.Main_ImportSubtitle, "Nhập Subtitle (Auto)" },
            { LangKeys.Main_CancelAllOps, "&Hủy Mọi Hoạt Động" },
            { LangKeys.Main_SearchTooltip, "Nhập thông tin cần tìm vào đây" },

            // ========== Main Form - Context Menu ==========
            { LangKeys.Main_ConvertText2Voice, "Chuyển Đổi Text -> Voice" },
            { LangKeys.Main_DownloadConvertedAudio, "Lấy Audio Chuyển Đổi" },
            { LangKeys.Main_CreateVideoFromMedia, "Tạo Đoạn Video Từ Media, Audio" },
            { LangKeys.Main_ReloadVideoTime, "Reload Time Video Nhập" },
            { LangKeys.Main_DeleteSelectedRows, "Xóa Dòng Chọn" },

            // ========== Main Form - Dynamic Messages ==========
            { LangKeys.Main_ErrProjectEmpty, "Nhập Đường Dẫn & Khởi Tạo Project !" },
            { LangKeys.Main_ErrRowIndex, "Chọn 1 Row để nạp thông tin !" },
            { LangKeys.Main_InvalidServerData, "Dữ liệu từ server không hợp lệ. Vui lòng liên hệ hỗ trợ." },
            { LangKeys.Main_InvalidServerDataTitle, "Lỗi dữ liệu" },
            { LangKeys.Main_AuthFailed, "Xác thực tài khoản thất bại. Vui lòng đăng nhập lại." },
            { LangKeys.Main_AuthFailedTitle, "Lỗi xác thực" },
            { LangKeys.Main_ConnectionError, "Không thể kết nối đến server. Vui lòng kiểm tra kết nối mạng và thử lại." },
            { LangKeys.Main_ConnectionErrorTitle, "Lỗi kết nối" },
            { LangKeys.Main_VoiceSourceError, "Nguồn Âm Thanh bị lỗi. Khởi động lại App !" },
            { LangKeys.Main_VoiceSourceErrorTitle, "Lỗi kết nối" },
            { LangKeys.Main_CannotLoadVoiceSource, "Không thể tải thông tin voice source từ server." },
            { LangKeys.Main_DailyLimitExceeded, "Đã hết ký tự hôm nay ({0}/{1}). Vui lòng thử lại vào ngày mai." },
            { LangKeys.Main_TotalLimitExceeded, "Đã hết ký tự gói ({0}/{1}). Vui lòng nâng cấp gói." },
            { LangKeys.Main_TotalChars, "Tổng ký tự: {0}/{1}" },
            { LangKeys.Main_TodayChars, "Hôm nay: {0}/{1}" },
            { LangKeys.Main_Unlimited, "Không giới hạn" },
            { LangKeys.Main_VoiceKeyError, "VoiceKey từ T2Psoft bị lỗi!" },
            { LangKeys.Main_CannotLoadVoices, "Không thể tải danh sách giọng đọc. Kiểm tra kết nối mạng và thử lại." },
            { LangKeys.Main_CannotLoadVoicesTitle, "Lỗi kết nối" },
            { LangKeys.Main_T2PsoftVoiceError, "Lỗi khi xử lý T2Psoft voice source: {0}" },
            { LangKeys.Main_UpdateTimeVideoDone, "Cập nhật TimeVideo xong !" },
            { LangKeys.Main_ReloadingSubtitle, "Đang Reload Line {0}/{1} Subtitle." },
            { LangKeys.Main_SubtitleFormatError, "File SubTitle sai định dạng!" },
            { LangKeys.Main_SubtitleNoData, "File SubTitle không có dữ liệu!" },
            { LangKeys.Main_SelectMediaFolder, "Chọn thư mục chứa media . Không Chọn file !" },
            { LangKeys.Main_FileFormatError, "Thư mục có {0} file không đúng định dạng!" },
            { LangKeys.Main_DataError, "Lỗi dữ liệu cũ, hãy xóa đi!\n" },
            { LangKeys.Main_ClipPlayerPathError, "ClipPlayer trả về đường dẫn không tồn tại:\n" },
            { LangKeys.Main_CancelledConvertRow, "Đã huỷ convert dòng." },
            { LangKeys.Main_ConvertTimeout, "Convert timeout - kiểm tra kết nối mạng." },
            { LangKeys.Main_NetworkErrorConvert, "Lỗi kết nối mạng khi convert." },
            { LangKeys.Main_CancelledDownloadRow, "Đã huỷ download audio dòng." },
            { LangKeys.Main_DownloadTimeout, "Download timeout - kiểm tra kết nối mạng." },
            { LangKeys.Main_NetworkErrorDownload, "Lỗi kết nối mạng khi download." },
            { LangKeys.Main_CancelledDownloadAll, "Đã huỷ tải toàn bộ audio." },
            { LangKeys.Main_CancelledDownloadSelected, "Đã huỷ tải những dòng audio đã chọn." },
            { LangKeys.Main_CancelledRenderPart, "Đã huỷ render video part {0}." },
            { LangKeys.Main_RenderError, "Lỗi khi render: {0}" },
            { LangKeys.Main_RenderAllDone, "Render xong tất cả đoạn video!" },
            { LangKeys.Main_CancelledRenderAll, "Đã huỷ render toàn bộ." },
            { LangKeys.Main_RenderSelectedDone, "Render xong các dòng đã chọn!" },
            { LangKeys.Main_CancelledRenderSelected, "Đã huỷ render nhóm chọn." },
            { LangKeys.Main_NoRowSelected, "Không có dòng nào được chọn!" },
            { LangKeys.Main_RenderingPart, "Đang Render Part {0}/{1} videos." },
            { LangKeys.Main_ErrorCheckMedia, "Lỗi, Kiểm Tra Hoặc Nhập lại Media " },
            { LangKeys.Main_DownloadingPart, "Download part thứ {0}/{1}" },
            { LangKeys.Main_MissingAudio, "Thiếu Audio , Render part Lỗi !" },
            { LangKeys.Main_MissingVideo, "Thiếu Video , Render part Lỗi !" },
            { LangKeys.Main_CannotDownloadAudio, "Không Tải được Audio !" },
            { LangKeys.Main_NoConvertLink, "Không Có Link Convert Speech !" },
            { LangKeys.Main_NoDownloadLink, "Không Có Link File Download !" },
            { LangKeys.Main_NoHistoryID, "Không Có HistoryID" },

            // ========== Main Form - Title Parts ==========
            { LangKeys.Main_DaysRemaining, "{0} ngày còn lại" },
            { LangKeys.Main_ExpiryToday, "Hết hạn hôm nay" },
            { LangKeys.Main_Expired, "Đã hết hạn" },
            { LangKeys.Main_Characters, "{0}/{1} ký tự" },
            { LangKeys.Main_Today, "Hôm nay: {0}/{1}" },

            // ========== Main Form - Project ==========
            { LangKeys.Main_EnterProjectPath, "Nhập Đường Dẫn & Khởi Tạo Project !" },
            { LangKeys.Main_CreateProjectSuccess, "Tạo Project Thành Công !" },
            { LangKeys.Main_CreateProjectFailed, "Không tạo được Project!" },
            { LangKeys.Main_SaveVoiceSourceSuccess, "Lưu Voice Source thành công!" },
            { LangKeys.Main_SaveSettingSuccess, "Lưu cấu hình thành công!" },

            // ========== Main Form - Merge Video ==========
            { LangKeys.Main_MergeNoVideo, "Không có video nào để ghép!" },
            { LangKeys.Main_MergeConfirm, "Bạn có muốn ghép {0} đoạn video?" },
            { LangKeys.Main_MergeConfirmTitle, "Xác nhận ghép video" },
            { LangKeys.Main_Merging, "Đang ghép video..." },
            { LangKeys.Main_MergeSuccess, "Ghép video thành công!" },
            { LangKeys.Main_MergeFailed, "Ghép video thất bại: {0}" },
            { LangKeys.Main_MergeCancelled, "Đã hủy ghép video." },

            // ========== FormLoadingCancel ==========
            { LangKeys.Loading_Cancelling, "Đang huỷ... vui lòng chờ" },

            // ========== VersionMessageHelper ==========
            { LangKeys.Version_Success, "Đăng nhập thành công!" },
            { LangKeys.Version_NoSubscription, "Tài khoản chưa kích hoạt gói dịch vụ hoặc gói đã hết hạn." },
            { LangKeys.Version_InvalidApiKey, "API Key không hợp lệ hoặc không tồn tại. Vui lòng kiểm tra lại." },
            { LangKeys.Version_UserInactive, "Tài khoản không hoạt động hoặc API đã bị tắt. Vui lòng liên hệ quản trị viên." },
            { LangKeys.Version_ProductNotFound, "Sản phẩm không tồn tại hoặc không hoạt động. Vui lòng kiểm tra lại." },
            { LangKeys.Version_DeviceNotFound, "Thiết bị không tồn tại cho sản phẩm này. Vui lòng đăng ký thiết bị hoặc kiểm tra lại mã ứng dụng." },
            { LangKeys.Version_InvalidRequest, "Yêu cầu không hợp lệ. Vui lòng kiểm tra lại." },
            { LangKeys.Version_InternalError, "Lỗi hệ thống, vui lòng thử lại sau." },
            { LangKeys.Version_UnknownError, "Đã xảy ra lỗi không xác định. Vui lòng thử lại sau." },

            // ========== GpuDetectionMessages ==========
            { LangKeys.Gpu_NotAvailable, "GPU NVIDIA không khả dụng!" },
            { LangKeys.Gpu_ErrorPrefix, "Lỗi: " },
            { LangKeys.Gpu_SwitchToCpu, "\n\nHệ thống sẽ chuyển về sử dụng CPU." },
            { LangKeys.Gpu_FfmpegNotFound, "Không tìm thấy FFmpeg.exe" },
            { LangKeys.Gpu_EncoderNotFound, "h264_nvenc không có trong danh sách encoders" },
            { LangKeys.Gpu_DriverNotSupport, "Driver NVIDIA không hỗ trợ phiên bản NVENC API yêu cầu" },
            { LangKeys.Gpu_ApiVersionMismatch, "Phiên bản NVENC API không tương thích" },
            { LangKeys.Gpu_DriverTooOld, "Driver NVIDIA quá cũ, cần cập nhật driver" },
            { LangKeys.Gpu_EncoderInitFailed, "Không thể khởi tạo encoder NVENC" },
            { LangKeys.Gpu_EncoderOpenFailed, "Không thể mở encoder NVENC" },
            { LangKeys.Gpu_EncodingFailed, "GPU encoding thất bại" },
            { LangKeys.Gpu_NoDeviceFound, "Không tìm thấy GPU hỗ trợ NVENC" },
            { LangKeys.Gpu_CannotLoadNvcuda, "Không load được nvcuda.dll" },
            { LangKeys.Gpu_CannotLoadNvencApi, "Không load được nvEncodeAPI" },
            { LangKeys.Gpu_FunctionNotImpl, "Chức năng không được hỗ trợ" },
            { LangKeys.Gpu_InvalidArgument, "Tham số không hợp lệ" },
            { LangKeys.Gpu_OutputStreamInit, "Lỗi khởi tạo output stream" },
            { LangKeys.Gpu_GuideFfmpeg, "FFmpeg chưa được cài đặt hoặc không tìm thấy.\nVui lòng tải và cài đặt FFmpeg." },
            { LangKeys.Gpu_GuideDriverOld, "Vui lòng cập nhật driver NVIDIA lên phiên bản mới nhất." },
            { LangKeys.Gpu_GuideNoDevice, "Không tìm thấy GPU NVIDIA hỗ trợ NVENC.\nCần card đồ họa NVIDIA GTX 600 series trở lên." },
            { LangKeys.Gpu_GuideGeneral, "Vui lòng kiểm tra:\n- Card đồ họa NVIDIA có hỗ trợ NVENC (GTX 600 series trở lên)\n- Driver NVIDIA đã được cài đặt và cập nhật\n- FFmpeg được build với hỗ trợ NVENC" },
            { LangKeys.Gpu_DetectTitle, "Đề xuất sử dụng GPU" },
            { LangKeys.Gpu_DetectMessage, "Phát hiện GPU NVIDIA hỗ trợ h264_nvenc!\n\nGPU rendering nhanh hơn CPU khoảng 5-10 lần.\n\nBạn có muốn sử dụng GPU để render không?" },
            { LangKeys.Gpu_ValidateFailedTitle, "GPU không hoạt động" },
            { LangKeys.Gpu_TestEncodingFailed, "GPU encoding test thất bại (exit code: {0})" },
            { LangKeys.Gpu_TestGpuError, "Lỗi test GPU: {0}" },
            { LangKeys.Gpu_UnknownError, "Lỗi không xác định: {0}" },

            // ========== Main Form - Cancel/Status ==========
            { LangKeys.Main_Cancelled, "Đã huỷ" },
            { LangKeys.Main_BatchAll, "Toàn bộ" },
            { LangKeys.Main_BatchSelected, "Dòng đã chọn" },

            // ========== Services - AudioConvertService ==========
            { LangKeys.Svc_ConvertAlreadyRunning, "Đang có tiến trình Convert Text2Speech khác đang chạy." },
            { LangKeys.Svc_ConvertError, "Lỗi chuyển đổi!" },
            { LangKeys.Svc_ConvertComplete, "Hoàn thành chuyển đổi ({0})" },
            { LangKeys.Svc_ConvertCancelled, "Đã huỷ Convert2Speech ({0})" },
            { LangKeys.Svc_NoContent, "Không có nội dung" },
            { LangKeys.Svc_ConvertingRow, "Đang chuyển đổi dòng {0}" },
            { LangKeys.Svc_ServerConnectionError, "Lỗi kết nối server!" },
            { LangKeys.Svc_UsageApiError, "Lỗi kết nối usage API: {0}" },
            { LangKeys.Svc_UnknownServerError, "Lỗi không xác định từ server" },
            { LangKeys.Svc_QuotaExceeded, "Hết quota ký tự!" },
            { LangKeys.Svc_CancelConvertRow, "Huỷ chuyển đổi dòng {0}" },
            { LangKeys.Svc_ConvertRowError, "Lỗi chuyển đổi dòng {0}: {1}" },

            // ========== Services - AudioDownloadService ==========
            { LangKeys.Svc_RecordSuccess, "Thu âm thành công! [AudioTime:{0}s]" },
            { LangKeys.Svc_DownloadSuccess, "Tải xuống thành công! [AudioTime:{0}s]" },
            { LangKeys.Svc_RecordFailed, "Thu âm thất bại!" },
            { LangKeys.Svc_DownloadFailed, "Tải xuống thất bại!" },
            { LangKeys.Svc_ConversionNotReady, "Chưa chuyển âm xong, thử lại sau!" },

            // ========== Services - AudioRecordService ==========
            { LangKeys.Svc_Recording, "Đang ghi âm..." },
            { LangKeys.Svc_RecordDone, "Đã ghi âm xong." },
            { LangKeys.Svc_RecordStartFailed, "Không bắt đầu được ghi âm." },
            { LangKeys.Svc_RecordError, "Lỗi ghi âm!" },
            { LangKeys.Svc_RecordCellError, "Lỗi ghi âm" },

            // ========== Services - VideoMergeService ==========
            { LangKeys.Svc_MergingProgress, "Đang ghép {0} video - Time: {1}{2}" },

            // ========== Services - ClipPlayerService ==========
            { LangKeys.Svc_ClipPlayerNotFound, "Không tìm thấy ClipPlayer.exe" },

            // ========== Services - LoadingService ==========
            { LangKeys.Svc_Processing, "Đang xử lý..." },

            // ========== Services - CustomTextBox ==========
            { LangKeys.Svc_TextPlaceholder, "Nhập text vào đây!" },

            // ========== LibCommon - APIGoogleTTS ==========
            { LangKeys.Lib_JsonDataEmpty, "JSON Data không được để trống." },
            { LangKeys.Lib_TextInputEmpty, "Nội dung chuyển đổi không được để trống." },
            { LangKeys.Lib_VoiceCodeEmpty, "Voice code không được để trống." },
            { LangKeys.Lib_SavePathEmpty, "Đường dẫn lưu file không được để trống." },
            { LangKeys.Lib_NoAudioData, "Không nhận được dữ liệu âm thanh từ API." },
            { LangKeys.Lib_ConvertDownloadSuccess, "Tải xuống thành công." },
            { LangKeys.Lib_ErrorFormat, "Lỗi: {0}" },

            // ========== LibCommon - Component (Effects) ==========
            { LangKeys.Lib_EffectZoomIn, "ZoomIn 4 góc" },
            { LangKeys.Lib_EffectZoomOut, "ZoomOut 4 góc" },
            { LangKeys.Lib_EffectMoveVertical, "Di chuyển dọc" },
            { LangKeys.Lib_EffectMoveHorizontal, "Di chuyển ngang" },
            { LangKeys.Lib_Zoom25Short, "25% - Lách Short" },
            { LangKeys.Lib_Zoom75Normal, "75% - Lách Normal" },

            // ========== LibCommon - EffectConfig ==========
            { LangKeys.Lib_ConfigDefault, "Mặc Định Tiêu Chuẩn" },
            { LangKeys.Lib_ConfigCustom, "Tùy Chỉnh" },

            // ========== LibCommon - PackageType ==========
            { LangKeys.Lib_PackageDisplayFormat, "{0} - {1} tháng" },

            // ========== Common - Additional ==========
            { LangKeys.Common_Success, "Thành Công" },
            { LangKeys.Common_Confirm, "Xác Nhận" },

            // ========== FormMain - Delete Row ==========
            { LangKeys.Main_SelectRowToDelete, "Vui lòng chọn một dòng để xóa." },
            { LangKeys.Main_CannotGetRowId, "Không lấy được ID dòng cần xóa." },
            { LangKeys.Main_OnlyDeleteLastRow, "Chỉ được xóa dòng cuối cùng." },
            { LangKeys.Main_DeleteRowError, "Lỗi khi xóa dòng: {0}" },

            // ========== FormMain - Text Validation ==========
            { LangKeys.Main_TextTooLong, "Nhập quá {0} ký tự!" },
            { LangKeys.Main_CharWordCount, "{0} 'Ký Tự' | {1} Chữ" },

            // ========== FormMain - Media/Audio ==========
            { LangKeys.Main_ImportMediaTitle, "Import Media" },
            { LangKeys.Main_InputMustBeAudio, "Nhập vào phải là File âm thanh !" },
            { LangKeys.Main_PictureError, "Lỗi Ảnh !" },
            { LangKeys.Main_VideoError, "Lỗi Video!" },

            // ========== FormMain - Button States ==========
            { LangKeys.Main_Stop, "Dừng" },
            { LangKeys.Main_MergeCancellingBtn, "Đang hủy..." },
            { LangKeys.Main_CancelMerge, "Hủy ghép" },
            { LangKeys.Main_MergeVideoBtn, "Ghép Video" },
            { LangKeys.Main_StopLoading, "Dừng Tải" },

            // ========== FormMain - Status ==========
            { LangKeys.Main_ConvertDone, "Chuyển đổi xong" },
            { LangKeys.Main_StatusError, "Lỗi!" },
            { LangKeys.Main_MergeDone, "Ghép xong" },
            { LangKeys.Main_MergeFailedStatus, "Ghép video thất bại!" },

            // ========== FormMain - Merge Video Messages ==========
            { LangKeys.Main_CheckingVideo, "Đang kiểm tra video {0}/{1}..." },
            { LangKeys.Main_MergingValidVideos, "Đang ghép {0} video hợp lệ..." },
            { LangKeys.Main_NoValidVideoToMerge, "Không có video hợp lệ để ghép!" },
            { LangKeys.Main_AllVideoCorrupt, "Tất cả video đều bị lỗi:\n\n" },
            { LangKeys.Main_MergeErrorTitle, "Lỗi - Không thể ghép video" },
            { LangKeys.Main_CorruptedVideoHeader, "⚠️ Phát hiện {0} video lỗi:\n\n" },
            { LangKeys.Main_CorruptedVideoMore, "\n... và {0} video khác" },
            { LangKeys.Main_ValidVideoCount, "\n\n✅ Video hợp lệ: {0}/{1}" },
            { LangKeys.Main_ContinueMergeQuestion, "\n\n❓ Bạn có muốn tiếp tục ghép {0} video hợp lệ không?" },
            { LangKeys.Main_MergeResultTitle, "Kết quả ghép video" },
            { LangKeys.Main_MergeReport, "✅ Ghép video hoàn tất!\n\n📊 Thống kê:\n- Tổng số video: {0}\n- Video hợp lệ: {1}\n- Video lỗi: {2}\n\n📁 Thư mục: {3}\n📹 Video: {4}" },
            { LangKeys.Main_MergeReportLog, "\n📝 Log: {0}" },
            { LangKeys.Main_MergeFfmpegError, "Lỗi khi ghép video!\n\nFFmpeg bị lỗi hoặc không thể chạy." },
            { LangKeys.Main_MergeFfmpegExitCode, "Lỗi khi ghép video!\n\nFFmpeg Exit Code: {0}" },

            // ========== FormMain - Check File ==========
            { LangKeys.Main_CheckFileRenamed, "Kiểm tra File đã đổi tên thành số chưa ?" },

            // ========== FormMain - Project Operations ==========
            { LangKeys.Main_ProjectNotFound, "Không Tìm thấy Project !" },
            { LangKeys.Main_ConfirmDeleteProject, "Bạn Xóa Project này ? \n Project : {0}" },
            { LangKeys.Main_ConfirmOpenProject, "Bạn muốn mở Project này ? \n Project : {0}" },
            { LangKeys.Main_ProjectInputEmpty, "Mục Nhập 'Project' không được trống !" },
            { LangKeys.Main_ProjectExists, "Project đã tồn tại. Vui lòng chọn tên khác hoặc kiểm tra danh sách!" },
            { LangKeys.Main_CriticalDataError, "Dữ liệu đang gặp lỗi, hệ thống sẽ tắt ứng dụng!" },
            { LangKeys.Main_CriticalErrorTitle, "Lỗi nghiêm trọng" },
            { LangKeys.Main_CreateProjectError, "Lỗi khi tạo project:\r\n{0}" },

            // ========== FormMain - Subtitle ==========
            { LangKeys.Main_SelectSubtitleFile, "Chọn File Subtitle để Split video !" },
            { LangKeys.Main_SubtitleTooLarge, "File Subtitle vượt quá 1MB!" },
            { LangKeys.Main_SubtitleCancelled, "Đã huỷ tải phụ đề." },
            { LangKeys.Main_ThreadError, "Lỗi luồng hoạt động." },
            { LangKeys.Main_SelectMediaFolderTitle, "Chọn thư mục media" },

            // ========== FormMain - API Errors ==========
            { LangKeys.Main_ElevenlabError, "Elevenlab bị lỗi !" },
            { LangKeys.Main_JsonDataError, "JsonData bị lỗi !" },
            { LangKeys.Main_ConnectionTimeout, "Kết nối bị timeout. Vui lòng kiểm tra mạng và thử lại." },
            { LangKeys.Main_SaveKeySuccess, "Lưu Key Thành Công!" },

            // ========== FormMain - Effect Settings ==========
            { LangKeys.Main_ConfirmChangeConfig, "Bạn muốn thay đổi cấu hình tùy chỉnh?\nChọn 'Có' để lưu, 'Không' để hủy." },
            { LangKeys.Main_SaveEffectSuccess, "Lưu Cấu Hình Hiệu Ứng Thành Công!" },
            { LangKeys.Main_SaveEffectError, "Lỗi khi lưu cấu hình! Vui lòng thử lại." },

            // ========== FormMain - Reload Confirm ==========
            { LangKeys.Main_ConfirmReloadAll, "Bạn có chắc chắn muốn reload toàn bộ dữ liệu?" },
            { LangKeys.Main_ConfirmReloadSelected, "Bạn có chắc chắn muốn reload nhiều dòng đã chọn?" },

            // ========== FormMain - Convert Video Status ==========
            { LangKeys.Main_ProcessingVideo, "Đang xử lý {0}/{1} videos." },
            { LangKeys.Main_ProcessingComplete, "Xử lý hoàn tất {0}/{1} videos." },

            // ========== FormMain - Cancel All Tasks ==========
            { LangKeys.Main_TaskReloadSelected, "Reload Media: Dòng Được chọn." },
            { LangKeys.Main_TaskReloadAll, "Reload Media: Toàn bộ Danh sách." },
            { LangKeys.Main_TaskConvertAll, "Convert Text2Speech: Toàn bộ Danh sách." },
            { LangKeys.Main_TaskConvertSelected, "Convert Text2Speech: Dòng Được chọn." },
            { LangKeys.Main_TaskConvertSingle, "Convert Text2Speech: Dòng hiện tại." },
            { LangKeys.Main_TaskDownloadAll, "Download Audio: Toàn bộ Danh sách." },
            { LangKeys.Main_TaskDownloadSelected, "Download Audio: Dòng Được chọn." },
            { LangKeys.Main_TaskDownloadSingle, "Download Audio: Dòng hiện tại." },
            { LangKeys.Main_TaskRecord, "Record Audio: Dòng hiện tại." },
            { LangKeys.Main_TaskRenderAll, "Render Part Video: Toàn bộ Danh sách." },
            { LangKeys.Main_TaskRenderSelected, "Render Part Video: Dòng Được chọn." },
            { LangKeys.Main_TaskRenderRow, "Render Part Video: Dòng {0}." },
            { LangKeys.Main_NoRunningProcesses, "Không có tiến trình nào đang chạy!" },
            { LangKeys.Main_CancelAllConfirm, "Các tiến trình sau đang chạy:\n- {0}\n\nBạn có muốn huỷ tất cả không?" },
            { LangKeys.Main_CancelAllTitle, "Xác nhận huỷ tiến trình" },
        };
    }
}
