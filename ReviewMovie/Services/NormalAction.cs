using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReviewMovie.Services
{
    public static class ActiveProject
    {
       public static void ActiveGroupBoxSetting(TableLayoutPanel tlpView, GroupBox grbConfigVoice , GroupBox grbConfigRender, GroupBox grbActionRender, bool enable)
        {
            tlpView.Enabled = enable ? true : false;
            grbConfigVoice.Enabled = enable ? true : false;
            grbConfigRender.Enabled = enable ? true : false;
            grbActionRender.Enabled = enable ? true : false;
        }
    }
}
