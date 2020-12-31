using System;
using System.Collections.Generic;

namespace Tetris
{
    public class Board
    {
        public int Height => boardMatrix.GetLength(1);
        public int Width => boardMatrix.GetLength(0);
        private ConsoleColor[,] boardMatrix;

        public Board(int w = 10, int h = 20)
        {
            boardMatrix = new ConsoleColor[w, h];
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                    boardMatrix[x,y] = ConsoleColor.Black;
        }

        public bool IsTileFree(Coord c)
        {
            return (boardMatrix[c.x, c.y] == ConsoleColor.Black);
        }

        public bool IsCollision(ICollection<Tuple<int,int>> position)
        {
            foreach(Tuple<int,int> t in position)
            {
                if(boardMatrix[t.Item1,t.Item2] != ConsoleColor.Black)
                    return true;
            }
            // todo verificar colisao com peça
            return false;
        }

        public void DeleteLine(int y)
        {
            // move rows down
            for (; y > 0; y--)
                for (int x = 0; x < Width; x++)
                    boardMatrix[x, y] = boardMatrix[x, y-1];
            
            // clear top row
            for (int x = 0; x < Width; x++)
                boardMatrix[x, 0] = ConsoleColor.Black;
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

        public void StorePiece(Tetromino t)
        {
            foreach (Coord c in t)
            {
                boardMatrix[c.x, c.y] = t.color;
            }
        }

    }
}