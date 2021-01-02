using System.Collections.Generic;

namespace Tetris
{
    public class SquarePiece : Tetromino
    {
        public SquarePiece(Coord pos): base(pos)
        {
            sprite = new Pixel(System.ConsoleColor.Blue);
            definition = new List<Coord>();
            definition.Add(new Coord(0, 0));
            definition.Add(new Coord(0, 1));
            definition.Add(new Coord(1, 0));
            definition.Add(new Coord(1, 1));
        }
    }
}