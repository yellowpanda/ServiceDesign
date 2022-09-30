namespace ApplicationLayer.Auction;

public class CreateAuctionCommandHandler : ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISyntaxValidator<CreateAuctionCommand> _syntaxValidator = new CreateAuctionCommandSyntaxValidator();

    public CreateAuctionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public HandlerResult<CreateAuctionCommandResponse> Execute(CreateAuctionCommand request)
    {
        var validationResult = _syntaxValidator.Validate(request);
        if (!validationResult.Success)
        {
            return new HandlerResult<CreateAuctionCommandResponse>(validationResult.ValidationErrors);
        }

        var auction = new DomainLayer.Auction
        {
            Title = request.Title!
        };

        _unitOfWork.Add(auction);
        _unitOfWork.SaveChanges();

        return new HandlerResult<CreateAuctionCommandResponse>(new CreateAuctionCommandResponse(auction.Id));
    }
}