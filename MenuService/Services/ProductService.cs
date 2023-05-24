using MenuService.Data.Repository.Interfaces;
using MenuService.Repositories.Entities;
using MenuService.Services.Interfaces;

namespace MenuService.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<MenuGroup>> GetMenuGroupsAsync()
        {
            return await _uow.MenuGroupRepository.GetAllAsync();
        }
    }
}
