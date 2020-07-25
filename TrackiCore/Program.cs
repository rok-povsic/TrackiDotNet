﻿using System;
using TrackiCore.History;

namespace TrackiCore
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Commands: main work stats");
                return;
            }

            switch (args[0])
            {
                case "main":
                    new Host().Main();
                    break;
                case "work":
                    if (args.Length != 2)
                    {
                        var categoriesList = new Host().Categories.List;
                        categoriesList.Sort();
                        Console.WriteLine("Specify: " + string.Join(' ', categoriesList));
                        return;
                    }
                    string category = args[1];
                    new Shift(category).Start();
                    break;
                case "stats":
                    new Host().Statistics.Show();
                    break;
            }
        }
    }
}
