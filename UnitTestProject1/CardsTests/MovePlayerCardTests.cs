using MonopolyKata;
using MonopolyKata.Cards;
using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace UnitTestProject1.CardsTests
{
    [TestFixture]
    public class MovePlayerCardTests
    {
        private Mock<Board> mockBoard;
        private Mock<Player> mockPlayer;
        private Card testCard;
        private LazyLoadCardDealer dealer;

        [SetUp]
        public void Setup()
        {
            dealer = new LazyLoadCardDealer(new Banker(), new JailWarden());
            mockBoard = new Mock<Board>(new Realtor(), new JailWarden(), new Banker(), dealer, new DiceRoller());
            mockPlayer = new Mock<Player>("Jim");

            testCard = new MovePlayerCard("Test", mockBoard.Object, 5);
        }

        [Test]
        public void WhenMovePlayerCardIsDrawn_BoardMovesThePlayer()
        {
            mockBoard.Setup(x => x.MovePlayer(mockPlayer.Object, It.IsAny<int>())).Verifiable();

            testCard.IsDrawn(mockPlayer.Object);
            mockBoard.Verify();
        }

        [TestCase(10, 15, 5)]
        [TestCase(5, 25, 20)]
        [TestCase(5, 1, 36)]
        [TestCase(39, 0, 1)]
        public void MovePlayerCard_CorrectlyCalculatesDistanceToMove(int playerPos, int objectivePos, int trueDistanceToMove)
        {
            testCard = new MovePlayerCard("Test", mockBoard.Object, objectivePos);

            mockPlayer.Setup(x => x.Position).Returns(playerPos);
            mockBoard.Setup(x => x.MovePlayer(mockPlayer.Object, trueDistanceToMove)).Verifiable();
            testCard.IsDrawn(mockPlayer.Object);
            mockBoard.Verify();
        }
    }
}
