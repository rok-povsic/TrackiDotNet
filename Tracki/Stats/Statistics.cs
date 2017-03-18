using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Tracki.Extensions;
using Tracki.Stats;
using Tracki.Structures;

namespace Tracki.Stats
{
    public enum CompleteStatsTime
    {
        All,
        ThisYear,
        ThisMonth,
        ThisWeek,
        Today
    }

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
    b - Work per task
    c - Work per week
    d - Work per month
    e - Chart of the last 14 days
    f - All time stats
    g - This year stats
    h - This month stats
    i - This week stats
    j - Today stats
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
                    _statisticsPerTask.Display();
                    break;
                }
                case "c":
                {
                    PerWeekDisplay();
                    break;
                }
                case "d":
                {
                    PerMonthDisplay();
                    break;
                }
                case "e":
                {
                    ChartLastTwoWeeks();
                    break;
                }
                case "f":
                {
                    CompleteStats(CompleteStatsTime.All);
                    break;
                }
                case "g":
                {
                    CompleteStats(CompleteStatsTime.ThisYear);
                    break;
                }
                case "h":
                {
                    CompleteStats(CompleteStatsTime.ThisMonth);
                    break;
                }
                case "i":
                {
                    CompleteStats(CompleteStatsTime.ThisWeek);
                    break;
                }
                case "j":
                {
                    CompleteStats(CompleteStatsTime.Today);
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
                    "{0,10} | {1,10} | {2,10}", date.ToString("yyyy-MM-dd"), 
                    _TimeSpanFormat(timeSpan), pomodoros
                );
            }

            Console.WriteLine();
        }

        private void PerDayOfWeekDisplay()
        {
            var d = new Dictionary<DayOfWeek, TimeSpan>();
            foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
            {
                d[dayOfWeek] = TimeSpan.Zero;
            }

            var workItems = _data.Read();
            foreach (WorkItem workItem in workItems)
            {
                var date = workItem.DtStart.Date;
                if (!d.ContainsKey(date.DayOfWeek))
                {
                    d[date.DayOfWeek] = TimeSpan.Zero;
                }

                d[date.DayOfWeek] += workItem.Timespan();
            }
            TimeSpan timeSpanTracking = workItems.Last().DtStart.Date 
                - workItems.First().DtStart.Date;
            int numOfWeeksTracking = (int)timeSpanTracking.TotalDays / 7 + 1;

            Console.WriteLine("{0,12} | {1,10} | {2,10}", "Day of week", "Avg. time", "Pomodoros");
            Console.WriteLine(new string('-', 14 + 20 + 2 * 2));
            foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
            {
                var avgTimeSpan = new TimeSpan(d[dayOfWeek].Ticks / numOfWeeksTracking);
                int avgPomodoros = new Pomodoros(avgTimeSpan).NumPomodoros();
                Console.WriteLine(
                    "{0,12} | {1,10} | {2,10}", dayOfWeek, _TimeSpanFormat(avgTimeSpan), 
                    avgPomodoros
                );
            }

            Console.WriteLine();
        }

        private void PerWeekDisplay()
        {
            var d = new Dictionary<string, TimeSpan>();
            foreach (WorkItem workItem in _data.Read())
            {
                var date = workItem.DtStart.Date;
                string yearWeek = date.ToString("yyyy-") + 
                    _WeekOfYear(date).ToString().PadLeft(2, '0');
                if (!d.ContainsKey(yearWeek))
                {
                    d[yearWeek] = TimeSpan.Zero;
                }

                d[yearWeek] += workItem.Timespan();
            }

            List<string> weeks = d.Keys.ToList();
            weeks.Sort();

            Console.WriteLine("{0,10} | {1,10} | {2,10}", "Week", "Sum time", "Pomodoros");
            Console.WriteLine(new string('-', 30 + 3 * 2));
            foreach (string yearWeek in weeks)
            {
                TimeSpan timeSpan = d[yearWeek];
                int pomodoros = new Pomodoros(timeSpan).NumPomodoros();
                Console.WriteLine(
                    "{0,10} | {1,10} | {2,10}", yearWeek, 
                    _TimeSpanFormat(timeSpan), pomodoros
                );
            }

            Console.WriteLine();
        }


        private void PerMonthDisplay()
        {
            var d = new Dictionary<string, TimeSpan>();
            foreach (WorkItem workItem in _data.Read())
            {
                var date = workItem.DtStart.Date;
                string yearMonth = date.ToString("yyyy-MM");
                if (!d.ContainsKey(yearMonth))
                {
                    d[yearMonth] = TimeSpan.Zero;
                }

                d[yearMonth] += workItem.Timespan();
            }

            List<string> months = d.Keys.ToList();
            months.Sort();

            Console.WriteLine("{0,10} | {1,10} | {2,10}", "Month", "Sum time", "Pomodoros");
            Console.WriteLine(new string('-', 30 + 3 * 2));
            foreach (string yearMonth in months)
            {
                TimeSpan timeSpan = d[yearMonth];
                int pomodoros = new Pomodoros(timeSpan).NumPomodoros();
                Console.WriteLine(
                    "{0,10} | {1,10} | {2,10}", yearMonth, 
                    _TimeSpanFormat(timeSpan), pomodoros
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
                    "{0,10} | {1,10} | {2,10} | {3}", curDate.ToShortDateString(), 
                    _TimeSpanFormat(timeSpan), numPomodoros, new string('x', numPomodoros)
                );

                curDate += TimeSpan.FromDays(1);
            }

            Console.WriteLine();
        }

        private void CompleteStats(CompleteStatsTime time)
        {
            DateTime dateFrom = DateTime.MinValue;
            DateTime dateTo = DateTime.MaxValue;
            switch (time)
            {
                case CompleteStatsTime.All:
                {
                    dateFrom = DateTime.MinValue;
                    dateTo = DateTime.MaxValue;
                    break;
                }
                case CompleteStatsTime.ThisYear:
                {
                    var now = DateTime.Now;
                    dateFrom = new DateTime(now.Year, 1, 1);
                    dateTo = dateFrom.AddYears(1);
                    break;
                }
                case CompleteStatsTime.ThisMonth:
                {
                    var now = DateTime.Now;
                    dateFrom = new DateTime(now.Year, now.Month, 1);
                    dateTo = dateFrom.AddMonths(1);
                    break;
                }
                case CompleteStatsTime.ThisWeek:
                {
                    var now = DateTime.Now;
                    dateFrom = new DateTimeExtensions().StartOfWeek(now, DayOfWeek.Monday);
                    dateTo = dateFrom.AddDays(7);
                    break;
                }
                case CompleteStatsTime.Today:
                {
                    var now = DateTime.Now;
                    dateFrom = now.Date;
                    dateTo = dateFrom.AddDays(1);
                    break;
                }
            }

            DateTime actualMin = DateTime.MaxValue;
            DateTime actualMax = DateTime.MinValue;

            TimeSpan sum = TimeSpan.Zero;
            var d = new SortedDictionary<DateTime, TimeSpan>();
            foreach (WorkItem workItem in _data.Read())
            {
                DateTime date = workItem.DtStart.Date;
                if (date < dateFrom)
                {
                    continue;
                }
                if (date < actualMin)
                {
                    actualMin = date;
                }
                if (actualMax < date)
                {
                    actualMax = date;
                }
                TimeSpan t = workItem.Timespan();
                sum += t;
                if (!d.ContainsKey(date)) {
                    d[date] = TimeSpan.Zero;
                }
                d[date] += t;
            }

            Console.Write( "From {0:d} to {1:d} you have worked ", actualMin.Date, actualMax.Date);
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0} hours and {1} minutes", (int)sum.TotalHours, sum.Minutes);
            Console.ForegroundColor = defaultColor;
            Console.WriteLine(".");
            Console.WriteLine();
        }

        private string _TimeSpanFormat(TimeSpan timeSpan)
        {
            var dt = new DateTime(timeSpan.Ticks);
            return string.Format("{0}h {1}m", (int)timeSpan.TotalHours, dt.ToString("mm"));
        }

        /// <summary>
        /// Iso8601 week of year
        /// This presumes that weeks start with Monday.
        /// Week 1 is the 1st week of the year with a Thursday in it.
        /// From: http://stackoverflow.com/questions/11154673/get-the-correct-week-number-of-a-given-date
        /// </summary>
        /// <param name="date">the date</param>
        /// <returns>the week of year</returns>
        public int _WeekOfYear(DateTime date)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                date = date.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday
            );
        }
    }
}