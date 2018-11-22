namespace Application.App9
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product GetByCategory(string Category);
    }
}
