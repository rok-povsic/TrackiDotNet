using TrackiCore.Stats;

namespace TrackiCore
{
    class Host
    {
        private readonly UserInput _userInput;

        public Statistics Statistics { get; }
        public Categories Categories { get; }

        public Host()
        {
            _userInput = new UserInput();
            Categories = new Categories();
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
                        Categories.Display();
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
            var option = new Option("Select a category", Categories);
            WorkTask workTask = option.AskForTask();

            workTask.Start();
        }
    }
}