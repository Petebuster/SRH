using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnePiece
{
    class Tiles
    {
        protected Texture2D MapTexture;
        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }


        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(MapTexture, rectangle, Color.White);
        }
    }
        class CollisionTiles : Tiles
        {
            public CollisionTiles(int i, Rectangle newRectangle)
            {
                MapTexture = Content.Load<Texture2D>("Tile" + i);
                Rectangle = newRectangle;
            }

        }
    }
