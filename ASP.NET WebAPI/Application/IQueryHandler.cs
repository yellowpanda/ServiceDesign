namespace ApplicationLayer;

public interface IQueryHandler<in TQuery, TQueryResponse> where TQuery : IQuery<TQueryResponse>
{
    public HandlerResult<TQueryResponse> Execute(TQuery request);
}