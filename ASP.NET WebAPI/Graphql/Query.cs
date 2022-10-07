using ApplicationLayer.Shared;
using Graphql.Auction;

namespace Graphql
{
    public class Query
    {
        private readonly IUnitOfWork _unitOfWork;

        public Query(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 100)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Auction.Auction> Auctions => _unitOfWork.QueryWithNoTracking<DomainLayer.Auction>().Select(x => new Auction.Auction
        {
            Id = x.Id,
            Title = x.Title
        });

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 100)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Bid> Bids => _unitOfWork.QueryWithNoTracking<DomainLayer.Bid>().Select(x => new Bid()
        {
            Id = x.Id,
            Price = x.Price,
            BidderName = x.BidderName,
            BidId = x.BidId
        });
    }
}
