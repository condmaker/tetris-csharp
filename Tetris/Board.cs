using System;
using System.Collections.Generic;

namespace Tetris
{
    public class Board: GameObject
    {
        /// <summary>
        /// Property that represents the vertical dimension of the board.
        /// </summary>
        /// <value>Vertical dimension of the board.</value>
        public int Height => BoardMatrix.GetLength(1);
        /// <summary>
        /// Property that represents the horizontal dimension of the board.
        /// </summary>
        /// <value>Horizontal dimension of the board.</value>
        public int Width => BoardMatrix.GetLength(0);

        /// <summary>
        /// Instance variable that contains a reference to the bi-dimensional 
        /// array that represents the game board.
        /// </summary>
        public Pixel[,] BoardMatrix { get; private set; }

        /// <summary>
        /// Creates a new instance of game board.
        /// </summary>
        /// <param name="w">Horizontal dimensions.</param>
        /// <param name="h">Vertical dimensions.</param>
        public Board(int w = 10, int h = 20)
        {
            BoardMatrix = new Pixel[w, h];
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                    BoardMatrix[x,y].Clear();
        }
        
        /// <summary>
        /// Method that indicates if a given Coord <param name="c"> is inside
        /// the limits of the board.
        /// </summary>
        /// <param name="c">A Coord</param>
        /// <returns><c>true</c> if the Coord <param name="c"> is within the 
        /// limits of the board, <c>false</c> otherwise
        public bool IsInsideBounds(Coord c)
        {
            if (c.x < 0)
                return false;
            if (c.y < 0)
                return false;
            if (c.x >= Width)
                return false;
            if (c.y >= Height)
                return false;
            return true;
        }

        /// <summary>
        /// Method that indicates if a given board position is free.
        /// </summary>
        /// <param name="c">Position on the board.</param>
        /// <returns><c>true</c> if an the board is free at position
        /// <param name="c">, <c>false</c> otherwise.</returns>
        public bool IsTileFree(Coord c)
        {
            if(!IsInsideBounds(c))
                return false;
            return (BoardMatrix[c.x, c.y].Color == ConsoleColor.Black);
        }

        /// <summary>
        /// Method that indicates whether a given set of positions are free or 
        /// occupied.
        /// </summary>
        /// <param name="position">Collection of positions.</param>
        /// <returns><c>true</c> if any of the positions are occuiped, 
        /// <c>false</c> if all positions are free.</returns>
        public bool IsCollision(ICollection<Coord> position)
        {
            foreach(Coord c in position)
            {
                if(!IsTileFree(c))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Method that indicates if a given Tetromino can move in a given 
        /// direction.
        /// </summary>
        /// <param name="t">Tetromino.</param>
        /// <param name="d">Direction.</param>
        /// <returns><c>true</c> if the piece can move in the direction 
        /// without colliding, <c>false</c> otherwise</returns>
        public bool IsMovementPossible(Tetromino t, Dir d)
        {
            Coord move = new Coord(d);
            foreach(Coord c in t)
            {
                Coord newCoord = c + move;
                if (!IsTileFree(newCoord))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Method that indicates if a given Tetromino can rotate.
        /// </summary>
        /// <param name="t">Tetromino</param>
        /// <returns><c>true</c> if the piece can rotate 
        /// without colliding, <c>false</c> otherwise</returns>
        public bool IsRotationPossible(Tetromino t)
        {
            // tratar definition
            // verificar collisao
            return true;
        }

        /// <summary>
        /// Moves all lines above given line <param name="y"> one line down,
        /// and cleats the top line.
        /// </summary>
        /// <param name="y">Line on board to be deleted.</param>
        public void DeleteLine(int y)
        {
            // move rows down
            for (; y > 0; y--)
                for (int x = 0; x < Width; x++)
                    BoardMatrix[x, y] = BoardMatrix[x, y-1];
            
            // clear top row
            for (int x = 0; x < Width; x++)
                BoardMatrix[x, 0].Clear();
        }

        /// <summary>
        /// Iterates through all lines and calls DeleteLine on lines that are 
        /// completely occupied.
        /// </summary>
        /// <returns>Number of completely occupied lines that were deleted.
        /// </returns>
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

        /// <summary>
        /// Update method to be called every frame.
        /// </summary>
        public override void Update()
        {

        }    
        
        /// <summary>
        /// Stores given Tetromino piece <param name="t"> in its current 
        /// position on the board.
        /// </summary>
        /// <param name="t">Tetromino Piece</param>
        public void StorePiece(Tetromino t)
        {
            foreach (Coord c in t)
            {
                BoardMatrix[c.x, c.y].Color = t.Color;
            }
        }

    }
}