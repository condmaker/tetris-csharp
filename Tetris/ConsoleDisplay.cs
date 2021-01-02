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

            Console.Clear();
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

        public void UpdateScene(Scene scene)
        {
            if (scene is Board)
            {
                Board board;
                board = scene as Board;

                short a = 0;

                for (int x = 0; x < board.Width; x++)
                {
                    for (int y = 0; y < board.Height; y++)
                    {
                        screen[((screen.xDim / 2) - board.Width) + a, (
                            (screen.yDim / 2) - (board.Height / 2)) + y]
                                = board.BoardMatrix[x, y];

                        screen[((screen.xDim / 2) - board.Width) + a + 1, (
                            (screen.yDim / 2) - (board.Height / 2)) + y] 
                                = board.BoardMatrix[x, y];
                    }
                    a += 2;
                }

                a += 4;

                for (int y = 0; y < board.NextPiece.Definition.Count; y++)
                {
                    screen[((screen.xDim / 2) - board.Width) + a + 
                        board.NextPiece.Definition[y].x, (
                            (screen.yDim / 2) - (board.Height / 2)) 
                                + board.NextPiece.Definition[y].y] 
                                    = board.NextPiece.sprite;
                }

                a += 4;

                screen[((screen.xDim / 2) - board.Width) + a,
                    (screen.yDim / 2) - (board.Height / 2)] = new Pixel(c:'N');
                screen[((screen.xDim / 2) - board.Width) + a,
                    (screen.yDim / 2) - (board.Height / 2) + 1] 
                        = new Pixel(c:'E');
                screen[((screen.xDim / 2) - board.Width) + a,
                    (screen.yDim / 2) - (board.Height / 2) + 2] 
                        = new Pixel(c:'X');
                screen[((screen.xDim / 2) - board.Width) + a,
                    (screen.yDim / 2) - (board.Height / 2) + 3] 
                        = new Pixel(c:'T');   

            }
            else if (scene is TitleScreen)
            {
                TitleScreen titleScreen;
                titleScreen = scene as TitleScreen;

                switch (titleScreen.CursorPos)
                {
                    case true:
                        TitleScreen(Dir.Up);
                        break;
                    case false:
                        TitleScreen(Dir.Down);
                        break;
                    default:
                        break;
                }
            }
            else if (scene is Tutorial)
            {
                Tutorial tutorial;
                tutorial = scene as Tutorial;
                
                for (int x = 0; x < screen.xDim; x++)
                    for (int y = 0; y < screen.yDim; y++)
                        screen[x, y] = new Pixel(ConsoleColor.Black);

                Console.SetCursorPosition((screen.xDim / 2) - 9
                    , (screen.yDim / 2) - 6);

                Console.Write("Welcome to TETRIS!");

                Console.SetCursorPosition((screen.xDim / 2) - 29
                    , (screen.yDim / 2) - 4);

                Console.Write("This tutorial will teach you how to play and ");
                Console.Write("control the game.");

                Console.SetCursorPosition(screen.xDim / 2 - 32
                    , screen.yDim / 2 - 2);

                Console.Write("Use the WASD keys or the keyboard arrows to ");
                Console.Write("move the pieces around.");

                Console.SetCursorPosition(screen.xDim / 2 - 26
                    , screen.yDim / 2);

                Console.Write("A and D (or ← and →) will move the piece left ");
                Console.Write("and right.");

                Console.SetCursorPosition(screen.xDim / 2 - 34
                    , screen.yDim / 2 + 2);

                Console.Write("W (or ↑) will rotate the piece, while S (or ↓)");
                Console.Write(" will make it go down faster.");

                Console.SetCursorPosition(screen.xDim / 2 - 44
                    , screen.yDim / 2 + 4);

                Console.Write("You can press the ESCAPE key to leave at ");
                Console.Write("anytime, and press ENTER to return to the ");
                Console.Write("main menu.");
            }

        }

        public void Finish()
        {
            for (int x = 0; x < screen.xDim; x++)
                    for (int y = 0; y < screen.yDim; y++)
                        screen[x, y] = new Pixel(ConsoleColor.Black);
            
            screen[(screen.xDim / 2) - 6, (screen.yDim / 2)] = new Pixel(c:'T');
            screen[(screen.xDim / 2) - 5, (screen.yDim / 2)] = new Pixel(c:'H');
            screen[(screen.xDim / 2) - 4, (screen.yDim / 2)] = new Pixel(c:'A');
            screen[(screen.xDim / 2) - 3, (screen.yDim / 2)] = new Pixel(c:'N');
            screen[(screen.xDim / 2) - 2, (screen.yDim / 2)] = new Pixel(c:'K');
            screen[(screen.xDim / 2) - 1, (screen.yDim / 2)] = new Pixel(c:'S');

            screen[(screen.xDim / 2) + 1, (screen.yDim / 2)] = new Pixel(c:'F');
            screen[(screen.xDim / 2) + 2, (screen.yDim / 2)] = new Pixel(c:'O');
            screen[(screen.xDim / 2) + 3, (screen.yDim / 2)] = new Pixel(c:'R');

            screen[(screen.xDim / 2) + 5, (screen.yDim / 2)] = new Pixel(c:'P');
            screen[(screen.xDim / 2) + 6, (screen.yDim / 2)] = new Pixel(c:'L');
            screen[(screen.xDim / 2) + 7, (screen.yDim / 2)] = new Pixel(c:'A');
            screen[(screen.xDim / 2) + 8, (screen.yDim / 2)] = new Pixel(c:'Y');
            screen[(screen.xDim / 2) + 9, (screen.yDim / 2)] = new Pixel(c:'I');
            screen[(screen.xDim / 2) + 10, (screen.yDim / 2)] = new Pixel(
                c:'N');
            screen[(screen.xDim / 2) + 11, (screen.yDim / 2)] = new Pixel(
                c:'G');

            Render();

            Console.SetCursorPosition(screen.xDim - 1, screen.yDim - 1);
            Console.CursorVisible = true;
        }

        public void Render()
        {
            Console.SetCursorPosition(0,0);
            screen.PrintToScreen();
        }
    }
}