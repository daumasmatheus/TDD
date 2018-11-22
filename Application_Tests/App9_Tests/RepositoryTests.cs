using Application.App9;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Application_Tests.App9_Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private Mock<DbSet<Product>> mockDbSet;
        private Mock<ProductDbContext> mockProductDbContext;
        private ProductRepository repo;

        [SetUp]
        public void Setup()
        {
            var fakeData = new List<Product>
            {
                new Product { Id = 1, Name = "Vga card", Description = "Gaming vga card", Category = "Hardware"},
                new Product { Id = 2, Name = "Mouse", Description = "Gaming mouse", Category = "Pheripherals" },
                new Product { Id = 3, Name = "Dragon Age Inquisition", Category = "Video Games", Description = "PC rpg game" },
                new Product { Id = 4, Name = "Mouse mat", Category = "Accessories", Description = "Rubber mouse mat" }
            }.AsQueryable();

            mockDbSet = new Mock<DbSet<Product>>();
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator);

            mockProductDbContext = new Mock<ProductDbContext>();
            mockProductDbContext.Setup(ctx => ctx.Set<Product>()).Returns(mockDbSet.Object);

            repo = new ProductRepository(mockProductDbContext.Object);
        }

        [TearDown]
        public void TearDown()
        {
            repo = null;
        }

        [Test]
        public void GetAll_ShouldGetAllData()
        {
            var data = repo.GetAll().ToList();

            data.Should().NotBeNull();
            data.Should().HaveCount(4);
        }

        [Test]
        public void Find_ShouldFetchTheFirstRegister()
        {
            string mustFind = "Vga card";
            var data = repo.Find(x => x.Name == mustFind);

            data.Should().NotBeNull();
            data.Should().Contain(x => x.Name == mustFind);
        }

        [Test]
        public void Add_ShouldAddANewRegister()
        {
            string newProductName = "TestProduct";
            int newProductId = 5;

            Product prod = new Product() { Id = newProductId, Name = newProductName, Category = "Test", Description = "Test" };

            repo.Add(prod);

            mockProductDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
