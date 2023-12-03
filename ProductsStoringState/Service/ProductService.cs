using ProductsStoringState.BusinessLayer.Models;
using ProductsStoringState.DataLayer.Repository;

namespace ProductsStoringState.BusinessLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public List<ProductModel> GetAllProducts()
        {
            var products = repository.GetAllProducts();

            return products.Select(p => new ProductModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                InStock = p.InStock,
            }).ToList();
        }

        public List<ProductModel> GetProducts(int page, int pageSize)
        {
            var products = repository.GetProducts(page, pageSize);

            return products.Select(p => new ProductModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                InStock = p.InStock,
            }).ToList();
        }
    }
}
