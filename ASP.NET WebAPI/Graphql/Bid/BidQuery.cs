using ApplicationLayer.Shared;

namespace Graphql.Bid
{
    [ExtendObjectType("Query")]
    public class BidQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public BidQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
