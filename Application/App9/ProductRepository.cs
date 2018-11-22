using System.Linq;

namespace Application.App9
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private ProductDbContext _context;

        public ProductRepository(ProductDbContext context) : base(context)
        {
            _context = context;
        }

        public Product GetByCategory(string Category)
        {
            return _context.Products.Where(p => p.Category == Category).FirstOrDefault();
        }
    }
}
