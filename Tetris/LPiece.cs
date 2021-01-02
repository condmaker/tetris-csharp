using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Class which represents the L shaped piece.
    /// </summary>
    public class LPiece: Tetromino
    {
        /// <summary>
        /// Constructor. Creates a new instance on a given position.
        /// </summary>
        /// <param name="pos">Piece position.</param>
        public LPiece(Coord pos)
            : base(pos)
        {
            sprite = new Pixel(System.ConsoleColor.DarkGreen);
            definition = new List<Coord>();
            definition.Add(new Coord(-1, 0));
            definition.Add(new Coord(0, 0));
            definition.Add(new Coord(0, 1));
            definition.Add(new Coord(0, 2));
        }
    }
}