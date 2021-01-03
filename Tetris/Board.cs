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
        /// <returns>Random number generator.</returns>
        private readonly Random rnd = new Random();

        /// <summary>
        /// Instance variable that records the last random number generated.
        /// </summary>
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

        private Score score;
        /// <summary>
        /// Instance property that controls the current game's score.
        /// </summary>
        public Score Score { get => score; }

        /// <summary>
        /// A boolean that defines if the game is running or not.
        /// </summary>
        public bool GameState { get; private set; }
        
        /// <summary>
        /// Property that gets the initial position of each piece according to 
        /// board size.
        /// </summary>
        /// <value>Initial piece's position.</value>
        private Coord InitialPos => new Coord(Width / 2, 2);

        /// <summary>
        /// Property that contains a reference to the current falling 
        /// piece.
        /// </summary>
        /// <value>The current falling piece.</value>
        public Tetromino NextPiece { get; private set; }
        
        /// <summary>
        /// Property that contains a reference to the next falling 
        /// piece.
        /// </summary>
        /// <value>The next falling piece.</value>
        public Tetromino CurrentPiece { get; private set; }

        /// <summary>
        /// Property that contains a reference to the bi-dimensional 
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

            score = new Score("Player", 0);

            GameState = true;
            
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

            CurrentPiece = piecePool[GetRandomPiece()];    
            NextPiece = piecePool[GetRandomPiece()];
          
            StorePiece(CurrentPiece);      
        }



        /// <summary>
        /// Deletes every line of the board, reseting it to its 
        /// original state
        /// </summary>
        public void ClearBoard()
        {
            for(int y = 0; y < Height; y++)
            {
                DeleteLine(y);
            }
        }


        /// <summary>
        /// Method responsible for getting a random number for the piece, 
        /// different from the last.
        /// </summary>
        /// <returns>Random number between 0 and 7, different from the last.
        /// </returns>
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


        // /// <summary>
        // /// Method that indicates whether a given set of positions are free or 
        // /// occupied.
        // /// </summary>
        // /// <param name="t">Collection of positions.</param>
        // /// <returns><c>true</c> if any of the positions are occuiped, 
        // /// <c>false</c> if all positions are free.</returns>
        // private bool IsCollision(Tetromino t)
        // {
        //     foreach (Coord c in t)
        //     {
        //         if (!IsTileFree(c))
        //             return true;
        //     }
           
        //     return false;
        // }


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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Scene UpdateScene()
        {
            if (sceneChange)
            {
                sceneChange = false;
                return scenes[0];
            }

            return this;
        }


        /// <summary>
        /// Method that changes a piece position or rotation according to the 
        /// user input.
        /// </summary>
        /// <param name="t">Piece to update.</param>
        /// <param name="dir">Direction inputted by the user.</param>
        /// <returns><c>true</c> if the change is possible, 
        /// <c>false</c> otherwise.</returns>
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


        /// <summary>
        /// Method responsible for placing the current piece on the board 
        /// permanently, and updating the board accordingly.
        /// </summary>
        private void PlacePiece()
        {
                // Check if piece stopped off screen
                foreach (Coord c in CurrentPiece)
                {
                    if (c.Y <= InitialPos.Y)
                    {
                        ClearBoard();
                        // End Game
                        GameState = false;
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
            
            if (input == Dir.Enter)
                sceneChange = true;
        }    
    }
}