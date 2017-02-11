using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracki.Structures
{
    class WorkItem
    {
        public string Name { get; private set; }
        public DateTime DtStart { get; private set; }
        public DateTime DtEnd { get; private set; }

        public WorkItem(string[] items)
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
