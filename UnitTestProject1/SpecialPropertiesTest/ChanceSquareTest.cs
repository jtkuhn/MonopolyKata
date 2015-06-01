using MonopolyKata;
using MonopolyKata.Cards;
using MonopolyKata.PropertySquares;
using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace UnitTestProject1.SpecialPropertiesTest
{
    [TestFixture]
    public class ChanceSquareTest
    {
        private Mock<CardDealer> mockDealer;
        private ChanceCardSquare chanceSquare;

        [SetUp]
        public void Setup()
        {
            
            Banker banker = new Banker();
            JailWarden jailWarden = new JailWarden();
            Board board = new Board(new Realtor(), jailWarden, banker, new DiceRoller());
            mockDealer = new Mock<CardDealer>(banker, jailWarden, board);
            chanceSquare = new ChanceCardSquare(mockDealer.Object);
        }

        [Test]
        public void CallingIsLandedOnWithChanceSquare_GetsCardFromChancePile()
        {
            mockDealer.Setup(x => x.DrawNextChanceCard()).Verifiable();
            mockDealer.Setup(x => x.DrawNextChanceCard()).Returns(new Card("Hi"));
            chanceSquare.IsLandedOn(new Player("Bob"));
            mockDealer.Verify();
        }

        [Test]
        public void CallingIsLandedOnWithChanceSquare_AddsTheCalledCardBackToThePileWhenDone()
        {
            mockDealer.Setup(x => x.AddCardToChancePile(It.IsAny<Card>())).Verifiable();
            mockDealer.Setup(x => x.DrawNextChanceCard()).Returns(new Card("Hi"));
            chanceSquare.IsLandedOn(new Player("Bob"));
            mockDealer.Verify();
        }
    }
}
