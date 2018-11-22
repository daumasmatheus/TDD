namespace Application.App1
{
    public class Account
    {
        public Account(string _name, float _balance)
        {
            Name = _name;
            Balance = _balance;
        }

        public string Name { get; set; }
        public float Balance { get; set; }

    }
}
