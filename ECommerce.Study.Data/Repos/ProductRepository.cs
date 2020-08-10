using ECommerce.Study.Data.Persistence;
using ECommerce.Study.Domain.Models;
using System.Linq;

namespace ECommerce.Study.Data.Repos
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(ApplicationContext applicationContext) 
			: base(applicationContext)
		{

		}

		public Product GetProductByStockCode(string stockCode)
		{
			return DbSet.FirstOrDefault(f => f.StockCode.Equals(stockCode));
		}
	}
}
