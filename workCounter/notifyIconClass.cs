using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workCounter
{
    class notifyIconClass
    {
        private NotifyIcon _notifyIcon;
        private mainForm _mainForm;
        public notifyIconClass(NotifyIcon notifyIcon,mainForm mainForm)
        {
            _mainForm=mainForm;
            _notifyIcon=notifyIcon;
            _notifyIcon.DoubleClick += _notifyIcon_DoubleClick;
        }

        void _notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            _mainForm.Show();
            _mainForm.WindowState = FormWindowState.Normal;
        }
        public void show()
        {
            _notifyIcon.ShowBalloonTip(1,"Work Counter","Press double click to open me!",ToolTipIcon.Info);
        }
    }
}
