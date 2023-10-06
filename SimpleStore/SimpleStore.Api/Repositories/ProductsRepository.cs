using SimpleStore.Api.Contracts;
using SimpleStore.Api.Data;

namespace SimpleStore.Api.Repositories
{
    public class ProductsRepository: GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(SimpleStoreDbContext context): base(context)
        {
            
        }
    }
}
