using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassicTetris
{
    public class Scores
    {
		private List<ScoreEntry> scores;

		public static Scores Instance { get { if (instance == null) instance = new Scores(); return instance; } }      
		private static Scores instance = null;      
        
        public Scores()
        {
			scores = new List<ScoreEntry>();
			AddScore(new ScoreEntry("RAPH", 30, 0));
            AddScore(new ScoreEntry("BAST", 40, 5));
			AddScore(new ScoreEntry("DAMIAN", 60, 9));
            AddScore(new ScoreEntry("OUT", 100, 0));
        }

		public void AddScore(ScoreEntry scoreEntry)
		{
			scores.Add(scoreEntry);
		}

		public List<ScoreEntry> GetTopScores()
		{
			return scores.OrderBy(x => -x.Score).ToList();
		}
    }
}
