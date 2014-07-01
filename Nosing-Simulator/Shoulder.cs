using SFML.Graphics;
using System;

namespace Nosing_Simulator
{
	public class Shoulder
	{
		public static int Y = 0;
		public static float Speed = 1f;
		public static float Sensitivity = 10f;
		public static Sprite sprite;
		public static float moveTo, X;

		public static void Load()
		{
			//Load Shoulder Sprite
			sprite = new Sprite(new Texture(new Image("Content/Shoulder.png")), new IntRect(0, 0, 800, 600));
			Console.WriteLine("Shoulder Sprite Loaded");
			//Set Shoulder Variables
            Sensitivity = 20;
			Console.WriteLine("Set Shoulder Variables");
		}

		public static void Move()
		{
			if (X != moveTo)
			{
				if (X < moveTo)
				{
					X += Speed;
				}
				else
				{
					X -= Speed;
				}
			}
			else
			{
				moveTo = new Random(DateTime.Now.Millisecond).Next(-40, 0);
			}
		}
	}
}