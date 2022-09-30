using DomainLayer;

namespace ApplicationLayer.Auction;

public class CreateAuctionCommandHandler : ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuctionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public CreateAuctionCommandResponse Execute(CreateAuctionCommand request)
    {
        var title = request.Title ?? throw new ArgumentException("request.Title is null");

        var auction = new DomainLayer.Auction();
        auction.Title = title;

        _unitOfWork.Add(auction);

        return new CreateAuctionCommandResponse(auction.Id);
    }
}