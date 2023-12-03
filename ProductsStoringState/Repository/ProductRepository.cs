using ProductsStoringState.DataLayer.Entities;

namespace ProductsStoringState.DataLayer.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsContext context;

        public ProductRepository(ProductsContext context)
        {
            this.context = context;
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public List<Product> GetProducts(int page, int pageSize)
        {
            return context.Products
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
