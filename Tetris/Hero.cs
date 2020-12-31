using System;
using System.Collections.Generic;

namespace Tetris
{
    public class Hero: Tetrimino
    {
        protected ConsoleColor color;

        //Devia ser um vector2
        protected Tuple<int,int> position;
    
        //Isto tbm 
        protected IList<Tuple<int,int>> definition;

    }
}