using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tracki.Structures;

namespace Tracki
{
    class Data
    {
        private readonly string _datetimeFormat = "yyyy-MM-dd HH:mm:ss";
        private char _separator = ',';

        private string Filepath => Path.Combine(Settings.DataDir, Settings.DataFilename);

        public void Add(string name, DateTime dtStart, DateTime dtEnd)
        {
            using (var sw = new StreamWriter(Filepath, true))
            {
                string[] line =
                {
                    name,
                    dtStart.ToString(_datetimeFormat),
                    dtEnd.ToString(_datetimeFormat)
                };
                sw.WriteLine(string.Join(_separator.ToString(), line));
            }
        }

        public List<WorkItem> Read()
        {
            var result = new List<WorkItem>();

            string[] readAllLines = File.ReadAllLines(Filepath);
            foreach (string line in readAllLines)
            {
                string[] spl = line.Split(_separator);
                result.Add(new WorkItem(spl));
            }

            return result;
        }
    }
}
