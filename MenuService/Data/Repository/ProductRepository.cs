using DataAccess;
using MenuService.Data.Repository.Interfaces;
using MenuService.Repositories.Entities;
using MenuService.Repositories.Persistence;

namespace MenuService.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MenuServiceDbContext dbContext) : base(dbContext)
        {
        
        }
    }
}
