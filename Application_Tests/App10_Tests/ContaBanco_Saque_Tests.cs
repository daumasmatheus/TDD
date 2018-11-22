using Application.App10;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Application_Tests.App10_Tests
{
    [Binding]
    public class ContaBanco_Saque_Tests
    {
        private ContaBanco _contaSaque;
        private ContaBanco _contaDeposito;

        [Given(@"conta valida")]
        [SetUp]
        public void DadoContaValida()
        {
            _contaSaque = new ContaBanco();
            _contaDeposito = new ContaBanco();
        }

        [Given(@"com o saldo inicial de (.*)")]
        public void DadoComOSaldoInicialDe(int saldoInicial)
        {
            _contaSaque.Saldo = saldoInicial;
        }

        [When(@"efetuo um saque de (.*)")]
        public void QuandoEfetuoUmSaqueDe(int valorSaque)
        {
            _contaSaque.Saque(valorSaque);
        }

        [Then(@"o meu saldo final devera ser de (.*)")]
        public void EntaoOMeuSaldoFinalDeveraSerDe(int saldoFinal)
        {
            _contaSaque.Saldo.Should().Be(saldoFinal);
        }

        [Given(@"com saldo inicial de (.*)")]
        public void DadoComSaldoInicialDe(int saldoInicial)
        {
            _contaDeposito.Saldo = saldoInicial;
        }

        [When(@"efetuo um deposito de (.*)")]
        public void QuandoEfetuoUmDepositoDe(int valorDeposito)
        {
            _contaDeposito.Deposito(valorDeposito);
        }

        [Then(@"o meu saldo final apos o deposito devera ser de (.*)")]
        public void EntaoOMeuSaldoFinalAposODepositoDeveraSerDe(int saldoFinal)
        {
            _contaDeposito.Saldo.Should().Be(saldoFinal);
        }


    }
}
