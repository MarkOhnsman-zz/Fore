using System;
using System.Collections.Generic;

namespace golf_card.Models
{
    class Game
    {
        Course Course { get; set; }
        Dictionary<string, Player> PlayerScores { get; set; }
        bool AddScore(string name, int hole)
        {
            System.Console.WriteLine($"Strokes for {name}> ");
            string scoreString = Console.ReadLine();
            int score;
            if (!Int32.TryParse(scoreString, out score) || score < 1)
            {
                System.Console.WriteLine("Please provide a valid number");
                return true;
            }
            PlayerScores[name].AddScore(score);
            return false;
        }
        string PrintCard()
        {
            string scorecard = Course.CourseCard();
            foreach (var player in PlayerScores)
            {
                scorecard += player.Value.GetScoreCard();
            }
            scorecard += Environment.NewLine;
            scorecard += "Course Par: " + Course.ParTotal;
            scorecard += Environment.NewLine;
            string winner = "";
            int low = Int32.MaxValue;
            foreach (var player in PlayerScores)
            {
                scorecard += $"{player.Key}: {player.Value.TotalScore}";
                scorecard += Environment.NewLine;
                if (player.Value.TotalScore < low)
                {
                    low = player.Value.TotalScore;
                    winner = player.Key;
                }
            }
            scorecard += Environment.NewLine;
            scorecard += $"Winner: {winner}";
            scorecard += Environment.NewLine;
            return scorecard;
        }



        public void Play()
        {
            int round = 1;
            foreach (var hole in Course.HolePars)
            {
                Console.Clear();
                Console.WriteLine("Hole: " + round);
                foreach (var playerScore in PlayerScores)
                {
                    while (AddScore(playerScore.Key, round)) ;
                }
                round++;
            }
            Console.Clear();
            Console.WriteLine(PrintCard());
        }


        public Game(Course course, List<Player> players)
        {
            Course = course;
            PlayerScores = new Dictionary<string, Player>();
            foreach (Player player in players)
            {
                PlayerScores.Add(player.Name, player);
            }
        }
    }
}