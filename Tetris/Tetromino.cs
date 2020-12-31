using System;
using System.Collections.Generic;
using System.Collections;

namespace Tetris
{
    public abstract class Tetromino: GameObject, IEnumerable<Coord>
    {
        public ConsoleColor color;

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

        public IEnumerator<Coord> GetEnumerator()
        {
            foreach (Coord c in definition)
                yield return (c+position);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // DELETE
        public override string ToString()
        {
            String str = "";
            foreach (Coord c in definition)
                str += (c+position).ToString() + ", ";
            return str;
        }


    }
}