using ApplicationLayer.Shared;

namespace ApplicationLayer.Auction;

public record GetAuctionQuery(int? Id) : IQuery<GetAuctionQueryResponse>;