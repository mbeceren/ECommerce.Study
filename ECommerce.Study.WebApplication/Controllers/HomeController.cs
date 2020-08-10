using ECommerce.Study.WebApplication.Profilers;
using System.Web.Mvc;

namespace ECommerce.Study.WebApplication.Controllers
{
	public class HomeController : ControllerBase
	{
		private readonly Business.Providers.IServiceProvider _serviceProvider;
		private readonly ICustomAutoMapper _mapper;
		public HomeController(Business.Providers.IServiceProvider serviceProvider, ICustomAutoMapper mapper)
		{
			_serviceProvider = serviceProvider;
			_mapper = mapper;
		}

		public ActionResult Index()
		{
			return View();
		}

	}
}