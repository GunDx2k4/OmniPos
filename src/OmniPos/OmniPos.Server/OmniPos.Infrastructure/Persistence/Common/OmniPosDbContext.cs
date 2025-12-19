using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using OmniPos.Application.Common;
using OmniPos.Domain.Common.Entities;
using OmniPos.Domain.Common.Repositories;
using System.Data;
using System.Reflection;

namespace OmniPos.Infrastructure.Persistence.Common
{
    public class OmniPosDbContext(ILogger<OmniPosDbContext> logger, DbContextOptions options, Dispatcher dispatcher) : DbContext(options), IUnitOfWork
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
            var entitiesWithEvents = ChangeTracker.Entries<Entity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

            var domainEvents = entitiesWithEvents
            .SelectMany(e => e.DomainEvents)
            .ToList();

            entitiesWithEvents.ForEach(e => e.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await dispatcher.DispatchAsync(domainEvent, cancellationToken);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
