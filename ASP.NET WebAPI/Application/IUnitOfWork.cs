namespace ApplicationLayer
{
    public interface IUnitOfWork
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
        
        IQueryable<TEntity> QueryWithNoTracking<TEntity>() where TEntity : class;

        void Add<TEntity>(TEntity entity) where TEntity : class;
        
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        
        int SaveChanges();
    }
}
