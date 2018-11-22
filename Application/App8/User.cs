using System;

namespace Application.App8
{
    public class User : IUserValidation
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsPasswordValid()
        {
            if (String.IsNullOrEmpty(Username) || String.IsNullOrWhiteSpace(Username))
                throw new ArgumentNullException("Please, inform the username to proceed with the registration.");

            return true;
        }

        public bool IsUsernameValid()
        {
            if (Password.Length < 4)
                throw new ArgumentOutOfRangeException("The password must be more than 4 characters long.");

            return true;
        }
    }
}