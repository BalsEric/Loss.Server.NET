using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loss.DAL.Models;

namespace Loss.DAL.IRepositories
{
	public interface IUserRepository : IRepository<User>
	{
		User GetUserByUsername(string username);
		void Login(User user);
	}
}
