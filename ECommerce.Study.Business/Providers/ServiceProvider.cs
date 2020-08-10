using ECommerce.Study.Business.Interfaces;
using ECommerce.Study.Business.Services;
using ECommerce.Study.Data.Persistence;

namespace ECommerce.Study.Business.Providers
{
	public sealed class ServiceProvider : IServiceProvider
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public ServiceProvider(string connectionString)
		{
			_repositoryFactory = new RepositoryFactory(connectionString);
		}

		public IProductService ProductService()
		{
			return new ProductService(_repositoryFactory);
		}

		public IStockService StockService()
		{
			return new StockService(_repositoryFactory);
		}

		public IUserService UserService()
		{
			return new UserService(_repositoryFactory);
		}
	}
}
