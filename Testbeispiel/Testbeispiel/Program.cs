using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbeispiel
{
    class Program
    {

       public static void Main()
        {

            // Create window
            RenderWindow window = new RenderWindow(new VideoMode(1600, 1200), "Hello SFML.Net!", Styles.Close, new ContextSettings(0, 0, 0));
            window.SetVerticalSyncEnabled(true);
            window.SetActive();

            // Setup event handlers
           window.Closed += new EventHandler(OnClosed);
           //window.KeyPressed += new EventHandler <keyeventargs> (OnKeyPressed) ;
            //</ keyeventargs>
            window.KeyPressed += new EventHandler<KeyEventArgs> (OnKeyPressed);
            
            // Create objects to draw
            
            RectangleShape rect = new RectangleShape(new Vector2f(600, 400));
            rect.Origin = 0.5f * rect.Size;
            rect.Position = new Vector2f(800, 600);

            Text text = new Text("Hello SFML.Net!", new Font(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "/arial.ttf"), 24);
            text.Position = new Vector2f(800, 600);
            text.Origin = rect.Origin;
            text.Color = Color.Black;

            // Set up timing
            Clock clock = new Clock();
            float delta = 0.0f;


            while (window.IsOpen)
            {
                // Update objects
                delta = clock.Restart().AsSeconds();
                rect.Rotation = rect.Rotation + 15 * delta;
                text.Rotation = rect.Rotation;
                window.DispatchEvents();

                // Display objects
                window.Clear(new Color((byte)50, (byte)180, (byte)50));
                window.Draw(rect);
                window.Draw(text);
                window.Display();
            }

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

        /// <summary>
        /// Function called when a key is pressed
        /// </summary>
        static void OnKeyPressed(object sender, KeyEventArgs k)
        {
            RenderWindow window = (RenderWindow)sender;
            if (k.Code == Keyboard.Key.Escape)
                window.Close();
            
        }
        
            
         

    }
}
