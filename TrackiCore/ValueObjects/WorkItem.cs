using System;

namespace TrackiCore.ValueObjects
{
    internal class WorkItem
    {
        internal string Name { get; }
        internal DateTime DtStart { get; }
        internal DateTime DtEnd { get; }

        internal WorkItem(string[] items):
            this(items[0], DateTime.Parse(items[1]), DateTime.Parse(items[2]))
        {
        }

        internal WorkItem(string name, DateTime dtStart, DateTime dtEnd)
        {
            Name = name;
            DtStart = dtStart;
            DtEnd = dtEnd;
        }

        public TimeSpan Timespan()
        {
            return DtEnd - DtStart;
        }
    }
}
