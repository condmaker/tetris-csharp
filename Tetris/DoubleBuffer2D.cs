using System;

namespace Tetris
{
    /// <summary>
    /// Class that defines a double buffer to print on a console. Code created
    /// by Nuno Fachada.
    /// </summary>
    public class DoubleBuffer2D
    {
        private readonly ConsoleColor defaultBg;
        private Pixel[,] current;
        private Pixel[,] next;

        public int XDim => current.GetLength(0);
        public int YDim => current.GetLength(1);

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

        public Pixel this[int x, int y] 
        {
            get => current[x, y];
            set => next[x, y] = value;
        }

        public void Clear()
        {
            Array.Clear(next, 0, XDim * YDim);
        }

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