using ApplicationLayer.Shared;

namespace Graphql.Auction
{
    [ExtendObjectType("Query")]
    public class AuctionQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuctionQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 100)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Auction> Auctions => _unitOfWork.QueryWithNoTracking<DomainLayer.Auction>().Select(x => new Auction
        {
            Id = x.Id,
            Title = x.Title
        });
    }
}
