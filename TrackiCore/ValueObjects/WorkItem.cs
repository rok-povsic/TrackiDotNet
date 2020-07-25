using System;

namespace TrackiCore.ValueObjects
{
    public class WorkItem
    {
        internal WorkType Type { get; }
        internal string Name { get; }
        internal DateTime DtStart { get; }
        internal DateTime DtEnd { get; }

        public static WorkItem None => new WorkItem(
            WorkType.NONE, "", DateTime.MinValue, DateTime.MinValue
        );

        internal WorkItem(WorkType type, string[] items):
            this(type, items[0], DateTime.Parse(items[1]), DateTime.Parse(items[2]))
        {
        }

        internal WorkItem(WorkType type, string name, DateTime dtStart, DateTime dtEnd)
        {
            Type = type;
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
