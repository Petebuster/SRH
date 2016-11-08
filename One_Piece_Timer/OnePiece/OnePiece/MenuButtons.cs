using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnePiece
{
    class MenuButtons
    {
        MouseState currentMousestate;
        MouseState previousMousestate;
        Texture2D Texture;
        Rectangle bounding;


        public bool Update()
        {
            currentMousestate = Mouse.GetState();
            bool Hover =  bounding.Contains(new Point(currentMousestate.X, currentMousestate.Y));
            if (Hover && currentMousestate.LeftButton == ButtonState.Pressed && previousMousestate.RightButton == ButtonState.Released)
                return true;
            previousMousestate = currentMousestate;
            return false;
        }
        
        public MenuButtons(int x, int y, Texture2D texture)
        {
            Texture = texture;
            bounding = new Rectangle(x, y, texture.Width, texture.Height);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, bounding, Color.White);
        }
    }
}
