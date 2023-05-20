using MenuService.Data.Repository.Interfaces;
using MenuService.Repositories.Persistence;

namespace MenuService.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MenuServiceDbContext _dbContext;

        public IMenuGroupRepository MenuGroupRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(MenuServiceDbContext dbContext)
        {
            _dbContext = dbContext;
            MenuGroupRepository = new MenuGroupRepository(_dbContext);
        }

        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
