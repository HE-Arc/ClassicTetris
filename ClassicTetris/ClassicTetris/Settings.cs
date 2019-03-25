using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris
{
    class Settings
    {
        public const int BOARD_WIDTH = 10;
        public const int BOARD_HEIGHT = 20;

        public const int START_X = 0;
        public const int START_Y = BOARD_WIDTH / 2 - 2;


        // HUD

        public const int SCORE_DIGITS = 6;
        public const int STATS_DIGITS = 3;

        public const int BOARD_OFFSET_X = 383;
        public const int BOARD_OFFSET_Y = 162;
        public const int SQUARE_SIZE = 32;
    }
}
