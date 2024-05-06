using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Domain.Infrastructure;
using CrystalSharpMongoDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate.Events;

namespace CrystalSharpMongoDbIntegrationExample.Application.EventHandlers
{
    public class CurrencyDeletedDomainEventHandler : ISynchronousDomainEventHandler<CurrencyDeletedDomainEvent>
    {
        public async Task Handle(CurrencyDeletedDomainEvent notification, CancellationToken cancellationToken = default)
        {
            //
        }
    }
}
