namespace ApplicationLayer.Auction;

public class GetAuctionQueryHandler : IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISyntaxValidator<GetAuctionQuery> _syntaxValidator = new GetAuctionQuerySyntaxValidator();

    public GetAuctionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public HandlerResult<GetAuctionQueryResponse> Execute(GetAuctionQuery request)
    {
        var validationResult = _syntaxValidator.Validate(request);
        if (!validationResult.Success)
        {
            return new HandlerResult<GetAuctionQueryResponse>(validationResult.ValidationErrors);
        }

        var getAuctionQueryResponse = _unitOfWork.Query<DomainLayer.Auction>()
            .Where(x => x.Id == request.Id)
            .Select(x => new GetAuctionQueryResponse(x.Id, x.Title))
            .SingleOrDefault();

        if (getAuctionQueryResponse == null)
        {
            return new HandlerResult<GetAuctionQueryResponse>(new ValidationError($"No action found with id = {request.Id}."));
        }

        return new HandlerResult<GetAuctionQueryResponse>(getAuctionQueryResponse);
    }
}