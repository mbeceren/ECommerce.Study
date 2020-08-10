using ECommerce.Study.Data.Repos;
using System;

namespace ECommerce.Study.Data.Persistence
{
	public interface IRepositoryFactory : IDisposable
	{
		IProductRepository GetProductRepository();
		IStockRepository GetStockRepository();
		IUserRepository GetAdminRepository();
	}
}
