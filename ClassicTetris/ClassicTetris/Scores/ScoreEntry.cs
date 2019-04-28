using System;
namespace ClassicTetris
{
    /// <summary>
    /// Structure to store one score entry
    /// </summary>
    public class ScoreEntry
	{
        public string Name { get; }
		public int Score { get; }
        public int Level { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Best player name</param>
        /// <param name="score">Current score</param>
        /// <param name="level">Higher level</param>
		public ScoreEntry(string name, int score, int level)
        {
			Name = name;
			Score = score;
			Level = level;
        }
    }
}
