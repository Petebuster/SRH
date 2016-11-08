using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnePiece
{
    class GameBackground
    {
        Texture2D Backgroundtexture;

        public GameBackground(Texture2D backgroundtexture)
        {
            Backgroundtexture = backgroundtexture;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Backgroundtexture, new Rectangle(0, 0, Camera.Main.Bounds.Width, Camera.Main.Bounds.Height), Color.White);
        }
    }
}
