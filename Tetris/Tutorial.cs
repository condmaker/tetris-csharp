using System;

namespace Tetris
{
    /// <summary>
    /// The tutorial scene. Can return to the title screen.
    /// </summary>
    public class Tutorial : Scene
    {
        /// <summary>
        /// Class constructor. Initializes the scenes array.
        /// </summary>
        public Tutorial()
        {
            sceneChange = false;
            scenes = new Scene[1];
        }

        /// <summary>
        /// Observes if the user has inputted something, and returns to the
        /// previous scene if so.
        /// </summary>
        /// <param name="input">The user's input.</param>
        public override void Update(Dir input)
        {
            if (input != Dir.None)
                sceneChange = true;
        }

        /// <summary>
        /// Changes scenes if the user selected any of them.
        /// </summary>
        /// <returns>A new scene or itself, in case the user inputted
        /// nothing.</returns>
        public override Scene UpdateScene()
        {
            if (sceneChange)
            {
                sceneChange = false;
                return scenes[0];
            }
            
            return this;
        }
    }
}