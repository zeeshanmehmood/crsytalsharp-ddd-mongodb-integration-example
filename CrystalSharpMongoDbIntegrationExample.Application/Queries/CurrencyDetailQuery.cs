using System;
using CrystalSharp.Application;
using CrystalSharpMongoDbIntegrationExample.Application.ReadModels;

namespace CrystalSharpMongoDbIntegrationExample.Application.Queries
{
    public class CurrencyDetailQuery : IQuery<QueryExecutionResult<CurrencyReadModel>>
    {
        public Guid GlobalUId { get; set; }
    }
}
