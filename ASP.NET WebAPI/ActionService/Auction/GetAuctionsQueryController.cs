using ApplicationLayer.Auction;
using ApplicationLayer;
using Microsoft.AspNetCore.Mvc;

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
        var query = new GetAuctionsQuery();

        var response = _handler.Execute(query);

        if (!response.ValidationSuccessful)
        {
            return new BadRequestObjectResult(response.ValidationResult);
        }

        return new OkObjectResult(response.Response);
    }
}