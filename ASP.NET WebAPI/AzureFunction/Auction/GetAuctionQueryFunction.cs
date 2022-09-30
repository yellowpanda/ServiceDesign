using ApplicationLayer;
using ApplicationLayer.Auction;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace AzureFunction.Auction;

public class GetAuctionQueryFunction
{
    // Should be injected
    private readonly IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse> _handler = new GetAuctionQueryHandler(new UnitOfWork());

    [FunctionName("GetAuctionQueryFunction")]
    public IActionResult Execute(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Auctions/{id:int}")] 
        HttpRequest request, int id)
    {
        var query = new GetAuctionQuery(id);

        var response = _handler.Execute(query);

        if (!response.ValidationSuccessful)
        {
            return new BadRequestObjectResult(response.ValidationResult);
        }

        return new OkObjectResult(response.Response);
    }
}