using Loss.BLL.IServices;
using Loss.DAL.IRepositories;
using Loss.DAL.Models;
using Loss.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Loss.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public IEnumerable<User> Get()
        {
            return userRepository.Get();
        }

        public User GetUserByUsername(string username)
        {
            return userRepository.GetUserByUsername(username);
        }

        public User Add(User user)
        {
            user.Password = HashingPassword(user.Password, "sfl@!va");
            return userRepository.Add(user);
        }

        public void Login(User user)
        {
            user.Password = HashingPassword(user.Password, "sfl@!va");
            userRepository.Login(user);
            UserGuid.Add(user.Username);

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

        // =========== UTILS ===========

        // Hashing passwords function
        public string HashingPassword(string password, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }


}
