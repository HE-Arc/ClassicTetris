using System;
namespace ClassicTetris
{
	/// <summary>
    /// Tetris logic, .
    /// </summary>
    public interface TetrisLogic
    {
		int Tick();
		bool Turn();
		bool Right();
		bool Left();
		bool Down();
		void Drop();
		int[][] GetGrid();
    }
}
