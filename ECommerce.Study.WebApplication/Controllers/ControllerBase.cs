using System.Web.Mvc;

namespace ECommerce.Study.WebApplication.Controllers
{
	public class ControllerBase : Controller
	{
		public bool IsLogged => User != null && User.Identity.IsAuthenticated;

		protected override void Initialize(System.Web.Routing.RequestContext requestContext)
		{
			base.Initialize(requestContext);
			ViewBag.IsLogged = IsLogged;
		}
	}
}