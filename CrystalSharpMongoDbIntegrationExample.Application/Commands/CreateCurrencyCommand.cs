using CrystalSharp.Application;
using CrystalSharpMongoDbIntegrationExample.Application.Responses;

namespace CrystalSharpMongoDbIntegrationExample.Application.Commands
{
    public class CreateCurrencyCommand : ICommand<CommandExecutionResult<CurrencyResponse>>
    {
        public string Name { get; set; }
    }
}
