namespace ApplicationLayer.Auction;

public class GetAuctionQueryValidator : IValidator<GetAuctionQuery>
{
    public ValidationResult Validate(GetAuctionQuery request)
    {
        var validationResult = new ValidationResult();

        if (request.Id == null)
        {
            validationResult.Errors.Add("request.Id is null");
        }

        return validationResult;
    }
}