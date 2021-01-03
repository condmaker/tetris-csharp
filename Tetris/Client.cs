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
        /// Instance variable for the Thread responsible for reading the user 
        /// input.
        /// </summary>
        private readonly Thread inputThread;

        /// <summary>
        /// Instance variable for the Thread responsible for making the pieces 
        /// fall .
        /// </summary>
        private readonly Thread FallTimerThread;

        /// <summary>
        /// Readonly variable that defines the game speed.
        /// <remarks>Bigger values are slower.</remarks>
        /// </summary>
        private readonly int GameSpeed = 50;

        /// <summary>
        /// Readonly variable that defines the acceleration of the falling 
        /// speed.
        /// <remarks>Bigger values are faster.</remarks>
        /// </summary>
        private readonly float GameDificultyAccel = 0.3f;

        /// <summary>
        /// Readonly variable that defines the maximum speed of falling pieces.
        /// </summary>
        private readonly int MaxGameDifSpeed = 130;

        /// <summary>
        /// Instance variable that controls if the game is running or ends.
        /// </summary>
        private bool running;

        /// <summary>
        /// Instance variable that controls the current piece falling speed.
        /// <remarks>Bigger values are slower.</remarks>
        /// </summary>
        private float gameDifSpeed;

        /// <summary>
        /// Instance variable to control access to critical sections.
        /// </summary>
        private object inputLock;

        /// <summary>
        /// Instance variable to control access to critical sections.
        /// </summary>
        private object fallTimerLock;

        /// <summary>
        /// Instance variable that tells whether the current frame should make 
        /// the piece fall.
        /// </summary>
        private bool isFallFrame;

        /// <summary>
        /// Instance variable which stores the last key pressed by the user 
        /// since the last update.
        /// </summary>
        private ConsoleKey inputKey;

        /// <summary>
        /// Instance variable of the possible program Scenes.
        /// </summary>
        private Scene currentScene;

        /// <summary>
        /// Instance variable of the game scene.
        /// </summary>
        private Board board;

        /// <summary>
        /// Instance variable of the title scene.
        /// </summary>
        private TitleScreen title;

        /// <summary>
        /// Instance variable of the tutorial scene.
        /// </summary>
        private Tutorial tutorial;

        /// <summary>
        /// Instance variable which stores Direction of movement.
        /// </summary>
        private Dir dir;

        /// <summary>
        /// Creates a new Client instance.
        /// <remarks>Starts 2 threads.</remarks>
        /// </summary>
        public Client()
        {
            inputThread = new Thread(ReadKey);
            FallTimerThread = new Thread(FallTimer);

            inputLock = new object();
            fallTimerLock = new object();
            
            title = new TitleScreen();
            board = new Board();
            tutorial = new Tutorial();

            title.SetScenes(new Scene[] { board, tutorial });
            board.SetScenes(title);
            tutorial.SetScenes(title);

            currentScene = title;

            board = new Board();

            gameDifSpeed = 300;
            isFallFrame = false;
        }

        /// <summary>
        /// Main game loop.
        /// </summary>
        public void GameLoop()
        {
            IDisplay ui = new ConsoleDisplay();
            running = true;

            inputThread.Start();
            FallTimerThread.Start();

            while (running)
            {
                // read direction
                ProcessInput(); 

                // move piece down
                lock (fallTimerLock)
                {
                    if (isFallFrame && currentScene is Board)
                    {
                        FallPiece();
                        isFallFrame = false;
                    }   
                }
                
                // update piece
                currentScene.Update(dir);
                currentScene = currentScene.UpdateScene();

                // UI.TitleScreen(dir);
                ui.UpdateScene(currentScene);
                
                // reset direction
                dir = Dir.None;   
                
                // render
                ui.Render();
                Thread.Sleep(GameSpeed);
            }

            Finish(ui);
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
                lock (inputLock)
                {
                    inputKey = ck;
                }
            } while (ck != ConsoleKey.Escape);
        }

        /// <summary>
        /// Method responsible for moving the piece down.
        /// </summary>
        private void FallPiece()
        {
            currentScene.Update(Dir.Down);   
        }

        /// <summary>
        /// Method responsible for controlling the natural fall speed.
        /// </summary>
        private void FallTimer()
        {
            while(running)
            {
                lock (fallTimerLock)
                {
                    isFallFrame = true;
                }

                if (gameDifSpeed >= MaxGameDifSpeed)
                    gameDifSpeed -= GameDificultyAccel;

                Thread.Sleep((int)Math.Ceiling(gameDifSpeed));
            }
            
        }

        /// <summary>
        /// Reads the last key press stored and updates the direction of 
        /// movement or exits the game accordingly.
        /// </summary>
        private void ProcessInput()
        {
            ConsoleKey key;
            lock (inputLock)
            {
                key = inputKey;
                inputKey = ConsoleKey.NoName;
            }

            switch (key)
            {
                case ConsoleKey.W:
                    dir = Dir.Up;
                    break;
                case ConsoleKey.S:
                    if (currentScene is Board)
                        dir = Dir.Fall;
                    else
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
        private void Finish(IDisplay ui)
        {
            inputThread.Join();
            FallTimerThread.Join();
            ui.Finish();
        }
    }
}