using System.Collections.Generic;

namespace Tetris
{
    public class LPiece: Tetromino
    {
        public LPiece(Coord pos): base(pos)
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