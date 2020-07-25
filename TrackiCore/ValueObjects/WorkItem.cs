using System;

namespace TrackiCore.ValueObjects
{
    public class WorkItem
    {
        internal string Name { get; }
        internal DateTime DtStart { get; }
        internal DateTime DtEnd { get; }

        public static WorkItem None => new WorkItem("", DateTime.MinValue, DateTime.MinValue);

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

        private bool Equals(WorkItem other)
        {
            return Name == other.Name && DtStart.Equals(other.DtStart) && DtEnd.Equals(other.DtEnd);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WorkItem) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, DtStart, DtEnd);
        }
    }
}
