using MonopolyKata;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class PropertyTest
    {
        private Player player1;
        private Player player2;
        private Property prop;

        [SetUp]
        public void Init()
        {
            player1 = new Player("One", new Board());
            player2 = new Player("Two", new Board());
            prop = new Property("TestProperty", 100, 20);
        }

        [Test]
        public void WhenConstructorFires_PropertiesAreCorrectlyInitialized()
        {
            Property BoardWalk = new Property("BoardWalk");
            Assert.AreEqual("BoardWalk", BoardWalk.Name);
        }

        [Test]
        public void WhenPropertyIsLandedOn_PlayerMoneyIsReducedByRent()
        {
            
        }
        

    }
}
