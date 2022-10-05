using ApplicationLayer.Shared;

namespace ApplicationLayer.Bid;

public class CreateBidCommandSyntaxValidator : ISyntaxValidator<CreateBidCommand>
{
    public ValidationResult Validate(CreateBidCommand request)
    {
        var validationResult = new List<ValidationError>();

        if (request.BidderName == null)
        {
            validationResult.Add(new ValidationError($"{nameof(request.BidderName)} is not provided."));
        }

        if (request.AuctionId == null)
        {
            validationResult.Add(new ValidationError($"{nameof(request.AuctionId)} is not provided."));
        }

        if (request.Price == null)
        {
            validationResult.Add(new ValidationError($"{nameof(request.Price)} is not provided."));
        }

        return new ValidationResult(validationResult);
    }
}