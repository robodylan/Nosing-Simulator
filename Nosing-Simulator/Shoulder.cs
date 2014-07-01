using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Import SFML
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace Nosing_Simulator
{
    class Shoulder
    {
        public static int Sensitivity, X, Y = 0;
        public static Sprite sprite;
        public static float moveTo = -30;
        public static void Load()
        {
            //Load Shoulder Sprite
            sprite = new Sprite(new Texture(new Image("Content/Shoulder.png")), new IntRect(0, 0, 800, 600));
            Console.WriteLine("Shoulder Sprite Loaded");
            //Set Shoulder Variables
            Sensitivity = 20;
            Y = -100;
            Console.WriteLine("Set Shoulder Variables");
        }

        public static void Move()
        {
            if(X != moveTo)
            {
                if(X < moveTo)
                {
                    X++;
                }
                else
                {
                    X--;
                }
            }
            else
            {
                moveTo = new Random(DateTime.Now.Millisecond).Next(-40,0);
            }
        }
    }
}
