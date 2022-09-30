using ApplicationLayer;
using ApplicationLayer.Auction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace AzureFunction.Auction;

public class GetAuctionQueryFunction
{
    private readonly IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse> _handler;

    public GetAuctionQueryFunction(IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse> handler)
    {
        _handler = handler;
    }

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