using MonopolyKata;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class PropertyTest
    {
        [Test]
        public void WhenConstructorFires_PropertiesAreCorrectlyInitialized()
        {
            Property BoardWalk = new Property("BoardWalk");
            Assert.AreEqual("BoardWalk", BoardWalk.Name);
        }

        

    }
}
