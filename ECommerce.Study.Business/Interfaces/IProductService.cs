using ECommerce.Study.Domain.Models;
using System.Collections.Generic;

namespace ECommerce.Study.Business.Interfaces
{
	public interface IProductService
	{
		Product GetProductById(int id);
		Product Save(Product product);
		Product Update(Product product);
		Product GetProductByStockCode(string stockCode);
		IList<Product> GetAll();
		void Delete(Product product);
	}
}
