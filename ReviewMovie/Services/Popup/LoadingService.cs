using EasyClip.Services.Popup;
using System;
using System.Threading;
using System.Windows.Forms;

namespace EasyClip.Services
{
    public class LoadingService : IDisposable
    {
        private readonly Func<ILoadingDialog> _dialogFactory;
        private ILoadingDialog _dialog;
        private System.Threading.Timer _timeoutTimer;
        private bool _isTimeout;
        private Action _onTimeout;

        public bool IsTimeout => _isTimeout;

        public LoadingService(Func<ILoadingDialog> dialogFactory)
        {
            _dialogFactory = dialogFactory ?? throw new ArgumentNullException(nameof(dialogFactory));
        }

        /// <summary>
        /// Hiện popup loading (modeless). Không khóa mainform.
        /// </summary>
        public void Show(string statusText = "Đang xử lý...", int timeoutMilliseconds = 0, Action onTimeout = null)
        {
            if (_dialog != null) return; // Đã mở, bỏ qua

            _isTimeout = false;
            _onTimeout = onTimeout;
            _dialog = _dialogFactory();
            _dialog.Show(statusText);

            if (timeoutMilliseconds > 0)
            {
                _timeoutTimer = new System.Threading.Timer(_ =>
                {
                    _isTimeout = true;
                    Close();
                    _onTimeout?.Invoke();
                }, null, timeoutMilliseconds, Timeout.Infinite);
            }
        }

        public void UpdateStatus(string status)
        {
            _dialog?.UpdateStatus(status);
        }

        public void Close()
        {
            _timeoutTimer?.Dispose();
            _timeoutTimer = null;

            if (_dialog != null)
            {
                _dialog.CloseDialog();
                _dialog.Dispose();
                _dialog = null;
            }
        }

        public void Dispose() => Close();
    }
}
