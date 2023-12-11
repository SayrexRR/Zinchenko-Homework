using ProductsStoringState.BusinessLayer.Models;

namespace ProductsStoringState.BusinessLayer.Service
{
    public interface IProductService
    {
        List<ProductModel> GetAllProducts();
        List<ProductModel> GetProducts(int page, int pageSize);
    }
}
