using MonopolyKata;
using NUnit.Framework;

namespace UnitTestProject1.SpecialPropertiesTest
{
    [TestFixture]
    public class UtilitySquareTest
    {
        private Player player;
        private Board board;

        [SetUp]
        public void Setup()
        {
            board = new Board(new Realtor());
            player = new Player("Tester", board);
        }
    }
}
