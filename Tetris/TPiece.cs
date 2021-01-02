using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Class which represents the T shaped piece.
    /// /// </summary>
    public class TPiece : Tetromino
    {
        /// <summary>
        /// Constructor. Creates a new instance on a given position.
        /// </summary>
        /// <param name="pos">Piece position.</param>
        public TPiece(Coord pos)
            : base(pos)
        {
            sprite = new Pixel(System.ConsoleColor.Magenta);
            definition = new List<Coord>();
            definition.Add(new Coord(-1, 0));
            definition.Add(new Coord(0, 0));
            definition.Add(new Coord(1, 0));
            definition.Add(new Coord(0, 1));
        }
    }
}