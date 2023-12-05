using Exchange.Domain.Aggregates.OperationAggregate;

namespace Exchange.Domain.Repositories
{
    public interface IOperationRepository
    {
        Task<Operation> GetByIdAsync(int id);
        Task AddAsync(Operation operation);
        Task UpdateAsync(Operation operation);
    }
}
