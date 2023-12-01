using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProductsStoringState.BusinessLayer.Service;

namespace ProductsStoringState.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMemoryCache memoryCache;
        private const int pageSize = 5;
        private const string cacheKey = "product_list";

        public ProductController(IProductService productService, IMemoryCache memoryCache)
        {
            this.productService = productService;
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            if (!memoryCache.TryGetValue(cacheKey, out var result))
            {
                result = productService.GetAllProducts();

                memoryCache.Set(cacheKey, result,
                    new MemoryCacheEntryOptions 
                    { 
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                    });
            }

            return View(result);
        }

        public IActionResult GetProducts()
        {
            string pageStr = Request.Query["page"];

            if (int.TryParse(pageStr, out var page))
            {
                var products = productService.GetProducts(page, pageSize);

                return View(products);
            }

            return View();
        }
    }
}
