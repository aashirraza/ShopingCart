using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SC.Data.Interfaces;
using SC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SC.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly StoreManagementDbContext _context;
        protected readonly DbSet<TEntity> _dbset;

        public Repository(StoreManagementDbContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public IList<TEntity> GetAll()
        {
            return _dbset.ToList();
        }
        
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                return;
            var dbEntity = _context.Entry(entity);
            if (dbEntity.State != EntityState.Deleted)
            {
                dbEntity.State = EntityState.Deleted;
            }
            else
            {
                _dbset.Attach(entity);
                _dbset.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Save(TEntity entity)
        {
            if (entity.Id > 0)
            {
                _dbset.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                _dbset.Add(entity);
                _context.SaveChanges();
            }
        }
    }
}
