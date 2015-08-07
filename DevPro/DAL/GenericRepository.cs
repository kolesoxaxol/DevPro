using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;



namespace DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IGenericModel
    {
        internal NewsAggregatorContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(NewsAggregatorContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public GenericRepository()
        {

        }
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            var list = DbSet.ToList();
            var query = list.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (entityToUpdate == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }
            var entry = Context.Entry(entityToUpdate);

            if (entry.State != EntityState.Detached) return;
            var set = Context.Set<TEntity>();
            var attachedEntity = set.Local.SingleOrDefault(e => e.Id == entityToUpdate.Id); 

            if (attachedEntity != null)
            {
                var attachedEntry = Context.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entityToUpdate);
            }
            else
            {
                entry.State = EntityState.Modified;
            }
        }
    }
}
