using ECommerce.Study.Domain.Models;

namespace ECommerce.Study.Data.Repos
{
	public interface IUserRepository : IRepository<User>
	{
		User GetByUsername(string username);
	}
}
