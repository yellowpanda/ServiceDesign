using ApplicationLayer.Auction;
using ApplicationLayer.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ActionService.Auction;


public class CreateAuctionCommandController : Controller
{
    private readonly ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse> _handler;

    public CreateAuctionCommandController(ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse> handler)
    {
        _handler = handler;
    }

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