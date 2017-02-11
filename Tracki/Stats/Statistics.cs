using System;
using System.Collections.Generic;
using System.Linq;
using Tracki.Stats;
using Tracki.Structures;

namespace Tracki.Stats
{
    public class Statistics
    {
        private readonly Data _data;
        private readonly UserInput _userInput;
        private StatisticsPerTask _statisticsPerTask;

        public Statistics()
        {
            _data = new Data();
            _userInput = new UserInput();
            _statisticsPerTask = new StatisticsPerTask();
        }

        public void Show()
        {
                string cmd = _userInput.Ask(
@"What kind of statistics would you like to see?
    a - Work per day
    b - Work per day of week
    c - Work per task
    d - Chart of last 14 days
");
            switch (cmd.ToLower())
            {
                case "a":
                {
                    PerDayDisplay();
                    break;
                }
                case "b":
                {
                    break;
                }
                case "c":
                {
                    _statisticsPerTask.Display();
                    break;
                }
                case "d":
                {
                    ChartLastTwoWeeks();
                    break;
                }
                default:
                {
                    break;
                }
            }
        }

        private void PerDayDisplay()
        {
            var d = new Dictionary<DateTime, TimeSpan>();
            foreach (WorkItem workItem in _data.Read())
            {
                var date = workItem.DtStart.Date;
                if (!d.ContainsKey(date))
                {
                    d[date] = TimeSpan.Zero;
                }

                d[date] += workItem.Timespan();
            }

            List<DateTime> dates = d.Keys.ToList();
            dates.Sort();

            Console.WriteLine("{0,10} | {1,10} | {2,10}", "Date", "Sum time", "Pomodoros");
            Console.WriteLine(new string('-', 30 + 3 * 2));
            foreach (DateTime date in dates)
            {
                TimeSpan timeSpan = d[date];
                int pomodoros = new Pomodoros(timeSpan).NumPomodoros();
                Console.WriteLine(
                    "{0,10} | {1,10} | {2,10}", date.ToString("yyyy-MM-dd"), timeSpan, pomodoros
                );
            }

            Console.WriteLine();
        }

        private void ChartLastTwoWeeks()
        {
            DateTime dateFrom = DateTime.Now.Date
                .AddDays(-14);
            var d = new SortedDictionary<DateTime, TimeSpan>();
            foreach (WorkItem workItem in _data.Read())
            {
                DateTime date = workItem.DtStart.Date;
                if (date < dateFrom)
                {
                    continue;
                }
                if (!d.ContainsKey(date)) {
                    d[date] = TimeSpan.Zero;
                }
                d[date] += workItem.Timespan();
            }

            TimeSpan maxTimeSpan = d.Values.Max();

            Console.WriteLine(
                "{0,10} | {1,10} | {2,10} | {3,20}", 
                "Name", 
                "Sum time", 
                "Pomodoros",
                "Visual"
            );
            Console.WriteLine(new string('-', 50 + 3 * 3));

            DateTime curDate = dateFrom;
            while (curDate <= DateTime.Now.Date)
            {
                TimeSpan timeSpan;
                if (d.Keys.Contains(curDate))
                {
                    timeSpan = d[curDate];
                }
                else
                {
                    timeSpan = TimeSpan.Zero;
                }

                double rate = (double) timeSpan.Ticks / maxTimeSpan.Ticks;
                int numPomodoros = new Pomodoros(timeSpan).NumPomodoros();

                Console.WriteLine(
                    "{0,10} | {1,10} | {2,10} | {3}", 
                    curDate.ToShortDateString(), 
                    timeSpan, 
                    numPomodoros, 
                    new string('x', numPomodoros)
                );

                curDate += TimeSpan.FromDays(1);
            }

            Console.WriteLine();
        }
    }
}