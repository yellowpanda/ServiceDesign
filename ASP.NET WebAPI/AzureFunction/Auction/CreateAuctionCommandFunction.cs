using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;
using ApplicationLayer.Auction;
using ApplicationLayer;
using Infrastructure;

namespace AzureFunction.Auction;

public class CreateAuctionCommandFunction
{
    // Should be injected
    private readonly ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse> _handler = new CreateAuctionCommandHandler(new UnitOfWork());
    private readonly IJsonDeserializer _jsonDeserializer = new JsonDeserializer();
    private readonly ISyntaxValidator<CreateAuctionCommand> _syntaxValidator = new CreateAuctionCommandSyntaxValidator();
    
    [FunctionName("CreateAuctionQueryFunction")]
    public async Task<IActionResult> Execute(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Auctions")] 
        HttpRequest request)
    {

        var command = await _jsonDeserializer.DeserializerAsync<CreateAuctionCommand>(request);

        var response = _handler.Execute(command);

        if (!response.ValidationSuccessful)
        {
            return new BadRequestObjectResult(response.ValidationResult);
        }

        return new CreatedResult("/Actions/" + response.Response.Id, null);
    }
}