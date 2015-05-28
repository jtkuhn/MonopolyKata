﻿using MonopolyKata;
using MonopolyKata.PropertySquares;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    class GoToJailSquareTest
    {
        private GoToJailSquare gtj = new GoToJailSquare();
        private Player player1 = new Player("t", new Board(new Realtor()));
        private BoardFactory bd = new BoardFactory();
        private Board board;

        [SetUp]
        public void Init()
        {
            board = bd.Create(new Realtor());
        }

        [Test]
        public void WhenConstructorFires_GoToJailIsInitializedCorrectly()
        {
            Assert.AreEqual("GoToJail", gtj.Name);
        }

        [Test]
        public void WhenPlayerLandsOnGoToJail_PlayerIsMovedToJail()
        {
            player1.Move(25);
            player1.Move(5);
            gtj.IsLandedOn(player1);
            Assert.AreEqual(10, player1.Position);
        }
    }
}
