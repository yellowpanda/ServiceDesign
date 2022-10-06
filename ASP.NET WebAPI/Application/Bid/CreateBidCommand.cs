using ApplicationLayer.Shared;

namespace ApplicationLayer.Bid
{
    public record CreateBidCommand(int? AuctionId, decimal? Price, string? BidderName) : ICommand<CreateBidCommandResponse>
    {
    }
}
