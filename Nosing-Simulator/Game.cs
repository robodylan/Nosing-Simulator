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
        public static int MouseX, MouseY;
        public static Vector2i mouseOffset;
        public RenderWindow window;
        public static Sprite BG, Overlay, failScreen;
        public static bool isFailure = false;
        public static bool isFirstRun = true;
        public static int finalScore = 0;
        public static Font font;
        public Game(uint w, uint h, string title)
        {
            window = new RenderWindow(new VideoMode(w, h), title);
        }
        public void Start()
        {
            //Load and Set Assets
            BG = new Sprite(new Texture(new Image("Content/BG.png")),new IntRect(0,0,800,600));
            Overlay = new Sprite(new Texture(new Image("Content/Overlay.png")), new IntRect(0,0,800,600));
            failScreen = new Sprite(new Texture(new Image("Content/failScreen.png")));
            Console.WriteLine("Loaded Background, Overlay, and Failure Screen");
            font = new Font("Content/Animated.ttf");
            Console.WriteLine("Loaded Fonts");
            Shoulder.Load();
            Nose.Load();
            Console.WriteLine("Loaded Overlay");
            window.MouseMoved += MouseInput;
            window.KeyPressed += Reset;
            window.SetFramerateLimit(60);
            window.SetMouseCursorVisible(false);
            Console.WriteLine("Setup Window");
            //On completion of loading and setting assets
            Console.WriteLine("Game Loaded");
            //Set Mouse Offset
            mouseOffset = new Vector2i(MouseX, MouseY);
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
            /* Update Image Positions */
            Nose.X = MouseX;
            Nose.sprite.Position = new Vector2f(Nose.X, 300 + Nose.Y);
            Shoulder.Move();
            Shoulder.sprite.Position = new Vector2f(Shoulder.X,0);
            /* Draw Images */
            window.Draw(BG); //Background
            window.Draw(Shoulder.sprite); //Shoulder
            window.Draw(Nose.sprite); //Nose
            window.Draw(Overlay);
            //If Player Lost, Show Reset Screen
            if (isFailure && !isFirstRun)
            {
                window.Draw(failScreen);
            }
            else
            {
                isFirstRun = false;
                finalScore = Nose.Touches;
            }
            //Draw Score
            window.Draw(new Text("Score: " + finalScore, font));
            Console.Clear();
            //Ouput Variables
            Console.WriteLine("Nose Position: " + Nose.X);
            Console.WriteLine("Shoulder Sensitivity: " + Shoulder.Sensitivity);
            Console.WriteLine("Shoulder Speed: " + Shoulder.Speed);
            Console.WriteLine("Touches: " + Nose.Touches);
            //Check If Player Lost
            if (isTooFar())
            {
                Console.WriteLine("Too Far!");
                Nose.Touches = 0;
                isFailure = true;
            }
            //Check If Player Is Touching Shoulder
            if (isTouching())
            {
                Console.WriteLine("You are touching him!");
                Nose.Touches++;
                Shoulder.Sensitivity -= .1f;
                new Music("Content/ScoreUp.ogg").Play();
            }
        }
        public void MouseInput(object sender, MouseMoveEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }
        public void Reset(object sender, KeyEventArgs e)
        {
            isFailure = false;
            window.InternalSetMousePosition(new Vector2i(650,300));
            Shoulder.Sensitivity = 10;
        }
        public static bool isTouching()
        {
            if( Nose.X < 484 + Shoulder.X + 5 && Nose.X > 484 + Shoulder.X - 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isTooFar()
        {
            if(Nose.X < 484 - Shoulder.Sensitivity + Shoulder.X)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
