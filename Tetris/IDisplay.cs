using System;
using System.Collections.Concurrent;

namespace Tetris
{
    public interface IDisplay
    {
        void TitleScreen(Dir dir);
        void Render();
        void UpdateBoard(Board board);
    }
}