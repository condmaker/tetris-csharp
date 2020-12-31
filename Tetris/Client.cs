using System;
using System.Threading;

namespace Tetris
{
    public class Client
    {
        private bool running;
        private Object inputLock; 
        private ConsoleKey inputKey;
        private Board board;
        private Thread inputThread;
        private Dir dir;

        // TODO piece?

        public Client()
        {
            inputThread = new Thread(ReadKey);
            inputLock = new Object();
            board = new Board();

            Console.CursorVisible = false;
            Console.Clear();
            board = new Board();
        }

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
                //board.DeleteCompleteLines();
                // update score
                // render
                UI.Render();
                // sleep                
            }

            Finish();
        }

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

        private void Finish()
        {
            inputThread.Join();
            Console.CursorVisible = true;
        }


    }
}