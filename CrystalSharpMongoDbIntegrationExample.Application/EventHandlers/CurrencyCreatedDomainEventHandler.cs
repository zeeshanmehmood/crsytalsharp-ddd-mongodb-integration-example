using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Domain.Infrastructure;
using CrystalSharpMongoDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate.Events;

namespace CrystalSharpMongoDbIntegrationExample.Application.EventHandlers
{
    public class CurrencyCreatedDomainEventHandler : ISynchronousDomainEventHandler<CurrencyCreatedDomainEvent>
    {
        public async Task Handle(CurrencyCreatedDomainEvent notification, CancellationToken cancellationToken = default)
        {
            //
        }
    }
}
