using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ECommerce.Study.Data.Repos
{
	public interface IRepository<TEntity>
	{
		TEntity GetById<TId>(TId id);
		IList<TEntity> GetAll();
		TEntity Save(TEntity entity);
		TEntity Update(TEntity entity);
		void Delete(TEntity entity);
		void SaveChanges();
		bool Exists(TEntity entity);
		IList<TEntity> Filter(Expression<Func<TEntity, bool>> filterExpression);
	}
}
