using System;
using System.Collections.Generic;

namespace ClassicTetris
{
    public class Tetromino
    {
		public enum Shape
		{
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
		///     d2&3 : grid of boolean, false == empty, true == in shape
        /// </summary>
		public static readonly Dictionary<Shape, bool[,,]> rotations;
        
		static Tetromino()
		{
			rotations = new Dictionary<Shape, bool[,,]>();

			// I
			rotations[Shape.I] = new bool[,,] {
				{
					{false, false, false, false},
					{false, false, false, false},
					{true , true , true , true},
					{false, false, false, false}
				},
				{
					{false, false, true, false},
					{false, false, true, false},
					{false, false, true, false},
					{false, false, true, false}
				}
			};

			// O
			rotations[Shape.O] = new bool[,,] {
				{
					{false, false, false, false},
					{false, true, true, false},
					{false, true, true, false},
					{false, false, false, false},
				},
			};

			// J
			rotations[Shape.J] = new bool[,,] {
				{
					{false, false, false},
					{true, true, true},
					{false, false, true},
				},
				{
					{false, true, false},
					{false, true, false},
					{true, true, false},
				},
				{
					{true, false, false},
					{true, true, true},
					{false, false, false},
				},
				{
					{false, true, true},
					{false, true, false},
					{false, true, false},
				}
			};

			// L
			rotations[Shape.L] = new bool[,,] {
				{
					{false, false, false},
					{true, true, true},
					{true, false, false},
				},
				{
					{true, true, false},
					{false, true, false},
					{false, true, false},
				},
				{
					{false, false, true},
					{true, true, true},
					{false, false, false},
				},
				{
					{false, true, false},
					{false, true, false},
					{false, true, true},
				}
			};

			// S
			rotations[Shape.S] = new bool[,,] {
				{
					{false, false, false},
					{false, true, true},
					{true, true, false},
				},
				{
					{false, true, false},
					{false, true, true},
					{false, false, true},
				}
			};

			// T
			rotations[Shape.T] = new bool[,,] {
				{
    				{false, false, false},
    				{true, true, true},
    				{false, true, false},
			    },
			    {
                    {false, true, false},
                    {true, true, false},
                    {false, true, false},
				},
			    {
                    {false, true, false},
                    {true, true, true},
                    {false, false, false},
				},
			    {
    				{false, true, false},
    				{false, true, true},
    				{false, true, false},
				}
            };

            // Z
			rotations[Shape.Z] = new bool[,,] {
				{
    				{false, false, false},
    				{true, true, false},
    				{false, true, true},
			    },
			    {
    				{false, false, true},
    				{false, true, true},
    				{false, true, false},
				}
            };

        }
    }
}
