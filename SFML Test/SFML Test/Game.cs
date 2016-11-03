using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SFML_Test
{
    abstract class Game
    {
        protected RenderWindow Window;
        protected Color ClearColor;

        protected Game(uint width, uint height, string title, Color ClearColor)
        {
            this.Window = new RenderWindow(new VideoMode(width, height),title, Styles.Close);
            this.ClearColor = ClearColor;

            Window.Closed += OnClosed;
        }

       

        public void Run()
        {
            LoadContent();
            Initialize();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Tick();

                Window.Clear(ClearColor);
                Render();
                Window.Display();
            }

        }

        protected abstract void LoadContent();
        protected abstract void Initialize();

        protected abstract void Tick();
        protected abstract void Render();

        private void OnClosed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
