using System;
using Model;
using Xunit;
using System.Linq;
using BusinessLogic;
using System.Collections.Generic;

namespace Highscore_Testing
{
    public class UnitTest1
    {

        [Fact]
        public void GetNullHighscoreList()
        {
            var logic = new HighscoreLogic();

            Assert.Equal(null, logic.addScore(null, null));
        }

        [Fact]
        public void GetNullScoreHighscoreList()
        {
            var logic = new HighscoreLogic();

            Assert.Equal(null, logic.addScore(new Score { }, null));
        }

        [Fact]
        public void GetNullNullHighscoreList()
        {
            var logic = new HighscoreLogic();

            Assert.Equal(null, logic.addScore(null, new HighscoreList { }));
        }

        [Fact]
        public void GetScoreHighscoreList()
        {
            var logic = new HighscoreLogic();

            Assert.Equal(null, logic.addScore(new Score { HighsoreListId = 1, Name = "Schmank", Points = 30 }, null));
        }

        [Fact]
        public void GetHighscoreList()
        {
            var logic = new HighscoreLogic();

            HighscoreList highscoreList = new HighscoreList();
            highscoreList.Scores = new List<Score>();
            highscoreList.HighscoreListId = 1;
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Schmank", Points = 30 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Friedl", Points = 20 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Brunner", Points = 10 });

            Assert.Equal(null, logic.addScore(null, highscoreList));
        }


        [Fact]
        public void GetWorst()
        {
            var logic = new HighscoreLogic();

            HighscoreList highscoreList = new HighscoreList();
            highscoreList.Scores = new List<Score>();
            highscoreList.HighscoreListId = 1;
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Schmank", Points = 30 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Friedl", Points = 20 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });

            Assert.Equal(10, logic.addScore(new Score { HighsoreListId = 1, Name = "Brunner", Points = 10 }, highscoreList).Scores.Last().Points);
        }


        [Fact]
        public void GetBest()
        {
            var logic = new HighscoreLogic();

            HighscoreList highscoreList = new HighscoreList();
            highscoreList.Scores = new List<Score>();
            highscoreList.HighscoreListId = 1;
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Schmank", Points = 30 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Friedl", Points = 20 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });

            Assert.Equal(40, logic.addScore(new Score { HighsoreListId = 1, Name = "Brunner", Points = 10 }, highscoreList).Scores.First().Points);
        }


        [Fact]
        public void AddSmallSCore()
        {
            var logic = new HighscoreLogic();

            HighscoreList highscoreList = new HighscoreList();
            highscoreList.Scores = new List<Score>();
            highscoreList.HighscoreListId = 1;
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Schmank", Points = 30 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Friedl", Points = 20 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Schmank", Points = 30 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Friedl", Points = 20 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Schmank", Points = 30 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Friedl", Points = 20 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });

            Assert.Equal(null, logic.addScore(new Score { HighsoreListId = 1, Name = "Brunner", Points = 10 }, highscoreList));
        }

        [Fact]
        public void AddMoreThanTen()
        {
            var logic = new HighscoreLogic();

            HighscoreList highscoreList = new HighscoreList();
            highscoreList.Scores = new List<Score>();
            highscoreList.HighscoreListId = 1;
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Schmank", Points = 30 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Friedl", Points = 20 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Schmank", Points = 30 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Friedl", Points = 20 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Schmank", Points = 30 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Friedl", Points = 20 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });
            highscoreList.Scores.Add(new Score { HighsoreListId = 1, Name = "Dude", Points = 40 });

            Assert.Equal(10, logic.addScore(new Score { HighsoreListId = 1, Name = "Brunner", Points = 80 }, highscoreList).Scores.Count);
        }
    }
}
