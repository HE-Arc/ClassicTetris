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
		private static readonly Dictionary<Shape, Shape[,,]> rotations;

		private int top;
        private int left;

		private Shape type;

		private int rotationSequance;

		static Tetromino()
		{
			rotations = new Dictionary<Shape, Shape[,,]>();

			// I
			rotations[Shape.I] = new Shape[,,] {
				{
					{Shape.None, Shape.None, Shape.None, Shape.None},
					{Shape.None, Shape.None, Shape.None, Shape.None},
					{Shape.I , Shape.I , Shape.I , Shape.I},
					{Shape.None, Shape.None, Shape.None, Shape.None}
				},
				{
					{Shape.None, Shape.None, Shape.I, Shape.None},
					{Shape.None, Shape.None, Shape.I, Shape.None},
					{Shape.None, Shape.None, Shape.I, Shape.None},
					{Shape.None, Shape.None, Shape.I, Shape.None}
				}
			};

			// O
			rotations[Shape.O] = new Shape[,,] {
				{
					{Shape.None, Shape.None, Shape.None, Shape.None},
					{Shape.None, Shape.O, Shape.O, Shape.None},
					{Shape.None, Shape.O, Shape.O, Shape.None},
					{Shape.None, Shape.None, Shape.None, Shape.None},
				},
			};

			// J
			rotations[Shape.J] = new Shape[,,] {
				{
					{Shape.None, Shape.None, Shape.None},
					{Shape.J, Shape.J, Shape.J},
					{Shape.None, Shape.None, Shape.J},
				},
				{
					{Shape.None, Shape.J, Shape.None},
					{Shape.None, Shape.J, Shape.None},
					{Shape.J, Shape.J, Shape.None},
				},
				{
					{Shape.J, Shape.None, Shape.None},
					{Shape.J, Shape.J, Shape.J},
					{Shape.None, Shape.None, Shape.None},
				},
				{
					{Shape.None, Shape.J, Shape.J},
					{Shape.None, Shape.J, Shape.None},
					{Shape.None, Shape.J, Shape.None},
				}
			};

			// L
			rotations[Shape.L] = new Shape[,,] {
				{
					{Shape.None, Shape.None, Shape.None},
					{Shape.L, Shape.L, Shape.L},
					{Shape.L, Shape.None, Shape.None},
				},
				{
					{Shape.L, Shape.L, Shape.None},
					{Shape.None, Shape.L, Shape.None},
					{Shape.None, Shape.L, Shape.None},
				},
				{
					{Shape.None, Shape.None, Shape.L},
					{Shape.L, Shape.L, Shape.L},
					{Shape.None, Shape.None, Shape.None},
				},
				{
					{Shape.None, Shape.L, Shape.None},
					{Shape.None, Shape.L, Shape.None},
					{Shape.None, Shape.L, Shape.L},
				}
			};

			// S
			rotations[Shape.S] = new Shape[,,] {
				{
					{Shape.None, Shape.None, Shape.None},
					{Shape.None, Shape.S, Shape.S},
					{Shape.S, Shape.S, Shape.None},
				},
				{
					{Shape.None, Shape.S, Shape.None},
					{Shape.None, Shape.S, Shape.S},
					{Shape.None, Shape.None, Shape.S},
				}
			};

			// T
			rotations[Shape.T] = new Shape[,,] {
				{
    				{Shape.None, Shape.None, Shape.None},
    				{Shape.T, Shape.T, Shape.T},
    				{Shape.None, Shape.T, Shape.None},
			    },
			    {
                    {Shape.None, Shape.T, Shape.None},
                    {Shape.T, Shape.T, Shape.None},
                    {Shape.None, Shape.T, Shape.None},
				},
			    {
                    {Shape.None, Shape.T, Shape.None},
                    {Shape.T, Shape.T, Shape.T},
                    {Shape.None, Shape.None, Shape.None},
				},
			    {
    				{Shape.None, Shape.T, Shape.None},
    				{Shape.None, Shape.T, Shape.T},
    				{Shape.None, Shape.T, Shape.None},
				}
            };

            // Z
			rotations[Shape.Z] = new Shape[,,] {
				{
    				{Shape.None, Shape.None, Shape.None},
    				{Shape.Z, Shape.Z, Shape.None},
    				{Shape.None, Shape.Z, Shape.Z},
			    },
			    {
    				{Shape.None, Shape.None, Shape.Z},
    				{Shape.None, Shape.Z, Shape.Z},
    				{Shape.None, Shape.Z, Shape.None},
				}
            };

        }

		public int I
        {
            get
            {
                return left;
            }
        }

		public int J
        {
            get
            {
                return top;
            }
        }

        public Shape[,] Grid
		{
			get
			{
				Shape[,,] rotation = Tetromino.rotations[this.type];
                Shape[,] grid = new Shape[rotation.GetLength(1), rotation.GetLength(2)];

                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        grid[i, j] = rotation[rotationSequance, i, j];
                    }
                }
                return grid;
			}
		}

		public Tetromino(int x, int y, Shape shape)
		{
			top = y;
            left = x;
			type = shape;
            rotationSequance = 0;
		}

        public void Rotate()
		{
			rotationSequance += 1;
			rotationSequance %= Tetromino.rotations[this.type].GetLength(0);
		}

		public void Left()
        {
            left -= 1;
        }

		public void Right()
        {
            left += 1;
        }

		public void Down()
        {
            top += 1;
        }
    }
}
