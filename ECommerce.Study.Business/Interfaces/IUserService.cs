using ECommerce.Study.Domain.Models;

namespace ECommerce.Study.Business.Interfaces
{
	public interface IUserService
	{
		User GetUserByUsername(string username);
	}
}
