using MonopolyKata;
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
            board = new Board(new Realtor());
            player1 = new Player("Hi", board);
            player2 = new Player("hello", board);
        }

        [Test]
        public void WhenPlayerHasNoMonopoly_IsMonopolyReturnsFalse()
        {
            player1.Move(1);
            Assert.False(board.IsPartOfMonopoly((MonopolizableProperty) board.GetSquareAt(1)));
            Assert.False(board.IsPartOfMonopoly((MonopolizableProperty) board.GetSquareAt(3)));
            player2.Move(3);
            Assert.False(board.IsPartOfMonopoly((MonopolizableProperty)board.GetSquareAt(1)));
            Assert.False(board.IsPartOfMonopoly((MonopolizableProperty)board.GetSquareAt(3)));
        }

        [Test]
        public void WhenPlayerHasMonopoly_IsMonopolyReturnsTrue()
        {
            player1.Move(1);
            player1.Move(2);
            Assert.True(board.IsPartOfMonopoly((MonopolizableProperty) board.GetSquareAt(1)));
            Assert.True(board.IsPartOfMonopoly((MonopolizableProperty) board.GetSquareAt(3)));
        }

    }
}
