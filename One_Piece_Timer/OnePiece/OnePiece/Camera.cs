using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnePiece
{
    /*class Camera
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }

        private Vector2 centre;
        private Viewport Viewport;

        public Camera (Viewport viewport)
        {
            Viewport = viewport;
        }

        public void Update (Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < Viewport.Width / 2)
                centre.X = Viewport.Width / 2;
            else if (position.X > xOffset - (Viewport.Width / 2))
                centre.X = xOffset - (Viewport.Width / 2);
            else centre.X = position.X;

            if (position.Y < Viewport.Height / 2)
                centre.Y = Viewport.Height / 2;
            else if (position.Y > yOffset - (Viewport.Height / 2))
                centre.Y = yOffset - (Viewport.Height / 2);
            else centre.Y = position.Y;

            transform = Matrix.CreateTranslation(new Vector3(-centre.X + (Viewport.Width / 2),
                                                             -centre.Y + (Viewport.Height / 2), 0));
        }


    }*/
}
