namespace ApplicationLayer.Auction;

public class GetAuctionsQueryHandler : IQueryHandler<GetAuctionsQuery, GetAuctionsQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISyntaxValidator<GetAuctionsQuery> _syntaxValidator;

    public GetAuctionsQueryHandler(IUnitOfWork unitOfWork, ISyntaxValidator<GetAuctionsQuery> syntaxValidator)
    {
        _unitOfWork = unitOfWork;
        _syntaxValidator = syntaxValidator;
    }

    public HandlerResult<GetAuctionsQueryResponse> Execute(GetAuctionsQuery request)
    {
        // Syntax validation
        var validationResult = _syntaxValidator.Validate(request);
        if (!validationResult.Success)
        {
            return new HandlerResult<GetAuctionsQueryResponse>(validationResult.ValidationErrors);
        }

        // Query
        var elements = _unitOfWork.QueryWithNoTracking<DomainLayer.Auction>()
            .Select(x => new GetAuctionsQueryResponse.Element(x.Id, x.Title))
            .ToList();

        // Response generation
        return new HandlerResult<GetAuctionsQueryResponse>(new GetAuctionsQueryResponse(elements));
    }
}