﻿using System;
using System.Collections.Generic;
using TrackiCore.Stats;

namespace TrackiCore
{
    public class Program
    {
        private readonly string[] _args;

        private readonly Categories _workCategories = new Categories("categories.txt");
        private readonly Categories _studyCategories = new Categories("categories-study.txt");

        private Program(string[] args)
        {
            _args = args;
        }

        private void Run()
        {
            List<string> commands = new List<string> { "work", "stats", "study" };
            if (_args.Length == 0 || !commands.Contains(_args[0]))
                throw new TrackiException("Commands: " + string.Join(' ', commands));

            switch (_args[0])
            {
                case "work":
                {
                    string category = CategoryFromArgs(_workCategories);
                    var shift = new Shift(Shift.Type.WORK, category);
                    shift.Start();
                    WaitForEnding(shift);
                    break;
                }
                case "study":
                {
                    string category = CategoryFromArgs(_studyCategories);
                    var shift = new Shift(Shift.Type.STUDY, category);
                    shift.Start();
                    WaitForEnding(shift);
                    break;
                }
                case "stats":
                {
                    new Statistics().Show();
                    break;
                }
                default:
                {
                    throw new Exception($"Command `{_args[0]}` not handled.");
                }
            }
        }

        private string CategoryFromArgs(Categories categories)
        {
            var names = categories.List;
            if (_args.Length != 2)
            {
                names.Sort();
                throw new TrackiException("Specify: " + string.Join(' ', names));
            }

            string category = _args[0];
            if (!categories.Contains(category))
            {
                throw new TrackiException($"Category {category} doesn't exist.");
            }
            return category;
        }

        private void WaitForEnding(Shift shift)
        {
            while (true)
            {
                string cmd = Ask("Type 'f' to finish.\nType 'c' to cancel.");
                switch (cmd)
                {
                    case "f":
                    {
                        shift.Finish();
                        return;
                    }
                    case "c":
                    {
                        if (Ask("Type 'c' to confirm cancel.") == "c")
                        {
                            return;
                        }

                        break;
                    }
                }
            }
        }

        private string Ask(string text)
        {
            Console.WriteLine(text);
            Console.Write(">> ");
            return Console.ReadLine();
        }

        public static void Main(string[] args)
        {
            try
            {
                new Program(args).Run();
            }
            catch (TrackiException ex)
            {
                Console.Error.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
