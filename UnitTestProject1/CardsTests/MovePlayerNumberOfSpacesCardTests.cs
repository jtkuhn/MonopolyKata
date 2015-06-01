using MonopolyKata;
using MonopolyKata.Cards;
using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace UnitTestProject1.CardsTests
{
    [TestFixture]
    public class MovePlayerNumberOfSpacesCardTests
    {
        private Board board;
        private Mock<Board> mockBoard;
        private Mock<Player> mockPlayer;
        private Card testCard;
        private CardDealer dealer;

        [SetUp]
        public void Setup()
        {
            mockBoard = new Mock<Board>(new Realtor(), new JailWarden(), new Banker(), dealer, new DiceRoller());
            mockPlayer = new Mock<Player>("Bob");

            testCard = new MovePlayerNumberOfSpacesCard("Test Card", mockBoard.Object, 5);
        }

        [Test]
        public void WhenMovePlayerNumberOfSpacesCardIsDrawn_BoardMovesThePlayer()
        {
            mockBoard.Setup(x => x.MovePlayer(mockPlayer.Object, 5)).Verifiable();

            testCard.IsDrawn(mockPlayer.Object);
            mockBoard.Verify();
        }
    }
}
