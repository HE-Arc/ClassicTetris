using System;
namespace ClassicTetris
{
    /// <summary>
    /// Structure to store one score entry
    /// </summary>
    public class ScoreEntry
    {
        public int Id { get; }
        public string Name { get; }
		public int Score { get; }
        public int Level { get; }

        private static int id = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Best player name</param>
        /// <param name="score">Current score</param>
        /// <param name="level">Higher level</param>
		public ScoreEntry(string name, int score, int level)
        {
            Id = id++;
			Name = name;
			Score = score;
			Level = level;
        }
    }
}
