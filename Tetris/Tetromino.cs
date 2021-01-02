using System;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Abstract class which represents a Tetromino piece
/// </summary>
namespace Tetris
{
    public abstract class Tetromino: GameObject, IEnumerable<Coord>
    {
        /// <summary>
        /// Property which represents the color of the Tetromino piece.
        /// </summary>
        /// <value>Tetromino piece's color.</value>
        public Pixel sprite { get; protected set;}

        private Coord initialPos;

        /// <summary>
        /// Instance variable which represents the current position of the 
        /// Tetromino piece.
        /// </summary>
        /// <value>Tetromino piece's current position.</value>
        protected Coord position;
    
        /// <summary>
        /// Instance variable which represents the different positions the 
        /// Tetromino piece occupies, from the current position.
        /// </summary>
        /// <value>Collection of Coord occupied by the Tetromino, from its 
        /// position.</value>
        protected IList<Coord> definition;


        public Tetromino(Coord initialPos)
        {
            this.initialPos = initialPos;
            ResetPos();
        }


        public void ResetPos()
        {
            position = initialPos;
        }

        /// <summary>
        /// Method responsible for rotating the Tetromino piece by 90 degrees 
        /// clockwise.
        /// </summary>
        public virtual void Rotate()
        {
            //Rotate bro
            for(int i = 0; i < definition.Count; i++){
                Coord t = definition[i];
                definition[i] = new Coord(-t.y,t.x);
            }
        }
    
        public void Move(Dir dir)
        {          
            switch(dir){
                case Dir.Left:
                break;
                case Dir.Right:
                break;
                case Dir.Down:
                position = position + new Coord(0,2);
                break;
                default:
                position = position + new Coord(0,1);
                return;
            }
            position = position + new Coord(dir);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the Tetromino 
        /// definition collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the 
        /// definition collection.</returns>
        public IEnumerator<Coord> GetEnumerator()
        {
            foreach (Coord c in definition)
                yield return (c+position);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the Tetromino 
        /// definition collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the 
        /// definition collection.</returns>
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