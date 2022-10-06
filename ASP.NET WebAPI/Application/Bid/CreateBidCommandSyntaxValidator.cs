using ApplicationLayer.Shared;
using DomainLayer;

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

        if (!Price.TryFrom((decimal)request.Price!, out Price _))
        {
            validationResult.Add(new ValidationError($"{nameof(request.Price)} is not valid."));
        }

        return new ValidationResult(validationResult);
    }
}