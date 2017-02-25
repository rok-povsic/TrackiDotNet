using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracki.History;

namespace Tracki
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                new Host().Start();
            } 
            else if (args[0] == "history")
            {
                new TogglData(args[1]).Transform();
            }
        }
    }
}
