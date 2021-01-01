using System;
using System.Collections.Generic;
using System.Collections;

namespace Tetris
{
    public abstract class Tetromino: GameObject, IEnumerable<Coord>
    {
        public Pixel sprite;

        //Devia ser um vector2
        protected Coord position;
    
        //Isto tbm 
        protected IList<Coord> definition;

        public virtual void Rotate()
        {
            //Rotate bro
            for(int i = 0; i < definition.Count; i++){
                Coord t = definition[i];
                definition[i] = new Coord(-t.y,t.x);
            }
        }

        public void Move(){
            position = position + new Coord(0,1);
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

        public override void Update(Dir input)
        {
            
        }

    }
}