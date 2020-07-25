using System;
using TrackiCore.Stats;

namespace TrackiCore
{
    class Host
    {
        private readonly UserInput _userInput;

        public Statistics Statistics { get; }
        public Categories WorkCategories { get; }
        public Categories StudyCategories { get; }

        public Host()
        {
            _userInput = new UserInput();
            WorkCategories = new Categories("categories.txt");
            StudyCategories = new Categories("categories-study.txt");
            Statistics = new Statistics();
        }

        public void Main()
        {
            while (true)
            {
                string cmd = _userInput.Ask(
                    @"What would you like to do?
    a - Start a task
    b - Modify categories
    c - Statistics
    q - Quit
");
                switch (cmd.ToLower())
                {
                    case "a":
                    {
                        StartTask();
                        break;
                    }
                    case "b":
                    {
                        WorkCategories.Display();
                        break;
                    }
                    case "c":
                    {
                        Statistics.Show();
                        break;
                    }
                    case "q":
                    {
                        return;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
        }

        private void StartTask()
        {
            var option = new Option("Select a category", WorkCategories);
            Shift shift = option.AskForTask();

            shift.Start();
        }

        public Categories Categories(Shift.Type type)
        {
            return type switch
            {
                Shift.Type.WORK => WorkCategories,
                Shift.Type.STUDY => StudyCategories,
                _ => throw new Exception("Unknown type.")
            };
        }
    }
}
