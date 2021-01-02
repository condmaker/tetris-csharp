using System;

namespace Tetris
{
    /// <summary>
    /// Class which represents a visual unit on the game UI.
    /// </summary>
    public struct Pixel
    {
        /// <summary>
        /// Property which represents the character to be printed.
        /// </summary>
        /// <value>Character to be printed.</value>
        public char Character { get; } 
        /// <summary>
        /// Property which represents the color to be printed.
        /// </summary>
        /// <value>Color to be printed.</value>
        public ConsoleColor Color { get;}

        /// <summary>
        /// Constructor. Creates a new instance of Pixel with given color and 
        /// character. Defaults to blank character on black background.
        /// </summary>
        /// <param name="cl">Console Color.</param>
        /// <param name="c">Character.</param>
        public Pixel(ConsoleColor cl = ConsoleColor.Black, char c = ' ')
        {
            Color = cl;
            Character = c;
        }

        /// <summary>
        /// Method that indicates whether two Pixels are equal.
        /// </summary>
        /// <param name="p1">A pixel.</param>
        /// <param name="p2">Another Pixel.</param>
        /// <returns><c>true</c> if the two given Pixels are equal, 
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(Pixel p1, Pixel p2)
        {
            if ((p1.Character == p2.Character) && (p1.Color == p2.Color))
                return true;
            return false;
        }

        /// <summary>
        /// Method that indicates whether two Pixels are different.
        /// </summary>
        /// <param name="p1">A pixel.</param>
        /// <param name="p2">Another Pixel.</param>
        /// <returns><c>true</c> if the two given Pixels are different, 
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(Pixel p1, Pixel p2)
        {
            if ((p1.Character == p2.Character) && (p1.Color == p2.Color))
                return false;
            return true;
        }

        /// <summary>
        /// Method that indicates whether a given Object is equal to this 
        /// Pixel.
        /// </summary>
        /// <param name="obj">An object.</param>
        /// <returns><c>true</c> if the object is a Pixel and is equal to 
        /// this Pixel, <c>false</c> otherwise.</returns>
        public override bool Equals(Object obj)
        {
            if (!(obj is Pixel))
                return false;
            Pixel p = (Pixel) obj;
            return ((Character == p.Character) && (Color == p.Color));

        }

        /// <summary>
        /// This method is used to return the hash code for this instance.
        /// </summary>
        /// <returns>The hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return Color.GetHashCode() ^ Character.GetHashCode();
        }

        /// <summary>
        /// Returns the instance's Pixel properly formatted in string format.
        /// </summary>
        /// <returns>A string representing the instance's Pixel.</returns>
        public override string ToString()
        {
            return Color.ToString();
        }
    }
}