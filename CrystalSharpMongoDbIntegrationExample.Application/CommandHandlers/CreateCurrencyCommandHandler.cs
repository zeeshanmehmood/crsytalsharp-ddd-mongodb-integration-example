using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.MongoDb.Database;
using CrystalSharpMongoDbIntegrationExample.Application.Commands;
using CrystalSharpMongoDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate;
using CrystalSharpMongoDbIntegrationExample.Application.Responses;

namespace CrystalSharpMongoDbIntegrationExample.Application.CommandHandlers
{
    public class CreateCurrencyCommandHandler : CommandHandler<CreateCurrencyCommand, CurrencyResponse>
    {
        private readonly IMongoDbContext _dbContext;

        public CreateCurrencyCommandHandler(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CommandExecutionResult<CurrencyResponse>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Currency currency = Currency.Create(request.Name);

            await _dbContext.SaveChanges(currency, cancellationToken).ConfigureAwait(false);

            CurrencyResponse response = new() { GlobalUId = currency.GlobalUId, Name = currency.Name };

            return await Ok(response);
        }
    }
}
