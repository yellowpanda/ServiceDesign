namespace ApplicationLayer.Auction;

public class GetAuctionQuerySyntaxValidator : ISyntaxValidator<GetAuctionQuery>
{
    public ValidationResult Validate(GetAuctionQuery request)
    {
        var validationResult = new List<ValidationError>();

        if (request.Id == null)
        {
            validationResult.Add(new ValidationError("request.Id is null"));
        }

        return new ValidationResult(validationResult);
    }
}