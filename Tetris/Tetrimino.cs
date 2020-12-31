using System;
using System.Collections.Generic;

namespace Tetris
{
    public abstract class Tetrimino
    {
        protected ConsoleColor color;

        //Devia ser um vector2
        protected Tuple<int,int> position;
    
        protected int[,] definition;

        protected void Rotate(Dir dir)
        {
            //Rotate bro
        }


    }
}