using ProductsStoringState.DataLayer.Entities;

namespace ProductsStoringState.DataLayer.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        List<Product> GetProducts(int page, int pageSize);
    }
}
