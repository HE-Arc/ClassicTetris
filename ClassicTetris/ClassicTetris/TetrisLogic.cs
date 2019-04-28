using System.Collections.Generic;

namespace ClassicTetris
{
	/// <summary>
    /// Interface for Tetris logic
    /// </summary>
    public interface TetrisLogic
    {
        /// <summary>
        /// Function called at each frame 
        /// </summary>
        /// <returns>Event code</returns>
		int Tick();

        /// <summary>
        /// Turn the current tetrominos
        /// </summary>
        /// <returns>Success</returns>
		bool Turn();

        /// <summary>
        /// Move right the current tetrominos
        /// </summary>
        /// <returns>Success</returns>
		bool Right();

        /// <summary>
        /// Move left the current tetrominos
        /// </summary>
        /// <returns>Success</returns>
        bool Left();

        /// <summary>
        /// Move down the current tetrominos
        /// </summary>
        /// <returns>Success</returns>
		bool Down();

        /// <summary>
        /// Hard drop the current tetrominos
        /// </summary>
        /// <returns>Success</returns>
        void Drop();

        /// <summary>
        /// Get the current game grid
        /// </summary>
        /// <returns>The grid of tetrominos</returns>
        int[][] GetGrid();

        /// <summary>
        /// Statistics of the number of differents shapes
        /// </summary>
        /// <returns>Shapes count</returns>
        Dictionary<Tetromino.Shape, int> GetStatistics();
    }
}
