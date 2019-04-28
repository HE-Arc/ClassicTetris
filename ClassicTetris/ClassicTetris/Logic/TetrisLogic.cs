using System.Collections.Generic;

namespace ClassicTetris
{
	/// <summary>
    /// Tetris logic, .
    /// </summary>
    public interface TetrisLogic
    {
		int Tick();
        bool TurnCW();
        bool TurnCCW();
        bool Right();
		bool Left();
		bool Down();
		void Drop();
		int[][] GetGrid();
        Dictionary<Tetromino.Shape, int> GetStatistics();
    }
}
