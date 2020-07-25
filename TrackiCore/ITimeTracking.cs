﻿using System;

namespace TrackiCore
{
    public interface ITimeTracking
    {
        void Start();
        TimeSpan Stop();
    }
}