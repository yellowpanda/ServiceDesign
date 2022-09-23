using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;
using ApplicationLayer.Auction;
using ApplicationLayer;

namespace AzureFunction.Auction;

public class CreateAuctionCommandFunction
{
    // Should be injected
    private readonly ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse> _handler = new CreateAuctionCommandHandler();
    private readonly ISyntaxValidator<CreateAuctionCommand> _syntaxValidator = new CreateAuctionCommandSyntaxValidator();
    private readonly IJsonDeserializer _jsonDeserializer = new JsonDeserializer();


    [FunctionName("CreateAuctionQueryFunction")]
    public async Task<IActionResult> Execute(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Auctions")] 
        HttpRequest request)
    {

        var command = await _jsonDeserializer.DeserializerAsync<CreateAuctionCommand>(request);

        var validationResult = _syntaxValidator.Validate(command);
        if (!validationResult.Success)
        {
            return new BadRequestObjectResult(validationResult);
        };

        var response = _handler.Execute(command);

        return new CreatedResult("/Actions/" + response.Id, null);
    }
}