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
        public ConsoleColor Color { get; private set;}

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

        /// <summary>
        /// Method responsible for rotating the Tetromino piece by 90 degrees 
        /// clockwise.
        /// </summary>
        protected virtual void Rotate()
        {
            //Rotate bro
            for(int i = 0; i < definition.Count; i++){
                Coord t = definition[i];
                definition[i] = new Coord(-t.y,t.x);
            }
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


    }
}