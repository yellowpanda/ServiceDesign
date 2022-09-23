using ApplicationLayer;
using ApplicationLayer.Auction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace AzureFunction.Auction;

public class GetAuctionQueryFunction
{
    // Should be injected
    private readonly IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse> _handler = new GetAuctionQueryHandler();
    private readonly ISyntaxValidator<GetAuctionQuery> _syntaxValidator = new GetAuctionQuerySyntaxValidator();

    [FunctionName("GetAuctionQueryFunction")]
    public IActionResult Execute(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Auctions/{id}")] 
        HttpRequest request)
    {
        int.TryParse(request.Query["id"], out var id);
        
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