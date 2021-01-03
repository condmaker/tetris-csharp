using System;

namespace Tetris
{
    /// <summary>
    /// The Program class. Only used to enter the Client.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main function. Enters Creates and enters a instance of client,
        /// and changes the output encoding to support unicode.
        /// </summary>
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Client gameClient = new Client();

            gameClient.GameLoop();
        }
    }
}
