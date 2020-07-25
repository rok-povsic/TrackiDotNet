﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TrackiCore
{
    public class Record
    {
        private readonly Shift _shift;
        private readonly ITimeTracking _timeTracking;

        public Record(Shift shift)
            : this(shift, new TimeTracking())
        { }

        public Record(Shift shift, ITimeTracking timeTracking)
        {
            _shift = shift;
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
