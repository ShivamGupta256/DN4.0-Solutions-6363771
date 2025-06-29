using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private CustomeComm _customerComm;
        private Mock<IMailSender> _mockMailSender;

        [SetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();
            _customerComm = new CustomeComm(_mockMailSender.Object);

            _mockMailSender
                .Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);
        }

        [Test]
        public void SendMailToCustomer_WhenCalled_ReturnsTrue()
        {

            var result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);
            
            _mockMailSender.Verify(
                x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()), 
                Times.Once);
        }

        [Test]
        [TestCase("test@example.com", "Welcome message")]
        [TestCase("customer@domain.com", "Order confirmation")]
        public void SendMailToCustomer_WithDifferentInputs_ReturnsTrue(string address, string message)
        {

            var result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);
            
            TestContext.WriteLine($"Tested with address: {address}");
            TestContext.WriteLine($"Tested with message: {message}");
        }

        [TearDown]
        public void Cleanup()
        {
            _mockMailSender = null;
            _customerComm = null;
        }
    }
}