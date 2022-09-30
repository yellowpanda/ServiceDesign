using System.Diagnostics;
using DomainLayer;

namespace ApplicationLayer.Auction;

public class GetAuctionQueryHandler : IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuctionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public GetAuctionQueryResponse Execute(GetAuctionQuery request)
    {
        GetAuctionQueryResponse? getAuctionQueryResponse;
        try
        {
            var requestId = request.Id ?? throw new ArgumentException("request.Id is null");

            getAuctionQueryResponse = _unitOfWork.Query<DomainLayer.Auction>()
                .Where(x => x.Id == requestId)
                .Select(x => new GetAuctionQueryResponse(x.Id, x.Title))
                .SingleOrDefault();

            if (getAuctionQueryResponse == null)
            {
                getAuctionQueryResponse = new GetAuctionQueryResponse(0, "No auction");
            }


        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }

        return getAuctionQueryResponse;
    }
}