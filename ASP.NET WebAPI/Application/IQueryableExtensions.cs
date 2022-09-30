namespace ApplicationLayer;

/// <summary>
/// Inspiration from https://www.codingame.com/playgrounds/5363/paging-with-entity-framework-core
/// </summary>
public static class IQueryableExtensions
{
    /// <summary>
    /// Returns a single page given page (1 indexed) and pageSize.
    /// </summary>
    public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
        int page, int pageSize) where T : class
    {
        var rowCount = query.Count();
        var resultPaginationInfo = new PaginationInfo(page, (int)Math.Ceiling((decimal)rowCount / pageSize), pageSize, rowCount);

        var skip = (page - 1) * pageSize;
        var results = query.Skip(skip).Take(pageSize).ToList();

        return new PagedResult<T>(results, resultPaginationInfo);
    }
}