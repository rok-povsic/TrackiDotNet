using System;
using TrackiCore.History;

namespace TrackiCore
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
