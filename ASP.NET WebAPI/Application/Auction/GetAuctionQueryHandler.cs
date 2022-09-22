namespace ApplicationLayer.Auction;

public class GetAuctionQueryHandler : IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse>
{
    public GetAuctionQueryResponse Execute(GetAuctionQuery request)
    {
        var requestId = request.Id ?? throw new ArgumentException("request.Id is null");
        return new GetAuctionQueryResponse(requestId, "test");
    }
}