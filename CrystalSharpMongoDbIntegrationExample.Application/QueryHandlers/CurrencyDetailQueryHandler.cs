using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.Domain;
using CrystalSharp.MongoDb.Database;
using CrystalSharpMongoDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate;
using CrystalSharpMongoDbIntegrationExample.Application.Queries;
using CrystalSharpMongoDbIntegrationExample.Application.ReadModels;

namespace CrystalSharpMongoDbIntegrationExample.Application.QueryHandlers
{
    public class CurrencyDetailQueryHandler : QueryHandler<CurrencyDetailQuery, CurrencyReadModel>
    {
        private readonly IMongoDbContext _dbContext;

        public CurrencyDetailQueryHandler(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<QueryExecutionResult<CurrencyReadModel>> Handle(CurrencyDetailQuery request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid query.");

            Currency currency = _dbContext.Query<Currency>(x => 
                x.GlobalUId == request.GlobalUId 
                && x.EntityStatus == EntityStatus.Active)
                .SingleOrDefault();

            if (currency == null)
            {
                return await Fail("Currency not found.");
            }

            CurrencyReadModel readModel = new() { GlobalUId = currency.GlobalUId, Name = currency.Name };

            return await Ok(readModel);
        }
    }
}
