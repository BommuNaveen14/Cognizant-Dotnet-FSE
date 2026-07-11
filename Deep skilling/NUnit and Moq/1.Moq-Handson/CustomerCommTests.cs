using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> mockMail;
        private CustomerComm customer;
        [OneTimeSetUp]
        public void Init()
        {
            mockMail = new Mock<IMailSender>();
            mockMail.Setup(x =>
                x.SendMail(It.IsAny<string>(),
                           It.IsAny<string>()))
                    .Returns(true);
            customer = new CustomerComm(mockMail.Object);
        }

        [TestCase]
        public void SendMailTest()
        {
            bool result = customer.SendMailToCustomer();

            Assert.IsTrue(result);
        }
    }
}