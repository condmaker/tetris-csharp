using System;
using System.Collections.Concurrent;

namespace Tetris
{
    public interface IDisplay
    {
        BlockingCollection<ConsoleKey> Input { get; }

        void TitleScreen();
        void InputRead();
    }
}