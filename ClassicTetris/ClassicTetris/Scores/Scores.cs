using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassicTetris
{
    /// <summary>
    /// Store to keep track of best scores in "ROM"
    /// </summary>
    public class Scores
    {
		private List<ScoreEntry> scores;

		public static Scores Instance { get { if (instance == null) instance = new Scores(); return instance; } }      
		private static Scores instance = null;      
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Scores()
        {
			scores = new List<ScoreEntry>();
            AddScore(new ScoreEntry("BAST", 10000, 9));
			AddScore(new ScoreEntry("DAMIAN", 7500, 5));
            AddScore(new ScoreEntry("RAPH", 5000, 0));
        }

        /// <summary>
        /// Add a score to the store
        /// </summary>
        /// <param name="scoreEntry">Entry</param>
		public void AddScore(ScoreEntry scoreEntry)
		{
			scores.Add(scoreEntry);
		}

        /// <summary>
        /// Return the scores sorted
        /// </summary>
        /// <returns>Scores' entry</returns>
		public List<ScoreEntry> GetTopScores()
		{
			return scores.OrderBy(x => -x.Score).ThenBy(x => -x.Id).ToList();
		}
    }
}
