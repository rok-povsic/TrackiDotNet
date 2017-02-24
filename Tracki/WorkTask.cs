using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework.Internal.Execution;

namespace Tracki
{
    class WorkTask
    {
        private string _name;
        public string Name => _name;

        private readonly UserInput _userInput;
        private Data _data;

        public WorkTask(string name)
        {
            _name = name;
            _userInput = new UserInput();
            _data = new Data();
        }

        public void Start()
        {
            Console.WriteLine("Starting task {0}", _name);

            var dtStart = DateTime.Now;
            while (true)
            {
                string cmd = _userInput.Ask(
@"Type 'f' to finish.
Type 'c' to cancel.");
                switch (cmd)
                {
                    case "f":
                    {
                        Finish(dtStart);
                        return;
                    }
                    case "c":
                    {
                        if (_userInput.Ask("Type 'c' to confirm cancel.") == "c")
                        {
                            Cancel();
                            return;
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    }
                    default:
                    {
                        continue;
                    }
                }
            }
        }

        private void Finish(DateTime dtStart)
        {
            var dtEnd = DateTime.Now;
            Console.WriteLine("Finished.");

            Directory.CreateDirectory(Settings.DataDir);

            _data.Add(_name, dtStart, dtEnd);
        }

        private void Cancel()
        {
            Console.WriteLine("Canceled");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}