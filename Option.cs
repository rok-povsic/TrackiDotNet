using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracki
{
    class Option
    {
        private readonly string _text;
        private readonly List<WorkTask> _options;

        public Option(string text, List<WorkTask> options)
        {
            _text = text;
            _options = options;
        }

        public WorkTask AskForTask()
        {
            Console.WriteLine(_text);
            for (int i = 0; i < _options.Count; i++)
            {
                char c = (char) ('a' + i);
                Console.WriteLine("\t" + c + " - " + _options[i]);
            }
            Console.Write(">> ");
            string answer = Console.ReadLine();
            char answerChar = Convert.ToChar(answer);

            int chosenTask = answerChar - 'a';

            return _options[chosenTask];
        }
    }
}
