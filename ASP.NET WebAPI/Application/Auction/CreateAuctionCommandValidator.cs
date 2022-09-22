namespace ApplicationLayer.Auction;

// There are libraries for validation. Use one of them.
public class CreateAuctionCommandValidator : IValidator<CreateAuctionCommand>
{
    public ValidationResult Validate(CreateAuctionCommand request)
    {
        var validationResult = new ValidationResult();

        if (request.Id == null)
        {
            validationResult.Errors.Add("Id is null");
        }

        return validationResult;
    }
}