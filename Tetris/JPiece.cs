using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Class which represents the J shaped piece.
    /// </summary>
    public class JPiece : Tetromino
    {
        /// <summary>
        /// Constructor. Creates a new instance on a given position.
        /// </summary>
        /// <param name="pos">Piece position.</param>
        public JPiece(Coord pos)
            : base(pos)
        {
            Sprite = new Pixel(System.ConsoleColor.Yellow);
            Definition.Add(new Coord(1, 0));
            Definition.Add(new Coord(0, 0));
            Definition.Add(new Coord(0, 1));
            Definition.Add(new Coord(0, 2));
        }
    }
}