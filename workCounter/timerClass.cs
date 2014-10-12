using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace workCounter
{
    class timerClass
    {
        private mainForm _mainForm;
        private DateTime _startTime;
        private System.Windows.Forms.Timer _timer;
        public timerClass(mainForm mainForm,DateTime startTime)
        {
            _startTime = startTime;
            _mainForm = mainForm;
            _timer = _mainForm.timer1;
            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            intervalElapsed();
        }
        void intervalElapsed()
        {
            timeIntervalClass timeIntervalClass = new workCounter.timeIntervalClass(_startTime, DateTime.Now);
            _mainForm.labelTimeElapsed.Text = timeIntervalClass.intervalAsString();
        }
        public void start()
        {
            intervalElapsed();
            _timer.Start();
        }
        public void stop()
        {
            _timer.Stop();
        }
    }
}
