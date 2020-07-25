using System;

namespace TrackiCore
{
    public class TrackiException : Exception
    {
        public TrackiException(string message) : base(message) {}
    }
}
