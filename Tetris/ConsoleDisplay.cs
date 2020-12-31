using System;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;

namespace Tetris
{
    /// <summary>
    /// A class that can represent game information to the player on a console.
    /// </summary>
    public class ConsoleDisplay : IDisplay
    {
        private DoubleBuffer2D screen;

        public ConsoleDisplay()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.CursorVisible = false;
                Console.SetWindowSize(110, 40);
            }
            Console.Title = "TETRIS";

            // Needs to be even. Otherwise screen won't be aligned.
            screen = new DoubleBuffer2D(
                Console.WindowWidth, Console.WindowHeight);

            Console.SetCursorPosition(0,0);
        }

        public void TitleScreen(Dir dir)
        {
            // T
            screen[((screen.xDim / 2) - 13), 4] = new Pixel(ConsoleColor.Red);
            screen[((screen.xDim / 2) - 12), 4] = new Pixel(ConsoleColor.Red);
            screen[((screen.xDim / 2) - 11), 4] = new Pixel(ConsoleColor.Red);
            screen[((screen.xDim / 2) - 11), 5] = new Pixel(ConsoleColor.Red);
            screen[((screen.xDim / 2) - 11), 6] = new Pixel(
                ConsoleColor.DarkRed);
            screen[((screen.xDim / 2) - 11), 7] = new Pixel(
                ConsoleColor.DarkRed);
            screen[((screen.xDim / 2) - 11), 8] = new Pixel(
                ConsoleColor.DarkRed);
            screen[((screen.xDim / 2) - 10), 4] = new Pixel(ConsoleColor.Red);
            screen[((screen.xDim / 2) - 9), 4] = new Pixel(ConsoleColor.Red);

            // E
            screen[((screen.xDim / 2) - 7), 4] = new Pixel(ConsoleColor.White);
            screen[((screen.xDim / 2) - 7), 5] = new Pixel(ConsoleColor.White);
            screen[((screen.xDim / 2) - 7), 6] = new Pixel(ConsoleColor.Gray);
            screen[((screen.xDim / 2) - 7), 7] = new Pixel(ConsoleColor.Gray);
            screen[((screen.xDim / 2) - 7), 8] = new Pixel(ConsoleColor.Gray);
            screen[((screen.xDim / 2) - 6), 4] = new Pixel(ConsoleColor.White);
            screen[((screen.xDim / 2) - 6), 6] = new Pixel(ConsoleColor.Gray);
            screen[((screen.xDim / 2) - 6), 8] = new Pixel(ConsoleColor.Gray);
            screen[((screen.xDim / 2) - 5), 4] = new Pixel(ConsoleColor.White);
            screen[((screen.xDim / 2) - 5), 6] = new Pixel(ConsoleColor.Gray);
            screen[((screen.xDim / 2) - 5), 8] = new Pixel(ConsoleColor.Gray);

            // T
            screen[((screen.xDim / 2) - 3), 4] = new Pixel(ConsoleColor.Yellow);
            screen[((screen.xDim / 2) - 2), 4] = new Pixel(ConsoleColor.Yellow);
            screen[((screen.xDim / 2) - 1), 4] = new Pixel(ConsoleColor.Yellow);
            screen[((screen.xDim / 2) - 1), 5] = new Pixel(ConsoleColor.Yellow);
            screen[((screen.xDim / 2) - 1), 6] = new Pixel(
                ConsoleColor.DarkYellow);
            screen[((screen.xDim / 2) - 1), 7] = new Pixel(
                ConsoleColor.DarkYellow);
            screen[((screen.xDim / 2) - 1), 8] = new Pixel(
                ConsoleColor.DarkYellow);
            screen[(screen.xDim / 2), 4] = new Pixel(ConsoleColor.Yellow);
            screen[((screen.xDim / 2) + 1), 4] = new Pixel(ConsoleColor.Yellow);

            // R
            screen[((screen.xDim / 2) + 3), 4] = new Pixel(ConsoleColor.Green);
            screen[((screen.xDim / 2) + 3), 5] = new Pixel(ConsoleColor.Green);
            screen[((screen.xDim / 2) + 3), 6] = new Pixel(
                ConsoleColor.DarkGreen);
            screen[((screen.xDim / 2) + 3), 7] = new Pixel(
                ConsoleColor.DarkGreen);
            screen[((screen.xDim / 2) + 3), 8] = new Pixel(
                ConsoleColor.DarkGreen);
            screen[((screen.xDim / 2) + 4), 4] = new Pixel(ConsoleColor.Green);
            screen[((screen.xDim / 2) + 4), 6] = new Pixel(
                ConsoleColor.DarkGreen);
            screen[((screen.xDim / 2) + 5), 5] = new Pixel(ConsoleColor.Green);
            screen[((screen.xDim / 2) + 5), 7] = new Pixel(
                ConsoleColor.DarkGreen);
            screen[((screen.xDim / 2) + 5), 8] = new Pixel(
                ConsoleColor.DarkGreen);

            // I
            screen[((screen.xDim / 2) + 7), 4] = new Pixel(ConsoleColor.Blue);
            screen[((screen.xDim / 2) + 7), 5] = new Pixel(ConsoleColor.Blue);
            screen[((screen.xDim / 2) + 7), 6] = new Pixel(
                ConsoleColor.DarkBlue);
            screen[((screen.xDim / 2) + 7), 7] = new Pixel(
                ConsoleColor.DarkBlue);
            screen[((screen.xDim / 2) + 7), 8] = new Pixel(
                ConsoleColor.DarkBlue);

            // S
            screen[((screen.xDim / 2) + 9), 5] = new Pixel(
                ConsoleColor.Magenta);
            screen[((screen.xDim / 2) + 9), 8] = new Pixel(
                ConsoleColor.DarkMagenta);
            screen[((screen.xDim / 2) + 10), 4] = new Pixel(
                ConsoleColor.Magenta);
            screen[((screen.xDim / 2) + 10), 6] = new Pixel(
                ConsoleColor.DarkMagenta);
            screen[((screen.xDim / 2) + 10), 8] = new Pixel(
                ConsoleColor.DarkMagenta);
            screen[((screen.xDim / 2) + 11), 4] = new Pixel(
                ConsoleColor.Magenta);
            screen[((screen.xDim / 2) + 11), 6] = new Pixel(
                ConsoleColor.DarkMagenta);
            screen[((screen.xDim / 2) + 11), 8] = new Pixel(
                ConsoleColor.DarkMagenta);
            screen[((screen.xDim / 2) + 12), 4] = new Pixel(
                ConsoleColor.Magenta);
            screen[((screen.xDim / 2) + 12), 7] = new Pixel(
                ConsoleColor.DarkMagenta);

            if (dir == Dir.Down)
            {
                screen[(screen.xDim / 2) - 6, (screen.yDim / 2) + 12] = new Pixel(
                c:' ');
                screen[(screen.xDim / 2) - 6, (screen.yDim / 2) + 13] = new Pixel(
                c:'→');
            }
            else if (dir == Dir.Up)
            {
                screen[(screen.xDim / 2) - 6, (screen.yDim / 2) + 12] = new Pixel(
                c:'→');
                screen[(screen.xDim / 2) - 6, (screen.yDim / 2) + 13] = new Pixel(
                c:' ');
            }
            // → START GAME
            screen[(screen.xDim / 2) - 4, (screen.yDim / 2) + 12] = new Pixel(
                c:'S');
            screen[(screen.xDim / 2) - 3, (screen.yDim / 2) + 12] = new Pixel(
                c:'T');
            screen[(screen.xDim / 2) - 2, (screen.yDim / 2) + 12] = new Pixel(
                c:'A');
            screen[(screen.xDim / 2) - 1, (screen.yDim / 2) + 12] = new Pixel(
                c:'R');
            screen[(screen.xDim / 2), (screen.yDim / 2) + 12] = new Pixel(
                c:'T');
            screen[(screen.xDim / 2) + 2, (screen.yDim / 2) + 12] = new Pixel(
                c:'G');
            screen[(screen.xDim / 2) + 3, (screen.yDim / 2) + 12] = new Pixel(
                c:'A');
            screen[(screen.xDim / 2) + 4, (screen.yDim / 2) + 12] = new Pixel(
                c:'M');
            screen[(screen.xDim / 2) + 5, (screen.yDim / 2) + 12] = new Pixel(
                c:'E');

            screen[(screen.xDim / 2) - 4, (screen.yDim / 2) + 13] = new Pixel(
                c:'T');
            screen[(screen.xDim / 2) - 3, (screen.yDim / 2) + 13] = new Pixel(
                c:'U');
            screen[(screen.xDim / 2) - 2, (screen.yDim / 2) + 13] = new Pixel(
                c:'T');
            screen[(screen.xDim / 2) - 1, (screen.yDim / 2) + 13] = new Pixel(
                c:'O');
            screen[(screen.xDim / 2), (screen.yDim / 2) + 13] = new Pixel(
                c:'R');
            screen[(screen.xDim / 2) + 1, (screen.yDim / 2) + 13] = new Pixel(
                c:'I');
            screen[(screen.xDim / 2) + 2, (screen.yDim / 2) + 13] = new Pixel(
                c:'A');
            screen[(screen.xDim / 2) + 3, (screen.yDim / 2) + 13] = new Pixel(
                c:'L');
        }

        public void UpdateBoard(Board board)
        {
            for (int x = 0; x < board.Width; x++)
                for (int y = 0; y < board.Height; y++)
                    screen[x, y] = board.BoardMatrix[x, y];
        }

        public void Render()
        {
            Console.SetCursorPosition(0,0);
            screen.PrintToScreen();
        }
    }
}