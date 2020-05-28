using Loss.DAL.IRepositories;
using Loss.DAL.Models;
using Loss.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loss.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> Get()
        {
            using (LossContext db = new LossContext())
            {
                return db.Users.ToList();
            }
        }

        public User GetUserByUsername(string username)
        {
            using (LossContext db = new LossContext())
            {
                foreach (User user in db.Users)
                {
                    if (user.Username == username)
                    {
                        return user;
                    }
                }
                return null;
            }
        }

        public User Add(User user)
        {
            using (LossContext db = new LossContext())
            {
                var result = db.Users.Add(user);
                db.SaveChanges();
                return result;
            }
        }


        public void Login(User user)
        {
            using (LossContext db = new LossContext())
            {
                var foundUser = this.GetUserByUsername(user.Username);
                if (foundUser != null)
                {
                    if (user.Password != foundUser.Password)
                    {
                        throw new System.ArgumentException("Invalid username or password");
                    }
                }
                else
                {
                    throw new System.ArgumentException("Invalid username or password");
                }
            }
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }


        public User Update(int id, User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
