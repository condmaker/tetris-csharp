using System;
using System.Collections.Generic;

namespace Tetris
{
    public class Board: GameObject
    {
        public int Height => BoardMatrix.GetLength(1);
        public int Width => BoardMatrix.GetLength(0);
        public Pixel[,] BoardMatrix { get; private set; }

        private Tetromino currentPiece;



        public Board(int w = 10, int h = 20)
        {
            BoardMatrix = new Pixel[w, h];
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {   
                    BoardMatrix[x,y] = new Pixel();
                }  

            currentPiece = new Square(new Coord(3,3));    
            StorePiece(currentPiece);      
        }

        public bool IsTileFree(Coord c)
        {
            return (BoardMatrix[c.x, c.y] == new Pixel());
        }

     
        public void DeleteLine(int y)
        {
            // move rows down
            for (; y > 0; y--)
                for (int x = 0; x < Width; x++)
                    BoardMatrix[x, y] = BoardMatrix[x, y-1];
            
            // clear top row
            for (int x = 0; x < Width; x++)
                BoardMatrix[x, 0] = new Pixel();
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
            ChangePiecePos(currentPiece);
        }   
        



        //Tou a ter um aneurisma
        public bool ChangePiecePos(Tetromino t)
        {        
            if(!IsCollision(t))
            {
                foreach (Coord c in t)
                {
                    BoardMatrix[c.x, c.y] = new Pixel();
                }
                t.Move();
                StorePiece(t);
                return true;
            }
            return false;
        }

        private bool IsCollision(Tetromino t)
        {
            foreach(Coord c in t)
            {
                if(IsTileFree(c))
                    return true;
                if(c.y >= Height - 1)
                    return true;
            }
           
            return false;
        }
    
        private void StorePiece(Tetromino t)
        {
            foreach (Coord c in t)
            {
                BoardMatrix[c.x, c.y] = t.sprite;
            }
        }

    }
}