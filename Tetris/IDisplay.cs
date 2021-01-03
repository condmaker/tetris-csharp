using System;
using System.Collections.Concurrent;

namespace Tetris
{
    /// <summary>
    /// An interface to define a display.
    /// </summary>
    public interface IDisplay
    {
        /// <summary>
        /// Renders a current frame.
        /// </summary>
        void Render();

        /// <summary>
        /// Updates a frame based on a scene.
        /// </summary>
        /// <param name="scene">The scene itself.</param>
        void UpdateScene(Scene scene);
        
        /// <summary>
        /// Renders a final time.
        /// </summary>
        void Finish();
    }
}