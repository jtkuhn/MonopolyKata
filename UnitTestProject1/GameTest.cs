using MonopolyKata;
using MonopolyKata.Cards;
using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class GameTest
    {
        private Game game;
        private Mock<DiceRoller> mockDiceRoller;
        private Player player;
        private CardDealer dealer;
        private JailWarden jailWarden;

        [SetUp]
        public void Setup()
        {
            game = new Game(4);
            dealer = game.GetCardDealer();
            jailWarden = game.GetJailWarden();
            mockDiceRoller = new Mock<DiceRoller>();
            player = game.players[0];
        }
        
        [Test]
        public void Board_IsInitializedCorrectly()
        {
            Assert.AreEqual("Go", game.Board.GetSquareAt(0).Name);
            Assert.AreEqual("Go To Jail", game.Board.GetSquareAt(30).Name);
        }

        [Test]
        public void WhenGameIsInitialized_PlayersAreAllInstantiated()
        {
            foreach (Player x in game.players)
            {
                Assert.NotNull(x);
            }
        }

        [Test]
        public void WhenPlayerRollsNoDoubles_TheyDoNotGoToJail()
        {
            game.SetDiceRoller(mockDiceRoller.Object);
            mockDiceRoller.Setup(x => x.GetNextRoll()).Returns(5);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(5);
            mockDiceRoller.Setup(x => x.WasDoubles()).Returns(false);
            game.PlayOneTurnOnBoard(player);
            Assert.That(jailWarden.IsInJail(player), Is.False);
        }

        [Test]
        public void WhenPlayerRollsThreeDoubles_TheyGoToJail()
        {
            game.SetDiceRoller(mockDiceRoller.Object);
            mockDiceRoller.Setup(x => x.GetNextRoll()).Returns(5);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(5);
            mockDiceRoller.Setup(x => x.WasDoubles()).Returns(true);
            game.PlayOneTurnOnBoard(player);
            Assert.True(jailWarden.IsInJail(player));
        }

        [Test]
        public void WhenPlayerIsInJail_AndRollsNoDoubles_TheyStayInJail()
        {
            game.SetDiceRoller(mockDiceRoller.Object);
            mockDiceRoller.Setup(x => x.GetNextRoll()).Returns(5);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(5);
            mockDiceRoller.Setup(x => x.WasDoubles()).Returns(false);
            jailWarden.MovePlayerToJail(player);
            Assert.AreEqual(10, player.Position);
            Assert.True(jailWarden.IsInJail(player));
            game.PlayOneTurnInJail(player);
            Assert.AreEqual(10, player.Position);
            Assert.True(jailWarden.IsInJail(player));
        }

        [Test]
        public void WhenPlayerIsInJail_AndRollsADouble_TheyGetOutFree()
        {
            game.SetDiceRoller(mockDiceRoller.Object);
            mockDiceRoller.Setup(x => x.GetNextRoll()).Returns(6);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(6);
            mockDiceRoller.Setup(x => x.WasDoubles()).Returns(true); 

            jailWarden.MovePlayerToJail(player);
            Assert.AreEqual(10, player.Position);
            Assert.True(jailWarden.IsInJail(player));

            game.PlayOneTurnInJail(player);

            Assert.AreEqual(16, player.Position);
            Assert.IsFalse(jailWarden.IsInJail(player));
        }

        [Test]
        public void WhenPlayerIsInJailOnThirdTurn_AndRollsDoubles_GetsOutFree()
        {
            game.SetDiceRoller(mockDiceRoller.Object);
            mockDiceRoller.Setup(x => x.GetNextRoll()).Returns(6);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(6);
            mockDiceRoller.Setup(x => x.WasDoubles()).Returns(false);

            jailWarden.MovePlayerToJail(player);
            Assert.AreEqual(10, player.Position);
            Assert.True(jailWarden.IsInJail(player));

            game.PlayOneTurnInJail(player);
            game.PlayOneTurnInJail(player);

            mockDiceRoller.Setup(x => x.WasDoubles()).Returns(true);
            Assert.AreEqual(1500, player.Money);

            game.PlayOneTurnInJail(player);

            Assert.IsFalse(jailWarden.IsInJail(player));
            Assert.AreEqual(16, player.Position);
            Assert.AreEqual(1500, player.Money);
        }

        [Test]
        public void WhenPlayerIsInJailOnThirdTurn_AndRollsNoDouble_Pays50DollarsAndGetsOut()
        {
            game.SetDiceRoller(mockDiceRoller.Object);
            mockDiceRoller.Setup(x => x.GetNextRoll()).Returns(6);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(6);
            mockDiceRoller.Setup(x => x.WasDoubles()).Returns(false);

            jailWarden.MovePlayerToJail(player);
            Assert.AreEqual(10, player.Position);
            Assert.AreEqual(1500, player.Money);
            Assert.True(jailWarden.IsInJail(player));

            game.PlayOneTurnInJail(player);
            game.PlayOneTurnInJail(player);
            game.PlayOneTurnInJail(player);

            Assert.AreEqual(16, player.Position);
            Assert.AreEqual(1450, player.Money);
        }

        [Test]
        public void WhenPlayerPays50ToLeaveJail_TheyAreInJustVisiting()
        {
            jailWarden.MovePlayerToJail(player);
            game.Pay50ToGetOutOfJail(player);
            Assert.AreEqual(10, player.Position);
            Assert.IsFalse(jailWarden.IsInJail(player));
        }

        [Test]
        public void WhenPlayerIsInJail_AndPaysToGetOut_TheyMoveLikeNormal()
        {
            jailWarden.MovePlayerToJail(player);
            game.Pay50ToGetOutOfJail(player);

            game.SetDiceRoller(mockDiceRoller.Object);
            mockDiceRoller.Setup(x => x.GetNextRoll()).Returns(6);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(6);
            mockDiceRoller.Setup(x => x.WasDoubles()).Returns(false);

            game.PlayOneTurn(player);

            Assert.AreEqual(16, player.Position);
        }

        [Test]
        public void WhenPlayerIsInJailAndUsesCard_HeGetsOutOfJail()
        {
            dealer.SetOwnerOfChanceJailCard(player);
            jailWarden.MovePlayerToJail(player);
            Assert.True(jailWarden.IsInJail(player));
            game.UseGetOutOfJailFreeCard(player);
            Assert.False(jailWarden.IsInJail(player));
        }
    }
}
