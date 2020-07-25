﻿using System;
using System.IO;

namespace TrackiCore
{
    public class Shift
    {
        private string _name;
        public string Name => _name;

        private readonly UserInput _userInput;
        private Data _data;

        public Shift(Type type, string name)
        {
            _name = name;
            _userInput = new UserInput();
            _data = new Data(type);
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
            Console.WriteLine("Finished: {0:hh}h {0:mm}min", dtEnd - dtStart);

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

        public enum Type { WORK, STUDY }
    }
}