using MonopolyKata;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    class GoToJailSquareTest
    {
        private GoToJailSquare gtj = new GoToJailSquare();
        private Player player1 = new Player("t");
        private BoardFactory bd = new BoardFactory();
        private Board board;

        [SetUp]
        public void Init()
        {
            board = bd.Create();
        }

        [Test]
        public void WhenConstructorFires_GoToJailIsInitializedCorrectly()
        {
            Assert.AreEqual("GoToJail", gtj.Name);
        }

        [Test]
        public void WhenPlayerLandsOnGoToJail_PlayerIsMovedToJail()
        {
            player1.Move(board, 25);
            player1.Move(board, 5);
            gtj.IsLandedOn(player1);
            Assert.AreEqual(10, player1.Position);
        }
    }
}
