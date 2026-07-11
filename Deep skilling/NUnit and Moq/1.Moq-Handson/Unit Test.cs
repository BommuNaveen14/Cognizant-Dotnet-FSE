using Moq;
using NUnit.Framework;
using PlayersManagerLib;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> mockMapper;

        [OneTimeSetUp]
        public void Init()
        {
            mockMapper = new Mock<IPlayerMapper>();

            mockMapper.Setup(x =>
                x.IsPlayerNameExistsInDb(It.IsAny<string>()))
                .Returns(false);
        }

        [TestCase]
        public void RegisterPlayerTest()
        {
            Player player =
                Player.RegisterNewPlayer(
                    "Virat",
                    mockMapper.Object);

            Assert.AreEqual("Virat", player.Name);
            Assert.AreEqual(23, player.Age);
            Assert.AreEqual("India", player.Country);
            Assert.AreEqual(30, player.NoOfMatches);
        }

        [TestCase]
        public void RegisterPlayerThrowsException()
        {
            mockMapper.Setup(x =>
                x.IsPlayerNameExistsInDb(It.IsAny<string>()))
                .Returns(true);

            Assert.Throws<System.ArgumentException>(() =>
            {
                Player.RegisterNewPlayer(
                    "Virat",
                    mockMapper.Object);
            });
        }
    }
}