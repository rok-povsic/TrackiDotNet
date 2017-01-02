using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tracki
{
    class Record
    {
        private readonly WorkTask _workTask;
        private readonly ITimeTracking _timeTracking;

        public Record(WorkTask workTask) 
            : this(workTask, new TimeTracking())
        { }

        public Record(WorkTask workTask, ITimeTracking timeTracking)
        {
            _workTask = workTask;
            _timeTracking = timeTracking;
        }

        public void Start()
        {
            _timeTracking.Start();
        }

        public TimeSpan Stop()
        {
            return _timeTracking.Stop();
        }
    }
}
