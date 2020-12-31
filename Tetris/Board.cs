using System;
using System.Collections.Generic;

namespace Tetris
{
    public class Board: GameObject
    {
        public int Height => BoardMatrix.GetLength(1);
        public int Width => BoardMatrix.GetLength(0);
        public ConsoleColor[,] BoardMatrix { get; private set; }

        public Board(int w = 10, int h = 20)
        {
            BoardMatrix = new ConsoleColor[w, h];
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                    BoardMatrix[x,y] = ConsoleColor.Black;
        }

        public bool IsTileFree(Coord c)
        {
            return (BoardMatrix[c.x, c.y] == ConsoleColor.Black);
        }

        public bool IsCollision(ICollection<Coord> position)
        {
            foreach(Coord c in position)
            {
                if(BoardMatrix[c.x, c.y] != ConsoleColor.Black)
                    return true;
            }

            return false;
        }

        public void DeleteLine(int y)
        {
            // move rows down
            for (; y > 0; y--)
                for (int x = 0; x < Width; x++)
                    BoardMatrix[x, y] = BoardMatrix[x, y-1];
            
            // clear top row
            for (int x = 0; x < Width; x++)
                BoardMatrix[x, 0] = ConsoleColor.Black;
        }

        public int DeleteCompleteLines()
        {
            int clearedLines = 0;
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    // if tile is free, go to next line
                    if (IsTileFree(new Coord(x, y)))
                        continue;
                    // if whole line is occupied, delete this line
                    DeleteLine(y);
                    clearedLines++;
                }
            return clearedLines;
        }

        public override void Update()
        {

        }    
        public void StorePiece(Tetromino t)
        {
            foreach (Coord c in t)
            {
                BoardMatrix[c.x, c.y] = t.color;
            }
        }

    }
}