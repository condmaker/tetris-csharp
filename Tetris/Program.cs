using System;

namespace Tetris
{
    static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Client gameClient = new Client();

            gameClient.GameLoop();
        }
    }
}
