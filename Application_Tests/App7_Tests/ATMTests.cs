using Application.App7;
using Moq;
using NUnit.Framework;

namespace Application_Tests.App7_Tests
{
    [TestFixture]
    public class ATMTests
    {

        [Test]
        public void Withdraw_GivenTheValue_ShouldWithdrawFromAccount()
        {
            float valueToWithdraw = 100;

            var bankOpsMock = new Mock<IBankOps>();
            bankOpsMock.Setup(b => b.Withdraw(It.IsAny<float>())).Returns(valueToWithdraw);

            Atm atmTest = new Atm(bankOpsMock.Object);

            var result = atmTest.Withdraw(valueToWithdraw);

            Assert.That(result, Is.EqualTo(valueToWithdraw));
        }
    }
}
