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
    class Nose
    {
        public static int Proximity,X,Y,Jitter,Offset;
        public static Sprite sprite;

        public static void Load()
        {
            //Load nose sprite
            sprite = new Sprite(new Texture(new Image("Content/Nose.png")), new IntRect(0,0,800,600));
            Console.WriteLine("Nose Sprite Loaded");
            //Set nose variables
            Proximity = 100;
            X = 400;
            Y = 0;
            Offset = X;
            Jitter = 10;
            Console.WriteLine("Set Nose Variables");
            sprite.Origin = new Vector2f((float)400, (float)300);
        }
    }
}
