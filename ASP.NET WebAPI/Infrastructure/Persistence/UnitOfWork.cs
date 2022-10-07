﻿using Microsoft.EntityFrameworkCore;
using DomainLayer;
using ApplicationLayer.Shared;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _dbContext = new MyDbContext();

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> QueryWithNoTracking<TEntity>() where TEntity : class
        {
            return Query<TEntity>().AsNoTracking();
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
            public static readonly LoggerFactory _myLoggerFactory = new(new[] { new DebugLoggerProvider() });

            public MyDbContext()
            {
            }

            public MyDbContext(DbContextOptions options) : base(options)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyContext;Integrated Security=SSPI");
                optionsBuilder.UseLoggerFactory(_myLoggerFactory);
            }

            public DbSet<Auction> Auctions { get; set; } = null!;
            public DbSet<Bid> Bids { get; set; } = null!;


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Bid>().OwnsOne(x => x.Price);

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}