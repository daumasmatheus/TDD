namespace Application.App1
{
    public class BankOps : IBankOps
    {
        public void Withdrawal(Account account, float ValueToWithdraw)
        {
            account.Balance -= ValueToWithdraw;
        }

        public void Deposit(Account account, float ValueToDeposit)
        {
            account.Balance += ValueToDeposit;
        }
    }
}
