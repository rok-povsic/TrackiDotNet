using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracki
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
