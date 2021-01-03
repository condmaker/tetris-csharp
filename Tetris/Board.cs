using System;
using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Class that defines the game board.
    /// </summary>
    public class Board : Scene
    {
        /// <summary>
        /// Constant that defines the board's background color.
        /// </summary>
        private const ConsoleColor BgColor = ConsoleColor.Gray;

        /// <summary>
        /// Readonly Collection that contains the pool of available pieces.
        /// </summary>
        private readonly IList<Tetromino> piecePool;

        /// <summary>
        /// Readonly random number generator.
        /// </summary>
        /// <returns></returns>
        private readonly Random rnd = new Random();

        private int lastRandom;

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
        /// Instance variable that controls the current game's score.
        /// </summary>
        public Score score;
        
        private Coord InitialPos => new Coord(Width / 2, 2);

        /// <summary>
        /// Instance variable that contains a reference to the current falling 
        /// piece.
        /// </summary>
        /// <value>The current falling piece.</value>
        public Tetromino NextPiece { get; private set; }
        
        /// <summary>
        /// Instance variable that contains a reference to the next falling 
        /// piece.
        /// </summary>
        /// <value>The next falling piece.</value>
        public Tetromino CurrentPiece { get; private set; }

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
            scenes = new Scene[1];
            sceneChange = false;
            score = new Score();
            lastRandom = -1;

            BoardMatrix = new Pixel[w, h];

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {   
                    BoardMatrix[x, y] = new Pixel(BgColor);
                }  
            }

            piecePool = new List<Tetromino>
            {
                new LPiece(InitialPos),
                new SquarePiece(InitialPos),
                new JPiece(InitialPos),
                new ZPiece(InitialPos),
                new SPiece(InitialPos),
                new LinePiece(InitialPos),
                new TPiece(InitialPos),
            };

            NextPiece = piecePool[GetRandomPiece()];
            CurrentPiece = piecePool[GetRandomPiece()];    
          
            StorePiece(CurrentPiece);      
        }

        private int GetRandomPiece()
        {
            int rng;
            do 
            {
                rng =  rnd.Next(0, piecePool.Count);
            } while (rng == lastRandom);

            lastRandom = rng;

            return rng;
        }
        
        /// <summary>
        /// Method that indicates if a given Coord <paramref name="c"/> is 
        /// inside the limits of the board.
        /// </summary>
        /// <param name="c">A Coord.</param>
        /// <returns><c>true</c> if the Coord <paramref name="c"/> is within 
        /// the limits of the board, <c>false</c> otherwise.
        /// </returns>
        public bool IsInsideBounds(Coord c)
        {
            if (c.X < 0)
                return false;
            if (c.Y < 0)
                return false;
            if (c.X >= Width)
                return false;
            if (c.Y >= Height)
                return false;
            return true;
        }

        /// <summary>
        /// Method that indicates if a given board position is free.
        /// </summary>
        /// <param name="c">Position on the board.</param>
        /// <returns><c>true</c> if an the board is free at position
        /// <paramref name="c"/>, <c>false</c> otherwise.</returns>
        public bool IsTileFree(Coord c)
        {
            if (!IsInsideBounds(c))
                return false;
            return BoardMatrix[c.X, c.Y] == new Pixel(BgColor);
        }

        /// <summary>
        /// Method that indicates whether a given set of positions are free or 
        /// occupied.
        /// </summary>
        /// <param name="t">Collection of positions.</param>
        /// <returns><c>true</c> if any of the positions are occuiped, 
        /// <c>false</c> if all positions are free.</returns>
        private bool IsCollision(Tetromino t)
        {
            foreach (Coord c in t)
            {
                if (!IsTileFree(c))
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
        /// without colliding, <c>false</c> otherwise.</returns>
        public bool IsMovementPossible(Tetromino t, Dir d)
        {
            Coord move = new Coord(d);
            foreach (Coord c in t)
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
        /// <param name="t">Tetromino.</param>
        /// <returns><c>true</c> if the piece can rotate 
        /// without colliding, <c>false</c> otherwise.</returns>
        public bool IsRotationPossible(Tetromino t)
        {
            bool canRot = true;

            foreach (Coord c in t.Rotated())
            {
                if (!IsTileFree(c))
                {
                    canRot = false;
                }
            }

            // tratar definition
            // verificar collisao
            return canRot;
        }

        /// <summary>
        /// Moves all lines above given line <paramref name="y"/> one line 
        /// down, and cleats the top line.
        /// </summary>
        /// <param name="y">Line on board to be deleted.</param>
        public void DeleteLine(int y)
        {
            // move rows down
            for (; y > 0; y--)
             {
                for (int x = 0; x < Width; x++)
                                    BoardMatrix[x, y] = BoardMatrix[x, y - 1];
            }                
            
            // clear top row
            for (int x = 0; x < Width; x++)
                BoardMatrix[x, 0] = new Pixel(BgColor);
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
            {
                bool isComplete = true;

                for (int x = 0; x < Width; x++)
                {
                    // if tile is free, go to next line
                    if (IsTileFree(new Coord(x, y)))
                    {
                        isComplete = false;
                        x = Width;
                    }           
                }

                // if whole line is occupied, delete this line    
                if (isComplete)
                {
                    DeleteLine(y);
                    clearedLines++;
                }
            }

            return clearedLines;
        }
     
        /// <summary>
        /// Stores given Tetromino piece <paramref name="t"/> in its current 
        /// position on the board.
        /// </summary>
        /// <param name="t">Tetromino Piece.</param>
        public void StorePiece(Tetromino t)
        {
            foreach (Coord c in t)
                BoardMatrix[c.X, c.Y] = t.Sprite;
        }

        public override Scene UpdateScene()
        {
            // Not implemented yet
            if (sceneChange)
            {
                sceneChange = false;
                return scenes[0];
            }

            return this;
        }

        public bool ChangePiecePos(Tetromino t, Dir dir)
        {        
            foreach (Coord c in t)
            {
                BoardMatrix[c.X, c.Y] = new Pixel(BgColor);
            }

            if (dir == Dir.Rot || dir == Dir.Up)
            {
                if (IsRotationPossible(t))
                {
                    t.Rotate();
                    return true;
                }

                return false;
            }

            if (dir == Dir.Fall)
            {
                while (IsMovementPossible(t, Dir.Down))
                {
                    t.Move(Dir.Down);
                } 
            }

            if (IsMovementPossible(t, dir))
            {             
                t.Move(dir);
                StorePiece(t);
                return true;
            }
            else
            {
                StorePiece(t);
                return false;
            }         
        }

        private void PlacePiece()
        {
                // Check if piece stopped off screen
                foreach (Coord c in CurrentPiece)
                {
                    if (c.Y <= InitialPos.Y)
                    {
                        // End Game
                        return;
                    }
                }

                // DeleteLines
                int cleared = DeleteCompleteLines();

                // Update score
                score.IncreaseScore(cleared);

                // Switch Piece
                CurrentPiece = NextPiece;
                NextPiece = piecePool[GetRandomPiece()];
                CurrentPiece.ResetPos();
                StorePiece(CurrentPiece);  
        }

        /// <summary>
        /// Update method to be called every frame.
        /// </summary>
        /// <param name="input">Direction of movement.</param>
        public override void Update(Dir input)
        {
            bool place = ChangePiecePos(CurrentPiece, input);

            if (!place && input == Dir.Down)
                PlacePiece();
 
            // if (!ChangePiecePos(CurrentPiece, Dir.Down))
            // {
            //     PlacePiece();
            // }
            
            if (input == Dir.Enter)
                sceneChange = true;
        }    
    }
}