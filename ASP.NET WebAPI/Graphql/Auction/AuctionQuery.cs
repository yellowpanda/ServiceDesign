using ApplicationLayer.Shared;
using Infrastructure;

namespace Graphql.Auction
{
    public class AuctionQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuctionQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [UseOffsetPaging(IncludeTotalCount = true)]
        public IQueryable<Auction> Auctions => _unitOfWork.Query<DomainLayer.Auction>().Select(x => new Auction(x.Id, x.Title));
    }
}
