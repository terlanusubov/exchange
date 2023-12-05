using Exchange.Domain.Aggregates.OperationAggregate;
using Exchange.Domain.Repositories;
using Exchange.Infrastructure.Persistance;

namespace Exchange.Infrastructure.Services
{
    public class OperationRepository : IOperationRepository
    {
        private readonly ApplicationDbContext _context;
        public OperationRepository(ApplicationDbContext context) => _context = context;

        public async Task AddAsync(Operation operation)
        {
            await _context.AddAsync(operation);
        }

        public Task<Operation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Operation operation)
        {
            throw new NotImplementedException();
        }
    }
}
