using ApplicationLayer.Shared;

namespace ApplicationLayer.Auction;

public record GetAuctionsQueryResponse(IEnumerable<GetAuctionsQueryResponse.Element> Elements, PaginationInfo ElementsPaginationInfo)
{
    public record Element(int Id, string Title);
};