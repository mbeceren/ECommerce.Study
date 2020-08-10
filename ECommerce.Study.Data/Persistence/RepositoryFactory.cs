using ECommerce.Study.Data.Repos;
using System;

namespace ECommerce.Study.Data.Persistence
{
	public class RepositoryFactory : IRepositoryFactory
	{
		private readonly ApplicationContext _applicationContext;
		private bool _disposed = false;
		
		public RepositoryFactory(string connectionString)
		{
			_applicationContext = new ApplicationContext(connectionString);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				_applicationContext?.Dispose();
			}

			_disposed = true;
		}

		~RepositoryFactory() => Dispose(false);

		public IProductRepository GetProductRepository()
		{
			return new ProductRepository(_applicationContext);
		}

		public IStockRepository GetStockRepository()
		{
			return new StockRepository(_applicationContext);
		}

		public IUserRepository GetAdminRepository()
		{
			return new UserRepository(_applicationContext);
		}

	}
}
