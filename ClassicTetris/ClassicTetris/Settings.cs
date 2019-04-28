using Microsoft.Xna.Framework;

namespace ClassicTetris
{
    class Settings
    {
        #region Window
        public const int WINDOW_WIDTH = 1024;
        public const int WINDOW_HEIGHT = 896;

        #endregion

        #region GameLogic

        public const int BOARD_WIDTH = 10;
        public const int BOARD_HEIGHT = 20;

        public const int START_X = BOARD_WIDTH / 2 - 2;
        public const int START_Y = -1;
        public const int TETROMINOES = 7;
        public static readonly int[] SPEED_LEVEL = { 48, 43, 38, 33, 28, 23, 18, 13, 8, 6, 5, 5, 5, 4, 4, 4, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 };
        public static readonly int[] LINE_LEVEL = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 100, 100, 100, 100, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 200, 200, 200 };
        public const int MAX_LEVEL_THEORICAL = 30;

        public const int FAST_DROP_GRAVITY = 5;
        public const int DELAY_AUTO_SHIFT_INITIAL = 16;
        public const int DELAY_AUTO_SHIFT = 6;
        public const int SPEED_LINE_REMOVAL = 2;
        public const int SPEED_ENDGAME_ANIMATION = 2;

        public const int END_GAME_TEXTURE = 8;
        #endregion

        #region HUD
        public const int SCORE_DIGITS = 6;
        public const int STATS_DIGITS = 3;
        public const int LEVEL_DIGITS = 2;
        public const int LINES_DIGITS = 3;

        public const int BOARD_OFFSET_X = 383;
        public const int BOARD_OFFSET_Y = 162;
        public const int NEXT_TETRO_OFFSET_X = 768;
        public const int NEXT_TETRO_OFFSET_Y = 420;

        public const int SQUARE_SIZE = 30;
        public const int SQUARE_SPREARD = 2;
        public const int EDGE_SIZE = SQUARE_SIZE / 6;

        public const int NB_COLORS_LEVELS = 10;
        public const int NB_TEXTURES = 5;

        public static Color COLOR_LEVEL_0_PRIMARY => Color.FromNonPremultiplied(32, 56, 236, 255);
        public static Color COLOR_LEVEL_0_SECONDARY => Color.FromNonPremultiplied(60, 188, 252, 255);

        public static Color COLOR_LEVEL_1_PRIMARY => Color.FromNonPremultiplied(0, 168, 0, 255);
        public static Color COLOR_LEVEL_1_SECONDARY => Color.FromNonPremultiplied(128, 208, 16, 255);

        public static Color COLOR_LEVEL_2_PRIMARY => Color.FromNonPremultiplied(188, 0, 188, 255);
        public static Color COLOR_LEVEL_2_SECONDARY => Color.FromNonPremultiplied(244, 120, 252, 255);

        public static Color COLOR_LEVEL_3_PRIMARY => COLOR_LEVEL_0_PRIMARY;
        public static Color COLOR_LEVEL_3_SECONDARY => Color.FromNonPremultiplied(76, 220, 72, 255);

        public static Color COLOR_LEVEL_4_PRIMARY => Color.FromNonPremultiplied(228, 0, 88, 255);
        public static Color COLOR_LEVEL_4_SECONDARY => Color.FromNonPremultiplied(88, 248, 152, 255);

        public static Color COLOR_LEVEL_5_PRIMARY => COLOR_LEVEL_4_SECONDARY;
        public static Color COLOR_LEVEL_5_SECONDARY => Color.FromNonPremultiplied(92, 148, 252, 255);

        public static Color COLOR_LEVEL_6_PRIMARY => Color.FromNonPremultiplied(216, 40, 0, 255);
        public static Color COLOR_LEVEL_6_SECONDARY => Color.FromNonPremultiplied(116, 116, 116, 255);

        public static Color COLOR_LEVEL_7_PRIMARY => Color.FromNonPremultiplied(128, 0, 240, 255);
        public static Color COLOR_LEVEL_7_SECONDARY => Color.FromNonPremultiplied(168, 0, 16, 255);

        public static Color COLOR_LEVEL_8_PRIMARY => COLOR_LEVEL_0_PRIMARY;
        public static Color COLOR_LEVEL_8_SECONDARY => COLOR_LEVEL_6_PRIMARY;

        public static Color COLOR_LEVEL_9_PRIMARY => COLOR_LEVEL_6_PRIMARY;
        public static Color COLOR_LEVEL_9_SECONDARY => Color.FromNonPremultiplied(252, 152, 56, 255);
        #endregion
    }
}
