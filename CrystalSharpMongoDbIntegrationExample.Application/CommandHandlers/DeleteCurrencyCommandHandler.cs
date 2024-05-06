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
    public class DeleteCurrencyCommandHandler : CommandHandler<DeleteCurrencyCommand, DeleteCurrencyResponse>
    {
        private readonly IMongoDbContext _dbContext;

        public DeleteCurrencyCommandHandler(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CommandExecutionResult<DeleteCurrencyResponse>> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken = default)
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

            existingCurrency.Delete();
            await _dbContext.SaveChanges(existingCurrency, cancellationToken).ConfigureAwait(false);

            DeleteCurrencyResponse response = new() { GlobalUId = existingCurrency.GlobalUId };

            return await Ok(response);
        }
    }
}
