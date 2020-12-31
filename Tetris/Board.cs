using System;
using System.Collections.Generic;

namespace Tetris
{
    public class Board: GameObject
    {
        private int Height;
        private int Width;

        //PRIVATE lembrar
        public ConsoleColor[,] boardMatrix;

        public Board(int w = 10, int h = 20)
        {
            Width = w;
            Height = h;
            boardMatrix = new ConsoleColor[Width, Height];
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    boardMatrix[x,y] = ConsoleColor.Black;
        }

        public bool IsTileFree(int X, int Y)
        {
            if (boardMatrix[X, Y] == ConsoleColor.Black)
                return true;
            return false;
        }

        public bool IsCollision(ICollection<Coord> position)
        {
            foreach(Coord c in position)
            {
                if(boardMatrix[c.x, c.y] != ConsoleColor.Black)
                    return true;
            }

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
                    if (IsTileFree(x, y))
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

    }
}