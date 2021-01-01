using System;

namespace Tetris
{
    public class TitleScreen : Scene
    {
        private bool cursorPos;
        public TitleScreen()
        {
            scenes = new Scene[2];

            cursorPos = true;
        }

        public override void Update(Dir input)
        {
            switch (input)
            {
                case Dir.Up:
                    cursorPos = true;
                    break;
                case Dir.Down:
                    cursorPos = false;
                    break;
                case Dir.Enter:
                    sceneChange = true;
                    break;
            }
        }

        public override Scene UpdateScene()
        {
            if (sceneChange)
            {
                sceneChange = false;
                
                if (cursorPos) return scenes[0];
                else if (!cursorPos) return scenes[1];
            }
            
            return this;
        }
    }
}