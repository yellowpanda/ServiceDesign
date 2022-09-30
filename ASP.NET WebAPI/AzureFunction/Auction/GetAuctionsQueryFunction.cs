using System.Linq;
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
        int.TryParse(request.Query["page"].LastOrDefault(), out var page);
        int.TryParse(request.Query["pageSize"].LastOrDefault(), out var pageSize);

        var query = new GetAuctionsQuery(page > 0 ? page : 1, pageSize>0? pageSize:10);

        var response = _handler.Execute(query);

        if (!response.ValidationSuccessful)
        {
            return new BadRequestObjectResult(response.ValidationResult);
        }

        request.HttpContext.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(response.Response.ElementsPaginationInfo));

        return new OkObjectResult(response.Response.Elements);
    }
}