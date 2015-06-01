using MonopolyKata;
using MonopolyKata.Cards;
using MonopolyKata.PropertySquares.Rent;
using NUnit.Framework;

namespace UnitTestProject1.SpecialPropertiesTest
{
    [TestFixture]
    public class UtilitySquareTest
    {
        private Player player;
        private Board board;
        private CardDealer dealer;

        [SetUp]
        public void Setup()
        {
            board = new Board(new Realtor(), new JailWarden(), new Banker(),  dealer, new DiceRoller());
            player = new Player("Tester");
        }
    }
}
