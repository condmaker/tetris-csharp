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
        public JPiece(Coord pos): base(pos)
        {
            sprite = new Pixel(System.ConsoleColor.Yellow);
            definition = new List<Coord>();
            definition.Add(new Coord(1, 0));
            definition.Add(new Coord(0, 0));
            definition.Add(new Coord(0, 1));
            definition.Add(new Coord(0, 2));
        }
    }
}