using System;
using System.Threading;

namespace Tetris
{
    /// <summary>
    /// Client class with game loop.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Instance variable that controls if the game is running or ends.
        /// </summary>
        private bool running;

        /// <summary>
        /// Instance variable to control access to critical sections.
        /// </summary>
        private Object inputLock; 

        /// <summary>
        /// Instance variable which stores the last key pressed by the user 
        /// since the last update.
        /// </summary>
        private ConsoleKey inputKey;

        /// <summary>
        /// Instance variable of the game board.
        /// </summary>
        private Board board;

        /// <summary>
        /// Instance variable for the Thread responsible for reading the user 
        /// input.
        /// </summary>
        private Thread inputThread;

        /// <summary>
        /// Instance variable which stores Direction of movement.
        /// </summary>
        private Dir dir;

        // TODO piece?

        /// <summary>
        /// Creates a new Client instance
        /// </summary>
        public Client()
        {
            inputThread = new Thread(ReadKey);
            inputLock = new Object();
            board = new Board();

            Console.CursorVisible = false;
            Console.Clear();
            board = new Board();
        }

        /// <summary>
        /// Main game loop.
        /// </summary>
        public void GameLoop()
        {
            IDisplay UI = new ConsoleDisplay();
            running = true;
            inputThread.Start();

            while(running)
            {
                // read direction
                ProcessInput();                
                // update piece
                //UI.TitleScreen(dir);
                UI.UpdateBoard(board);
                // reset direction
                dir = Dir.None;
                // check  and delete lines
                board.DeleteCompleteLines();
                // update score
                // render
                UI.Render();
                // sleep
                
                while(dir != Dir.Down)
                {
                    Console.WriteLine(dir);
                }

            }

            Finish();
        }

        /// <summary>
        /// Reads key presses and stores the last one pressed in the instance 
        /// variable.
        /// </summary>
        private void ReadKey()
        {
            ConsoleKey ck;
            do
            {
                ck = Console.ReadKey(true).Key;
                lock(inputLock)
                {
                    inputKey = ck;
                }
            } while (ck != ConsoleKey.Escape);
        }

        /// <summary>
        /// Reads the last key press stored and updates the direction of 
        /// movement or exits the game accordingly.
        /// </summary>
        private void ProcessInput()
        {
            ConsoleKey key;
            lock(inputLock)
            {
                key = inputKey;
            }
            switch(key)
            {
                case ConsoleKey.W:
                    dir = Dir.Up;
                    break;
                case ConsoleKey.S:
                    dir = Dir.Down;
                    break;
                case ConsoleKey.A:
                    dir = Dir.Left;
                    break;
                case ConsoleKey.D:
                    dir = Dir.Right;
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
                default:
                    dir = Dir.None;
                    break;
            }
        }

        /// <summary>
        /// Method responsible for cleanup before the program ends.
        /// </summary>
        private void Finish()
        {
            inputThread.Join();
            Console.CursorVisible = true;
        }


    }
}