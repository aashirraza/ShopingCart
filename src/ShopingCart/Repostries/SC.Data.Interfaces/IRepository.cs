
using SC.Data.Model;
using System.Linq.Expressions;

namespace SC.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func <TEntity, bool>> predicate);
        void Save(TEntity entity);
        void Delete(TEntity entity);

    }
}