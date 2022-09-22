namespace ApplicationLayer;

public interface IQueryHandler<in TQuery, out TQueryResponse> where TQuery : IQuery<TQueryResponse>
{
    public TQueryResponse Execute(TQuery request);
}