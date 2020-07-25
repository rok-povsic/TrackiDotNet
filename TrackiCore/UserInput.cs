﻿using System;

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
