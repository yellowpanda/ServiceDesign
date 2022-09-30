using ApplicationLayer.Shared;

namespace ApplicationLayer.Auction;

public class GetAuctionsQuerySyntaxValidator : ISyntaxValidator<GetAuctionsQuery>
{
    public ValidationResult Validate(GetAuctionsQuery request)
    {
        return new ValidationResult();
    }
}