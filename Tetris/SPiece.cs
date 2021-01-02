using System.Collections.Generic;

namespace Tetris
{
    public class SPiece : Tetromino
    {
        public SPiece(Coord pos): base(pos)
        {
            definition = new List<Coord>();
            definition.Add(new Coord(-1, 0));
            definition.Add(new Coord(0, 0));
            definition.Add(new Coord(0, 1));
            definition.Add(new Coord(1, 1));
        }
    }
}