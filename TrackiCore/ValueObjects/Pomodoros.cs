using System;

namespace TrackiCore.ValueObjects
{
    internal class Pomodoros
    {
        private readonly TimeSpan _timeSpan;

        internal Pomodoros(TimeSpan timeSpan)
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
