﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicTetris
{
    /// <summary>
    /// Main class managing all the logic of Tetris
    /// </summary>
    class Board
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
            landedShape = new int[Settings.HEIGHT][];
            for (int i = 0; i < landedShape.Length; i++)
            {
                landedShape[i] = new int[Settings.WIDTH];
            }

            //Create first shape
            currentShape = Tetromino.Random(Settings.START_X, Settings.START_Y);

            //Create next shape
            nextShape = Tetromino.Random(Settings.START_X, Settings.START_Y);
        }

        /// <summary>
        /// Trigger when a turn must be run
        /// </summary>
        public void Tick()
        {
            if (!Down())
            {
                //Merge shape to current grid
                this.landedShape = MergeGridWithShape();

                //Clear lines
                ClearLines(currentShape.y);

                //Change current shape
                currentShape = nextShape;
                
                //Generate next shape
                nextShape = Tetromino.Random(Settings.START_X, Settings.START_Y);
            }
            else
            {
                //Tetromino not down Nothing to do
            }
        }

        /// <summary>
        /// Turn the pieces
        /// </summary>
        public bool Turn()
        {
            //TODO turn currentShape
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
            Tetromino nextShape = currentShape.Down();
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
            for (int col = 0; col < landedShape.GetLength(1); ++col)
            {
                if (landedShape[row][col] == 0)
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
                    grid[currentShape.x + i][currentShape.y + j]
                        = shape[i, j];
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
            int nbRow = 4;   //check fourth row
            int rowId = startLine + nbRow - 1;

            int nbRowRemoved = 0;

            while (nbRow > 0)
            {
                if (RowIsFull(rowId))
                {
                    //Move all content above one line below
                    MoveDownAllRowAbove(rowId);
                    ++nbRowRemoved;
                }
                else
                {
                    //Look at the row above
                    --rowId;
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
            landedShape[0] = new int[Settings.WIDTH];
        }

        /// <summary>
        /// Return true if the move is valid
        /// </summary>
        /// <param name="nextPos"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        private bool CanMove(Tetromino shape)
        {
            int n = shape.Grid.Length;
            
            for(int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (shape.Grid[i, j] > 0 && (
                        shape.x + i < 0 || shape.x + i >= Settings.WIDTH ||
                        shape.y + j < 0 || shape.y + j >= Settings.HEIGHT ||
                        landedShape[shape.x+i][shape.y+j] > 0))
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