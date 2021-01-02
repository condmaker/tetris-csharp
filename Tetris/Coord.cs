using System;

namespace Tetris
{
    /// <summary>
    /// Struct that defines what is a 'position'/'coordinate' on the game's
    /// 'board'.
    /// </summary>
    public struct Coord
    {
        /// <summary>
        /// Property that defines a horizontal position on the 'board'.
        /// </summary>
        /// <value>Aforementioned horizontal position.</value>
        public int x { get; }

        /// <summary>
        /// Property that defines a vertical position on the 'board'.
        /// </summary>
        /// <value>Aforementioned vertical position.</value>
        public int y { get; }

        /// <summary>
        /// Creates a position (Coord instance) to be used on the board.
        /// </summary>
        /// <param name="x">Horizontal position.</param>
        /// <param name="y">Vertical position.</param>
        public Coord(int x=0, int y=0)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Creates a position (Coord instance) to be used on the board from a 
        /// Direction.
        /// </summary>
        /// <param name="dir">Direction.</param>
        public Coord(Dir dir)
        {
            x = 0;
            y = 0;
            switch (dir)
            {
                case Dir.None:
                    x = 0;
                    y = 0;
                    break;
                case Dir.Up:
                    x = 0;
                    y = -1;
                    break;
                case Dir.Down:
                    x = 0;
                    y = 1;
                    break;
                case Dir.Left:
                    x = -1;
                    y = 0;
                    break;
                case Dir.Right:
                    x = 1;
                    y = 0;
                    break;           
            }
        }

        /// <summary>
        /// Returns the instance's position properly formatted in string format.
        /// </summary>
        /// <returns>A string representing the instance's position.</returns>
        public  override string ToString() => $"({x}, {y})";

        /// <summary>
        /// Retuns the sum of two positions.
        /// </summary>
        /// <param name="a">A position.</param>
        /// <param name="b">A position.</param>
        /// <returns>The sum of the positions.</returns>
        public static Coord operator +(Coord a, Coord b) 
        => new Coord(a.x + b.x, a.y + b.y);

        /// <summary>
        /// Retuns the subtraction of two positions.
        /// </summary>
        /// <param name="a">A position.</param>
        /// <param name="b">A position.</param>
        /// <returns>The subtraction of the positions.</returns>
        public static Coord operator -(Coord a, Coord b) 
        => new Coord(a.x - b.x, a.y - b.y);

        /// <summary>
        /// Retuns the mutiplication of two positions.
        /// </summary>
        /// <param name="a">A position.</param>
        /// <param name="b">A position.</param>
        /// <returns>The multiplication of the positions.</returns>
        public static Coord operator *(Coord a, int b) 
        => new Coord(a.x * b, a.y * b);

        /// <summary>
        /// Retuns the division of two positions.
        /// </summary>
        /// <param name="a">A position.</param>
        /// <param name="b">A position.</param>
        /// <returns>The division of the positions.</returns>
        public static Coord operator /(Coord a, int b)
        {
            if (b == 0)
                throw new System.DivideByZeroException();
            return new Coord(a.x / b, a.y / b);
        }

        /// <summary>
        /// Method that indicates whether two given Positions are equal.
        /// </summary>
        /// <param name="a">A position.</param>
        /// <param name="b">A position.</param>
        /// <returns><c>true</c> if the two given positions are equal,
        /// <c>false</c> otherwise.</returns>
        public static bool operator ==(Coord a, Coord b){
            if (a.x != b.x)
                return false;
            if (a.y != b.y)
                return false;
            return true;
        } 

        /// <summary>
        /// Method that indicates whether two given Positions are different.
        /// </summary>
        /// <param name="a">A position.</param>
        /// <param name="b">A position.</param>
        /// <returns><c>true</c> if the two given positions are different,
        /// <c>false</c> otherwise.</returns>
        public static bool operator !=(Coord a, Coord b){
            return !(a==b);
        }

        /// <summary>
        /// Method that indicates whether a given Object is equal to this 
        /// Position.
        /// </summary>
        /// <param name="obj">An object.</param>
        /// <returns><c>true</c> if the object is a position and is equal to 
        /// this position, <c>false</c> otherwise.</returns>
        public override bool Equals(Object obj){
            if (!(obj is Coord))
                return false;
            Coord c = (Coord) obj;
            return ((x == c.x) && (y == c.y));
        }

        /// <summary>
        /// This method is used to return the hash code for this instance.
        /// </summary>
        /// <returns>The hash code for this instance.</returns>
        public override int GetHashCode(){
            return x.GetHashCode() ^ y.GetHashCode();
        }
    }
}