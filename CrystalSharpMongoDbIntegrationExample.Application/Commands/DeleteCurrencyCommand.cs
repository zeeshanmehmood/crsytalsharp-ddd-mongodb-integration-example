using System;
using CrystalSharp.Application;
using CrystalSharpMongoDbIntegrationExample.Application.Responses;

namespace CrystalSharpMongoDbIntegrationExample.Application.Commands
{
    public class DeleteCurrencyCommand : ICommand<CommandExecutionResult<DeleteCurrencyResponse>>
    {
        public Guid GlobalUId { get; set; }
    }
}
