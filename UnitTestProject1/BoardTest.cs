﻿using MonopolyKata;
using MonopolyKata.PropertySquares.Properties;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class BoardTest
    {
        private Board board;
        private Player player1;
        private Player player2;

        [SetUp]
        public void Setup()
        {
            board = new Board(new Realtor(), new JailWarden());
            player1 = new Player("Hi");
            player2 = new Player("hello");
        }

        [Test]
        public void WhenPlayerHasNoMonopoly_IsMonopolyReturnsFalse()
        {
            board.MovePlayer(player2, 1);
            Assert.False(board.IsPartOfMonopoly((MonopolizableProperty) board.GetSquareAt(1)));
            Assert.False(board.IsPartOfMonopoly((MonopolizableProperty) board.GetSquareAt(3)));
            board.MovePlayer(player2, 3);
            Assert.False(board.IsPartOfMonopoly((MonopolizableProperty)board.GetSquareAt(1)));
            Assert.False(board.IsPartOfMonopoly((MonopolizableProperty)board.GetSquareAt(3)));
        }

        [Test]
        public void WhenPlayerHasMonopoly_IsMonopolyReturnsTrue()
        {
            board.MovePlayer(player1, 1);
            board.MovePlayer(player1, 2);
            Assert.True(board.IsPartOfMonopoly((MonopolizableProperty) board.GetSquareAt(1)));
            Assert.True(board.IsPartOfMonopoly((MonopolizableProperty) board.GetSquareAt(3)));
        }
    }
}
