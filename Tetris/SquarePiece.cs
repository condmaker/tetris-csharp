using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Class which represents the square shaped piece.
    /// </summary>
    public class SquarePiece : Tetromino
    {
        /// <summary>
        /// Constructor. Creates a new instance on a given position.
        /// </summary>
        /// <param name="pos">Piece position.</param>
        public SquarePiece(Coord pos)
            : base(pos)
        {
            Sprite = new Pixel(System.ConsoleColor.Blue);
            Definition.Add(new Coord(0, 0));
            Definition.Add(new Coord(0, 1));
            Definition.Add(new Coord(1, 0));
            Definition.Add(new Coord(1, 1));
        }

        /// <summary>
        /// Method responsible for rotating the Tetromino piece by 90 degrees 
        /// clockwise.
        /// The method is empty to make sure the square piece doesn't
        /// rotate
        /// /// </summary>
        public override void Rotate()
        { }
    }
}