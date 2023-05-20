using DataAccess;
using MenuService.Data.Repository.Interfaces;
using MenuService.Repositories.Entities;
using MenuService.Repositories.Persistence;

namespace MenuService.Data.Repository
{
    public class MenuGroupRepository : Repository<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(MenuServiceDbContext dbContext) : base(dbContext)
        {
        
        }
    }
}
