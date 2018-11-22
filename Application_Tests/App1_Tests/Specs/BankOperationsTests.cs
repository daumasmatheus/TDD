using Application.App1;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Application_Tests.App1_Tests.Specs
{
    [Binding]
    public class BankOperationsSteps
    {
        private Account _account;
        private BankOps _bankOps;

        [SetUp]
        public void Setup()
        {
            _account = new Account("asdasd", 0);
            _bankOps = new BankOps();
        }

        [Given(@"uma conta com o seguninte saldo (.*)")]
        public void DadoUmaContaComOSeguninteSaldo(float saldoInicial)
        {
            _account.Balance = saldoInicial;
        }
        
        [Given(@"uma conta com o seguinte saldo (.*)")]
        public void DadoUmaContaComOSeguinteSaldo(float saldoInicial)
        {
            _account.Balance = saldoInicial;
        }
        
        [When(@"efetuo um saque de valor (.*)")]
        public void QuandoEfetuoUmSaqueDeValor(float valorSaque)
        {
            _bankOps.Withdrawal(_account, valorSaque);
        }
        
        [When(@"efetuo um  deposito de valor (.*)")]
        public void QuandoEfetuoUmDepositoDeValor(float valorDeposito)
        {
            _bankOps.Deposit(_account, valorDeposito);
        }
        
        [Then(@"deverei ter um saldo final de (.*)")]
        public void EntaoDevereiTerUmSaldoFinalDe(float saldoFinal)
        {
            Assert.That(_account.Balance, Is.EqualTo(saldoFinal));
        }
    }
}
