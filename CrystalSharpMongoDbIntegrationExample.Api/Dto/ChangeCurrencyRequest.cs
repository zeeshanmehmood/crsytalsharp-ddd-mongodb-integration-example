using System;

namespace CrystalSharpMongoDbIntegrationExample.Api.Dto
{
    public class ChangeCurrencyRequest
    {
        public Guid GlobalUId { get; set; }
        public string Name { get; set; }
    }
}
