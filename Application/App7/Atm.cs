namespace Application.App7
{
    public class Atm
    {
        private readonly IBankOps _bankOps;

        public Atm(IBankOps bankOps)
        {
            _bankOps = bankOps;
        }

        public float Withdraw(float value)
        {
            return _bankOps.Withdraw(value);
        }
    }
}
