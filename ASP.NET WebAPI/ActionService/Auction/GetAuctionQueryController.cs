using ApplicationLayer;
using ApplicationLayer.Auction;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ActionService.Auction;

public class GetAuctionQueryController : Controller
{
    // Should be injected
    private readonly IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse> _handler = new GetAuctionQueryHandler(new UnitOfWork());

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