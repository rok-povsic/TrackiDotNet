﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackiCore.Structures
{
    class Pomodoros
    {
        private TimeSpan _timeSpan;

        public Pomodoros(TimeSpan timeSpan)
        {
            _timeSpan = timeSpan;
        }

        public int NumPomodoros()
        {
            int numPomodoros = (int) (_timeSpan.Ticks / TimeSpan.FromMinutes(25).Ticks);
            return numPomodoros;
        }
    }
}
