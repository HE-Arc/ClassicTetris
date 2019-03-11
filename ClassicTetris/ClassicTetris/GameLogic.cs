using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris
{
    /// <summary>
    /// Main class managing alf the logic of Tetris
    /// </summary>
    class GameLogic
    {
        //TODO Change int to
        private Tuple<int, int> topLeftShape;
        private int shape;

        private int[,] landedShape;


        /// <summary>
        /// Turn the pieces
        /// </summary>
        public void Turn()
        {

        }

        /// <summary>
        /// Move the piece one column to the right
        /// </summary>
        public void Right()
        {
            
        }

        /// <summary>
        /// Move the piece one column left
        /// </summary>
        public void Left()
        {

        }

        /// <summary>
        /// Move the pieces one line down
        /// </summary>
        public void Down()
        {

        }

        /// <summary>
        /// Drop the piece all the way down
        /// </summary>
        public void Drop()
        {

        }

        /// <summary>
        /// Return the grid
        /// </summary>
        /// <returns></returns>
        public int[,] GetGrid()
        {
            return null;
        }

        /// <summary>
        /// Return true if the move is valid
        /// </summary>
        /// <param name="nextPos"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        private bool CanMove(int[,] nextShape, Tuple<int,int> topLeftCorner)
        {
            //TODO Manage shape out of grid
            int n = nextShape.Length;
            
            for(int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (landedShape[topLeftCorner.Item1+i, topLeftCorner.Item2+j] > 0 && nextShape[i,j] > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
