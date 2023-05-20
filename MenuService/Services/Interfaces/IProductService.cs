using MenuService.Repositories.Entities;

namespace MenuService.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<MenuGroup>> GetMenuGroups();
    }
}
