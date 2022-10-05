using ApplicationLayer.Bid;
using ApplicationLayer.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ActionService.Bid;

public class CreateBidCommandController : Controller
{
    private readonly ICommandHandler<CreateBidCommand, CreateBidCommandResponse> _handler;

    public CreateBidCommandController(ICommandHandler<CreateBidCommand, CreateBidCommandResponse> handler)
    {
        _handler = handler;
    }

    [HttpPost("Bids/")]
    public IActionResult CreateAuction([FromBody] CreateBidCommand command)
    {
        var response = _handler.Execute(command);

        if (!response.ValidationSuccessful)
        {
            return new BadRequestObjectResult(response.ValidationResult);
        }

        return Created("/Bids/" + response.Response.Id, null);
    }
}