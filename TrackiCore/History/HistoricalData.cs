﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackiCore.History
{
    public class TogglData
    {
        private readonly string _filePath;

        public TogglData(string filePath)
        {
            _filePath = filePath;
        }

        public void Transform()
        {
            var newLines = new List<string>();
            bool first = true;
            foreach (string line in File.ReadAllLines(_filePath))
            {
                if (first)
                {
                    first = false;
                    continue;
                }
                string[] spl = line.Split(',');
                string task = spl[3];
                string from = spl[7] + " " + spl[8];
                string to = spl[9] + " " + spl[10];

                newLines.Add(string.Format("{0},{1},{2}", task, from, to));
            }

            string dir = Path.GetDirectoryName(_filePath);
            string fileName = string.Format(
                "{0}_tracki{1}",
                Path.GetFileNameWithoutExtension(_filePath),
                Path.GetExtension(_filePath)
            );

            File.WriteAllLines(Path.Combine(dir, fileName), newLines.ToArray());

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
