using System;

namespace Tetris
{
    public class TitleScreen : Scene
    {
        public bool CursorPos { get; private set; }
        public TitleScreen()
        {
            scenes = new Scene[2];
            sceneChange = false;
            CursorPos = true;
        }

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
                    sceneChange = true;
                    break;
            }
        }

        public override Scene UpdateScene()
        {
            if (sceneChange)
            {
                sceneChange = false;

                if (CursorPos) 
                    return scenes[0];
                else if (!CursorPos) 
                    return scenes[1];
            }
            
            return this;
        }
    }
}