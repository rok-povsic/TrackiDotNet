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

            string category;
            while (true)
            {
                Console.Write(">> ");
                string answer = Console.ReadLine();

                if (answer.StartsWith(" "))
                {
                    char answerChar = Convert.ToChar(answer);
                    int chosenTask = answerChar - 'a';
                    category = _categories[chosenTask];
                    break;
                }
                else
                {
                    category = answer.ToUpper();
                    if (_categories.Contains(category))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Category name doesn't exist.");
                    }
                }
            }

            return new WorkTask(category);
        }
    }
}
