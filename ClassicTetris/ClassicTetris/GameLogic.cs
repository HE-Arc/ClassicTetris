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
        private struct ShapeGrid
        {
            public int shape;
            public int[,] currentShape;
            // i, j represent the top left corner of the piece
            public int i;
            public int j;
            public ShapeGrid Clone()
            {
                ShapeGrid newShape;
                newShape = this;
                newShape.currentShape = currentShape.Clone();
            }
        }

        //TODO Change int to;
        private ShapeGrid currentShape;

        private int[,] landedShape;

        /// <summary>
        /// Trigger when a turn must be run
        /// </summary>
        public void Tick()
        {
            if (Down())
            {
                //Piece not down
            }
            else
            {
                //TODO prepare for next piece
                //TODO Check end of game
            }
        }

        /// <summary>
        /// Turn the pieces
        /// </summary>
        public void Turn()
        {
            //TODO turn currentShape
            int[,] nextShape = null;

            if(CanMove(nextShape, topLeftShape))
            {
                currentShape = nextShape;
            }
        }

        /// <summary>
        /// Move the piece one column to the right
        /// </summary>
        public bool Right()
        {
            ShapeGrid nextShape = currentShape.Clone();
            nextShape.i++;
            if (CanMove(nextShape))
            {
                currentShape = nextShape;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Move the piece one column left
        /// </summary>
        public bool Left()
        {
            ShapeGrid nextShape = currentShape.Clone();
            nextShape.i--;
            if (CanMove(nextShape))
            {
                currentShape = nextShape;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Move the pieces one line down
        /// </summary>
        public bool Down()
        {
            ShapeGrid nextShape = currentShape.Clone();
            nextShape.j++;
            if (CanMove(nextShape))
            {
                currentShape = nextShape;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Drop the piece all the way down
        /// </summary>
        public void Drop()
        {
            while (Down()) { };
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
        private bool CanMove(ShapeGrid shape)
        {
            //TODO Manage shape out of grid
            int n = nextShape.Length;
            
            for(int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (shape.currentShape[i, j] > 0 &&
                        i > 0 && i < Settings.WIDTH &&
                        j > 0 && j < Settings.HEIGHT &&
                        landedShape[shape.i+i, shape.j+j] > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
