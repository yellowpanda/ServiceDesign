namespace DomainLayer;

public class Bid
{
    public int Id { get; set; }

    public string BidderName { get; set; } = string.Empty;

    public int BidId { get; set; }

    public Price Price { get; set; } = Price.From(0);
}