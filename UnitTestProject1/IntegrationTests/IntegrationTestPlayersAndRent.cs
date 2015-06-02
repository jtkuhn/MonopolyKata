using System;
using MonopolyKata;
using MonopolyKata.Cards;
using MonopolyKata.PropertySquares;
using MonopolyKata.PropertySquares.Rent;
using NUnit.Framework;

namespace UnitTestProject1.IntegrationTests
{
    [TestFixture]
    public class IntegrationTestPlayersAndRent
    {
        private Realtor realtor;
        private JailWarden jailWarden;
        private Banker banker;
        private LazyLoadCardDealer cardDealer;
        private DiceRoller diceRoller;
        private Board board;
        private Player player1;
        private Player player2;

        [SetUp]
        public void Setup()
        {
            realtor = new Realtor();
            jailWarden = new JailWarden();
            banker = new Banker();
            diceRoller = new DiceRoller();
            cardDealer = new LazyLoadCardDealer(banker, jailWarden);
            board = new Board(realtor, jailWarden, banker, cardDealer, diceRoller);
            player1 = new Player("Bob");
            player2 = new Player("Bob's unfortunate brother");
        }

        [Test]
        public void Integration_PlayerLandingOnGoToJail_ActuallyGoesToJail()
        {
            board.MovePlayer(player1, 30);
            Assert.True(jailWarden.IsInJail(player1));
        }

        [Test]
        public void PlayerThatOwnsAProperty_IsNotChargedForLandingBackOnIt_ButOthersAre()
        {
            board.MovePlayer(player1, 3);
            Assert.AreEqual(1440, player1.Money);
            board.MovePlayer(player1, 40);
            Assert.AreEqual(1640, player1.Money);
            board.MovePlayer(player2, 3);
            Assert.AreEqual(1496, player2.Money);
            Assert.AreEqual(1644, player1.Money);
        }

        [Test]
        public void TwoPlayersCanLandOnTheSameSquare_WithoutProblems()
        {
            board.MovePlayer(player1, 3);
            board.MovePlayer(player2, 3);
            Assert.AreEqual(player1, realtor.GetOwnerOf((Property) board.GetSquareAt(3)));
            Assert.AreEqual(1496, player2.Money);
        }

        [Test]
        public void WhenAPlayerTakesThreeRailroads_RentIsChargedAppropriately()
        {
            board.MovePlayer(player1, 5);
            board.MovePlayer(player1, 10);
            board.MovePlayer(player1, 10);
            Assert.AreEqual(900, player1.Money);
            board.MovePlayer(player2, 5);
            Assert.AreEqual(1400, player2.Money);
            Assert.AreEqual(1000, player1.Money);
            board.MovePlayer(player1, 20);
            Assert.AreEqual(1200, player1.Money);
        }
    }
}
