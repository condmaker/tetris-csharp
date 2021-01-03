using System;

namespace Tetris
{
    /// <summary>
    /// The Title Screen scene. Can enter the game itself and the tutorial.
    /// </summary>
    public class TitleScreen : Scene
    {
        /// <summary>
        /// The position of the cursor. It only has two of them.
        /// </summary>
        /// <value>If the value is true, it points to the game, if it is 
        /// false, it points to the tutorial.</value>
        public bool CursorPos { get; private set; }

        /// <summary>
        /// Class constructor. Initializes the scenes array.
        /// </summary>
        public TitleScreen()
        {
            Scenes = new Scene[2];
            SceneChange = false;
            CursorPos = true;
        }

        /// <summary>
        /// Updates the scene status according to the user's input.
        /// </summary>
        /// <param name="input">The user's input.</param>
        public override void Update(Dir input)
        {
            switch (input)
            {
                case Dir.Up:
                    CursorPos = true;
                    break;
                case Dir.Down:
                    CursorPos = false;
                    break;
                case Dir.Enter:
                    SceneChange = true;
                    break;
            }
        }

        /// <summary>
        /// Changes scenes if the user selected any of them.
        /// </summary>
        /// <returns>A new scene or itself, in case the user inputted
        /// nothing.</returns>
        public override Scene UpdateScene()
        {
            if (SceneChange)
            {
                SceneChange = false;

                if (CursorPos) 
                    return Scenes[0];
                else if (!CursorPos) 
                    return Scenes[1];
            }
            
            return this;
        }
    }
}