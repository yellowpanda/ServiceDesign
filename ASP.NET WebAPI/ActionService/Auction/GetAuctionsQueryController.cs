using ApplicationLayer.Auction;
using Microsoft.AspNetCore.Mvc;
using ApplicationLayer.Shared;

namespace ActionService.Auction;

public class GetAuctionsQueryController
{
    private readonly IQueryHandler<GetAuctionsQuery, GetAuctionsQueryResponse> _handler;

    public GetAuctionsQueryController(IQueryHandler<GetAuctionsQuery, GetAuctionsQueryResponse> handler)
    {
        _handler = handler;
    }

    [HttpGet("Auctions/")]
    [ActionName("GetAuctions")]
    public IActionResult GetAuctions()
    {
        // TODO: Replace page and page size with url parameters
        var query = new GetAuctionsQuery(0, int.MaxValue);

        var response = _handler.Execute(query);

        if (!response.ValidationSuccessful)
        {
            return new BadRequestObjectResult(response.ValidationResult);
        }

        return new OkObjectResult(response.Response);
    }
}