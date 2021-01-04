using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Class which represents the line shaped piece.
    /// </summary>
    public class LinePiece : Tetromino
    {
        /// <summary>
        /// Constructor. Creates a new instance on a given position.
        /// </summary>
        /// <param name="pos">Piece position.</param>
        public LinePiece(Coord pos)
            : base(pos)
        {
            Sprite = System.ConsoleColor.Cyan;
            Definition.Add(new Coord(0, -1));
            Definition.Add(new Coord(0, 0));
            Definition.Add(new Coord(0, 1));
            Definition.Add(new Coord(0, 2));
        }
    }
}