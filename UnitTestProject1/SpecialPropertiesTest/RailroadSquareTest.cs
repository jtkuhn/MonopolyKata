using MonopolyKata;
using MonopolyKata.PropertySquares;
using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    class RailroadSquareTest
    {
        private Property rr1;
        private Player player1;
        private Player player2;
        private Board board;
        private Mock<IRentStrategy> mockRentStrategy;

        [SetUp]
        public void Init()
        {
            mockRentStrategy = new Mock<IRentStrategy>();
            board = new Board();
            rr1 = new RailroadSquare(mockRentStrategy.Object, "Reading Railroad");
            player1 = new Player("t", board);
            player2 = new Player("2", board);
        }

        [Test]
        public void WhenPlayerLandsOnUnownedRailroad_TheyLose200Dollars()
        {
            Assert.AreEqual(1500, player1.Money);
            rr1.IsLandedOn(player1);
            Assert.AreEqual(1300, player1.Money);
        }

        [Test]
        public void WhenUnownedRailroadIsLandedOn_PlayerBecomesOwner()
        {
            Assert.Null(rr1.owner);
            rr1.IsLandedOn(player1);
            Assert.AreEqual(player1, rr1.owner);
        }
        
        [Test]
        public void WhenPlayerOwns0Railroads_GetNumberOfRailroads_Returns0()
        {
            Assert.AreEqual(0, board.GetNumberOfRailroads(player1));
        }

        [Test]
        public void WhenPlayerOwns2Railroads_GetNumberOfRailroads_Returns2()
        {
            player2.Move(5);
            player2.Move(10);
            Assert.AreEqual(1100, player2.Money);
            Assert.AreEqual(2, board.GetNumberOfRailroads(player2));
        }

        [Test]
        public void WhenRailroadIsMortgaged_NoRentIsCharged()
        {
            Assert.AreEqual(1500, player1.Money);
            rr1.IsLandedOn(player2);
            rr1.IsMortgaged = true;
            rr1.IsLandedOn(player1);
            Assert.AreEqual(1500, player1.Money);
        }
    }
}
