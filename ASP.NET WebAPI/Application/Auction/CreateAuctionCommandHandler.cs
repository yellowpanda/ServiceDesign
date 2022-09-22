namespace ApplicationLayer.Auction;

public class CreateAuctionCommandHandler : ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse>
{
    public CreateAuctionCommandResponse Execute(CreateAuctionCommand request)
    {
        var requestId = request.Id ?? throw new ArgumentException("request.Id is null");
        return new CreateAuctionCommandResponse(requestId);
    }
}