﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackiCore
{
    class Option
    {
        private readonly string _text;
        private readonly Categories _categories;

        public Option(string text, Categories categories)
        {
            _text = text;
            _categories = categories;
        }

        public WorkTask AskForTask()
        {
            Console.WriteLine(_text);
            for (int i = 0; i < _categories.Count; i++)
            {
                char c = (char) ('a' + i);
                Console.WriteLine("\t" + c + " - " + _categories[i]);
            }
            Console.Write(">> ");
            string answer = Console.ReadLine();
            char answerChar = Convert.ToChar(answer);

            int chosenTask = answerChar - 'a';

            string category = _categories[chosenTask];
            return new WorkTask(category);
        }
    }
}
