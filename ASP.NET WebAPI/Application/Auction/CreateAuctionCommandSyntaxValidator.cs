using ApplicationLayer.Shared;

namespace ApplicationLayer.Auction;

// There are libraries for validation. Use one of them.
public class CreateAuctionCommandSyntaxValidator : ISyntaxValidator<CreateAuctionCommand>
{
    public ValidationResult Validate(CreateAuctionCommand request)
    {
        var validationResult = new List<ValidationError>();

        if (request.Title == null)
        {
            validationResult.Add(new ValidationError($"{nameof(request.Title)} is not provided."));
        }

        return new ValidationResult(validationResult);
    }
}