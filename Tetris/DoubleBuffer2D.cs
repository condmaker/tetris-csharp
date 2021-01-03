using System;

namespace Tetris
{
    /// <summary>
    /// Class that defines a double buffer to print on a console. Code based 
    /// on DoubleBuffer2D created by Nuno Fachada.
    /// </summary>
    public class DoubleBuffer2D
    {
        private readonly ConsoleColor defaultBg;
        private Pixel[,] current;
        private Pixel[,] next;

        /// <summary>
        /// The number of X positions on the screen (length)
        /// </summary>
        /// <returns>The length of the screen</returns>
        public int XDim => current.GetLength(0);
        /// <summary>
        /// The number of Y positions on the screen (height)
        /// </summary>
        /// <returns>The height of the screen</returns>
        public int YDim => current.GetLength(1);

        /// <summary>
        /// Class Constructor. Initializes the current and next buffer, and
        /// fills them with a blue color.
        /// </summary>
        /// <param name="x">The screen length.</param>
        /// <param name="y">The screen height.</param>
        public DoubleBuffer2D(int x, int y)
        {
            current = new Pixel[x, y];
            next = new Pixel[x, y];

            for (int a = 0; a < XDim; a += 1) 
            {
                for (int b = 0; b < YDim; b += 1)
                    current[a, b] = new Pixel(ConsoleColor.Blue);
            }

            Clear();

            defaultBg = ConsoleColor.Black;
        }

        /// <summary>
        /// An indexer that gets pixels from the current buffer, and writes
        /// pixels to the next.
        /// </summary>
        /// <value>The value to be written on the next buffer.</value>
        public Pixel this[int x, int y] 
        {
            get => current[x, y];
            set => next[x, y] = value;
        }

        /// <summary>
        /// Clears the 'next' array.
        /// </summary>
        public void Clear()
        {
            Array.Clear(next, 0, XDim * YDim);
        }

        /// <summary>
        /// Clears the screen, replaces all pixels with black ones.
        /// </summary>
        public void ClearScreen()
        {
            for (int x = 0; x < XDim; x++)
                {
                    for (int y = 0; y < YDim; y++)
                        this[x, y] = new Pixel(ConsoleColor.Black);
                }
        }

        /// <summary>
        /// Effectively renders the image on the current buffer, and then flips
        /// the buffers around.
        /// </summary>
        public void PrintToScreen()
        {
            Console.BackgroundColor = defaultBg;

            Pixel[,] aux;

            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    if (next[x, y] == current[x, y]) 
                        continue;
                    else if (next[x, y].Color == ConsoleColor.Black)
                        Console.BackgroundColor = defaultBg;
                    else
                        Console.BackgroundColor = next[x, y].Color;
                    
                    Console.SetCursorPosition(x, y);
                    Console.Write(next[x, y].Character);
                }
            }

            aux = next;
            next = current;
            current = aux;
            Clear();
        }
    }
}