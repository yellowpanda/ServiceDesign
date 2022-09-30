﻿using ApplicationLayer;
using ApplicationLayer.Auction;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ActionService.Auction;


public class CreateAuctionCommandController : Controller
{
    // Should be injected
    private readonly ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse> _handler = new CreateAuctionCommandHandler(new UnitOfWork());
    private readonly ISyntaxValidator<CreateAuctionCommand> _syntaxValidator = new CreateAuctionCommandSyntaxValidator();

    [HttpPost("Auctions/")]
    public IActionResult CreateAuction([FromBody]CreateAuctionCommand command)
    {
        var validationResult = _syntaxValidator.Validate(command);
        if (!validationResult.Success)
        {
            return new BadRequestObjectResult(validationResult);
        };

        var response = _handler.Execute(command);
        return Created("/Actions/"+response.Id, null);
    }
}