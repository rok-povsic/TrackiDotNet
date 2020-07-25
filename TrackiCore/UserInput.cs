﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackiCore
{
    class UserInput
    {
        public string Ask(string text)
        {
            Console.WriteLine(text);
            Console.Write(">> ");
            return Console.ReadLine();
        }
    }
}
