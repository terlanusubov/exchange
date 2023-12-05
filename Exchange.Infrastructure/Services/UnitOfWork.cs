using Exchange.Application.Exceptions;
using Exchange.Application.Interfaces;
using Exchange.Infrastructure.Persistance;

namespace Exchange.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) => _context = context;

        /// <summary>
        /// EF Core start transaction, if there is an active transaction then TransactionCouldNotStartedException
        /// </summary>
        /// <returns></returns>
        /// <exception cref="TransactionCouldNotStartedException"></exception>
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_context.Database.CurrentTransaction is null)
                await _context.Database.BeginTransactionAsync(cancellationToken);
            else
                throw new TransactionCouldNotStartedException("A transaction is already in progress.");
        }


        /// <summary>
        /// EF Core commit transaction 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ThereIsNotAnyTransactionToCommitException"></exception>
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_context.Database.CurrentTransaction is null)
                throw new ThereIsNotAnyTransactionToCommitException("There is not any active transaction to commit.");

            else
                await _context.Database.CommitTransactionAsync(cancellationToken);

        }

        /// <summary>
        /// Dispose the database object
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// EF Core RollBack transaction
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ThereIsNotAnyTransactionToRollBackException"></exception>
        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_context.Database.CurrentTransaction is null)
                throw new ThereIsNotAnyTransactionToRollBackException("There is not any active transaction to roll back.");

            else
                await _context.Database.RollbackTransactionAsync(cancellationToken);
        }

        /// <summary>
        /// EF Core SaveChanges process
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

}
