namespace ApplicationLayer.Auction;

public record CreateAuctionCommand(int? Id, string? Title) : ICommand<CreateAuctionCommandResponse>;