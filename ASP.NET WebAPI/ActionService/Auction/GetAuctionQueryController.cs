using ApplicationLayer;
using ApplicationLayer.Auction;
using Microsoft.AspNetCore.Mvc;

namespace ActionService.Auction;

public class GetAuctionQueryController : Controller
{
    private readonly IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse> _handler;

    public GetAuctionQueryController(IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse> handler)
    {
        _handler = handler;
    }

    [HttpGet("Auctions/{id}")]
    [ActionName("GetAuction")]
    public IActionResult GetAuction(int id)
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