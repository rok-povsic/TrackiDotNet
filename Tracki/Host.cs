using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracki.Stats;

namespace Tracki
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
