using System;
using System.Collections.Generic;

namespace Tetris
{
    public abstract class Tetromino: GameObject
    {
        protected ConsoleColor color;

        //Devia ser um vector2
        protected Coord position;
    
        //Isto tbm 
        protected IList<Coord> definition;

        protected virtual void Rotate(Dir dir)
        {
            //Rotate bro
            for(int i = 0; i < definition.Count; i++){
                Coord t = definition[i];
                definition[i] = new Coord(-t.y,t.x);
            }
        }
    }
}