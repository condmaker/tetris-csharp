using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Class which represents the S shaped piece.
    /// </summary>
    public class SPiece : Tetromino
    {
        /// <summary>
        /// Constructor. Creates a new instance on a given position.
        /// </summary>
        /// <param name="pos">Piece position.</param>
        public SPiece(Coord pos)
            : base(pos)
        {
            Sprite = System.ConsoleColor.Red;
            Definition.Add(new Coord(-1, 0));
            Definition.Add(new Coord(0, 0));
            Definition.Add(new Coord(0, 1));
            Definition.Add(new Coord(1, 1));
        }
    }
}