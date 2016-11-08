using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Otter;

namespace Bouncing_Ball
{
    class Program
    {
        static void Main()
        {


            Texture Imagen = new Texture("ball.jpg");
            
            Sprite sprite = new Sprite(Imagen);
            sprite.Scale = new Vector2f (0.1f,0.1f);
            sprite.Position = new Vector2f(200, 200);

            
            // Create window
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Bounce", Styles.Close, new ContextSettings(24, 8, 2));
            window.SetVerticalSyncEnabled(true);
            window.SetActive();

            // Setup event handlers
            window.Closed += new EventHandler(OnClosed);
            //window.KeyPressed += new EventHandler <keyeventargs> (OnKeyPressed) ;
            //</ keyeventargs>
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);

            // Set up timing
            Clock clock = new Clock();
            float delta = 0.0f;
            float alpha = 0.0f;
            
            float faktorX = 1f;
            float faktorY = 1f;

            while (window.IsOpen)
            {
                //float seconds = clock.ElapsedTime.AsSeconds();
                //clock.Restart();
                //delta = seconds * faktorX;

                delta = clock.Restart().AsSeconds() * faktorX;
                  alpha = delta / faktorX * faktorY;
               
                  sprite.Position = sprite.Position + new Vector2f(150 * delta, 150 * alpha);
                if (/*sprite.Position.Y > 475*/sprite.Position.Y > window.GetView().Size.Y - (sprite.Texture.Size.Y / 10))
                {
                    faktorX *=  1;
                    faktorY *= -1;
                }
                else if (/*sprite.Position.X < 0*/sprite.Position.X < window.GetView().Size.X - window.GetView().Size.X)
                {
                    faktorX *= -1;
                    faktorY *=  1;
                }
                else if (sprite.Position.Y < 0/*sprite.Position.Y < window.GetView().Size.Y - (sprite.Texture.Size.Y / 10)*/)
                {
                    faktorX *=  1;
                    faktorY *= -1;
                }
                else if (/*sprite.Position.X > 671*/sprite.Position.X > window.GetView().Size.X - (sprite.Texture.Size.X / 10))
                {
                    faktorX *=  -1;
                    faktorY *= 1;
                }
               
                   
                window.DispatchEvents();

                Console.WriteLine(clock.Restart().AsSeconds());
               // Console.WriteLine(window.Size);

                //Display objects
                window.Clear(new Color(50, 180, 50));
                window.Draw(sprite);       
                window.Display();

            }
        }

        static void Update()
        {
           // delta = clock.Restart().AsSeconds();
            //sprite.Position = sprite.Position + new Vector2f(150 * delta, 150 * delta);
        }
        

        private static void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void OnClosed(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
        static void OnKeyPressed(object sender, KeyEventArgs k)
        {
            RenderWindow window = (RenderWindow)sender;
            if (k.Code == Keyboard.Key.Escape)
                window.Close();

        }
    }
}