using System;

namespace Tetris
{
    /// <summary>
    /// Struct that defines the game score and player name.
    /// </summary>
    public struct Score:  IComparable<Score>
    {
        /// <summary>
        /// Property that defines the player's name.
        /// </summary>
        /// <value>The player name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the property that defines the player's score.
        /// </summary>
        /// <value>The score.</value>
        public int Points { get; private set; }

        /// <summary>
        /// Constructor. Creates a new instance of Score.
        /// </summary>
        /// <param name="name">The player name.</param>
        /// <param name="points">The Starting score.</param>
        public Score(string name = "Player", int points = 0)
        {
            Name = name;
            Points = points;
        }

        /// <summary>
        /// Method that increases the current score based on the given integer 
        /// of lines cleared.
        /// </summary>
        /// <param name="linesCleared">Number of lines cleared.</param>
        public void IncreaseScore(int linesCleared)
        {
            int increaseBy = 0;
            switch (linesCleared)
            {
                case 1:
                    increaseBy = 100;
                    break;
                case 2:
                    increaseBy = 300;
                    break;
                case 3:
                    increaseBy = 500;
                    break;
                case 4:
                    increaseBy = 800;
                    break;
            }

            Points += increaseBy;
        }

        /// <summary>
        /// Returns the instance's score properly formatted in string format.
        /// </summary>
        /// <returns>A string representing the score.</returns>
        public override string ToString()
        {
            return $"{Name} - {Points}";
        }

        /// <summary>
        /// Compares two Score objects.
        /// </summary>
        /// <param name="other">Second Score object.</param>
        /// <returns><c>-1</c> if <param name="other"> is not a Score,
        /// difference between <param name="other"> and this Score otherwise.
        /// </returns>
        public int CompareTo(Score other)
        {
            return other.Points - Points;
        }

    }
}