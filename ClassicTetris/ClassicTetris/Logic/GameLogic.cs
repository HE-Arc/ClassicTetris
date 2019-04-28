using System.Collections.Generic;
using System.Timers;
using ClassicTetris.Audio;
using ClassicTetris.Menus;

namespace ClassicTetris
{
	class GameLogic : TetrisLogic
    {
        #region Attributes
        private static GameLogic instance = null;
        private Board board;
        private int counterUpdate;
        private int lineLevel;
        private bool ended;
        
        #endregion

        public int Score { get; private set; }
        public int Level { get; private set; }
        public int NbLines { get; private set; }
		public GameType Type { get; private set; } //0 = A, 1 = B
        public bool GameEnded => ended && !board.AnimationEndGame;

        internal static GameLogic Instance
        {
            get
            {
                if (instance == null)
                {
					Reset(0, 0);
                }
                return instance;
            }
        }

		public static void Reset(int level, GameType gameType)
		{
			instance = new GameLogic(level, gameType);
		}

		protected GameLogic(int level, GameType gameType)
        {
            Score = 0;
            Level = level;
			Type = gameType;
            ended = true;
            counterUpdate = Settings.SPEED_LEVEL[Level % Settings.MAX_LEVEL_THEORICAL];
            lineLevel = Settings.LINE_LEVEL[Level % Settings.MAX_LEVEL_THEORICAL];

            board = new Board();
            StartGame();
        }

        private void StartGame()
        {
            ended = false;
        }

        public Tetromino GetNextShape()
        {
            return board.NextShape;
        }
        
        public Dictionary<Tetromino.Shape, int> GetStatistics()
        {
            return board.GetStatistics();
        }

        public void update()
        {
            if (ended && !board.AnimationEndGame)
            {
                return;
            }

            --counterUpdate;
            if (counterUpdate <= 0)
            {
                // Animate remove line
                Tick();

                if(board.AnimationEndGame)
                {
                    counterUpdate = Settings.SPEED_ENDGAME_ANIMATION;
                }
                else if (board.RemovingLineState)
                {
                    counterUpdate = Settings.SPEED_LINE_REMOVAL;
                }
                else
                {
                    counterUpdate = Settings.SPEED_LEVEL[Level % Settings.MAX_LEVEL_THEORICAL];
                }
            }
        }

        public int Tick()
		{
            //Down on the board
			int nbLineRemoved = board.Tick();
            switch (nbLineRemoved)
            {
                case -1:
                    ended = true;
                    break;
                case 1:
                    Score += 40 * (Level + 1);
                    break;
                case 2:
                    Score += 100 * (Level + 1);
                    break;
                case 3:
                    Score += 300 * (Level + 1);
                    break;
                case 4:
                    Score += 1200 * (Level + 1);
                    break;
            }

            // Add sound
			if (nbLineRemoved >= 4)
            {
				AudioManager.GetInstance().Play(SFX.LineRemoval4);
            }
			else if(nbLineRemoved >= 1)
			{
				AudioManager.GetInstance().Play(SFX.LineRemove);
			}
            else if(nbLineRemoved < 0){
                //TODO: Add loose animation + delay
                ended = true;
                return 0;
            }

            // Check level up
            NbLines += nbLineRemoved;
            lineLevel -= nbLineRemoved;
            if(lineLevel < 0)
            {
                ++Level;
                lineLevel += Settings.LINE_LEVEL[Level % Settings.MAX_LEVEL_THEORICAL];
            }

            return nbLineRemoved;
		}
        
        public bool TurnCW()
        {
            bool result = board.TurnCW();
            if (!result)
            {
                AudioManager.GetInstance().Play(SFX.BlockRotate);
            }
            return result;
        }

        public bool TurnCCW()
        {
            bool result = board.TurnCCW();
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
				AudioManager.GetInstance().Play(SFX.ForceHit);
            }
            return result;
		}

		public void Drop()
		{
			board.Drop();
			AudioManager.GetInstance().Play(SFX.LineDrop);
		}

		public int[][] GetGrid()
		{
			return board.GetGrid();
		}
    }
}
