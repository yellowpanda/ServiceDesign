using ApplicationLayer;
using ApplicationLayer.Auction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace AzureFunction.Auction;

public class GetAuctionsQueryFunction
{
    private readonly IQueryHandler<GetAuctionsQuery, GetAuctionsQueryResponse> _handler;

    public GetAuctionsQueryFunction(IQueryHandler<GetAuctionsQuery, GetAuctionsQueryResponse> handler)
    {
        _handler = handler;
    }

    [FunctionName("GetAuctionsQueryFunction")]
    public IActionResult Execute(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Auctions/")] 
        HttpRequest request)
    {
        var query = new GetAuctionsQuery();

        var response = _handler.Execute(query);

        if (!response.ValidationSuccessful)
        {
            return new BadRequestObjectResult(response.ValidationResult);
        }

        return new OkObjectResult(response.Response.Elements);
    }
}