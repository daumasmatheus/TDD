namespace Application.App1
{
    public interface IBankOps
    {
        void Withdrawal(Account account, float ValueToWithdraw);
        void Deposit(Account account, float ValueToDeposit);
    }
}
