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
        public static int Sensitivity;
        public static Sprite sprite;

        public static void Load()
        {
            //Load Shoulder Sprite
            sprite = new Sprite(new Texture(new Image("Content/Shoulder.png")), new IntRect(0, 0, 800, 600));
            Console.WriteLine("Shoulder Sprite Loaded");
            //Set Shoulder Variables
            Sensitivity = 1;
            Console.WriteLine("Set Shoulder Variables");
        }
    }
}
