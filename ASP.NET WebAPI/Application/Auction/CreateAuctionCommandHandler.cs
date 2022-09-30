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
        // Syntax validation
        var validationResult = _syntaxValidator.Validate(request);
        if (!validationResult.Success)
        {
            return new HandlerResult<CreateAuctionCommandResponse>(validationResult.ValidationErrors);
        }


        // Domain validation
        if (_unitOfWork.Query<DomainLayer.Auction>().Any(x => x.Title == request.Title))
        {
            return new HandlerResult<CreateAuctionCommandResponse>(new ValidationError($"Auction with title = '{request.Title}' already exist."));
        }
        
        // Domain logic
        var auction = new DomainLayer.Auction
        {
            Title = request.Title!
        };

        _unitOfWork.Add(auction);
        _unitOfWork.SaveChanges();

        // Response generation
        return new HandlerResult<CreateAuctionCommandResponse>(new CreateAuctionCommandResponse(auction.Id));
    }
}