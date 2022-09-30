namespace ApplicationLayer;

/// <summary>
/// Inspiration from https://www.codingame.com/playgrounds/5363/paging-with-entity-framework-core
/// </summary>
public record PagedResult<T>(IList<T> Results, PaginationInfo PaginationInfo) where T : class
{
}

public record PaginationInfo(int CurrentPage, int PageCount, int PageSize, int TotalCount)
{

}