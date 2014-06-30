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
        public static int Proximity, X, Y, Jitter;
        public static Sprite sprite;

        public static void Load()
        {
            //Load nose sprite
            sprite = new Sprite(new Texture(new Image("Content/Nose.png")), new IntRect(0,0,800,600));
            Console.WriteLine("Nose Sprite Loaded");
            //Set nose variables
            Proximity = 100;
            X = +100;
            Y = 0;
            Jitter = 10;
            Console.WriteLine("Set Nose Variables");
        }

        public static void Update()
        {
            //Update Position
            sprite.Position = new Vector2f((float)X,(float)Y);
            sprite.Rotation++;
        }
    }
}
