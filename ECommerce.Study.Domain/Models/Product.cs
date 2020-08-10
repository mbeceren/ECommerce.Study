namespace ECommerce.Study.Domain.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string StockCode { get; set; }
		public decimal Price { get; set; }
		public int StockId { get; set; }

		public virtual Stock Stock { get; set; }
	}
}
