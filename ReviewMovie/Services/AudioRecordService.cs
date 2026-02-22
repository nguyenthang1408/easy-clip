using Lib;
using ReviewMovie.Localization;
using ReviewMovie.Model;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyClip.Services
{
    public interface IAudioRecordService
    {
        bool IsRecording { get; }
        void StartRecord(AudioRecordContextModel context, CancellationToken token);
        void StopRecord();
    }
    public class AudioRecordService : IAudioRecordService
    {
        private Thread _recordThread;
        private volatile bool _isRecording;
        private bool _checkrecord;
        private CancellationTokenSource _cts;
        private AudioRecordContextModel _currentContext;

        public bool IsRecording => _isRecording;

        public void StartRecord(AudioRecordContextModel context, CancellationToken token)
        {
            if (_isRecording) return;
            _isRecording = true;
            _cts = CancellationTokenSource.CreateLinkedTokenSource(token);
            _currentContext = context;

            _recordThread = new Thread(() => RecordWorker(context, _cts.Token));
            _recordThread.IsBackground = true;
            _recordThread.Start();

            // Báo UI: bắt đầu record
            context.UpdateRowCallback?.Invoke(context.RowIndex, "", LanguageManager.Get(LangKeys.Svc_StartRecording));
            context.SetStatusCallback?.Invoke(LanguageManager.Get(LangKeys.Svc_Recording), Color.Yellow);
        }

        public void StopRecord()
        {
            _cts?.Cancel();
        }

        private void RecordWorker(AudioRecordContextModel context, CancellationToken token)
        {
            string status = "";
            string fullpath = $"{context.AudioTempPath}{context.RowIndex}.mp3";
            try
            {
                _checkrecord = RecordAudio.StartRecord();
                if (!_checkrecord)
                {
                    status = LanguageManager.Get(LangKeys.Svc_RecordCellError);
                    context.UpdateRowCallback?.Invoke(context.RowIndex, "", status);
                    context.SetStatusCallback?.Invoke(LanguageManager.Get(LangKeys.Svc_RecordStartFailed), Color.Red);
                    context.OnAfterRecord?.Invoke(context.RowIndex, "", status);
                    return;
                }

                // Wait đến khi bấm stop/cancel
                while (!token.IsCancellationRequested)
                    Thread.Sleep(100);

                RecordAudio.EndRecord(fullpath);
                _checkrecord = false;
                status = LanguageManager.Get(LangKeys.Svc_EndRecord);
                context.UpdateRowCallback?.Invoke(context.RowIndex, fullpath, status);
                context.SetStatusCallback?.Invoke(LanguageManager.Get(LangKeys.Svc_RecordDone), Color.Green);
                context.OnAfterRecord?.Invoke(context.RowIndex, fullpath, status);

            }
            catch
            {
                RecordAudio.DestroyRecord();
                status = LanguageManager.Get(LangKeys.Svc_RecordCellError);
                context.UpdateRowCallback?.Invoke(context.RowIndex, "", status);
                context.SetStatusCallback?.Invoke(LanguageManager.Get(LangKeys.Svc_RecordError), Color.Red);
                context.OnAfterRecord?.Invoke(context.RowIndex, "", status);
            }
            finally
            {
                _isRecording = false;
                _cts?.Dispose();
                _cts = null;
            }
        }
    }

}
