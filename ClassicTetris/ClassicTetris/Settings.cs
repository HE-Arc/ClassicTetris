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


        public const int START_X = BOARD_WIDTH / 2 - 2;
        public const int START_Y = -1;

        public const int TETROMINOES = 7;


        // HUD

        public const int SCORE_DIGITS = 6;
        public const int STATS_DIGITS = 3;
        public const int LEVEL_DIGITS = 2;

        public const int BOARD_OFFSET_X = 383;
        public const int BOARD_OFFSET_Y = 162;
        public const int NEXT_TETRO_OFFSET_X = 768;
        public const int NEXT_TETRO_OFFSET_Y = 420;

        public const int SQUARE_SIZE = 32;
    }
}
