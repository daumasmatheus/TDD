using Application.App8;
using Moq;
using NUnit.Framework;
using System;

namespace Application_Tests.App8_Tests
{
    [TestFixture]
    public class UserServicesTest
    {
        private Mock<IUserServices> mockUserServices;
        private User userTests;
        private UserAuthentication authTest;

        [TearDown]
        public void TearDown()
        {
            userTests = null;
            authTest = null;
            mockUserServices = null;
        }

        [Test]
        public void Register_UsernameAndPasswordAreValid_ShouldRegisterTheUser()
        {
            userTests = new User()
            {
                Username = "Matheus",
                Password = "123456789"
            };

            mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(x => x.Register(It.IsAny<User>())).Returns(true);

            authTest = new UserAuthentication(mockUserServices.Object);
            var result = authTest.RegisterNewUser(userTests);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void Register_UsernameIsEmpty_ShouldThrowException()
        {
            userTests = new User()
            {
                Username = "",
                Password = "123465"
            };

            mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(x => x.Register(It.IsAny<User>())).Throws<ArgumentNullException>();

            authTest = new UserAuthentication(mockUserServices.Object);            

            Assert.Throws<ArgumentNullException>(() => authTest.RegisterNewUser(userTests));
        }

        [Test]
        public void Register_PasswordIsLessThanFourCharactersLong_ShouldThrowException()
        {
            userTests = new User()
            {
                Username = "Matheus",
                Password = "123"
            };

            mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(x => x.Register(It.IsAny<User>())).Throws<ArgumentOutOfRangeException>();

            authTest = new UserAuthentication(mockUserServices.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => authTest.RegisterNewUser(userTests));
        }

        [Test]
        public void Login_UsernameAndPasswordAreCorrect_ShouldAllowALogin()
        {
            string testUsername = "Matheus";
            string testPassword = "123456";
            userTests = new User() { Username = testUsername, Password = testPassword };

            mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(x => x.Login(It.Is<User>(y => y.Username == testUsername && 
                                                                 y.Password == testPassword))).Returns(true);

            authTest = new UserAuthentication(mockUserServices.Object);
            var result = authTest.Login(userTests);

            Assert.That(result, Is.True);
        }
    }
}
