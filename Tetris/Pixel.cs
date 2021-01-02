using System;

namespace Tetris
{
    public struct Pixel
    {
        public char Character { get; set; } 
        public ConsoleColor Color { get; set; }

        public Pixel(ConsoleColor cl = ConsoleColor.Black, char c = ' ')
        {
            Color = cl;
            Character = c;
        }

        public static bool operator ==(Pixel p1, Pixel p2)
        {
            if ((p1.Character == p2.Character) && (p1.Color == p2.Color))
                return true;
            return false;
        }

        public static bool operator !=(Pixel p1, Pixel p2)
        {
            if ((p1.Character == p2.Character) && (p1.Color == p2.Color))
                return false;
            return true;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Pixel))
                return false;
            Pixel p = (Pixel) obj;
            return ((Character == p.Character) && (Color == p.Color));

        }

        public override int GetHashCode()
        {
            return Color.GetHashCode() ^ Character.GetHashCode();
        }

        public override string ToString()
        {
            return Color.ToString();
        }

        public void Clear()
        {
            Color = ConsoleColor.Gray;
        }
    }
}