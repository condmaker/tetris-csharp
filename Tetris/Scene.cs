using System;

namespace Tetris
{
    public abstract class Scene : GameObject
    {
        protected Scene[] scenes;
        protected bool sceneChange;

        public abstract Scene UpdateScene();

        public void SetScenes(Scene[] o)
        {
            for (int i = 0; i < o.Length; i++)
                scenes[i] = o[i];
        }

        public void SetScenes(Scene o)
        {
            scenes[0] = o;
        }
    }
}
