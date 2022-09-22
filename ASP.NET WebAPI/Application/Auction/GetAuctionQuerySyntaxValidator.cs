namespace ApplicationLayer.Auction;

public class GetAuctionQuerySyntaxValidator : ISyntaxValidator<GetAuctionQuery>
{
    public SyntaxValidationResult Validate(GetAuctionQuery request)
    {
        var validationResult = new SyntaxValidationResult();

        if (request.Id == null)
        {
            validationResult.Errors.Add("request.Id is null");
        }

        return validationResult;
    }
}