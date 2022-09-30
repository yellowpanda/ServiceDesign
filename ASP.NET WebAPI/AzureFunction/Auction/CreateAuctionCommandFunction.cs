using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;
using ApplicationLayer.Auction;
using ApplicationLayer.Shared;
using AzureFunction.Shared;

namespace AzureFunction.Auction;

public class CreateAuctionCommandFunction
{
    private readonly ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse> _handler;
    private readonly IJsonDeserializer _jsonDeserializer;

    public CreateAuctionCommandFunction(ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse> handler, IJsonDeserializer jsonDeserializer)
    {
        _handler = handler;
        _jsonDeserializer = jsonDeserializer;
    }

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