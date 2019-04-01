using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ClassicTetris.Audio;

namespace ClassicTetris
{
	class GameLogic : TetrisLogic
    {

        #region Attributes
        private static GameLogic instance = null;
        private int score;
        private int level;
        private int[] statistics; //Array of size=7, containing the number of time that the nth tetromino has spawned.
        private int type; //0 = A, 1 = B
        private Board board;
        private Timer timer;
        #endregion

        public int Score { get => score; set => score = value; }
        public int Level { get => level; set => level = value; }
        public int[] Statistics { get => statistics; set => statistics = value; }
        public int Type { get => type; set => type = value; }
        internal static GameLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameLogic();
                }
                return instance;
            }
        }

        protected GameLogic()
        {
            this.Score = 0;
            this.Level = 1;
            this.Statistics = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            this.Type = 0;
			this.board = new Board();
            timer = new Timer(800);
            timer.Elapsed += (sender, e) => Tick();

            StartGame();
        }

        private void StartGame()
        {
            timer.Start();
        }

		public int Tick()
		{
			int test = board.Tick();
			if (test > 1)
            {
				AudioManager.GetInstance().Play(SFX.BlockRotate);
            }
            score += 10 * test;
			return score;
		}

		public bool Turn()
		{
			bool result = board.Turn();
			if (!result)
            {
				AudioManager.GetInstance().Play(SFX.BlockRotate);
            }
			return result;
		}

		public bool Right()
		{
			bool result = board.Right();
			if (!result)
            {
				AudioManager.GetInstance().Play(SFX.BlockRotate);
            }
            return result;
		}

		public bool Left()
		{
			bool result = board.Left();
            if (!result)
			{
				AudioManager.GetInstance().Play(SFX.BlockRotate);            
            }
            return result;
		}

		public bool Down()
		{
			bool result = board.Down();
			if (!result)
            {
				AudioManager.GetInstance().Play(SFX.BlockRotate);
            }
            return result;
		}

		public void Drop()
		{
			board.Drop();
		}

		public int[][] GetGrid()
		{
			return board.GetGrid();
		}
	}
}
