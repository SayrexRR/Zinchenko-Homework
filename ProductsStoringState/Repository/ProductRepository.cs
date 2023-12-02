using ProductsStoringState.DataLayer.Entities;
using ProductsStoringState.Repository;

namespace ProductsStoringState.DataLayer.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductsContext context)
            :base(context)
        {
        }       

        public List<Product> GetAllProducts()
        {
            return productsContext.Products.ToList();
        }

        public List<Product> GetProducts(int page, int pageSize)
        {
            return productsContext.Products
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
