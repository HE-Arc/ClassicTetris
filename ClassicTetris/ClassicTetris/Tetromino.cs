using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassicTetris
{
    /// <summary>
    /// Represent a Tetrominos
    /// Those objects are immutable
    /// </summary>
    public class Tetromino
    {
        #region Static
		public enum Shape
		{
            None = 0,
			I = 1,
            O = 2,
            J = 3,
            L = 4,
            S = 5,
            T = 6,
            Z = 7
        }

        /// <summary>
		/// Key : Shape
		/// Value :
		///     - first array : rotation
		///     - second array : 2d grid with the pattern
        /// </summary>
        ///
		public static readonly Dictionary<Shape, int[][,]> sequence = new Dictionary<Shape, int[][,]>();
        private static readonly Random random = new Random();

        #endregion

        #region Static random
        
    /// <summary>
    /// Create a new random Tetromino
    /// </summary>
    /// <param name="x">X location</param>
    /// <param name="y">Y location</param>
    /// <returns>New newly created tetromino</returns>
    public static Tetromino Random(int x, int y)
        {
            Shape[] values = (Shape[])Enum.GetValues(typeof(Shape));
            Shape randomShape = (Shape)values.GetValue(random.Next(1,values.Length));
            return new Tetromino(x, y, randomShape);
        }

        #endregion

        #region Static constructor

        static Tetromino()
        {
            int empty = 0;
            // I
            int shape = (int)Shape.I;
            sequence[Shape.I] = new int[2][,];
            sequence[Shape.I][0] = new int[,] {
                { empty, empty, empty, empty},
                { empty, empty, empty, empty},
                { shape, shape, shape, shape},
                { empty, empty, empty, empty}
            };
            sequence[Shape.I][1] = new int[,]{
                {empty, empty, shape, empty},
                {empty, empty, shape, empty},
                {empty, empty, shape, empty},
                {empty, empty, shape, empty}
            };

            // O
            shape = (int)Shape.O;
            sequence[Shape.O] = new int[1][,];
            sequence[Shape.O][0] = new int[,] {
                {empty, empty, empty, empty},
                {empty, shape, shape, empty},
                {empty, shape, shape, empty},
                {empty, empty, empty, empty}
            };

            // J
            shape = (int)Shape.J;
            sequence[Shape.J] = new int[4][,];
            sequence[Shape.J][0] = new int[,] {
                {empty, empty, empty},
                {shape, shape, shape},
                {empty, empty, shape},
            };

            sequence[Shape.J][1] = new int[,] {
                {empty, shape, empty},
                {empty, shape, empty},
                {shape, shape, empty}
            };
            sequence[Shape.J][2] = new int[,] {
                {shape, empty, empty},
                {shape, shape, shape},
                {empty, empty, empty}
            };
            sequence[Shape.J][3] = new int[,] {
                {empty, shape, shape},
                {empty, shape, empty},
                {empty, shape, empty}
            };

            // L  
            shape = (int)Shape.L;
            sequence[Shape.L] = new int[4][,];
            sequence[Shape.L][0] = new int[,] {
                {empty, empty, empty},
                {shape, shape, shape},
                {shape, empty, empty}
            };
            sequence[Shape.L][1] = new int[,] {
                {shape, shape, empty},
                {empty, shape, empty},
                {empty, shape, empty}
            };
            sequence[Shape.L][2] = new int[,] {
                {empty, empty, shape},
                {shape, shape, shape},
                {empty, empty, empty}
            };
            sequence[Shape.L][3] = new int[,] {
                {empty, shape, empty},
                {empty, shape, empty},
                {empty, shape, shape}
            };

            // S
            shape = (int)Shape.S;
            sequence[Shape.S] = new int[2][,];
            sequence[Shape.S][0] = new int[,] {
                {empty, empty, empty},
                {empty, shape, shape},
                {shape, shape, empty},
            };
            sequence[Shape.S][1] = new int[,] {
                {empty, shape, empty},
                {empty, shape, shape},
                {empty, empty, shape},
            };

            // T
            shape = (int)Shape.T;
            sequence[Shape.T] = new int[4][,];
            sequence[Shape.T][0] = new int[,] {
                {empty, empty, empty},
                {shape, shape, shape},
                {empty, shape, empty},
            };
            sequence[Shape.T][1] = new int[,] {
                {empty, shape, empty},
                {shape, shape, empty},
                {empty, shape, empty}
            };
            sequence[Shape.T][2] = new int[,] {
                {empty, shape, empty},
                {shape, shape, shape},
                {empty, empty, empty}
            };
            sequence[Shape.T][3] = new int[,] {
                {empty, shape, empty},
                {empty, shape, shape},
                {empty, shape, empty}
            };

            // Z
            shape = (int)Shape.Z;
            sequence[Shape.Z] = new int[2][,];
            sequence[Shape.Z][0] = new int[,] {
                {empty, empty, empty},
                {shape, shape, empty},
                {empty, shape, shape}
            };
            sequence[Shape.Z][1] = new int[,] {
                {empty, empty, shape},
                {empty, shape, shape},
                {empty, shape, empty}
            };
        }

        #endregion
        
        #region Attributes
        public readonly int x;
        public readonly int y;
        public readonly Shape shape;
        private readonly int sequenceIndex;

        #endregion
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="shape"></param>
        /// <param name="sequenceIndex"></param>
        public Tetromino(int x, int y, Shape shape, int sequenceIndex = 0)
        {
            this.x = x;
            this.y = y;
            this.shape = shape;
            this.sequenceIndex = sequenceIndex;
        }

        /// <summary>
        /// Return the grid of the Tetromino
        /// </summary>
        public int[,] Grid => sequence[shape][sequenceIndex];

        /// <summary>
        /// Rotate a tetromino Clockwise
        /// </summary>
        /// <returns>The rotated Tetromino</returns>
        public Tetromino Rotate() => new Tetromino(x, y, shape, (sequenceIndex + 1) % sequence[shape].GetLength(0));

        /// <summary>
        /// Rotate a tetromino CounterClockwise
        /// </summary>
        /// <returns>The rotated Tetromino</returns>
        public Tetromino RotateCounterClockwise() => new Tetromino(x, y, shape, (sequenceIndex - 1) % sequence[shape].GetLength(0));
        
        /// <summary>
        /// Return a new Tetromino one column left
        /// </summary>
        /// <returns>New tetromino</returns>
        public Tetromino Left() => new Tetromino(x - 1, y, shape, sequenceIndex);

        /// <summary>
        /// Return a new Tetromino one column right
        /// </summary>
        /// <returns>New tetromino</returns>
        public Tetromino Right() => new Tetromino(x + 1, y, shape, sequenceIndex);

        /// <summary>
        /// Return a new Tetromino one row below
        /// </summary>
        /// <returns>New tetromino</returns>
        public Tetromino Down() => new Tetromino(x, y + 1, shape, sequenceIndex);
    }
}
