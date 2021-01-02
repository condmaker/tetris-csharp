using System;
using System.Collections.Generic;

namespace Tetris
{
    public abstract class GameObject
    {
        public abstract void Update(Dir input);
    }
}