using System.Collections.Generic;

namespace ReviewMovie.Localization.Resources
{
    public static class Lang_en
    {
        public static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            // ========== Common ==========
            { LangKeys.Common_Notice, "Notice" },
            { LangKeys.Common_Error, "Error" },
            { LangKeys.Common_Warning, "Warning" },
            { LangKeys.Common_Save, "Save" },
            { LangKeys.Common_Cancel, "Cancel" },
            { LangKeys.Common_SelectAll, "Select All" },
            { LangKeys.Common_SelectGroup, "Select Group" },
            { LangKeys.Common_CancelSelectAll, "Cancel All" },
            { LangKeys.Common_CancelSelectGroup, "Cancel Group" },

            // ========== Program.cs ==========
            { LangKeys.Program_AlreadyRunning, "Application is already running. Do you want to open another instance?" },

            // ========== Login Form ==========
            { LangKeys.Login_Title, "REVIEW_MOVIE LOGIN" },
            { LangKeys.Login_AppCode, "APP CODE" },
            { LangKeys.Login_ApiKey, "API KEY" },
            { LangKeys.Login_BtnLogin, "LOGIN" },
            { LangKeys.Login_Help, "Help" },
            { LangKeys.Login_Register, "Register" },
            { LangKeys.Login_EnterApiKey, "Please enter API Key!" },
            { LangKeys.Login_Success, "Login successful!" },
            { LangKeys.Login_CannotGetKey, "Cannot get T2PKey: " },
            { LangKeys.Login_VersionUpdate, "You are using version {0}. The latest version is {1}. Do you want to update?" },
            { LangKeys.Login_VersionUpdateTitle, "Version Update" },
            { LangKeys.Login_ConnectionFailed, "Connection failed. API needs to be activated!" },
            { LangKeys.Login_SelectLanguage, "Language" },

            // ========== Main Form - Settings ==========
            { LangKeys.Main_Settings, "Settings " },
            { LangKeys.Main_Project, "Project" },
            { LangKeys.Main_Create, "Create" },
            { LangKeys.Main_VoiceSettings, "Voice Settings" },
            { LangKeys.Main_VoiceSource, "Voice Source" },

            // ========== Main Form - Effect Settings ==========
            { LangKeys.Main_EffectSettings, "Effect Settings" },
            { LangKeys.Main_ZoomUp, "% ZoomUp :" },
            { LangKeys.Main_ZQuality, "% ZQuality :" },
            { LangKeys.Main_Quality, "Quality :" },
            { LangKeys.Main_VoiceType, "Voice :" },
            { LangKeys.Main_SpeechSpeed, "Voice Speed :" },
            { LangKeys.Main_FpsInput, "FPS (Input) :" },
            { LangKeys.Main_Thread, "Thread :" },
            { LangKeys.Main_SelectionMode, "Mode :" },
            { LangKeys.Main_EffectType, "Effect :" },
            { LangKeys.Main_ZoomVideo, "Zoom video" },
            { LangKeys.Main_RotateVideo, "Rotate video" },
            { LangKeys.Main_FlipVideo, "Flip video" },
            { LangKeys.Main_FlipRandom, "Random flip" },
            { LangKeys.Main_LayerAutoMove, "Auto layer move Left <-> Right" },
            { LangKeys.Main_AudioScale, "Audio Speed :" },
            { LangKeys.Main_OriginalVolume, "Org. volume :" },
            { LangKeys.Main_NoAudio, "No audio" },
            { LangKeys.Main_Language, "Language :" },
            { LangKeys.Main_Config, "Config :" },
            { LangKeys.Main_AutoOpenPlayer, "Auto open Player" },

            // ========== Main Form - Render ==========
            { LangKeys.Main_PublishVideo, "Publish Video" },
            { LangKeys.Main_MergeClips, "MERGE CLIPS" },

            // ========== Main Form - Action Buttons ==========
            { LangKeys.Main_Record, "Record" },
            { LangKeys.Main_ConvertAudio, "Convert Audio" },
            { LangKeys.Main_SaveAudio, "Save Audio" },
            { LangKeys.Main_RenderPart, "Render Part" },
            { LangKeys.Main_UseCPU, "Use CPU" },
            { LangKeys.Main_UseGPU, "Use GPU" },

            // ========== Main Form - Content Header ==========
            { LangKeys.Main_MicIn, "Mic In" },
            { LangKeys.Main_DragDropMedia, "Drag & Drop (Image, Video)" },
            { LangKeys.Main_InputTextHeader, "Enter Text | Or Drag Audio File Here!" },

            // ========== Main Form - Toolbar ==========
            { LangKeys.Main_SelectTask, "Select Task" },
            { LangKeys.Main_SelectDeselectAll, "Select/Deselect all" },
            { LangKeys.Main_AddNewRow, "Add New Row" },
            { LangKeys.Main_ImportSubtitle, "Import Subtitle (Auto)" },
            { LangKeys.Main_CancelAllOps, "&Cancel All Operations" },
            { LangKeys.Main_SearchTooltip, "Enter search text here" },

            // ========== Main Form - Context Menu ==========
            { LangKeys.Main_ConvertText2Voice, "Convert Text -> Voice" },
            { LangKeys.Main_DownloadConvertedAudio, "Download Converted Audio" },
            { LangKeys.Main_CreateVideoFromMedia, "Create Video From Media, Audio" },
            { LangKeys.Main_ReloadVideoTime, "Reload Input Video Time" },
            { LangKeys.Main_DeleteSelectedRows, "Delete Selected Rows" },

            // ========== Main Form - Dynamic Messages ==========
            { LangKeys.Main_ErrProjectEmpty, "Enter path & initialize Project!" },
            { LangKeys.Main_ErrRowIndex, "Select a row to load information!" },
            { LangKeys.Main_InvalidServerData, "Invalid data from server. Please contact support." },
            { LangKeys.Main_InvalidServerDataTitle, "Data Error" },
            { LangKeys.Main_AuthFailed, "Authentication failed. Please login again." },
            { LangKeys.Main_AuthFailedTitle, "Authentication Error" },
            { LangKeys.Main_ConnectionError, "Cannot connect to server. Please check network connection and try again." },
            { LangKeys.Main_ConnectionErrorTitle, "Connection Error" },
            { LangKeys.Main_VoiceSourceError, "Voice source error. Please restart the app!" },
            { LangKeys.Main_VoiceSourceErrorTitle, "Connection Error" },
            { LangKeys.Main_CannotLoadVoiceSource, "Cannot load voice source info from server." },
            { LangKeys.Main_DailyLimitExceeded, "Daily character limit reached ({0}/{1}). Please try again tomorrow." },
            { LangKeys.Main_TotalLimitExceeded, "Package character limit reached ({0}/{1}). Please upgrade your package." },
            { LangKeys.Main_TotalChars, "Total chars: {0}/{1}" },
            { LangKeys.Main_TodayChars, "Today: {0}/{1}" },
            { LangKeys.Main_Unlimited, "Unlimited" },
            { LangKeys.Main_VoiceKeyError, "VoiceKey from T2Psoft is invalid!" },
            { LangKeys.Main_CannotLoadVoices, "Cannot load voice list. Check network connection and try again." },
            { LangKeys.Main_CannotLoadVoicesTitle, "Connection Error" },
            { LangKeys.Main_T2PsoftVoiceError, "Error processing T2Psoft voice source: {0}" },
            { LangKeys.Main_UpdateTimeVideoDone, "Video time update complete!" },
            { LangKeys.Main_ReloadingSubtitle, "Reloading Line {0}/{1} Subtitle." },
            { LangKeys.Main_SubtitleFormatError, "Subtitle file has invalid format!" },
            { LangKeys.Main_SubtitleNoData, "Subtitle file has no data!" },
            { LangKeys.Main_SelectMediaFolder, "Select folder containing media. Do not select file!" },
            { LangKeys.Main_FileFormatError, "Folder has {0} files with invalid format!" },
            { LangKeys.Main_DataError, "Old data error, please delete!\n" },
            { LangKeys.Main_ClipPlayerPathError, "ClipPlayer returned non-existent path:\n" },
            { LangKeys.Main_CancelledConvertRow, "Row conversion cancelled." },
            { LangKeys.Main_ConvertTimeout, "Convert timeout - check network connection." },
            { LangKeys.Main_NetworkErrorConvert, "Network error during conversion." },
            { LangKeys.Main_CancelledDownloadRow, "Row audio download cancelled." },
            { LangKeys.Main_DownloadTimeout, "Download timeout - check network connection." },
            { LangKeys.Main_NetworkErrorDownload, "Network error during download." },
            { LangKeys.Main_CancelledDownloadAll, "All audio downloads cancelled." },
            { LangKeys.Main_CancelledDownloadSelected, "Selected audio downloads cancelled." },
            { LangKeys.Main_CancelledRenderPart, "Video part {0} render cancelled." },
            { LangKeys.Main_RenderError, "Render error: {0}" },
            { LangKeys.Main_RenderAllDone, "All video parts rendered!" },
            { LangKeys.Main_CancelledRenderAll, "All rendering cancelled." },
            { LangKeys.Main_RenderSelectedDone, "Selected rows rendered!" },
            { LangKeys.Main_CancelledRenderSelected, "Selected group rendering cancelled." },
            { LangKeys.Main_NoRowSelected, "No rows selected!" },
            { LangKeys.Main_RenderingPart, "Rendering Part {0}/{1} videos." },
            { LangKeys.Main_ErrorCheckMedia, "Error, check or re-import media" },
            { LangKeys.Main_DownloadingPart, "Downloading part {0}/{1}" },
            { LangKeys.Main_MissingAudio, "Missing Audio, render part failed!" },
            { LangKeys.Main_MissingVideo, "Missing Video, render part failed!" },
            { LangKeys.Main_CannotDownloadAudio, "Cannot download audio!" },
            { LangKeys.Main_NoConvertLink, "No Convert Speech link!" },
            { LangKeys.Main_NoDownloadLink, "No Download File link!" },
            { LangKeys.Main_NoHistoryID, "No HistoryID" },

            // ========== Main Form - Title Parts ==========
            { LangKeys.Main_DaysRemaining, "{0} days remaining" },
            { LangKeys.Main_ExpiryToday, "Expires today" },
            { LangKeys.Main_Expired, "Expired" },
            { LangKeys.Main_Characters, "{0}/{1} chars" },
            { LangKeys.Main_Today, "Today: {0}/{1}" },

            // ========== Main Form - Project ==========
            { LangKeys.Main_EnterProjectPath, "Enter path & initialize Project!" },
            { LangKeys.Main_CreateProjectSuccess, "Project created successfully!" },
            { LangKeys.Main_CreateProjectFailed, "Cannot create project!" },
            { LangKeys.Main_SaveVoiceSourceSuccess, "Voice source saved successfully!" },
            { LangKeys.Main_SaveSettingSuccess, "Settings saved successfully!" },

            // ========== Main Form - Merge Video ==========
            { LangKeys.Main_MergeNoVideo, "No video to merge!" },
            { LangKeys.Main_MergeConfirm, "Do you want to merge {0} video clips?" },
            { LangKeys.Main_MergeConfirmTitle, "Confirm video merge" },
            { LangKeys.Main_Merging, "Merging video..." },
            { LangKeys.Main_MergeSuccess, "Video merged successfully!" },
            { LangKeys.Main_MergeFailed, "Video merge failed: {0}" },
            { LangKeys.Main_MergeCancelled, "Video merge cancelled." },

            // ========== FormLoadingCancel ==========
            { LangKeys.Loading_Cancelling, "Cancelling... please wait" },

            // ========== VersionMessageHelper ==========
            { LangKeys.Version_Success, "Login successful!" },
            { LangKeys.Version_NoSubscription, "Account has no active subscription or subscription has expired." },
            { LangKeys.Version_InvalidApiKey, "Invalid or non-existent API Key. Please check again." },
            { LangKeys.Version_UserInactive, "Account is inactive or API has been disabled. Please contact administrator." },
            { LangKeys.Version_ProductNotFound, "Product does not exist or is inactive. Please check again." },
            { LangKeys.Version_DeviceNotFound, "Device does not exist for this product. Please register device or check application code." },
            { LangKeys.Version_InvalidRequest, "Invalid request. Please check again." },
            { LangKeys.Version_InternalError, "System error, please try again later." },
            { LangKeys.Version_UnknownError, "An unknown error occurred. Please try again later." },

            // ========== GpuDetectionMessages ==========
            { LangKeys.Gpu_NotAvailable, "NVIDIA GPU is not available!" },
            { LangKeys.Gpu_ErrorPrefix, "Error: " },
            { LangKeys.Gpu_SwitchToCpu, "\n\nSystem will switch to CPU." },
            { LangKeys.Gpu_FfmpegNotFound, "FFmpeg.exe not found" },
            { LangKeys.Gpu_EncoderNotFound, "h264_nvenc not found in encoder list" },
            { LangKeys.Gpu_DriverNotSupport, "NVIDIA driver does not support required NVENC API version" },
            { LangKeys.Gpu_ApiVersionMismatch, "NVENC API version incompatible" },
            { LangKeys.Gpu_DriverTooOld, "NVIDIA driver too old, please update driver" },
            { LangKeys.Gpu_EncoderInitFailed, "Cannot initialize NVENC encoder" },
            { LangKeys.Gpu_EncoderOpenFailed, "Cannot open NVENC encoder" },
            { LangKeys.Gpu_EncodingFailed, "GPU encoding failed" },
            { LangKeys.Gpu_NoDeviceFound, "No GPU with NVENC support found" },
            { LangKeys.Gpu_CannotLoadNvcuda, "Cannot load nvcuda.dll" },
            { LangKeys.Gpu_CannotLoadNvencApi, "Cannot load nvEncodeAPI" },
            { LangKeys.Gpu_FunctionNotImpl, "Function not supported" },
            { LangKeys.Gpu_InvalidArgument, "Invalid argument" },
            { LangKeys.Gpu_OutputStreamInit, "Error initializing output stream" },
            { LangKeys.Gpu_GuideFfmpeg, "FFmpeg is not installed or not found.\nPlease download and install FFmpeg." },
            { LangKeys.Gpu_GuideDriverOld, "Please update NVIDIA driver to the latest version." },
            { LangKeys.Gpu_GuideNoDevice, "No NVIDIA GPU with NVENC support found.\nRequires NVIDIA GTX 600 series or higher." },
            { LangKeys.Gpu_GuideGeneral, "Please check:\n- NVIDIA GPU supports NVENC (GTX 600 series or higher)\n- NVIDIA driver is installed and updated\n- FFmpeg is built with NVENC support" },
            { LangKeys.Gpu_DetectTitle, "GPU Usage Suggestion" },
            { LangKeys.Gpu_DetectMessage, "NVIDIA GPU with h264_nvenc support detected!\n\nGPU rendering is about 5-10x faster than CPU.\n\nDo you want to use GPU for rendering?" },
            { LangKeys.Gpu_ValidateFailedTitle, "GPU Not Working" },
            { LangKeys.Gpu_TestEncodingFailed, "GPU encoding test failed (exit code: {0})" },
            { LangKeys.Gpu_TestGpuError, "GPU test error: {0}" },
            { LangKeys.Gpu_UnknownError, "Unknown error: {0}" },

            // ========== Main Form - Cancel/Status ==========
            { LangKeys.Main_Cancelled, "Cancelled" },
            { LangKeys.Main_BatchAll, "All" },
            { LangKeys.Main_BatchSelected, "Selected rows" },

            // ========== Services - AudioConvertService ==========
            { LangKeys.Svc_ConvertAlreadyRunning, "Another Text2Speech conversion is already running." },
            { LangKeys.Svc_ConvertError, "Conversion error!" },
            { LangKeys.Svc_ConvertComplete, "Conversion complete ({0})" },
            { LangKeys.Svc_ConvertCancelled, "Convert2Speech cancelled ({0})" },
            { LangKeys.Svc_NoContent, "No content" },
            { LangKeys.Svc_ConvertingRow, "Converting row {0}" },
            { LangKeys.Svc_ServerConnectionError, "Server connection error!" },
            { LangKeys.Svc_UsageApiError, "Usage API connection error: {0}" },
            { LangKeys.Svc_UnknownServerError, "Unknown error from server" },
            { LangKeys.Svc_QuotaExceeded, "Character quota exceeded!" },
            { LangKeys.Svc_CancelConvertRow, "Row {0} conversion cancelled" },
            { LangKeys.Svc_ConvertRowError, "Row {0} conversion error: {1}" },

            // ========== Services - AudioDownloadService ==========
            { LangKeys.Svc_RecordSuccess, "Recording successful! [AudioTime:{0}s]" },
            { LangKeys.Svc_DownloadSuccess, "Download successful! [AudioTime:{0}s]" },
            { LangKeys.Svc_RecordFailed, "Recording failed!" },
            { LangKeys.Svc_DownloadFailed, "Download failed!" },
            { LangKeys.Svc_ConversionNotReady, "Conversion not ready, try again later!" },

            // ========== Services - AudioRecordService ==========
            { LangKeys.Svc_Recording, "Recording..." },
            { LangKeys.Svc_RecordDone, "Recording complete." },
            { LangKeys.Svc_RecordStartFailed, "Cannot start recording." },
            { LangKeys.Svc_RecordError, "Recording error!" },
            { LangKeys.Svc_RecordCellError, "Record error" },

            // ========== Services - VideoMergeService ==========
            { LangKeys.Svc_MergingProgress, "Merging {0} videos - Time: {1}{2}" },

            // ========== Services - ClipPlayerService ==========
            { LangKeys.Svc_ClipPlayerNotFound, "ClipPlayer.exe not found" },

            // ========== Services - LoadingService ==========
            { LangKeys.Svc_Processing, "Processing..." },

            // ========== Services - CustomTextBox ==========
            { LangKeys.Svc_TextPlaceholder, "Enter text here!" },

            // ========== LibCommon - APIGoogleTTS ==========
            { LangKeys.Lib_JsonDataEmpty, "JSON Data cannot be empty." },
            { LangKeys.Lib_TextInputEmpty, "Text content cannot be empty." },
            { LangKeys.Lib_VoiceCodeEmpty, "Voice code cannot be empty." },
            { LangKeys.Lib_SavePathEmpty, "File save path cannot be empty." },
            { LangKeys.Lib_NoAudioData, "No audio data received from API." },
            { LangKeys.Lib_ConvertDownloadSuccess, "Download successful." },
            { LangKeys.Lib_ErrorFormat, "Error: {0}" },

            // ========== LibCommon - Component (Effects) ==========
            { LangKeys.Lib_EffectZoomIn, "ZoomIn 4 corners" },
            { LangKeys.Lib_EffectZoomOut, "ZoomOut 4 corners" },
            { LangKeys.Lib_EffectMoveVertical, "Move vertically" },
            { LangKeys.Lib_EffectMoveHorizontal, "Move horizontally" },
            { LangKeys.Lib_Zoom25Short, "25% - Short bypass" },
            { LangKeys.Lib_Zoom75Normal, "75% - Normal bypass" },

            // ========== LibCommon - EffectConfig ==========
            { LangKeys.Lib_ConfigDefault, "Standard Default" },
            { LangKeys.Lib_ConfigCustom, "Custom" },

            // ========== LibCommon - PackageType ==========
            { LangKeys.Lib_PackageDisplayFormat, "{0} - {1} months" },

            // ========== Common - Additional ==========
            { LangKeys.Common_Success, "Success" },
            { LangKeys.Common_Confirm, "Confirm" },

            // ========== FormMain - Delete Row ==========
            { LangKeys.Main_SelectRowToDelete, "Please select a row to delete." },
            { LangKeys.Main_CannotGetRowId, "Cannot get the ID of the row to delete." },
            { LangKeys.Main_OnlyDeleteLastRow, "Can only delete the last row." },
            { LangKeys.Main_DeleteRowError, "Error deleting row: {0}" },

            // ========== FormMain - Text Validation ==========
            { LangKeys.Main_TextTooLong, "Text too long! Max {0} chars." },
            { LangKeys.Main_CharWordCount, "{0} Chars | {1} Words" },

            // ========== FormMain - Media/Audio ==========
            { LangKeys.Main_ImportMediaTitle, "Import Media" },
            { LangKeys.Main_InputMustBeAudio, "Input must be an audio file!" },
            { LangKeys.Main_PictureError, "Picture Error!" },
            { LangKeys.Main_VideoError, "Video Error!" },

            // ========== FormMain - Button States ==========
            { LangKeys.Main_Stop, "Stop" },
            { LangKeys.Main_MergeCancellingBtn, "Cancelling..." },
            { LangKeys.Main_CancelMerge, "Cancel merge" },
            { LangKeys.Main_MergeVideoBtn, "Merge Video" },
            { LangKeys.Main_StopLoading, "Stop Loading" },

            // ========== FormMain - Status ==========
            { LangKeys.Main_ConvertDone, "Convert Done" },
            { LangKeys.Main_StatusError, "Error!" },
            { LangKeys.Main_MergeDone, "Merge Done" },
            { LangKeys.Main_MergeFailedStatus, "Video merge failed!" },

            // ========== FormMain - Merge Video Messages ==========
            { LangKeys.Main_CheckingVideo, "Checking video {0}/{1}..." },
            { LangKeys.Main_MergingValidVideos, "Merging {0} valid videos..." },
            { LangKeys.Main_NoValidVideoToMerge, "No valid video to merge!" },
            { LangKeys.Main_AllVideoCorrupt, "All videos are corrupted:\n\n" },
            { LangKeys.Main_MergeErrorTitle, "Error - Cannot merge video" },
            { LangKeys.Main_CorruptedVideoHeader, "⚠️ Found {0} corrupted videos:\n\n" },
            { LangKeys.Main_CorruptedVideoMore, "\n... and {0} more videos" },
            { LangKeys.Main_ValidVideoCount, "\n\n✅ Valid videos: {0}/{1}" },
            { LangKeys.Main_ContinueMergeQuestion, "\n\n❓ Do you want to continue merging {0} valid videos?" },
            { LangKeys.Main_MergeResultTitle, "Merge video result" },
            { LangKeys.Main_MergeReport, "✅ Video merge complete!\n\n📊 Statistics:\n- Total videos: {0}\n- Valid videos: {1}\n- Corrupted videos: {2}\n\n📁 Folder: {3}\n📹 Video: {4}" },
            { LangKeys.Main_MergeReportLog, "\n📝 Log: {0}" },
            { LangKeys.Main_MergeFfmpegError, "Error merging video!\n\nFFmpeg error or cannot run." },
            { LangKeys.Main_MergeFfmpegExitCode, "Error merging video!\n\nFFmpeg Exit Code: {0}" },

            // ========== FormMain - Check File ==========
            { LangKeys.Main_CheckFileRenamed, "Check if files have been renamed to numbers?" },

            // ========== FormMain - Project Operations ==========
            { LangKeys.Main_ProjectNotFound, "Project not found!" },
            { LangKeys.Main_ConfirmDeleteProject, "Delete this project? \n Project: {0}" },
            { LangKeys.Main_ConfirmOpenProject, "Open this project? \n Project: {0}" },
            { LangKeys.Main_ProjectInputEmpty, "Project name cannot be empty!" },
            { LangKeys.Main_ProjectExists, "Project already exists. Please choose another name or check the list!" },
            { LangKeys.Main_CriticalDataError, "Data error, the system will close the application!" },
            { LangKeys.Main_CriticalErrorTitle, "Critical Error" },
            { LangKeys.Main_CreateProjectError, "Error creating project:\r\n{0}" },

            // ========== FormMain - Subtitle ==========
            { LangKeys.Main_SelectSubtitleFile, "Select Subtitle file to split video!" },
            { LangKeys.Main_SubtitleTooLarge, "Subtitle file exceeds 1MB!" },
            { LangKeys.Main_SubtitleCancelled, "Subtitle loading cancelled." },
            { LangKeys.Main_ThreadError, "Thread operation error." },
            { LangKeys.Main_SelectMediaFolderTitle, "Select media folder" },

            // ========== FormMain - API Errors ==========
            { LangKeys.Main_ElevenlabError, "Elevenlab error!" },
            { LangKeys.Main_JsonDataError, "JsonData error!" },
            { LangKeys.Main_ConnectionTimeout, "Connection timeout. Please check network and try again." },
            { LangKeys.Main_SaveKeySuccess, "Key saved successfully!" },

            // ========== FormMain - Effect Settings ==========
            { LangKeys.Main_ConfirmChangeConfig, "Do you want to change custom configuration?\nSelect 'Yes' to save, 'No' to cancel." },
            { LangKeys.Main_SaveEffectSuccess, "Effect settings saved successfully!" },
            { LangKeys.Main_SaveEffectError, "Error saving settings! Please try again." },

            // ========== FormMain - Reload Confirm ==========
            { LangKeys.Main_ConfirmReloadAll, "Are you sure you want to reload all data?" },
            { LangKeys.Main_ConfirmReloadSelected, "Are you sure you want to reload selected rows?" },

            // ========== FormMain - Convert Video Status ==========
            { LangKeys.Main_ProcessingVideo, "Processing {0}/{1} videos." },
            { LangKeys.Main_ProcessingComplete, "Processing complete {0}/{1} videos." },

            // ========== FormMain - Cancel All Tasks ==========
            { LangKeys.Main_TaskReloadSelected, "Reload Media: Selected rows." },
            { LangKeys.Main_TaskReloadAll, "Reload Media: All rows." },
            { LangKeys.Main_TaskConvertAll, "Convert Text2Speech: All rows." },
            { LangKeys.Main_TaskConvertSelected, "Convert Text2Speech: Selected rows." },
            { LangKeys.Main_TaskConvertSingle, "Convert Text2Speech: Current row." },
            { LangKeys.Main_TaskDownloadAll, "Download Audio: All rows." },
            { LangKeys.Main_TaskDownloadSelected, "Download Audio: Selected rows." },
            { LangKeys.Main_TaskDownloadSingle, "Download Audio: Current row." },
            { LangKeys.Main_TaskRecord, "Record Audio: Current row." },
            { LangKeys.Main_TaskRenderAll, "Render Part Video: All rows." },
            { LangKeys.Main_TaskRenderSelected, "Render Part Video: Selected rows." },
            { LangKeys.Main_TaskRenderRow, "Render Part Video: Row {0}." },
            { LangKeys.Main_NoRunningProcesses, "No running processes!" },
            { LangKeys.Main_CancelAllConfirm, "The following processes are running:\n- {0}\n\nDo you want to cancel all?" },
            { LangKeys.Main_CancelAllTitle, "Confirm cancel processes" },

            // ========== FormMain - Loading Popup ==========
            { LangKeys.Main_CancellingProcesses, "Cancelling processes!" },
            { LangKeys.Main_LoadingVoice, "Loading Voice..." },

            // ========== FormMain - Render Video Status ==========
            { LangKeys.Main_RenderInputError, "Input Error" },
            { LangKeys.Main_RenderVideoMissing, "Video Missing" },
            { LangKeys.Main_RenderAudioMissing, "Audio Missing" },
            { LangKeys.Main_RenderServerError, "Server Error !" },
            { LangKeys.Main_RenderProgress, "Render part {0} - Speed: {1}" },
            { LangKeys.Main_RenderDone, "Done" },
            { LangKeys.Main_RenderFail, "Fail" },
            { LangKeys.Main_RenderPartCompleted, "Part {0} render completed!" },
            { LangKeys.Main_RenderPartFailed, "Part {0} render failed!" },
            { LangKeys.Main_RenderSettingFail, "Setting Fail !" },
            { LangKeys.Main_StartDownload, "Downloading ..." },
        };
    }
}
