using System.Collections.Generic;

namespace Tetris
{
    public class TPiece: Tetromino
    {
        public TPiece(Coord pos)
        {
            position = pos;
            definition = new List<Coord>();
            definition.Add(new Coord(-1, 0));
            definition.Add(new Coord(0, 0));
            definition.Add(new Coord(1, 0));
            definition.Add(new Coord(0, 1));
        }


    }
}