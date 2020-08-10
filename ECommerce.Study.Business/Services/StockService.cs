using ECommerce.Study.Business.Interfaces;
using ECommerce.Study.Data.Persistence;
using ECommerce.Study.Data.Repos;
using ECommerce.Study.Domain.Models;

namespace ECommerce.Study.Business.Services
{
	internal class StockService : IStockService
	{
		private readonly IStockRepository _stockRepository;
		internal StockService(IRepositoryFactory repositoryFactory)
		{
			_stockRepository = repositoryFactory.GetStockRepository();
		}

		public Stock Save(Stock stock)
		{
			return _stockRepository.Save(stock);
		}
	}
}
