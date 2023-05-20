using MenuService.Repositories.Entities;
using MenuService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IProductService _productService;

        public MenuController(ILogger<MenuController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet(Name = "GetMenuGroups")]
        public async Task<List<MenuGroup>> GetMenuGroups()
        {
            var result = new List<MenuGroup>();
            try
            {
                var menuGroups = await _productService.GetMenuGroups();
                result = menuGroups.ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);
                return result;
            }
        }
    }
}