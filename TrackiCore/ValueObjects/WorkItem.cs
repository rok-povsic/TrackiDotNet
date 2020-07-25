using System;

namespace TrackiCore.ValueObjects
{
    internal class WorkItem
    {
        internal string Name { get; }
        internal DateTime DtStart { get; }
        internal DateTime DtEnd { get; }

        internal WorkItem(string[] items)
        {
            Name = items[0];
            DtStart = DateTime.Parse(items[1]);
            DtEnd = DateTime.Parse(items[2]);
        }

        public TimeSpan Timespan()
        {
            return DtEnd - DtStart;
        }
    }
}
