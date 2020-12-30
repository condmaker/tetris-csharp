using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Client gameClient = new Client();

            gameClient.Run();
        }
    }
}
