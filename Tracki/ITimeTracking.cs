using System;

namespace Tracki
{
    interface ITimeTracking
    {
        void Start();
        TimeSpan Stop();
    }
}