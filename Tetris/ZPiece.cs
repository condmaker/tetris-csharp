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
        public ZPiece(Coord pos): base(pos)
        {
            sprite = new Pixel(System.ConsoleColor.White);
            definition = new List<Coord>();
            definition.Add(new Coord(-1, 1));
            definition.Add(new Coord(0, 0));
            definition.Add(new Coord(0, 1));
            definition.Add(new Coord(1, 0));
        }
    }
}