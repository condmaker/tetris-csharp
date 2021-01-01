using System;

namespace Tetris
{
    public class Tutorial : Scene
    {
        public Tutorial()
        {
            sceneChange = false;
            scenes = new Scene[1];
        }

        public override void Update(Dir input)
        {
            if (input != Dir.None)
                sceneChange = false;
        }

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