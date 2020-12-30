using System;
using System.Collections.Concurrent;

namespace Tetris
{
    /// <summary>
    /// A class that can represent game information to the player on a console.
    /// </summary>
    public class ConsoleDisplay : IDisplay
    {
        /// <summary>
        /// The general input manager of the game.
        /// </summary>
        /// <value></value>
        public BlockingCollection<ConsoleKey> Input { get; private set; }
        private DoubleBuffer2D screen;

        public ConsoleDisplay()
        {
            int bH = (Console.WindowHeight % 2) == 0 ? Console.WindowHeight + 1
                : Console.WindowHeight - 1;
            int bW = (Console.WindowWidth % 2) == 0 ? Console.WindowWidth - 1
                : Console.WindowWidth - 1;

            // Needs to be even. Otherwise screen won't be aligned.
            screen = new DoubleBuffer2D(bW, bH);

            Input = new BlockingCollection<ConsoleKey>();
        }

        public void TitleScreen()
        {
            // T
            screen[((screen.xDim / 2) - 13), 4] = ConsoleColor.Red;
            screen[((screen.xDim / 2) - 12), 4] = ConsoleColor.Red;
            screen[((screen.xDim / 2) - 11), 4] = ConsoleColor.Red;
            screen[((screen.xDim / 2) - 11), 5] = ConsoleColor.Red;
            screen[((screen.xDim / 2) - 11), 6] = ConsoleColor.DarkRed;
            screen[((screen.xDim / 2) - 11), 7] = ConsoleColor.DarkRed;
            screen[((screen.xDim / 2) - 11), 8] = ConsoleColor.DarkRed;
            screen[((screen.xDim / 2) - 10), 4] = ConsoleColor.Red;
            screen[((screen.xDim / 2) - 9), 4] = ConsoleColor.Red;

            screen[((screen.xDim / 2) - 7), 4] = ConsoleColor.White;
            screen[((screen.xDim / 2) - 7), 5] = ConsoleColor.White;
            screen[((screen.xDim / 2) - 7), 6] = ConsoleColor.Gray;
            screen[((screen.xDim / 2) - 7), 7] = ConsoleColor.Gray;
            screen[((screen.xDim / 2) - 7), 8] = ConsoleColor.Gray;
            screen[((screen.xDim / 2) - 6), 4] = ConsoleColor.White;
            screen[((screen.xDim / 2) - 6), 6] = ConsoleColor.Gray;
            screen[((screen.xDim / 2) - 6), 8] = ConsoleColor.Gray;
            screen[((screen.xDim / 2) - 5), 4] = ConsoleColor.White;
            screen[((screen.xDim / 2) - 5), 6] = ConsoleColor.Gray;
            screen[((screen.xDim / 2) - 5), 8] = ConsoleColor.Gray;

            screen[((screen.xDim / 2) - 3), 4] = ConsoleColor.Yellow;
            screen[((screen.xDim / 2) - 2), 4] = ConsoleColor.Yellow;
            screen[((screen.xDim / 2) - 1), 4] = ConsoleColor.Yellow;
            screen[((screen.xDim / 2) - 1), 5] = ConsoleColor.Yellow;
            screen[((screen.xDim / 2) - 1), 6] = ConsoleColor.DarkYellow;
            screen[((screen.xDim / 2) - 1), 7] = ConsoleColor.DarkYellow;
            screen[((screen.xDim / 2) - 1), 8] = ConsoleColor.DarkYellow;
            screen[(screen.xDim / 2), 4] = ConsoleColor.Yellow;
            screen[((screen.xDim / 2) + 1), 4] = ConsoleColor.Yellow;

            screen[((screen.xDim / 2) + 3), 4] = ConsoleColor.Green;
            screen[((screen.xDim / 2) + 3), 5] = ConsoleColor.Green;
            screen[((screen.xDim / 2) + 3), 6] = ConsoleColor.DarkGreen;
            screen[((screen.xDim / 2) + 3), 7] = ConsoleColor.DarkGreen;
            screen[((screen.xDim / 2) + 3), 8] = ConsoleColor.DarkGreen;
            screen[((screen.xDim / 2) + 4), 4] = ConsoleColor.Green;
            screen[((screen.xDim / 2) + 4), 6] = ConsoleColor.DarkGreen;
            screen[((screen.xDim / 2) + 5), 5] = ConsoleColor.Green;
            screen[((screen.xDim / 2) + 5), 7] = ConsoleColor.DarkGreen;
            screen[((screen.xDim / 2) + 5), 8] = ConsoleColor.DarkGreen;

            screen[((screen.xDim / 2) + 7), 4] = ConsoleColor.Blue;
            screen[((screen.xDim / 2) + 7), 5] = ConsoleColor.Blue;
            screen[((screen.xDim / 2) + 7), 6] = ConsoleColor.DarkBlue;
            screen[((screen.xDim / 2) + 7), 7] = ConsoleColor.DarkBlue;
            screen[((screen.xDim / 2) + 7), 8] = ConsoleColor.DarkBlue;

            screen[((screen.xDim / 2) + 9), 5] = ConsoleColor.Magenta;
            screen[((screen.xDim / 2) + 9), 8] = ConsoleColor.DarkMagenta;
            screen[((screen.xDim / 2) + 10), 4] = ConsoleColor.Magenta;
            screen[((screen.xDim / 2) + 10), 6] = ConsoleColor.DarkMagenta;
            screen[((screen.xDim / 2) + 10), 8] = ConsoleColor.DarkMagenta;
            screen[((screen.xDim / 2) + 11), 4] = ConsoleColor.Magenta;
            screen[((screen.xDim / 2) + 11), 6] = ConsoleColor.DarkMagenta;
            screen[((screen.xDim / 2) + 11), 8] = ConsoleColor.DarkMagenta;
            screen[((screen.xDim / 2) + 12), 4] = ConsoleColor.Magenta;
            screen[((screen.xDim / 2) + 12), 7] = ConsoleColor.DarkMagenta;

            Render();
        }

        public void InputRead()
        {
            ConsoleKey c;

            do
            {
                c = Console.ReadKey(true).Key;

            } while (c != ConsoleKey.Escape);
        }

        public void Render()
        {
            screen.Swap();
            screen.PrintToScreen();
        }
    }
}