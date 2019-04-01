using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris
{
    /// <summary>
    /// Main class managing all the logic of Tetris
    /// </summary>
	class Board : TetrisLogic
    {
        #region Attributes
        private Tetromino currentShape;
        private Tetromino nextShape;

        private int[][] landedShape;

        #endregion

        /// <summary>
        /// Constructor of the board
        /// </summary>
        public Board()
        {
            //Init grid
            landedShape = new int[Settings.BOARD_HEIGHT][];
            for (int i = 0; i < landedShape.Length; i++)
            {
                landedShape[i] = new int[Settings.BOARD_WIDTH];
            }

            //Create first shape
            currentShape = Tetromino.Random(Settings.START_X, Settings.START_Y);

            //Create next shape
            nextShape = Tetromino.Random(Settings.START_X, Settings.START_Y);
        }

        /// <summary>
        /// Trigger when a turn must be run
        /// </summary>
        /// <returns>Nb line removed - (-1) for Game Over</returns>
        public int Tick()
        {
            if (!Down())
            {
                // Detect Game Over
                if(currentShape.y < 0)
                {
                    Console.WriteLine("Game Over !");
                    return -1;
                }

                //Merge shape to current grid
                this.landedShape = MergeGridWithShape();

                //Clear lines
                int nbLignesRemoved = ClearLines(currentShape.y);

                //Change current shape
                currentShape = nextShape;
                
                //Generate next shape
                nextShape = Tetromino.Random(Settings.START_X, Settings.START_Y);
                return nbLignesRemoved;
            }
            else
            {
                //Tetromino not down Nothing to do
            }
            return 0;
        }

        /// <summary>
        /// Turn the pieces
        /// </summary>
        public bool Turn()
        {
            //turn currentShape
            Tetromino nextShape = currentShape.Rotate();
            if(CanMove(nextShape))
            {
                currentShape = nextShape;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Move the piece one column to the right
        /// </summary>
        public bool Right()
        {
            Tetromino nextShape = currentShape.Right();
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
            Tetromino nextShape = currentShape.Left();
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
            Tetromino movedShape = currentShape.Down();
            if (CanMove(movedShape))
            {
                currentShape = movedShape;
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
        /// <returns>The grid</returns>
        public int[][] GetGrid() => MergeGridWithShape();

        #region Private methods

        /// <summary>
        /// Check if a row is full
        /// </summary>
        /// <param name="row">Number of the row</param>
        /// <returns>True is the row is full</returns>
        private bool RowIsFull(int row)
        {
            for (int col = 0; col < landedShape[0].Length; ++col)
            {
                if (landedShape[row][col] <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Function to clone a 2d array
        /// </summary>
        /// <param name="source">Clone of the 2d array</param>
        /// <returns></returns>
        private static int[][] CopyArrayLinq(int[][] source)
        {
            return source.Select(s => s.ToArray()).ToArray();
        }

        /// <summary>
        /// Merge the grid with the current shape
        /// </summary>
        /// <returns>Complete grid</returns>
        private int[][] MergeGridWithShape()
        {
            int[,] shape = currentShape.Grid;
            int[][] grid = CopyArrayLinq(landedShape);

            int n = shape.GetLength(0);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if(shape[i, j] > 0 && currentShape.y + i >= 0)
                    {
                        grid[currentShape.y + i][currentShape.x + j]
                            = shape[i, j];
                    }
                }
            }
            return grid;
        }

        /// <summary>
        /// Remove all full lines
        /// </summary>
        /// <param name="startLine"></param>
        /// <returns>Number of row removed</returns>
        private int ClearLines(int startLine)
        {
            int nbRow = currentShape.Grid.GetLength(0);   //check four row
            int row = Math.Min(startLine + nbRow, Settings.BOARD_HEIGHT) - 1;

            int nbRowRemoved = 0;

            while (nbRow > 0)
            {
                if (RowIsFull(row))
                {
                    //Move all content above one line below
                    MoveDownAllRowAbove(row);
                    ++nbRowRemoved;
                }
                else
                {
                    //Look at the row above
                    --row;
                }
                --nbRow;
            }
            return nbRowRemoved;
        }

        /// <summary>
        /// Move all rows above the given row one row below
        /// The given rowId will be deleted
        /// </summary>
        /// <param name="rowId"></param>
        private void MoveDownAllRowAbove(int rowId)
        {
            for (int i = rowId; i > 0; --i)
            {
                landedShape[i] = (int[])landedShape[i - 1].Clone();
            }
            landedShape[0] = new int[Settings.BOARD_WIDTH];
        }

        /// <summary>
        /// Return true if the move is valid
        /// </summary>
        /// <param name="nextPos"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        private bool CanMove(Tetromino shape)
        {
            int n = shape.Grid.GetLength(0);
            
            for(int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (shape.Grid[i, j] > 0 && shape.y + i >= 0 && (
                        shape.y + i >= Settings.BOARD_HEIGHT ||
                        shape.x + j < 0 || shape.x + j >= Settings.BOARD_WIDTH ||
                        landedShape[shape.y+i][shape.x+j] > 0))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion
    }
}
