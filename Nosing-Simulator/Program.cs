using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nosing_Simulator
{
    class Program
    {
        public static Game G;
        static void Main(string[] args)
        {
            G = new Game(800,600,"Nosing Simulator");
            Console.WriteLine("Loading New Game");
            G.Start();
        }
    }
}
