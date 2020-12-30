using System;
using System.Threading;

namespace Tetris
{
    /// <summary>
    /// Contains the main game loop.
    /// </summary>
    public class Client
    {
        public Client()
        {
            Console.Clear();
        }

        // The main game loop.
        public void Run()
        {
            bool running = true;
            IDisplay UI = new ConsoleDisplay();

            Thread inputThread = new Thread(UI.InputRead);
            inputThread.Start();

            // Everything
            while (running)
            {
                // Delta Time stuffs, we're implementing fixed version
                // Process the player input, can grab it from UI.Input
                // GameUpdate.Update();

                UI.TitleScreen();

                ConsoleKey key;
                if (UI.Input.TryTake(out key))
                {
                    switch (key)
                    {
                        case ConsoleKey.W:
                            UI.CursorUp();
                            break;
                        case ConsoleKey.S:
                            UI.CursorDown();
                            break;
                        case ConsoleKey.Escape:
                            running = false;
                            break;

                    }
                }

                UI.Render();
            }

            Console.ReadKey(true);
            inputThread.Join();
            Console.CursorVisible = true;
        }
    }
}