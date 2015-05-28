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
        private Realtor realtor;

        [SetUp]
        public void Init()
        {
            realtor = new Realtor();
            mockRentStrategy = new Mock<IRentStrategy>();
            board = new Board();
            rr1 = new RailroadSquare(mockRentStrategy.Object, "Reading Railroad", realtor);
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
            Assert.Null(realtor.GetOwnerOf(rr1));
            rr1.IsLandedOn(player1);
            Assert.AreEqual(player1, realtor.GetOwnerOf(rr1));
        }
        
        [Test]
        public void WhenRailroadIsMortgaged_NoRentIsCharged()
        {
            Assert.AreEqual(1500, player1.Money);
            realtor.SetOwnerOf(rr1, player2);
            rr1.IsMortgaged = true;
            rr1.IsLandedOn(player1);
            Assert.AreEqual(1500, player1.Money);
        }
    }
}
