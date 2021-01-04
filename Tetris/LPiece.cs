using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Class which represents the L shaped piece.
    /// </summary>
    public class LPiece : Tetromino
    {
        /// <summary>
        /// Constructor. Creates a new instance on a given position.
        /// </summary>
        /// <param name="pos">Piece position.</param>
        public LPiece(Coord pos)
            : base(pos)
        {
            Sprite = System.ConsoleColor.DarkGreen;
            Definition.Add(new Coord(-1, 0));
            Definition.Add(new Coord(0, 0));
            Definition.Add(new Coord(0, 1));
            Definition.Add(new Coord(0, 2));
        }
    }
}