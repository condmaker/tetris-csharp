using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            // Client gameClient = new Client();

            // gameClient.GameLoop();

            // TESTING
            Square p1 = new Square(new Coord(2, 2));
            Console.WriteLine(p1);

            foreach(Coord c in p1)
            Console.WriteLine(c);
        }
    }
}
