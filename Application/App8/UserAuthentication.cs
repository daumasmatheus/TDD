namespace Application.App8
{
    public class UserAuthentication
    {
        private IUserServices _userServices;

        public UserAuthentication(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public bool RegisterNewUser(User user)
        {
            return _userServices.Register(user);
        }

        public bool Login(User user)
        {
            return _userServices.Login(user);
        }
    }
}
