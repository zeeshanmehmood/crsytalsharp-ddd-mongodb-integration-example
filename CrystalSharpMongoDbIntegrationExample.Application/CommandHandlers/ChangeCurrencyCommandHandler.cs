using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.Domain;
using CrystalSharp.MongoDb.Database;
using CrystalSharpMongoDbIntegrationExample.Application.Commands;
using CrystalSharpMongoDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate;
using CrystalSharpMongoDbIntegrationExample.Application.Responses;

namespace CrystalSharpMongoDbIntegrationExample.Application.CommandHandlers
{
    public class ChangeCurrencyCommandHandler : CommandHandler<ChangeCurrencyCommand, CurrencyResponse>
    {
        private readonly IMongoDbContext _dbContext;

        public ChangeCurrencyCommandHandler(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CommandExecutionResult<CurrencyResponse>> Handle(ChangeCurrencyCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Currency existingCurrency = _dbContext.Query<Currency>(x => 
                x.GlobalUId == request.GlobalUId 
                && x.EntityStatus == EntityStatus.Active)
                .SingleOrDefault();

            if (existingCurrency == null)
            {
                return await Fail("Currency not found.");
            }

            existingCurrency.ChangeName(request.Name);

            await _dbContext.SaveChanges(existingCurrency, cancellationToken).ConfigureAwait(false);

            CurrencyResponse response = new() { GlobalUId = existingCurrency.GlobalUId, Name = existingCurrency.Name };

            return await Ok(response);
        }
    }
}
