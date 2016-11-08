using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnePiece
{
    class Healthbar
    {
        Texture2D healthbartexture;
        Rectangle rectangle;
        Vector2 position;
        int health = 3;


        public Healthbar(Texture2D healthbartexture/*, Rectangle rectangle*/)
        {
            this.healthbartexture = healthbartexture;
            position = new Vector2(50,50);
            rectangle = new Rectangle(0,0,healthbartexture.Width, healthbartexture.Height);
        }

        private void UpdateHealth()
        {
            //if (health == 3)
            //{
            //    rectangle.Width = rectangle.Width * 1;
            //}

            //if (health == 66)
            //{
            //    rectangle.Width = rectangle.Width / 3 * 2;
            //}

            //if (health == 33)
            //{
            //    rectangle.Width = rectangle.Width / 3;
            //}

            rectangle.Width = (int)(healthbartexture.Width * (health/3f));
        }

        public void DecreaseHealth()
        {
            health--;
        }

        public void Update(GameTime gameTime)
        {
            UpdateHealth();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            
            spritebatch.Draw(healthbartexture, position, rectangle, Color.White);
            
        }

    }
}
