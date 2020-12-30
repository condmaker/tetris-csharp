using System;

namespace Tetris
{
    /// <summary>
    /// Class that defines a double buffer to print on a console. Code created
    /// by Nuno Fachada.
    /// </summary>
    /// <typeparam name="T">The type to instantiate</typeparam>
    public class DoubleBuffer2D
    {
        private ConsoleColor[,] current, next;
        private ConsoleColor defaultBg;

        public int xDim => current.GetLength(0);
        public int yDim => current.GetLength(1);

        public DoubleBuffer2D(int x, int y)
        {
            current = new ConsoleColor[x, y];
            next = new ConsoleColor[x, y];

            defaultBg = ConsoleColor.Black;
        }
        public ConsoleColor this[int x, int y] 
        {
            get => current[x, y];
            set => next[x, y] = value;
        }

        public void Clear()
        {
            Array.Clear(next, 0, xDim * yDim);
        }
        
        public void Swap()
        {
            ConsoleColor[,] aux = current;
            current = next;
            next = aux;
        }

        public void PrintToScreen()
        {
            Console.BackgroundColor = defaultBg;

            for (int y = 0; y < yDim; y++)
            {
                for (int x = 0; x < xDim; x++)
                {
                    // this may not work for everything, nullables dont work
                    // up there for some reason
                    if (this[x, y] == ConsoleColor.Black)
                    {
                        Console.BackgroundColor = defaultBg;
                    }
                    else
                    {
                        Console.BackgroundColor = this[x, y];
                    }

                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}