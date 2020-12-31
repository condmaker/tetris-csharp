using System;
using System.Collections.Generic;

namespace Tetris
{
    public abstract class Tetrimino
    {
        protected ConsoleColor color;

        //Devia ser um vector2
        protected Tuple<int,int> position;
    
        //Isto tbm, e n tenho a certeza se pode ser IEquatable
        protected IList<Tuple<int,int>> definition;

        protected virtual void Rotate(Dir dir)
        {
            //Rotate bro
            for(int i = 0; i < definition.Count; i++){
                Tuple<int, int> t = definition[i];
                definition[i] = new Tuple<int, int>(-t.Item2,t.Item1);
            }
        }


    }
}