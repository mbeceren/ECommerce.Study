using System.Collections.Generic;

namespace ECommerce.Study.Domain.Models
{
	public class Stock
	{
		public int Id { get; set; }
		public int StockCount { get; set; }

		public virtual IList<Product> Products { get; set; }
	}
}
