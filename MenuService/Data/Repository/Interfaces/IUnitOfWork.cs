namespace MenuService.Data.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMenuGroupRepository MenuGroupRepository { get; }

        IProductRepository ProductRepository { get; }

        Task<int> Complete();
    }
}
