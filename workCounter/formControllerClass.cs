using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace workCounter
{
    class formControllerClass
    {
        private mainForm _mainForm;
        private DateTime _startTime;
        private DateTime _endTime;
        private insertWorkRegisterClass _insertWorkRegisterClass;
        private reportForm _reportForm;
        private timerClass _timer;
        private bool _started = false;
        private notifyIconClass _notifyIconClass;
        public formControllerClass(mainForm mainForm)
        {
            _mainForm = mainForm;
            changeStatusOfButtons(false);
            _mainForm.FormClosing += _mainForm_FormClosing;
        }

        void _mainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if(_started)
                stop();
        }
        
        void insertDataInDatabase(string message)
        {
            _insertWorkRegisterClass = new insertWorkRegisterClass(_startTime, _endTime, message);
            _insertWorkRegisterClass.insert();

        }
        void changeStatusOfButtons(bool started)
        {
            _mainForm.buttonStop.Enabled = started;
            _mainForm.buttonStart.Enabled = !started;
        }
        
        public void start()
        {
            _notifyIconClass = new notifyIconClass(_mainForm.notifyIcon1,_mainForm);
            _notifyIconClass.show();
            _startTime = DateTime.Now;
            _timer = new timerClass(_mainForm, _startTime);
            _timer.start();
            changeStatusOfButtons(true);
            _mainForm.Hide();
            _started = true;
        }
        public void stop()
        {
            _started = false;
            //_mainForm.buttonStart.Enabled = false;
            _timer.stop();
            changeStatusOfButtons(false);
            _endTime = DateTime.Now;
            _reportForm = new reportForm();
            _reportForm.ShowDialog();
            insertDataInDatabase(_reportForm.message);
            
        }
        public void formSizeChanged()
        {
            if(_mainForm.WindowState==System.Windows.Forms.FormWindowState.Minimized)
            {
                _mainForm.Hide();
            }
        }
    }
}
