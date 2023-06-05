using AutoFixture;
using MenuService.Data.Repository.Interfaces;
using MenuService.Repositories.Entities;
using MenuService.Services;
using Moq;
using Xunit;

namespace MenuService.Test
{
    public class ProductFactoryTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMenuGroupRepository> _mockGroupRepository;
        private Fixture _fixture;


        public ProductFactoryTest()
        {
            _fixture = new Fixture();
            // Ommit recursion
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockGroupRepository = new Mock<IMenuGroupRepository>();
        }

        [Fact]
        public async Task GetMenuGroups_WithRows_ReturnsAll()
        {
            // Arrange
            int menuGroupCount = 2;
            IEnumerable<MenuGroup> mockDepartmentsEntity = _fixture.CreateMany<MenuGroup>(menuGroupCount);

            _mockGroupRepository.Setup(mgr => mgr.GetAllAsync()).ReturnsAsync(mockDepartmentsEntity).Verifiable();
            _mockUnitOfWork.Setup(muow => muow.MenuGroupRepository).Returns(_mockGroupRepository.Object);

            // Act
            ProductFactory productService = new ProductFactory(_mockUnitOfWork.Object);
            IEnumerable<MenuGroup> response = await productService.GetMenuGroupsAsync();

            // Assert
            _mockGroupRepository.Verify();
            Assert.NotEmpty(response);
            Assert.IsAssignableFrom<IEnumerable<MenuGroup>>(response);
            Assert.Equal(menuGroupCount, response.Count());

        }
    }
}