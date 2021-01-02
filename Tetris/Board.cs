using System;
using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Class that defines the game board.
    /// </summary>
    public class Board: Scene
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

        private Random rnd = new Random();

        private Coord InitialPos => new Coord(Width / 2 ,2);
       
        private IList<Tetromino> piecePool;


        public Tetromino NextPiece { get; private set; }
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

            BoardMatrix = new Pixel[w, h];

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {   
                    BoardMatrix[x,y] = new Pixel(ConsoleColor.Gray);
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
                new TPiece(InitialPos)
            };

            NextPiece = piecePool[5];
            CurrentPiece = new SquarePiece(InitialPos);    
          
            StorePiece(CurrentPiece);      
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
            return (BoardMatrix[c.x, c.y] == new Pixel(ConsoleColor.Gray));
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
                BoardMatrix[x, 0] = new Pixel();
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
                        continue;
                    }
                                 
                }

                // if whole line is occupied, delete this line    
                if(isComplete)
                {
                    
                    DeleteLine(y);
                    clearedLines++;
                }
            }
            return clearedLines;
        }
     
        /// <summary>
        /// Stores given Tetromino piece <param name="t"> in its current 
        /// position on the board.
        /// </summary>
        /// <param name="t">Tetromino Piece</param>
        public void StorePiece(Tetromino t)
        {
            foreach (Coord c in t)
                BoardMatrix[c.x, c.y] = t.sprite;

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

        //Tou a ter um aneurisma
        public bool ChangePiecePos(Tetromino t, Dir dir)
        {        
            foreach (Coord c in t)
            {
                BoardMatrix[c.x, c.y] = new Pixel();
            }

            if(IsMovementPossible(t, dir))
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
                //Switch Piece
                CurrentPiece = NextPiece;
                NextPiece = piecePool[rnd.Next(0,7)];
                CurrentPiece.ResetPos();
                StorePiece(CurrentPiece);
                //DeleteLines
                DeleteCompleteLines();
        }

        /// <summary>
        /// Update method to be called every frame.
        /// </summary>
        public override void Update(Dir input)
        {

            ChangePiecePos(CurrentPiece, input);
 
            if(!ChangePiecePos(CurrentPiece, Dir.Down))
            {
                PlacePiece();
            }
            
            

            if (input == Dir.Enter)
                sceneChange = true;
        }    
        

    }
}