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


        /// The 3 scenes.
        private Scene currentScene;
        /// <summary>
        /// Instance variable of the game board.
        /// </summary>
        private Board board;
        private TitleScreen title;
        private Tutorial tutorial;

        /// <summary>
        /// Instance variable for the Thread responsible for reading the user 
        /// input.
        /// </summary>
        private Thread inputThread;

        /// <summary>
        /// Instance variable which stores Direction of movement.
        /// </summary>
        private Dir dir;

        /// <summary>
        /// Creates a new Client instance
        /// </summary>
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
                currentScene.Update(dir);
                currentScene = currentScene.UpdateScene();
                //UI.TitleScreen(dir);
                UI.UpdateScene(currentScene);
                // reset direction
                dir = Dir.None;
                // check  and delete lines              
                // update score
                // render
                UI.Render();
                // sleep         
                Thread.Sleep(100);       
            }

            Finish(UI);
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
                case ConsoleKey.E:
                    dir = Dir.Rot;
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
        private void Finish(IDisplay UI)
        {
            inputThread.Join();
            UI.Finish();
        }


    }
}