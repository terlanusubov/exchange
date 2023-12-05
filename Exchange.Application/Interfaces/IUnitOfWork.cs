namespace Exchange.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }

}
