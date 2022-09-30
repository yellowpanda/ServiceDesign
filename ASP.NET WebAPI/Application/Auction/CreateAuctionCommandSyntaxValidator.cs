namespace ApplicationLayer.Auction;

// There are libraries for validation. Use one of them.
public class CreateAuctionCommandSyntaxValidator : ISyntaxValidator<CreateAuctionCommand>
{
    public ValidationResult Validate(CreateAuctionCommand request)
    {
        var validationResult = new List<ValidationError>();

        if (request.Title == null)
        {
            validationResult.Add(new ValidationError("Title is null"));
        }

        return new ValidationResult(validationResult);
    }
}