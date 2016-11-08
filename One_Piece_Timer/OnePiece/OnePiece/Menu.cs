using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace OnePiece
{
    class Menu : State
    {
        Estates targetState;
        Texture2D Menutexture;
        MenuButtons menubuttons;


        public Menu(Texture2D menutexture, Texture2D playbutton)
        {
            Menutexture = menutexture;
            menubuttons = new MenuButtons(50, 30, playbutton);
        }



        public override void Dispose()
        {

        }

        public override void Initialize()
        {
            targetState = Estates.Menu;
        }

        public override Estates Update(GameTime gameTime)
        {
            if (menubuttons.Update())
                targetState = Estates.Gameplay;
                return targetState;
        }




        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();
            spritebatch.Draw(Menutexture, new Vector2(), Color.White);
            menubuttons.Draw(spritebatch);
            spritebatch.End();
        }
    }
}
