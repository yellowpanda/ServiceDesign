using ApplicationLayer;
using Microsoft.EntityFrameworkCore;
using DomainLayer;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _dbContext = new MyDbContext();

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
        }
        
        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public class MyDbContext : DbContext
        {
            public MyDbContext()
            {
            }

            public MyDbContext(DbContextOptions options) : base(options)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyContext;Integrated Security=SSPI");
            }

            public DbSet<Auction> Auctions { get; set; } = null!;
        }
    }
}