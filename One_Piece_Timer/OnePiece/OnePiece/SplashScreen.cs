using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OnePiece
{
    class SplashScreen : State
    {
       Texture2D Splashtexture;
        Timer timer;


        public SplashScreen (Texture2D splashtexture)
        {
            Splashtexture = splashtexture;
            
        }

        public override void Dispose()
        {
            
        }
        public override void Initialize ()
        {
            timer = new Timer();
        }

        public override Estates Update (GameTime gametime)
        {
            timer.Update(gametime);
            if (timer.Current.Seconds >= 2)
            {
                return Estates.Menu;
            }
            return Estates.Splashscreen;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();
            spritebatch.Draw(Splashtexture, new Vector2(), Color.White);
            spritebatch.End();
        }
    }
}
