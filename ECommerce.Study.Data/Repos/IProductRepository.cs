using ECommerce.Study.Domain.Models;

namespace ECommerce.Study.Data.Repos
{
	public interface IProductRepository : IRepository<Product>
	{
		Product GetProductByStockCode(string stockCode);
	}
}
