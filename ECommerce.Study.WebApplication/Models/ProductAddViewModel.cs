using System.Collections.Generic;

namespace ECommerce.Study.WebApplication.Models
{
	public class ProductAddViewModel
	{
		public ProductViewModel Product { get; set; }
		public IEnumerable<string> Errors { get; set; }
		public bool Success { get; set; }
	}
}