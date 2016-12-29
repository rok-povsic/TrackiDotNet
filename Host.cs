using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracki
{
    class Host
    {
        private List<WorkTask> _categories;
        private UserInput _userInput;

        public Host()
        {
            _userInput = new UserInput();
            _categories = new List<WorkTask>
            {
                new WorkTask("Task 1"),
                new WorkTask("Task 2"),
            };
        }

        public void Start()
        {
            while (true)
            {
                string cmd = _userInput.Ask(
@"What would you like to do?
    a - Start a task
    b - Modify categories
    b - Statistics
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
                        break;
                    }
                    case "c":
                    {
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
