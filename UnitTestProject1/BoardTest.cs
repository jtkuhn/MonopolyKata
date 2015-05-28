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
            board = new Board();
            player1 = new Player("Hi", board);
            player2 = new Player("hello", board);
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
