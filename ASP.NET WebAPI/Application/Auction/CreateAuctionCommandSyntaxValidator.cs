namespace ApplicationLayer.Auction;

// There are libraries for validation. Use one of them.
public class CreateAuctionCommandSyntaxValidator : ISyntaxValidator<CreateAuctionCommand>
{
    public SyntaxValidationResult Validate(CreateAuctionCommand request)
    {
        var validationResult = new SyntaxValidationResult();

        if (request.Title == null)
        {
            validationResult.Errors.Add("Title is null");
        }

        return validationResult;
    }
}