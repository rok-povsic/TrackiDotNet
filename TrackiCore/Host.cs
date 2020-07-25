using TrackiCore.Stats;

namespace TrackiCore
{
    class Host
    {
        private readonly UserInput _userInput;
        private readonly Categories _categories;
        private readonly Statistics _statistics;

        public Host()
        {
            _userInput = new UserInput();
            _categories = new Categories();
            _statistics = new Statistics();
        }

        public void Start()
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
                        _categories.Display();
                        break;
                    }
                    case "c":
                    {
                        _statistics.Show();
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
            var option = new Option("Select a category", _categories);
            WorkTask workTask = option.AskForTask();

            workTask.Start();
        }
    }
}