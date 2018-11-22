namespace Application.App10
{
    public class ContaBanco
    {
        public int Saldo { get; set; } = 0;

        public void Saque(int valorSaque)
        {
            Saldo -= valorSaque;
        }

        public void Deposito(int valorDeposito)
        {
            Saldo += valorDeposito;
        }
    }
}
