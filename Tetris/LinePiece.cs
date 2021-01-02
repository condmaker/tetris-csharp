using System;
using System.Collections.Generic;

namespace Tetris
{
    public class LinePiece: Tetromino
    {
        public LinePiece(Coord pos): base(pos)
        {
            sprite = new Pixel(System.ConsoleColor.Cyan);
            definition = new List<Coord>();
            definition.Add(new Coord(0, -1));
            definition.Add(new Coord(0, 0));
            definition.Add(new Coord(0, 1));
            definition.Add(new Coord(0, 2));
        }
    }
}