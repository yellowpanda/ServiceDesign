namespace ApplicationLayer.Auction;

public record CreateAuctionCommand(string? Title) : ICommand<CreateAuctionCommandResponse>;