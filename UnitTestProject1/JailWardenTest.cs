using MonopolyKata;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class JailWardenTest
    {
        private JailWarden jailWarden;

        [SetUp]
        public void Setup()
        {
            jailWarden = new JailWarden();
            jailWarden.SetPositionOfJail(10);
        }

        [Test]
        public void SendPlayerToJail_PutsPlayerInJail()
        {
            Player player1 = new Player("Bob");
            Assert.AreEqual(0, player1.Position);
            jailWarden.MovePlayerToJail(player1);
            Assert.AreEqual(10, player1.Position);
        }

        [Test]
        public void AllPlayersAreNotInJail_ByDefault()
        {
            Player player1 = new Player("Bob");
            Assert.That(jailWarden.IsInJail(player1), Is.False);
        }

        [Test]
        public void WhenPlayerIsMovedToJail_TurnsInJailEqualsOne()
        {
            Player player1 = new Player("Bob");
            Assert.AreEqual(0, jailWarden.TurnsInJail(player1));
            jailWarden.MovePlayerToJail(player1);
            Assert.AreEqual(1, jailWarden.TurnsInJail(player1));
        }

        [Test]
        public void WhenPlayerDoesNotEscapeFromJailWithDoubles_TimeInJailIncrements()
        {
            Player player1 = new Player("Bob");
            Assert.AreEqual(0, jailWarden.TurnsInJail(player1));
            jailWarden.MovePlayerToJail(player1);
            Assert.AreEqual(1, jailWarden.TurnsInJail(player1));
            jailWarden.FailsToEscapeWithDoubles(player1);
            Assert.AreEqual(2, jailWarden.TurnsInJail(player1));
        }

        [Test]
        public void WhenPlayerGetsOutOfJail_IsInJailReturnsFalse()
        {
            Player player1 = new Player("Bob");
            Assert.AreEqual(0, jailWarden.TurnsInJail(player1));
            jailWarden.MovePlayerToJail(player1);
            Assert.True(jailWarden.IsInJail(player1));
            Assert.AreEqual(1, jailWarden.TurnsInJail(player1));
            jailWarden.GetsOutOfJail(player1);
            Assert.False(jailWarden.IsInJail(player1));
        }

        [Test]
        public void WhenPlayerIsAtJailSquare_ButNotInJail_IsInJailReturnsFalse()
        {
            Player player1 = new Player("hi");
            player1.Position = 10;
            Assert.False(jailWarden.IsInJail(player1));
        }
    }
}
