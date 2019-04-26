using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassicTetris
{
    /// <summary>
    /// Main class managing all the logic of Tetris
    /// </summary>
	class Board : TetrisLogic
    {
        #region Attributes
        private int[][] landedShape;
        private Dictionary<Tetromino.Shape, int> statistics;
        private List<int> linesToRemoveId;
        private int lineRemoveState = 0;
        private int endGameState = -1;

        public bool AnimationEndGame => endGameState > -1 && endGameState < Settings.BOARD_HEIGHT;
        public bool RemovingLineState => lineRemoveState > 0;
        public Tetromino NextShape { get; private set; }
        public Tetromino CurrentShape { get; private set; }

        #endregion

        /// <summary>
        /// Constructor of the board
        /// </summary>
        public Board()
        {
            //Init line remove
            linesToRemoveId = new List<int>();
            lineRemoveState = 0;

            //Init grid
            landedShape = new int[Settings.BOARD_HEIGHT][];
            for (int i = 0; i < landedShape.Length; i++)
            {
                landedShape[i] = new int[Settings.BOARD_WIDTH];
            }

            //Create first shape
            CurrentShape = Tetromino.Random(Settings.START_X, Settings.START_Y);

            //Create next shape
            NextShape = Tetromino.Random(Settings.START_X, Settings.START_Y);

            //Statistics
            statistics = new Dictionary<Tetromino.Shape, int>();
            foreach(Tetromino.Shape shape in Enum.GetValues(typeof(Tetromino.Shape)))
            {
                statistics.Add(shape, 0);
            }
        }

        /// <summary>
        /// Get the dictionary of the stitistics
        /// </summary>
        /// <returns>Statistics of th pieces</returns>
        public Dictionary<Tetromino.Shape, int> GetStatistics() => statistics.ToDictionary(entry => entry.Key, entry => entry.Value);
        
        /// <summary>
        /// Trigger when a turn must be run
        /// </summary>
        /// <returns>Nb line removed - (-1) for Game Over</returns>
        public int Tick()
        {
            if (endGameState >= Settings.BOARD_HEIGHT)
            {
                return -1;
            }

            if (AnimationEndGame)
            {
                EndLineAnimate(endGameState);
                ++endGameState;
                return -1;
            }

            if (lineRemoveState > 0)
            {
                switch (lineRemoveState)
                {
                    //Last state, move down all the lines
                    case 1:
                        ClearLines(linesToRemoveId);
                        break;
                    
                    //Default we remove two squares
                    default:
                        RemoveAnimate(linesToRemoveId, lineRemoveState);
                        break;
                }

                --lineRemoveState;
                return 0;
            }

            if (!Down())
            {
                // Detect Game Over
                if(CurrentShape.y < 0)
                {
                    Console.WriteLine("Game Over !");
                    ++endGameState;
                    landedShape = MergeGridWithShape();
                    CurrentShape = Tetromino.Empty();
                    return -1;
                }
                
                //Update statistics
                statistics[CurrentShape.shape]++;

                //Merge shape to current grid
                landedShape = MergeGridWithShape();

                //Clear lines
                linesToRemoveId = CompletedLines(CurrentShape.y);

                //Change current shape
                CurrentShape = NextShape;
                
                //Generate next shape
                NextShape = Tetromino.Random(Settings.START_X, Settings.START_Y);

                //Set removing line state
                lineRemoveState = 6;

                return linesToRemoveId.Count();
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
            Tetromino nextShape = CurrentShape.Rotate();
            if(CanMove(nextShape))
            {
                CurrentShape = nextShape;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Move the piece one column to the right
        /// </summary>
        public bool Right()
        {
            Tetromino nextShape = CurrentShape.Right();
            if (CanMove(nextShape))
            {
                CurrentShape = nextShape;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Move the piece one column left
        /// </summary>
        public bool Left()
        {
            Tetromino nextShape = CurrentShape.Left();
            if (CanMove(nextShape))
            {
                CurrentShape = nextShape;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Move the pieces one line down
        /// </summary>
        public bool Down()
        {
            Tetromino movedShape = CurrentShape.Down();
            if (CanMove(movedShape))
            {
                CurrentShape = movedShape;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Drop the piece all the way down
        /// </summary>
        public void Drop()
        {
            while (Down()) { }
        }

        /// <summary>
        /// Return the grid
        /// </summary>
        /// <returns>The grid</returns>
        public int[][] GetGrid() => MergeGridWithShape();

        #region Private methods

        /// <summary>
        /// 
        /// </summary>
        private void EndLineAnimate(int lineId)
        {
            for(int i = 0; i < Settings.BOARD_WIDTH; ++i)
            {
                landedShape[lineId][i] = Settings.END_GAME_TEXTURE;
            }
        }

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
            int[,] shape = CurrentShape.Grid;
            int[][] grid = CopyArrayLinq(landedShape);

            int n = shape.GetLength(0);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if(shape[i, j] > 0 && CurrentShape.y + i >= 0)
                    {
                        grid[CurrentShape.y + i][CurrentShape.x + j]
                            = shape[i, j];
                    }
                }
            }
            return grid;
        }

        private void RemoveAnimate(List<int> linesToRemove, int lineRemoveState)
        {
            //lineRemoveState 
            // From 6 to 2
            int indiceOne = lineRemoveState - 2;
            int indiceTwo = 9 - (lineRemoveState - 2);

            linesToRemove.ForEach(i =>
            {
                landedShape[i][indiceOne] = (int)Tetromino.Shape.None;
                landedShape[i][indiceTwo] = (int)Tetromino.Shape.None;
            });
        }

        /// <summary>
        /// Remove all full lines
        /// </summary>
        /// <param name="startLine"></param>
        /// <returns>Number of row removed</returns>
        private void ClearLines(List<int> lines)
        {
            lines.Sort();
            lines.ForEach(i => MoveDownAllRowAbove(i));
        }

        /// <summary>
        /// Return aq list of all completed lines indices
        /// </summary>
        /// <param name="startLine"></param>
        /// <returns>Indices of completed lines</returns>
        private List<int> CompletedLines(int startLine)
        {
            List<int> linesToRemove = new List<int>();
            int nbRow = CurrentShape.Grid.GetLength(0);   //check four row
            int row = Math.Min(startLine + nbRow, Settings.BOARD_HEIGHT) - 1;
            
            while (nbRow > 0)
            {
                if (RowIsFull(row))
                {
                    linesToRemove.Add(row);
                }
                --row;
                --nbRow;
            }
            return linesToRemove;
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
