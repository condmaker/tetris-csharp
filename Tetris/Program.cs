using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Client gameClient = new Client();

            gameClient.GameLoop();
        }
    }
}
