using Application.App1;
using FluentAssertions;
using NUnit.Framework;

namespace Application_Tests.App1_Tests
{
    [TestFixture]
    class BankOpsTests
    {
        private BankOps _bankOps;
        private Account account;

        [SetUp]
        public void SetUp()
        {
            _bankOps = new BankOps();

        }

        [TearDown]
        public void TearDown()
        {
            _bankOps = null;
            account = null;
        }

        [Test]
        public void BankOps_Withdrawal_PositiveBalance_ShouldAllowWithdrawal()
        {
            account = new Account("John", 1200);
            _bankOps.Withdrawal(account, 200);

            float newBalance = 1000;

            //Assert.That(account.Balance, Is.EqualTo(newBalance));
            account.Balance.Should().Be(newBalance);
        }

        [Test]
        public void BankOps_Withdrawal_LowBalance_ShouldGotNegativeBalance()
        {
            account = new Account("John", 500);
            _bankOps.Withdrawal(account, 1000);

            float newBalance = -500;

            //Assert.That(account.Balance, Is.EqualTo(newBalance));
            account.Balance.Should().Be(newBalance);
        }

        [Test]
        public void BankOps_Withdrawal_NegativeBalance_ShouldIncreaseNegativeBalance()
        {
            account = new Account("John", -500);
            _bankOps.Withdrawal(account, 500);

            float newBalance = -1000;

            //Assert.That(account.Balance, Is.EqualTo(newBalance));
            account.Balance.Should().Be(newBalance);
        }

        [Test]
        public void BankOps_Deposit_NoBalance_ShouldIncreaseTheBalance()
        {
            account = new Account("John", 0);
            _bankOps.Deposit(account, 500);

            float newBalance = 500;

            //Assert.That(account.Balance, Is.EqualTo(newBalance));
            account.Balance.Should().Be(newBalance);
        }

        [Test]
        public void BankOps_Deposit_PositiveBalance_ShouldIncreaseTheBalance()
        {
            account = new Account("John", 500);
            _bankOps.Deposit(account, 500);

            float newBalance = 1000;

            //Assert.That(account.Balance, Is.EqualTo(newBalance));
            account.Balance.Should().Be(newBalance);
        }

        [Test]
        public void BankOps_Deposit_NegativeBalance_ShouldIncreaseTheBalance()
        {
            account = new Account("John", -500);
            _bankOps.Deposit(account, 1000);

            float newBalance = 500;

            //Assert.That(account.Balance, Is.EqualTo(newBalance));
            account.Balance.Should().Be(newBalance);
        }
    }
}
