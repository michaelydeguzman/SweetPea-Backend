using Common.Models;
using MenuService.Repositories.Entities;
using MenuService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IProductService _productService;

        public MenuController(ILogger<MenuController> logger, IProductService productService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        [Route("menu_groups")]
        public async Task<IActionResult> GetMenuGroups()
        {
            var result = new List<MenuGroup>();
            try
            {
                var menuGroups = await _productService.GetMenuGroupsAsync();
                result = menuGroups.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);
                return BadRequest(ex);
            }
        }
    }
}