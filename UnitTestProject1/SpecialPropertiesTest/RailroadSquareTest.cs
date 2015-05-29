using MonopolyKata;
using MonopolyKata.PropertySquares;
using MonopolyKata.PropertySquares.Rent;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    class RailroadSquareTest
    {
        private Property rr1;
        private Player player1;
        private Player player2;
        private IRentStrategy rentStrategy;
        private Realtor realtor;

        [SetUp]
        public void Init()
        {
            realtor = new Realtor();
            rentStrategy = new RentStrategyRailroad(realtor);
            rr1 = new RailroadSquare(rentStrategy, new Banker(), "Reading Railroad", realtor);
            player1 = new Player("t");
            player2 = new Player("2");
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
