using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loss.DAL.Models;
using Loss.BLL.IServices;

namespace Loss.BLL.IServices
{
    public interface IUserService : IService<User>
    {
        User GetUserByUsername(string username);
        void Login(User user);
    }
}
