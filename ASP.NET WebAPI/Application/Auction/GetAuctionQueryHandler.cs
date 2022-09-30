using ApplicationLayer.Shared;

namespace ApplicationLayer.Auction;

public class GetAuctionQueryHandler : IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISyntaxValidator<GetAuctionQuery> _syntaxValidator;

    public GetAuctionQueryHandler(IUnitOfWork unitOfWork, ISyntaxValidator<GetAuctionQuery> syntaxValidator)
    {
        _unitOfWork = unitOfWork;
        _syntaxValidator = syntaxValidator;
    }

    public HandlerResult<GetAuctionQueryResponse> Execute(GetAuctionQuery request)
    {
        // Syntax validation
        var validationResult = _syntaxValidator.Validate(request);
        if (!validationResult.Success)
        {
            return new HandlerResult<GetAuctionQueryResponse>(validationResult.ValidationErrors);
        }

        // Query
        var getAuctionQueryResponse = _unitOfWork.QueryWithNoTracking<DomainLayer.Auction>()
            .Where(x => x.Id == request.Id)
            .Select(x => new GetAuctionQueryResponse(x.Id, x.Title))
            .SingleOrDefault();

        // Response generation
        if (getAuctionQueryResponse == null)
        {
            return new HandlerResult<GetAuctionQueryResponse>(new ValidationError($"No action found with id = {request.Id}."));
        }

        return new HandlerResult<GetAuctionQueryResponse>(getAuctionQueryResponse);
    }
}