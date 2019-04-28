using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris
{
    class TetrisMath
    {
        /// <summary>
        /// A real mathematical modulo
        /// https://stackoverflow.com/a/10065670/9263555
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="n">n</param>
        /// <returns>a modulo n</returns>
        public static int mod(int a, int n)
        {
            return ((a % n) + n) % n;
        }
    }
}
