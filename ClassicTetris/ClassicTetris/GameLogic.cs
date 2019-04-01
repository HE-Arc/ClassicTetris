using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ClassicTetris
{
    class GameLogic
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
        internal Board Board { get => board; set => board = value; }
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
            this.Board = new Board();
            timer = new Timer(800);
            timer.Elapsed += (sender, e) => Tick();

            StartGame();
        }

        private void StartGame()
        {
            timer.Start();
        }

        public void Tick()
        {
            int test = Board.Tick();
            score += 10 * test;
        }
    }
}
