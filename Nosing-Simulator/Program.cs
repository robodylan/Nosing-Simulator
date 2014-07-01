using System;

namespace Nosing_Simulator
{
	public class Program
	{
		public static Game G;

		private static void Main(string[] args)
		{
			G = new Game(800, 600, "Nosing Simulator V1.3.7");
			Console.WriteLine("Loading New Game");
			G.Start();
		}
	}
}