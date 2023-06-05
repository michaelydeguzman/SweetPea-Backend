using MenuService.Repositories.Entities;

namespace MenuService.Services.Interfaces
{
    public interface IProductFactory
    {
        Task<IEnumerable<MenuGroup>> GetMenuGroupsAsync();
    }
}
