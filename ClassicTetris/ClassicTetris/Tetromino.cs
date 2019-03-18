using System;
using System.Collections.Generic;

namespace ClassicTetris
{
    public class Tetromino
    {
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
		///     d1 : Rotation
		///     d2&3 : grid of boolean, Shape.None == empty, true == in shape
        /// </summary>
		private static readonly Dictionary<Shape, Shape[][,]> sequence = new Dictionary<Shape, Shape[][,]>();
        private static readonly Random random = new Random();

		private int x;
        private int y;

		private Shape type;

		private int sequenceIndex;


		static Tetromino()
		{
            // I
			sequence[Shape.I] = new Shape[2][,];
			sequence[Shape.I][0] = new Shape[,] {
                { Shape.None, Shape.None, Shape.None, Shape.None},
                { Shape.None, Shape.None, Shape.None, Shape.None},
                { Shape.I , Shape.I , Shape.I , Shape.I},
                { Shape.None, Shape.None, Shape.None, Shape.None}
            };
			sequence[Shape.I][1] = new Shape[,]{
                {Shape.None, Shape.None, Shape.I, Shape.None},
                {Shape.None, Shape.None, Shape.I, Shape.None},
                {Shape.None, Shape.None, Shape.I, Shape.None},
                {Shape.None, Shape.None, Shape.I, Shape.None}
            };

			// O
			sequence[Shape.O] = new Shape[1][,];
            sequence[Shape.O][0] = new Shape[,] {
				{Shape.None, Shape.None, Shape.None, Shape.None},
				{Shape.None, Shape.O, Shape.O, Shape.None},
				{Shape.None, Shape.O, Shape.O, Shape.None},
				{Shape.None, Shape.None, Shape.None, Shape.None}
			};

			// J
			sequence[Shape.J] = new Shape[4][,];
			sequence[Shape.J][0] = new Shape[,] {
                {Shape.None, Shape.None, Shape.None},
                {Shape.J, Shape.J, Shape.J},
                {Shape.None, Shape.None, Shape.J},
            };

			sequence[Shape.J][1] = new Shape[,] {
                {Shape.None, Shape.J, Shape.None},
                {Shape.None, Shape.J, Shape.None},
                {Shape.J, Shape.J, Shape.None}
            };
			sequence[Shape.J][2] = new Shape[,] {
                {Shape.J, Shape.None, Shape.None},
                {Shape.J, Shape.J, Shape.J},
                {Shape.None, Shape.None, Shape.None}
            };
			sequence[Shape.J][3] = new Shape[,] {
                {Shape.None, Shape.J, Shape.J},
                {Shape.None, Shape.J, Shape.None},
                {Shape.None, Shape.J, Shape.None}
            };

			// L         
            sequence[Shape.L] = new Shape[4][,];
			sequence[Shape.L][0] = new Shape[,] {
                {Shape.None, Shape.None, Shape.None},
                {Shape.L, Shape.L, Shape.L},
                {Shape.L, Shape.None, Shape.None}
            };
			sequence[Shape.L][1] = new Shape[,] {
                {Shape.L, Shape.L, Shape.None},
                {Shape.None, Shape.L, Shape.None},
                {Shape.None, Shape.L, Shape.None}
            };
			sequence[Shape.L][2] = new Shape[,] {
                {Shape.None, Shape.None, Shape.L},
                {Shape.L, Shape.L, Shape.L},
                {Shape.None, Shape.None, Shape.None}
            };
			sequence[Shape.L][3] = new Shape[,] {
                {Shape.None, Shape.L, Shape.None},
                {Shape.None, Shape.L, Shape.None},
                {Shape.None, Shape.L, Shape.L}
            };

			// S
            sequence[Shape.S] = new Shape[2][,];
			sequence[Shape.S][0] = new Shape[,] {
                {Shape.None, Shape.None, Shape.None},
                {Shape.None, Shape.S, Shape.S},
                {Shape.S, Shape.S, Shape.None},
            };
			sequence[Shape.S][1] = new Shape[,] {
                {Shape.None, Shape.S, Shape.None},
                {Shape.None, Shape.S, Shape.S},
                {Shape.None, Shape.None, Shape.S},
            };

			// T
			sequence[Shape.T] = new Shape[4][,];
			sequence[Shape.T][0] = new Shape[,] {
                {Shape.None, Shape.None, Shape.None},
                {Shape.T, Shape.T, Shape.T},
                {Shape.None, Shape.T, Shape.None},
            };
			sequence[Shape.T][1] = new Shape[,] {
				{Shape.None, Shape.T, Shape.None},
                {Shape.T, Shape.T, Shape.None},
                {Shape.None, Shape.T, Shape.None}
            };
			sequence[Shape.T][2] = new Shape[,] {
				{Shape.None, Shape.T, Shape.None},
                {Shape.T, Shape.T, Shape.T},
                {Shape.None, Shape.None, Shape.None}
            };
			sequence[Shape.T][3] = new Shape[,] {
				{Shape.None, Shape.T, Shape.None},
                {Shape.None, Shape.T, Shape.T},
                {Shape.None, Shape.T, Shape.None}
            };

			// Z
			sequence[Shape.Z] = new Shape[2][,];
			sequence[Shape.Z][0] = new Shape[,] {
				{Shape.None, Shape.None, Shape.None},
                {Shape.Z, Shape.Z, Shape.None},
                {Shape.None, Shape.Z, Shape.Z}
            };
			sequence[Shape.Z][0] = new Shape[,] {
				{Shape.None, Shape.None, Shape.Z},
                {Shape.None, Shape.Z, Shape.Z},
                {Shape.None, Shape.Z, Shape.None}
            };
        }

		static Tetromino Random(int x, int y)
		{
			Array values = Enum.GetValues(typeof(Shape));
			Shape randomShape = (Shape)values.GetValue(random.Next(values.Length));
			Tetromino tetromino = new Tetromino(x, y, randomShape);
			return tetromino;
		}

		public int X
        {
            get
            {
                return x;
            }
        }

		public int Y
        {
            get
            {
                return y;
            }
        }

        public Shape[,] Grid
		{
			get
			{
				Shape[][,] rotation = GetCurrentShapeSequence();
				return rotation[this.sequenceIndex];            
			}
		}

		public Tetromino(int x, int y, Shape shape)
		{
			this.x = x;
            this.y = y;
			type = shape;
			sequenceIndex = 0;
		}

        public void Rotate()
		{
			sequenceIndex += 1;
			sequenceIndex %= GetCurrentShapeSequence().GetLength(0);
		}

		private Shape[][,] GetCurrentShapeSequence()
		{
			return Tetromino.sequence[this.type];
		}

		public void Left()
        {
            x -= 1;
        }

		public void Right()
        {
            x += 1;
        }
        
		public void Down()
        {
            y += 1;
        }
    }
}
