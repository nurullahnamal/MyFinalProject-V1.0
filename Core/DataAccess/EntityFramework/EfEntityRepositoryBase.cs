using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity, new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext Context = new TContext())
            {
                var AddedEntity = Context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                Context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext Context = new TContext())
            {
                var DeletedEntity = Context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext Context = new TContext())
            {
                return Context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext Context = new TContext())
            {
                return filter == null
                    ? Context.Set<TEntity>().ToList()
                    : Context.Set<TEntity>().Where(filter).ToList();
            }

        }

        public List<TEntity> GetAllByCategory(int categoryid)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext Context = new TContext())
            {
                var UpdatedEntity = Context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                Context.SaveChanges();
            }
        }
    }
    
}
