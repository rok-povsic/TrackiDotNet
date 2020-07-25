﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackiCore.Tests.Fake
{
    class FkTimeTracking : ITimeTracking
    {
        private TimeSpan _stop;
        public void Start()
        {
        }

        public TimeSpan Stop()
        {
            return _stop;
        }

        public void SetStop(TimeSpan stop)
        {
            _stop = stop;
        }
    }
}
