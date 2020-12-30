using System;

namespace Tetris
{
    /// <summary>
    /// Class that defines a double buffer to print on a console. Code created
    /// by Nuno Fachada.
    /// </summary>
    public class DoubleBuffer2D
    {
        private Pixel[,] current, next;
        private ConsoleColor defaultBg;

        public int xDim => current.GetLength(0);
        public int yDim => current.GetLength(1);

        public DoubleBuffer2D(int x, int y)
        {
            current = new Pixel[x, y];
            next = new Pixel[x, y];

            for (int a = 0; a < xDim; a += 1) 
                for (int b = 0; b < yDim; b += 1)
                    current[a, b] = new Pixel(ConsoleColor.Blue);

            Clear();

            defaultBg = ConsoleColor.Black;
        }
        public Pixel this[int x, int y] 
        {
            get => current[x, y];
            set => next[x, y] = value;
        }

        public void Clear()
        {
            Array.Clear(next, 0, xDim * yDim);
        }

        public void PrintToScreen()
        {
            Console.BackgroundColor = defaultBg;

            Pixel[,] aux;

            for (int y = 0; y < yDim; y++)
            {
                for (int x = 0; x < xDim; x++)
                {
                    if (next[x, y] == current[x, y]) continue;

                    else if (next[x, y].Color == ConsoleColor.Black)
                    {
                        Console.BackgroundColor = defaultBg;
                    }
                    else
                    {
                        Console.BackgroundColor = next[x, y].Color;
                    }
                    
                    Console.SetCursorPosition(x, y);
                    Console.Write(next[x,y].Character);
                }
                Console.WriteLine();
            }

            aux = next;
            next = current;
            current = aux;
            Clear();
        }
    }
}