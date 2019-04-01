using System;
using System.Collections.Generic;

namespace golf_card.Models
{
    class Player
    {
        public string Name { get; private set; }
        List<int> Scores { get; set; }
        public int TotalScore { get; private set; }
        public void AddScore(int score)
        {
            TotalScore += score;
            Scores.Add(score);
        }
        public string GetScoreCard()
        {
            string scorecard = "";
            scorecard += PlayerName();
            foreach (var score in Scores)
            {
                scorecard += score + " ";
                if (score < 9)
                {
                    scorecard += " ";
                }
            }
            scorecard += Environment.NewLine;
            return scorecard;
        }
        string PlayerName()
        {
            string name = Name;
            if (name.Length > 6)
            {
                return name.Substring(0, 7) + ": ";
            }
            name += ":";
            for (int i = name.Length; i <= 8; i++)
            {
                name += " ";
            }
            return name;
        }
        public Player(string name)
        {
            Name = name;
            Scores = new List<int>();
        }
    }
}