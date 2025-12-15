using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using OmniPos.Domain.Common.Repositories;
using System.Data;
using System.Reflection;

namespace OmniPos.Infrastructure.Persistence.Common
{
    public class OmniPosDbContext(ILogger<OmniPosDbContext> logger, DbContextOptions options) : DbContext(options), IUnitOfWork
    {
        private readonly ILogger<OmniPosDbContext> _logger = logger;

        private IDbContextTransaction? _dbContextTransaction;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
        {
            _dbContextTransaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);
            return _dbContextTransaction;
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_dbContextTransaction == null)
            {
                _logger.LogWarning("No active transaction to commit.");
                return;
            }
            await _dbContextTransaction.CommitAsync(cancellationToken);
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
