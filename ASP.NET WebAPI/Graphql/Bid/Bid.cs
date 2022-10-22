using DomainLayer;

namespace Graphql.Bid;

public class Bid
{
    public int Id { get; set; }
    public int BidId { get; set; }
    public string BidderName { get; set; }
    public Price Price { get; set; }
}