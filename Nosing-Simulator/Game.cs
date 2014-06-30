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
    class Game
    {
        public RenderWindow window;
        public static Sprite BG;
        public Game(uint w, uint h, string title)
        {
            window = new RenderWindow(new VideoMode(w, h), title);
        }

        public void Start()
        {
            //Load and Set Assets
            BG = new Sprite(new Texture(new Image("Content/BG.png")),new IntRect(0,0,800,600));
            Console.WriteLine("Loaded Background");
            Shoulder.Load();
            Nose.Load();
            while(window.IsOpen())
            {
                window.Clear(new Color(0,0,0));
                window.DispatchEvents();
                Draw();
                window.Display();
            }
        }

        public void Draw() 
        {
            //Draw Background
            window.Draw(BG);
            //Draw Shoulder
            window.Draw(Shoulder.sprite);
            //Update Nose
            Nose.Update();
            //Draw Nose
            window.Draw(Nose.sprite);
        }
    }
}
