namespace Application.App8
{
    public interface IUserServices
    {
        bool Register(User user);
        bool Login(User user);
    }
}
