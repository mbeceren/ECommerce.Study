using ECommerce.Study.Business.Providers;
using ECommerce.Study.WebApplication.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ECommerce.Study.WebApplication.Controllers
{
	public class AuthController : ControllerBase
    {
		private readonly IServiceProvider _serviceProvider;
		public AuthController(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		[HttpGet]
		public ActionResult Login()
		{
			if (IsLogged)
				return RedirectToAction("Index", "Home");

			return View();
		}

		[HttpPost]
        public ActionResult Login(LoginRequest loginRequest)
        {
			if (IsLogged)
				return RedirectToAction("Index", "Home");

			if (!ModelState.IsValid)
			{
				return View(new LoginViewModel
				{
					Error = string.Join("<br />", ModelState.Values.Where(w => w.Errors.Count > 0).SelectMany(sm => sm.Errors).Select(s => s.ErrorMessage))
				});
			}

			var adminService = _serviceProvider.UserService();
			var user = adminService.GetUserByUsername(loginRequest.Username);
			if (user == null || !user.Password.Equals(loginRequest.Password))
				return View(new LoginViewModel
				{
					Username = loginRequest.Username,
					Error = "Kullanıcı adı veya şifre yanlış."
				});

			FormsAuthentication.SetAuthCookie(user.Username, false);

			return RedirectToAction("Index", "Home");
        }

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Login");
		}

	}
}