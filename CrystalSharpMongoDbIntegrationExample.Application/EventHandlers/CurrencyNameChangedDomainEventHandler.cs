using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Domain.Infrastructure;
using CrystalSharpMongoDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate.Events;

namespace CrystalSharpMongoDbIntegrationExample.Application.EventHandlers
{
    public class CurrencyNameChangedDomainEventHandler : ISynchronousDomainEventHandler<CurrencyNameChangedDomainEvent>
    {
        public async Task Handle(CurrencyNameChangedDomainEvent notification, CancellationToken cancellationToken = default)
        {
            //
        }
    }
}
