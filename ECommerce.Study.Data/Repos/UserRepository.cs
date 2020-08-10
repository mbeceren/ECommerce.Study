using ECommerce.Study.Data.Persistence;
using ECommerce.Study.Domain.Models;
using System.Linq;

namespace ECommerce.Study.Data.Repos
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(ApplicationContext applicationContext) : base(applicationContext)
		{
		}

		public User GetByUsername(string username)
		{
			return Filter(f => f.Username.Equals(username)).FirstOrDefault();
		}
	}
}
