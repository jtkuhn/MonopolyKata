using MonopolyKata;
using MonopolyKata.PropertySquares.Properties;
using MonopolyKata.PropertySquares.Rent;
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
            board = new Board(new Realtor(), new JailWarden(), new Banker(), new DiceRoller());
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

        [Test]
        public void WhenGetIndexOfIsCalled_FindsRightPropertyAndIndex()
        {
            Assert.AreEqual(10, board.GetIndexOf("Just Visiting"));
            Assert.AreEqual(5, board.GetIndexOf("Reading Railroad"));
            Assert.AreEqual(-1, board.GetIndexOf("Go Directly To Jail")); //not the right name
            Assert.AreEqual(30, board.GetIndexOf("Go To Jail"));
        }

        [Test]
        public void MovingAPlayerBackwards_DoesNotPassByAnySquares_ButDoesLandOnTheSquare()
        {
            Assert.AreEqual(0, player1.Position);
            board.MovePlayer(player1, 1);
            board.MovePlayer(player1, -3); //moves him backwards past go and onto luxury tax
            Assert.AreEqual(1425, player1.Money); //does not collect $200 and does pay $75 fine

        }
    }
}
