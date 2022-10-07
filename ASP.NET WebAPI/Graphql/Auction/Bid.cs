using DomainLayer;

namespace Graphql.Auction;

public class Bid
{
    public int Id { get; set; }
    public int BidId { get; set; }
    public string BidderName { get; set; }
    public Price Price { get; set; }
}