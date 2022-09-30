namespace ApplicationLayer.Auction;

public record GetAuctionsQueryResponse(IEnumerable<GetAuctionsQueryResponse.Element> Elements)
{
    public record Element(int Id, string Title);
};