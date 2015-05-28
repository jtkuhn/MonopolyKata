using MonopolyKata;
using MonopolyKata.PropertySquares;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    class GoToJailSquareTest
    {
        private JailWarden jailWarden;
        private GoToJailSquare gtj;
        private Board board;
        private Player player1;

        [SetUp]
        public void Init()
        {
            board = new Board(new Realtor(), new JailWarden());
            player1 = new Player("t");
            jailWarden = new JailWarden();
            jailWarden.SetPositionOfJail(10);
            gtj = new GoToJailSquare(jailWarden);
        }

        [Test]
        public void WhenConstructorFires_GoToJailIsInitializedCorrectly()
        {
            Assert.AreEqual("GoToJail", gtj.Name);
        }

        [Test]
        public void WhenPlayerLandsOnGoToJail_PlayerIsMovedToJail()
        {
            board.MovePlayer(player1, 25);
            board.MovePlayer(player1, 5);
            gtj.IsLandedOn(player1);
            Assert.AreEqual(10, player1.Position);
        }
    }
}
