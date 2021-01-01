using System;
using System.Threading;

namespace Tetris
{
    public class Client
    {
        private bool running;
        private Object inputLock; 
        private ConsoleKey inputKey;

        /// The 3 scenes.
        private Scene currentScene;
        private Board board;
        private TitleScreen title;
        private Tutorial tutorial;

        private Thread inputThread;
        private Dir dir;

        // TODO piece?

        public Client()
        {
            inputThread = new Thread(ReadKey);
            inputLock = new Object();
            
            title = new TitleScreen();
            board = new Board();
            tutorial = new Tutorial();

            title.SetScenes(new Scene[] {board, tutorial});
            board.SetScenes(title);
            tutorial.SetScenes(title);

            currentScene = title;

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
                currentScene.Update(dir);
                currentScene = currentScene.UpdateScene();
                //UI.TitleScreen(dir);
                UI.UpdateScene(currentScene);
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
                inputKey = ConsoleKey.NoName;
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
                case ConsoleKey.Enter:
                    dir = Dir.Enter;
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