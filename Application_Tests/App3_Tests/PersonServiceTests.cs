using Application.App3;
using Moq;
using NUnit.Framework;

namespace Application_Tests.App3_Tests
{
    [TestFixture]
    public class PersonServiceTests
    {
        private Mock<IPersonService> mockPersonService;
        private PersonService personService;
        private Person _person;

        [SetUp]
        public void TestSetup()
        {
            mockPersonService = new Mock<IPersonService>();
            personService = new PersonService();
        }

        [TearDown]
        public void TestTearDown()
        {
            personService = null;
            _person = null;
        }

        [Test]
        public void AddNewPerson_NameIsEmpty_ShoudThrowAnExeption()
        {
            _person = new Person
            {
                Id = 1,
                Age = 35,
                FirstName = "",
                LastName = "Rourke"
            };

            Assert.That(() => personService.AddNewPerson(_person), Throws.ArgumentNullException);
        }
    }
}
