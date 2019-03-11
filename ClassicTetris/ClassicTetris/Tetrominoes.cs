using System;
using System.Collections.Generic;

namespace ClassicTetris
{
    public class Tetrominoes
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

		private static Dictionary<Shape, List<bool[,]>> tetrominoes;

		static Tetrominoes()
		{
			tetrominoes = new Dictionary<Shape, List<bool[,]>>();

			foreach(Shape s in Enum.GetValues(typeof(Shape)))
			{
                tetrominoes[s] = new List<bool[,]>();
			}
            
            // I
			tetrominoes[Shape.I].Add(new bool[,] {
                {false, false, false, false},
                {false, false, false, false},
				{true, true, true, true},
                {false, false, false, false}
            });         
			tetrominoes[Shape.I].Add(new bool[,] {
				{false, false, true, false},
				{false, false, true, false},
				{false, false, true, false},
				{false, false, true, false}
            });

            // O
			tetrominoes[Shape.O].Add(new bool[,] {
				{false, false, false, false},
				{false, true, true, false},
				{false, true, true, false},
				{false, false, false, false}
			});

            // J
			tetrominoes[Shape.J].Add(new bool[,] {
                {false, false, false},
				{true, true, true},
				{false, false, true},
            });
			tetrominoes[Shape.J].Add(new bool[,] {
				{false, true, false},
				{false, true, false},
				{true, true, false},
            });
			tetrominoes[Shape.J].Add(new bool[,] {
				{true, false, false},
				{true, true, true},
                {false, false, false},
            });
			tetrominoes[Shape.J].Add(new bool[,] {
				{false, true, true},
				{false, true, false},
				{false, true, false},
            });

            // L
			tetrominoes[Shape.L].Add(new bool[,] {
                {false, false, false},
				{true, true, true},
				{true, false, false},
            });
			tetrominoes[Shape.L].Add(new bool[,] {
				{true, true, false},
				{false, true, false},
				{false, true, false},
            });
			tetrominoes[Shape.L].Add(new bool[,] {
				{false, false, true},
				{true, true, true},
                {false, false, false},
            });
			tetrominoes[Shape.L].Add(new bool[,] {
				{false, true, false},
				{false, true, false},
				{false, true, true},
            });

            // S
			tetrominoes[Shape.S].Add(new bool[,] {
                {false, false, false},
				{false, true, true},
				{true, true, false},
            });
			tetrominoes[Shape.S].Add(new bool[,] {
				{false, true, false},
				{false, true, true},
				{false, false, true},
            });

            // T
			tetrominoes[Shape.T].Add(new bool[,] {
                {false, false, false},
				{true, true, true},
				{false, true, false},
            });
			tetrominoes[Shape.T].Add(new bool[,] {
				{false, true, false},
				{true, true, false},
				{false, true, false},
            });
			tetrominoes[Shape.T].Add(new bool[,] {
				{false, true, false},
				{true, true, true},
                {false, false, false},
            });
			tetrominoes[Shape.T].Add(new bool[,] {
				{false, true, false},
				{false, true, true},
				{false, true, false},
            });

            // Z
			tetrominoes[Shape.Z].Add(new bool[,] {
                {false, false, false},
				{true, true, false},
				{false, true, true},
            });
			tetrominoes[Shape.Z].Add(new bool[,] {
				{false, false, true},
				{false, true, true},
				{false, true, false},
            });

        }
    }
}
