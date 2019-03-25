using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris
{
    class Settings
    {
        public const int WIDTH = 10;
        public const int HEIGHT = 20;

        public const int START_X = WIDTH / 2 - 2;
        public const int START_Y = -1;


        // HUD

        public const int SCORE_DIGITS = 6;
        public const int STATS_DIGITS = 3;

        public const int BOARD_OFFSET_X = 383;
        public const int BOARD_OFFSET_Y = 162;
        public const int SQUARE_SIZE = 32;
    }
}
