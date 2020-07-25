﻿using System;
using System.Collections.Generic;
 using TrackiCore.ValueObjects;

 namespace TrackiCore.Stats
{
    class StatisticsPerTask
    {
        private DataRepo _dataRepo;

        private List<ConsoleColor> _colors = new List<ConsoleColor>
        {
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.Magenta,
            ConsoleColor.White,
            ConsoleColor.Cyan,
        };

        public StatisticsPerTask()
        {
            _dataRepo = new DataRepo(WorkType.WORK);
        }

        public void Display()
        {
            var categoryToTimespan = new Dictionary<string, TimeSpan>();
            foreach (WorkItem workItem in _dataRepo.Read())
            {
                if (!categoryToTimespan.ContainsKey(workItem.Name))
                {
                    categoryToTimespan[workItem.Name] = TimeSpan.Zero;
                }

                categoryToTimespan[workItem.Name] += workItem.Timespan();
            }

            Console.WriteLine("{0,10} | {1,10} | {2,10}", "Name", "Sum time", "Pomodoros");
            Console.WriteLine(new string('-', 30 + 3 * 2));

            TimeSpan allTimeWorked = TimeSpan.Zero;
            foreach (string name in categoryToTimespan.Keys)
            {
                TimeSpan timeSpan = categoryToTimespan[name];
                int numPomodoros = new Pomodoros(timeSpan).NumPomodoros();
                Console.WriteLine("{0,10} | {1,10} | {2,10}", name, timeSpan, numPomodoros);

                allTimeWorked += timeSpan;
            }

            ConsoleColor defaultColor = Console.ForegroundColor;

            int allNumChars = 38;
            int curColorIndex = 0;
            foreach (string name in categoryToTimespan.Keys)
            {
                TimeSpan timeSpan = categoryToTimespan[name];
                decimal shareCategory = (decimal) timeSpan.Ticks / allTimeWorked.Ticks;
                int numCharsCategory = (int) (shareCategory * allNumChars);

                Console.ForegroundColor = _colors[curColorIndex];
                Console.Write(new string('x', numCharsCategory));

                curColorIndex++;
            }

            Console.ForegroundColor = defaultColor;

            Console.WriteLine();
        }

    }
}
