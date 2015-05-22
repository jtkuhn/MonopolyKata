using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
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

        [SetUp]
        public void Init()
        {
            board = new Board();
            rr1 = new RailroadSquare("Reading Railroad");
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
        public void WhenPlayerLandsOnRailroad_AndOwnerOnlyHasOneRailroad_RentIs25Dollars()
        {
            Assert.AreEqual(1500, player1.Money);
            player2.Move(5);
            player1.Move(5);
            Assert.AreEqual(1475, player1.Money);
        }

        [Test]
        public void WhenPlayerLandsOnRailroad_AndOwnerHasThreeRailroads_RentIs100Dollars()
        {
            Assert.AreEqual(1500, player1.Money);
            player2.Move(5);
            player2.Move(10);
            player2.Move(10);
            player1.Move(5);
            Assert.AreEqual(1400, player1.Money);
        }

        [Test]
        public void WhenPlayerOwns0Railroads_GetNumberOfRailroads_Returns0()
        {
            Assert.AreEqual(0, player1.GetNumberOfRailroads());
        }

        [Test]
        public void WhenPlayerOwns2Railroads_GetNumberOfRailroads_Returns2()
        {
            player2.Move(5);
            player2.Move(10);
            Assert.AreEqual(1100, player2.Money);
            Assert.AreEqual(2, player2.GetNumberOfRailroads());
        }
    }
}
