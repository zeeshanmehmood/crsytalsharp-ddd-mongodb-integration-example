using System;
using CrystalSharp.Application;
using CrystalSharpMongoDbIntegrationExample.Application.Responses;

namespace CrystalSharpMongoDbIntegrationExample.Application.Commands
{
    public class ChangeCurrencyCommand : ICommand<CommandExecutionResult<CurrencyResponse>>
    {
        public Guid GlobalUId { get; set; }
        public string Name { get; set; }
    }
}
