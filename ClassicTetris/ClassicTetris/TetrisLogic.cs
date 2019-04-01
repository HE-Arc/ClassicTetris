using System;
using System.Collections.Generic;

namespace ClassicTetris
{
    public interface TetrisLogic
    {
		int Tick();
		bool Turn();
		bool Right();
		bool Left();
		bool Down();
		void Drop();
		int[][] GetGrid();
        Dictionary<Tetromino.Shape, int> GetStatistics();
    }
}
