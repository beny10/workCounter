using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workCounter
{
    class timeIntervalClass
    {
        private DateTime _startTime, _stopTime;
        public timeIntervalClass(DateTime startTime,DateTime stopTime)
        {
            _startTime = startTime;
            _stopTime = stopTime;
        }
        public string intervalAsString()
        {
            TimeSpan timeSpan = _stopTime - _startTime;
            return String.Format("{0}:{1}", (int)timeSpan.TotalHours, (int)timeSpan.Minutes);
        }
    }
}
