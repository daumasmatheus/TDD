using System.Data.Entity;

namespace Application.App9
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base() { }

        public DbSet<Product> Products { get; set; }
    }
}
