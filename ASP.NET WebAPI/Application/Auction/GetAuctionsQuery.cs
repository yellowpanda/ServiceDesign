using ApplicationLayer.Shared;

namespace ApplicationLayer.Auction;

public record GetAuctionsQuery(int Page, int PageSize) : IQuery<GetAuctionsQueryResponse>;