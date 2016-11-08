using System;

namespace OnePiece
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Statemachine game = new Statemachine())
            {
                game.Run();
            }
        }
    }
#endif
}

