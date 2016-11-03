using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace SFML_Test
{
    static class Program
    {

        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void Main()
        {
            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(640, 480), "SFML Works!");
            app.Closed += new EventHandler(OnClose);

            Color windowColor = new Color(20, 192, 0);

            // Start the game loop
            while (app.IsOpen)
            {
                // Process events
                app.DispatchEvents();

                // Clear screen
                app.Clear(windowColor);
                 
                // Update the window
                app.Display();
            } //End game loop
        } //End Main()
    } //End Program
}