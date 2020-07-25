using System;
using TrackiCore.ValueObjects;

namespace TrackiCore
{
    public partial class Shift
    {
        private readonly string _name;
        private DateTime _dtStart;

        public Shift(string name)
        {
            _name = name;
        }

        public void Start()
        {
            Console.WriteLine("Starting task {0}", _name);
            _dtStart = DateTime.Now;
        }

        public WorkItem Finish()
        {
            var dtEnd = DateTime.Now;
            Console.WriteLine("Finished: {0:hh}h {0:mm}min", dtEnd - _dtStart);

            return new WorkItem(_name, _dtStart, dtEnd);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}