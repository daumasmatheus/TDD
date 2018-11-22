using Application.App3;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Application_Tests.App3_Tests
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        private Mock<DbSet<Person>> mockDbSet;
        private Mock<DataContext> mockDataContext;

        private PersonRepository repo;

        [SetUp]
        public void SetUp()
        {
            var data = new List<Person>
            {
                new Person { Id = 1, FirstName = "Matheus", Age = 27, LastName = "Daumas"},
                new Person { Id = 2, FirstName = "Bob", Age = 32, LastName = "Donald" },
                new Person { Id = 3, FirstName = "Martin", Age = 25, LastName = "Wayne" },
                new Person { Id = 4, FirstName = "James", Age = 21, LastName = "Mice" }

            };

            mockDbSet = new Mock<DbSet<Person>>();

            //mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            //mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.AsQueryable().GetEnumerator);

            mockDataContext = new Mock<DataContext>();
            mockDataContext.Setup(ctx => ctx.Set<Person>()).Returns(mockDbSet.Object);

            repo = new PersonRepository(mockDataContext.Object);
        }

        [TearDown]
        public void TearDown()
        {
            repo = null;
        }

        [Test]
        public void GetAll_ShouldNotBeNull()
        {
            var persons = repo.GetAll().ToList();

            Assert.That(persons, Is.Not.Null);
        }

        [Test]
        public void GetAll_ShouldHaveFourRecords()
        {
            var persons = repo.GetAll().ToList();

            Assert.That(persons.Count, Is.EqualTo(4));
        }

        [Test]
        public void GetAll_ShouldHaveARecordWithNameMatheusAndIdOne()
        {
            var persons = repo.GetAll().ToList();

            Assert.That(persons[0].FirstName, Is.EqualTo("Matheus").IgnoreCase);
            Assert.That(persons[0].Id, Is.EqualTo(1));
        }

        [Test]
        public void Find_ShouldReturnAPersonGivenAnExpecifiedId()
        {
            var person = repo.Find(x => x.Id == 1);

            Assert.That(person, Is.Not.Null);
            Assert.That(person.FirstName, Is.EqualTo("Matheus").IgnoreCase);
        }

        [Test]
        public void Add_ShouldAddANewRecord()
        {
            var person = new Person { Id = 5, FirstName = "Adam", LastName = "Smith", Age = 65 };
            repo.Add(person);            

            mockDbSet.Verify(p => p.Add(It.IsAny<Person>()), Times.Once());            
        }

        [Test]
        public void Delete_ShouldDeleteAnExistingRecord()
        {
            var listPersons = repo.GetAll().ToList();
            var personToDelete = listPersons[0];

            repo.Delete(personToDelete);
            repo.SaveChanges();

            mockDbSet.Verify(p => p.Remove(It.IsAny<Person>()), Times.Once());
        }

        [Test]
        public void Edit_ShouldEditAnExistingRecord()
        {
            var personToEdit = repo.Find(x => x.Id == 1);
            personToEdit.FirstName = "Edited name";
            repo.SaveChanges();

            var personList = repo.GetAll().ToList();

            Assert.That(personList[0].FirstName, Is.EqualTo("Edited name"));
        }
    }
}
