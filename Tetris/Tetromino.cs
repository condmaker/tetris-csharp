using System;
using System.Collections.Generic;
using System.Collections;

namespace Tetris
{
    /// <summary>
    /// Abstract class which represents a Tetromino piece.
    /// </summary>
    public abstract class Tetromino : IEnumerable<Coord>
    {
        /// <summary>
        /// Gets the property which represents the color of the Tetromino piece.
        /// </summary>
        /// <value>Tetromino piece's color.</value>
        public Pixel Sprite { get; protected set; }

        private Coord initialPos;

        /// <summary>
        /// Instance variable which represents the current position of the 
        /// Tetromino piece.
        /// </summary>
        /// <value>Tetromino piece's current position.</value>
        private Coord position;
    
        /// <summary>
        /// Instance variable which represents the different positions the 
        /// Tetromino piece occupies, from the current position.
        /// </summary>
        /// <value>Collection of Coord occupied by the Tetromino, from its 
        /// position.</value>
        public IList<Coord> Definition { get; private set; }

        /// <summary>
        /// Constructor. Creates a new instance with the given initial 
        /// position.
        /// </summary>
        /// <param name="initialPos">Initial position.</param>
        protected Tetromino(Coord initialPos)
        {
            this.initialPos = initialPos;
            Definition = new List<Coord>();
            ResetPos();
        }

        /// <summary>
        /// Method that resets current position of the Tetromino to its 
        /// starting position.
        /// </summary>
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
            for (int i = 0; i < Definition.Count; i++)
            {
                Coord t = Definition[i];
                Definition[i] = new Coord(-t.Y, t.X);
            }
        }
        
        /// <summary>
        /// An IEnumerable of coordinates with the possible positions of the
        /// piece when rotated.
        /// </summary>
        /// <returns>A coordinate with the possible rotation.</returns>
        public virtual IEnumerable<Coord> Rotated()
        {
            for (int i = 0; i < Definition.Count; i++)
            {
                Coord t = Definition[i];
                yield return new Coord(-t.Y, t.X) + position;
            }
        }

        /// <summary>
        /// Method responsible for moving the Tetromino in a given direction.
        /// </summary>
        /// <param name="dir">Direction.</param>
        public void Move(Dir dir)
        {          
            switch (dir)
            {
                case Dir.Rot:
                Rotate();
                break;
                case Dir.Left:
                position = position + new Coord(dir);
                break;
                case Dir.Right:
                position = position + new Coord(dir);
                break;
                case Dir.Down:
                position = position + new Coord(0, 1);
                break;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the Tetromino 
        /// Definition collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the 
        /// Definition collection.</returns>
        public IEnumerator<Coord> GetEnumerator()
        {
            foreach (Coord c in Definition)
                yield return c + position;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the Tetromino 
        /// Definition collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the 
        /// Definition collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}