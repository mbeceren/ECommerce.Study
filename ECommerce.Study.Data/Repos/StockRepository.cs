using ECommerce.Study.Data.Persistence;
using ECommerce.Study.Domain.Models;

namespace ECommerce.Study.Data.Repos
{
	public class StockRepository : Repository<Stock>, IStockRepository
	{
		public StockRepository(ApplicationContext context)
			: base(context)
		{

		}
	}
}
