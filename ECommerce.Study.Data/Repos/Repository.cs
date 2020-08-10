using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerce.Study.Data.Repos
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly ApplicationContext ApplicationContext;
		protected readonly DbSet<TEntity> DbSet;

		protected Repository(ApplicationContext applicationContext)
		{
			ApplicationContext = applicationContext;
			DbSet = ApplicationContext.Set<TEntity>();
		}

		public void Delete(TEntity entity)
		{
			var entry = ApplicationContext.Entry(entity);
			if (entry.State == EntityState.Deleted)
				entry.State = EntityState.Deleted;
			else
			{
				DbSet.Attach(entity);
				DbSet.Remove(entity);
			}
		}

		public TEntity GetById<TId>(TId id)
		{
			return ApplicationContext.Set<TEntity>().Find(id);
		}

		public IList<TEntity> GetAll()
		{
			return ApplicationContext.Set<TEntity>().ToList();
		}

		public TEntity Save(TEntity entity)
		{
			return ApplicationContext.Set<TEntity>().Add(entity);
		}

		public TEntity Update(TEntity entity)
		{
			if (ApplicationContext.Entry(entity).State == EntityState.Detached)
				DbSet.Attach(entity);
			ApplicationContext.Entry(entity).State = EntityState.Modified;
			return entity;
		}

		public bool Exists(TEntity entity)
		{
			return ApplicationContext.Entry(entity).Entity != null;
		}

		public void SaveChanges()
		{
			ApplicationContext.SaveChanges();
		}

		public IList<TEntity> Filter(Expression<Func<TEntity, bool>> filterExpression)
		{
			return DbSet.Where(filterExpression)?.ToList() ?? new List<TEntity>();
		}
	}
}
