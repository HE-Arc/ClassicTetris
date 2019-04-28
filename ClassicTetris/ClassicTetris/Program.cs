using System;

namespace ClassicTetris
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (Tetris tetris = new Tetris())
                tetris.Run();
        }
    }
}
