using System;
using System.Collections.Generic;
using System.IO;
using TrackiCore.ValueObjects;

namespace TrackiCore
{
    public class DataRepo
    {
        private readonly string _datetimeFormat = "yyyy-MM-dd HH:mm:ss";
        private readonly char _separator = ',';

        public void Add(WorkItem workItem)
        {
            using (var sw = new StreamWriter(FilePath(workItem.Type), true))
            {
                string[] line =
                {
                    workItem.Name,
                    workItem.DtStart.ToString(_datetimeFormat),
                    workItem.DtEnd.ToString(_datetimeFormat)
                };
                sw.WriteLine(string.Join(_separator.ToString(), line));
            }
        }

        public List<WorkItem> Read(WorkType type)
        {
            var result = new List<WorkItem>();

            string[] readAllLines = File.ReadAllLines(FilePath(type));
            foreach (string line in readAllLines)
            {
                string[] spl = line.Split(_separator);
                result.Add(new WorkItem(type, spl));
            }

            return result;
        }

        private string FilePath(WorkType type)
        {
            string filename;
            switch (type)
            {
                case WorkType.WORK:
                    filename = "data.txt";
                    break;
                case WorkType.STUDY:
                    filename = "data-study.txt";
                    break;
                default:
                    throw new Exception("Unknown type: " + type);
            }
            return Path.Combine(Settings.DataDir, filename);
        }
    }
}
