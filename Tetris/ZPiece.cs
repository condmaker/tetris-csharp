using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Class which represents the Z shaped piece.
    /// </summary>
    public class ZPiece : Tetromino
    {
        /// <summary>
        /// Constructor. Creates a new instance on a given position.
        /// </summary>
        /// <param name="pos">Piece position.</param>
        public ZPiece(Coord pos)
            : base(pos)
        {
            Sprite = System.ConsoleColor.White;
            Definition.Add(new Coord(-1, 1));
            Definition.Add(new Coord(0, 0));
            Definition.Add(new Coord(0, 1));
            Definition.Add(new Coord(1, 0));
        }
    }
}