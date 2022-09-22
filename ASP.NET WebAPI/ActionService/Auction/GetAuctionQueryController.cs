using ApplicationLayer;
using ApplicationLayer.Auction;
using Microsoft.AspNetCore.Mvc;

namespace ActionService.Auction;

public class GetAuctionQueryController : Controller
{
    // Should be injected
    private readonly IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse> _handler = new GetAuctionQueryHandler();
    private readonly ISyntaxValidator<GetAuctionQuery> _syntaxValidator = new GetAuctionQuerySyntaxValidator();

    [HttpGet("Auctions/{id}")]
    [ActionName("GetAuction")]
    public IActionResult GetAuction(int id)
    {
        var query = new GetAuctionQuery(id);

        var validationResult = _syntaxValidator.Validate(query);
        if (!validationResult.Success)
        {
            return new BadRequestObjectResult(validationResult);
        }

        var response = _handler.Execute(query);
        return new OkObjectResult(response);
    }
}