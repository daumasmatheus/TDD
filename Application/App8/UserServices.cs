using System;

namespace Application.App8
{
    public class UserServices : IUserServices
    {
        public bool Login(User user)
        {
            throw new NotImplementedException();
        }

        public bool Register(User user)
        {
            if (user.IsPasswordValid() && user.IsUsernameValid())
                return true;

            return false;
        }
    }
}
