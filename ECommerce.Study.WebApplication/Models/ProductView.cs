using System.ComponentModel.DataAnnotations;

namespace ECommerce.Study.WebApplication.Models
{
	public class ProductViewModel
	{
		[Required]
		public string StockCode { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		[Range(typeof(decimal), "1", "79228162514264337593543950335")]
		public decimal Price { get; set; }
		[Range(0, int.MaxValue)]
		public int StockCount { get; set; }
	}
}