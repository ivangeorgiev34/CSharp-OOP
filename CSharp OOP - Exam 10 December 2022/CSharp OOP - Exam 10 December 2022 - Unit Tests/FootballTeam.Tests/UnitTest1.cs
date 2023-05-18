using NUnit.Framework;
using System;
using System.Transactions;

namespace FootballTeam.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FootballPlayer_ConstructorShouldWorkProperly()
        {
            FootballPlayer footballPlayer = new FootballPlayer("abc", 10, "Forward");

            Assert.AreEqual("abc", footballPlayer.Name);
            Assert.AreEqual(10, footballPlayer.PlayerNumber);
            Assert.AreEqual("Forward", footballPlayer.Position);
            Assert.AreEqual(0, footballPlayer.ScoredGoals);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FootballPlayer_PropertyNameShouldThrowExceptionWhenIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer footballPlayer = new FootballPlayer(name, 10, "Forward");
            }); 
        }

        [Test]
        [TestCase(0)]
        [TestCase(22)]
        public void FootballPlayer_PropertyPlayerNumberShouldThrowExceptionWhenIsBelow1Or21(int num)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer footballPlayer = new FootballPlayer("abc", num, "Forward");
            });
        }

        [Test]
        public void FootballPlayer_PropertyPositionShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer footballPlayer = new FootballPlayer("abc", 10, "gr");
            });
        }

        [Test]
        public void FootballPlayer_MethodScoreShouldWorkProperly()
        {
            FootballPlayer footballPlayer = new FootballPlayer("abc", 10, "Forward");
            footballPlayer.Score();
            Assert.AreEqual(1, footballPlayer.ScoredGoals);
        }

        [Test]
        public void FootballTeam_ConstructorShouldWorkProperly()
        {
            FootballTeam team = new FootballTeam("abc", 20);
            Assert.AreEqual("abc", team.Name);
            Assert.AreEqual(20, team.Capacity);
            Assert.AreEqual(0, team.Players.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FootballTeam_PropertyNameShouldThrowExceptionWhenIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(name, 20);
            });
        }

        [Test]
        public void FootballTeam_PropertyCapacityShouldThrowExceptionWhenIsBelow15()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("abc", 1);
            });
        }

        [Test]
        public void FootballTeam_MethodAddNewPlayerShouldWorkProperly()
        {
            FootballPlayer footballPlayer = new FootballPlayer("abcd", 10, "Forward");
            FootballTeam team = new FootballTeam("abc", 20);

            team.AddNewPlayer(footballPlayer);
            Assert.AreEqual(1, team.Players.Count);
            Assert.AreEqual("Added player abcd in position Forward with number 10", team.AddNewPlayer(footballPlayer));
        }

        [Test]
        public void FootballTeam_MethodAddNewPlayerShouldThrowExceptionWhenCountEqualsCapacity()
        {
            //check for null player
            FootballPlayer footballPlayer = new FootballPlayer("abcd", 10, "Forward");
            FootballTeam team = new FootballTeam("abc", 16);
            for (int i = 0; i < 16; i++)
            {
                team.AddNewPlayer(footballPlayer);
            }
            Assert.AreEqual("No more positions available!", team.AddNewPlayer(footballPlayer));
        }

        [Test]
        public void FootballTeam_MethodPickPlayerShouldWorkProperly()
        {//check for null player
            FootballPlayer footballPlayer = new FootballPlayer("abcd", 10, "Forward");
            FootballTeam team = new FootballTeam("abc", 16);
            team.AddNewPlayer(footballPlayer);

            Assert.AreSame(footballPlayer, team.PickPlayer("abcd"));
        }

        [Test]
        public void FootballTeam_MethodPlayerScoreShouldWorkProperly()
        {
            FootballPlayer footballPlayer = new FootballPlayer("abcd", 10, "Forward");
            FootballTeam team = new FootballTeam("abc", 16);
            team.AddNewPlayer(footballPlayer);

            Assert.AreEqual("abcd scored and now has 1 for this season!", team.PlayerScore(10));
            Assert.AreEqual(1, footballPlayer.ScoredGoals);

        }
    }
}