using System;
using System.Collections.Generic;

namespace Tetris
{
    public class Hero: Tetromino
    {
        public Hero(Coord pos): base(pos)
        {
            definition = new List<Coord>();
            definition.Add(new Coord(0, -1));
            definition.Add(new Coord(0, 0));
            definition.Add(new Coord(0, 1));
            definition.Add(new Coord(0, 2));
        }
    }
}