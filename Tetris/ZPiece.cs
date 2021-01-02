using System.Collections.Generic;

namespace Tetris
{
    public class ZPiece : Tetromino
    {
        public ZPiece(Coord pos): base(pos)
        {

            definition = new List<Coord>();
            definition.Add(new Coord(-1, 1));
            definition.Add(new Coord(0, 0));
            definition.Add(new Coord(0, 1));
            definition.Add(new Coord(1, 0));
        }
    }
}