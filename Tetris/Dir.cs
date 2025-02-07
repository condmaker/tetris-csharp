namespace Tetris
{
    /// <summary>
    /// An enumerator defining possible actions to be performed by the user.
    /// </summary>
    public enum Dir
    {
        /// <summary>
        /// Moves up or rotates 90 degrees clockwise.
        /// </summary>
        Up,

        /// <summary>
        /// Moves down.
        /// </summary>
        Down,

        /// <summary>
        /// Moves down faster.
        /// </summary>
        Fall,

        /// <summary>
        /// Moves left.
        /// </summary>
        Left,

        /// <summary>
        /// Moves right.
        /// </summary>
        Right,

        /// <summary>
        /// Confirm selection or return.
        /// </summary>
        Enter,

        /// <summary>
        /// Rotates 90 degrees clockwise.
        /// </summary>
        Rot,

        /// <summary>
        /// Does nothing.
        /// </summary>
        None,
    }
}