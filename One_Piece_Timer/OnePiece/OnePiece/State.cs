using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OnePiece
{
    abstract class State
    {
        public abstract void Dispose();
        public abstract void Initialize();
        public abstract void Draw(SpriteBatch spritebatch);
        public abstract Estates Update(GameTime gametime);
    }
}
