using OmniPos.Domain.Entities;
using OmniPos.Domain.Repositories;
using OmniPos.Infrastructure.Persistence.Common;

namespace OmniPos.Infrastructure.Persistence.Repositories;

public class OrderRepository(OmniPosDbContext dbContext) : Repository<Order>(dbContext), IOrderRepository
{
}
