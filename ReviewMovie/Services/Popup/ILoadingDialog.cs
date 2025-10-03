using System;
using System.Windows.Forms;

namespace EasyClip.Services.Popup
{
    public interface ILoadingDialog : IDisposable
    {
        void Show(string status);
        void UpdateStatus(string status);
        void CloseDialog();
    }
}
