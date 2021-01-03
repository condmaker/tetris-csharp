using System;
using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// The basis for every updatable object on the program.
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// The class that will update the GameObject's state for each frame.
        /// </summary>
        /// <param name="input">The user's input to be registered.</param>
        public abstract void Update(Dir input);
    }
}