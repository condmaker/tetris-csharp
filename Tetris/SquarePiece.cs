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

        public override void Rotate()
        { }

        // public override IEnumerable<Coord> Rotated()
        // {
        //     for (int i = 0; i < Definition.Count; i++)
        //     {
        //         Coord t = Definition[i];
        //         yield return t + position;
        //     }
        // }
    }
}