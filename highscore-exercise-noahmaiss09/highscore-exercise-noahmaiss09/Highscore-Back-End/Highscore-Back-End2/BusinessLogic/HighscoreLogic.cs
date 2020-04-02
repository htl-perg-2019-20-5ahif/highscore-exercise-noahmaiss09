using Model;
using System;
using System.Linq;

namespace BusinessLogic
{
    public class HighscoreLogic
    {
        public HighscoreList addScore(Score score, HighscoreList highscoreList)
        {
            if (score == null || highscoreList == null || score.Name == "" || highscoreList.Scores == null)
            {
                return null;
            }

            highscoreList.Scores = highscoreList.Scores.OrderByDescending(s => s.Points).ToList();

            if (highscoreList.Scores.Count < 10)
            {
                highscoreList.Scores.Add(score);
            }
            else
            {
                if (highscoreList.Scores.Last().Points < score.Points)
                {
                    highscoreList.Scores.Remove(highscoreList.Scores.Last());
                    highscoreList.Scores.Add(score);
                }
                else
                {
                    return null;
                }
            }

            highscoreList.Scores = highscoreList.Scores.OrderByDescending(s => s.Points).ToList();

            return highscoreList;
        }
    }
}
