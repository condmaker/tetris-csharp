using System;

namespace Tetris
{
    /// <summary>
    /// Defines a interchangeable scene for the game.
    /// </summary>
    public abstract class Scene : GameObject
    {
        /// <summary>
        /// An array of scenes that this scene can access.
        /// </summary>
        protected Scene[] scenes;
        
        /// <summary>
        /// A bool defining if the scene needs to be changed or not.
        /// </summary>
        protected bool sceneChange;

        /// <summary>
        /// An method that updates the status of the current scene.
        /// </summary>
        /// <returns>Returns itself or another scene if needed.</returns>
        public abstract Scene UpdateScene();

        /// <summary>
        /// Sets the scenes on the instance.
        /// </summary>
        /// <param name="o">The array of scenes to be setted.</param>
        public void SetScenes(Scene[] o)
        {
            for (int i = 0; i < o.Length; i++)
                scenes[i] = o[i];
        }

        /// <summary>
        /// Sets the scenes on the instance.
        /// </summary>
        /// <param name="o">The scene to be set.</param>
        public void SetScenes(Scene o)
        {
            scenes[0] = o;
        }
    }
}
