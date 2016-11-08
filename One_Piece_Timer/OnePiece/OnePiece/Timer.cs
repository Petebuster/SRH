using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OnePiece
{
    class Timer
    {
        TimeSpan time;

        public TimeSpan Current { get { return this.time; } }
        public void Update(GameTime gametime)
        {
            time += gametime.ElapsedGameTime;
        }
        public Timer()
        {
            Reset();
        }
        public void Reset()
        {
            this.time = new TimeSpan();
        }
    }
}

