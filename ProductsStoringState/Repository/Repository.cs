using ProductsStoringState.DataLayer;

namespace ProductsStoringState.Repository
{
    public abstract class Repository<T> where T : class
    {
        protected readonly ProductsContext productsContext;
        public Repository(ProductsContext context)
        {
            productsContext = context;
        }

        public T GetById(int id) => productsContext.Set<T>().Find(id);

        public List<T> GetAll() => productsContext.Set<T>().ToList();
    }
}
