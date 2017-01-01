using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Tracki
{
    public class Statistics
    {
        private Data _data;

        public Statistics()
        {
            _data = new Data();
        }

        public void Show()
        {
            var d = new Dictionary<string, TimeSpan>();

            foreach (string[] items in _data.Read())
            {
                string name = items[0];
                DateTime dtStart = DateTime.Parse(items[1]);
                DateTime dtEnd = DateTime.Parse(items[2]);

                if (!d.ContainsKey(name))
                {
                    d[name] = TimeSpan.Zero;
                }

                TimeSpan timeSpan = dtEnd - dtStart;
                d[name] += timeSpan;
            }

            Console.WriteLine("{0,10} | {1,10} | {2,10}", "Name", "Sum time", "Pomodoros");
            Console.WriteLine(new string('-', 30 + 3*2));
            foreach (string name in d.Keys)
            {
                TimeSpan timeSpan = d[name];
                long numPomodoros = timeSpan.Ticks / TimeSpan.FromMinutes(25).Ticks;
                Console.WriteLine("{0,10} | {1,10} | {2,10}", name, timeSpan, numPomodoros);
            }

            Console.WriteLine();
        }
    }
}