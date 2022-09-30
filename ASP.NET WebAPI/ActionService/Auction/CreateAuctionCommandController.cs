using ApplicationLayer;
using ApplicationLayer.Auction;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ActionService.Auction;


public class CreateAuctionCommandController : Controller
{
    // Should be injected
    private readonly ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse> _handler = new CreateAuctionCommandHandler(new UnitOfWork());
    
    [HttpPost("Auctions/")]
    public IActionResult CreateAuction([FromBody]CreateAuctionCommand command)
    {
        var response = _handler.Execute(command);

        if (!response.ValidationSuccessful)
        {
            return new BadRequestObjectResult(response.ValidationResult);
        }

        return Created("/Actions/"+response.Response.Id, null);
    }
}