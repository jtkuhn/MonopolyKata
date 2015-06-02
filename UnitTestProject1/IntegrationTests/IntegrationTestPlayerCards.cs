using System;
using MonopolyKata;
using MonopolyKata.Cards;
using MonopolyKata.PropertySquares;
using MonopolyKata.PropertySquares.Rent;
using NUnit.Framework;

namespace UnitTestProject1.IntegrationTests
{
    [TestFixture]
    public class IntegrationTestPlayerCards
    {
        private Realtor realtor;
        private JailWarden jailWarden;
        private Banker banker;
        private LazyLoadCardDealer cardDealer;
        private DiceRoller diceRoller;
        private Board board;
        private Player player1;

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
        }

        [Test]
        public void Integration_WhenPlayerLandsOnChanceSquare_HePullsACard()
        {
            Assert.That(board.GetSquareAt(2) as CommunityChestCardSquare, Is.TypeOf<CommunityChestCardSquare>());
            board.MovePlayer(player1, 2);
        }

        [Test]
        public void Z()
        {
            board.MovePlayer(player1, 2);
        }
    }
}
