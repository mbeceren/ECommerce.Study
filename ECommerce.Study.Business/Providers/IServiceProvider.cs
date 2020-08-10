using ECommerce.Study.Business.Interfaces;

namespace ECommerce.Study.Business.Providers
{
	public interface IServiceProvider
	{
		IProductService ProductService();
		IStockService StockService();
		IUserService UserService();

	}
}
