using ECommerce.Study.Business.Interfaces;
using ECommerce.Study.Data.Persistence;
using ECommerce.Study.Data.Repos;
using ECommerce.Study.Domain.Models;

namespace ECommerce.Study.Business.Services
{
	internal class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		public UserService(IRepositoryFactory repositoryFactory)
		{
			_userRepository = repositoryFactory.GetAdminRepository();
		}

		public User GetUserByUsername(string username)
		{
			return _userRepository.GetByUsername(username);
		}
	}
}
