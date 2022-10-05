using ApplicationLayer.Shared;

namespace ApplicationLayer.Bid;

public class CreateBidHandler : ICommandHandler<CreateBidCommand, CreateBidCommandResponse>
{
    private readonly ISyntaxValidator<CreateBidCommand> _syntaxValidator;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBidHandler(ISyntaxValidator<CreateBidCommand> syntaxValidator, IUnitOfWork unitOfWork)
    {
        _syntaxValidator = syntaxValidator;
        _unitOfWork = unitOfWork;
    }

    public HandlerResult<CreateBidCommandResponse> Execute(CreateBidCommand request)
    {
        // Syntax validation
        var validationResult = _syntaxValidator.Validate(request);
        if (!validationResult.Success)
        {
            return new HandlerResult<CreateBidCommandResponse>(validationResult.ValidationErrors);
        }

        // Fetch data
        var auctionExists = _unitOfWork.Query<DomainLayer.Auction>().Any(x => x.Id == request.AuctionId);

        // Domain validation
        if (!auctionExists)
        {
            return new HandlerResult<CreateBidCommandResponse>(new ValidationError($"There are no auctions with Id = {request.AuctionId}."));
        }

        // Domain logic
        var bid = new DomainLayer.Bid()
        {
            BidId = (int)request.AuctionId!,
            BidderName = request.BidderName!,
            Price = (decimal)request.Price!,

        };

        _unitOfWork.Add(bid);
        _unitOfWork.SaveChanges();

        // Response generation
        return new HandlerResult<CreateBidCommandResponse>(new CreateBidCommandResponse(bid.Id));
    }
}