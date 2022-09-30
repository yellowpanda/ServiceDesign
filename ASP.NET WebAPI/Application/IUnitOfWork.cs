using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public interface IUnitOfWork
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}
