using System;
namespace ClassicTetris
{
    public class ScoreEntry
	{
        public string Name { get;  }
		public int Score { get; }
        public int Level { get; }

		public ScoreEntry(string name, int score, int level)
        {
			Name = name;
			Score = score;
			Level = level;
        }
    }
}
