using System;
using System.Collections.Generic;
using TrackiCore.History;

namespace TrackiCore
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> commands = new List<string>
            {
                "work", "stats", "study"
            };
            if (args.Length == 0 || !commands.Contains(args[0]))
            {
                Console.WriteLine("Commands: " + String.Join(' ', commands));
                return;
            }

            switch (args[0])
            {
                case "work":
                    Start(Shift.Type.WORK, args);
                    break;
                case "study":
                    Start(Shift.Type.STUDY, args);
                    break;
                case "stats":
                    new Host().Statistics.Show();
                    break;
            }
        }

        private static void Start(Shift.Type type, string[] args)
        {
            var categoriesList = new Host().Categories(type).List;

            if (args.Length != 2)
            {
                categoriesList.Sort();
                Console.WriteLine("Specify: " + string.Join(' ', categoriesList));
                return;
            }

            string category = args[1];

            if (!categoriesList.Contains(category))
            {
                Console.WriteLine($"Category {category} doesn't exist.");
                return;
            }

            new Shift(type, category).Start();
        }
    }
}
