﻿using MonopolyKata;
using MonopolyKata.PropertySquares;
using MonopolyKata.PropertySquares.Rent;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class RealtorTest
    {
        private Realtor realtor;
        private Board board;
        private Property prop;
        private Player player1;
        
        [SetUp]
        public void Setup()
        {
            realtor = new Realtor();
            board = new Board(realtor);
            prop = new Property(new RentStrategyMonopolizable(board), "hi", realtor);
            player1 = new Player("Bob", board);
        }

        [Test]
        public void SetOwner_GivesThePropertyAnOwner()
        {
            realtor.SetOwnerOf(prop, player1);
            Assert.AreEqual(player1, realtor.GetOwnerOf(prop));
        }

        [Test]
        public void GetOwner_GetsThePropertyOwner()
        {
            player1 = realtor.GetOwnerOf(prop);
            Assert.Null(player1);
            Player player2 = new Player("Joe", new Board(realtor));
            realtor.SetOwnerOf(prop, player2);
            Assert.AreEqual(player2, realtor.GetOwnerOf(prop));
        }

        [Test]
        public void WhenPlayerMortagesHisProperty_ItBecomesMortgaged()
        {
            Property prop = new Property(new RentStrategyMonopolizable(board), "testProperty", realtor);
            Assert.IsFalse(prop.IsMortgaged);
            realtor.Mortgage(prop);
            Assert.IsTrue(prop.IsMortgaged);
        }

        [Test]
        public void WhenPlayerUnmortgagesProperty_ItBecomesUnmortgaged()
        {
            Property prop = new Property(new RentStrategyMonopolizable(board), "testProperty", realtor);
            prop.IsMortgaged = true;
            Assert.IsTrue(prop.IsMortgaged);
            realtor.UnMortgage(prop);
            Assert.IsFalse(prop.IsMortgaged);
        }

        [Test]
        public void WhenPlayerOwns0Railroads_GetNumberOfRailroads_Returns0()
        {
            Assert.AreEqual(0, realtor.GetNumberOfOwnedRailroads(player1));
        }

        [Test]
        public void WhenPlayerOwns2Railroads_GetNumberOfRailroads_Returns2()
        {
            RailroadSquare rr1 = new RailroadSquare(new RentStrategyRailroad(realtor), "1", realtor);
            RailroadSquare rr2 = new RailroadSquare(new RentStrategyRailroad(realtor), "2", realtor);
            RailroadSquare rr3 = new RailroadSquare(new RentStrategyRailroad(realtor), "3", realtor);
            realtor.SetOwnerOf(rr1, player1);
            realtor.SetOwnerOf(rr2, player1);
            realtor.SetOwnerOf(rr3, new Player("hi", board));
            Assert.AreEqual(2, realtor.GetNumberOfOwnedRailroads(player1));
        }

        [Test]
        public void WhenOneUtilityIsOwned_GetNumberOfUtilities_ReturnsOne()
        {
            Assert.AreEqual(0, realtor.GetNumberOfOwnedUtilities());
            Player player1 = new Player("Hi", board);
            Property prop1 = new UtilitySquare(new RentStrategyUtility(new DiceRoller(), realtor), "util1", realtor);
            realtor.SetOwnerOf(prop1, player1);
            Assert.AreEqual(1, realtor.GetNumberOfOwnedUtilities());
        }

        [Test]
        public void WhenTwoUtilitiesAreOwned_GetNumber_ReturnsTwo()
        {
            Player player1 = new Player("peekaboo", board);
            Property prop1 = new UtilitySquare(new RentStrategyUtility(new DiceRoller(), realtor), "util1", realtor);
            Property prop2 = new UtilitySquare(new RentStrategyUtility(new DiceRoller(), realtor), "util2", realtor);
            realtor.SetOwnerOf(prop1, player1);
            realtor.SetOwnerOf(prop2, player1);
            Assert.AreEqual(2, realtor.GetNumberOfOwnedUtilities());
        }
    }
}
