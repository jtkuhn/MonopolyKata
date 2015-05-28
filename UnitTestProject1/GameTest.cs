using System;
using System.Collections.Generic;
using MonopolyKata;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class GameTest
    {
        private Game game = new Game(4);

        [Test]
        public void Board_IsInitializedCorrectly()
        {
            Assert.AreEqual("Go", game.Board.GetSquareAt(0).Name);
            Assert.AreEqual("GoToJail", game.Board.GetSquareAt(30).Name);
        }

        [Test]
        public void WhenGameIsInitialized_PlayersAreInitiatedRandomly()
        {
            foreach (Player x in game.players)
            {
                Assert.NotNull(x);
            }
        }

        [Test]
        public void WhenGamePlaysOneTurn_EveryPlayerHasMoved()
        {
            game.PlayOneTurn();
            List<String> list = new List<string>();
            foreach (Player player in game.players)
            {
                if (player.Position != 0) list.Add(player.Name);
            }
            Assert.Contains("Player 0", list);
            Assert.Contains("Player 1", list);
            Assert.Contains("Player 2", list);
            Assert.Contains("Player 3", list);
        }

        [Test]
        public void WhenPlayerRollsThreeDoubles_TheyGoToJail()
        {
            
        }
    }
}
