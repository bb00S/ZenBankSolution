using System.Linq;
using ZenCoreService.Data;
using ZenCoreService.Models;
using ZenCoreService.Services.Interfaces;

namespace ZenCoreService.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User UpdateUser(int userId, User updatedUser)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email; 

                _dbContext.SaveChanges();
            }

            return existingUser;
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (userToDelete != null)
            {
                _dbContext.Users.Remove(userToDelete);
                _dbContext.SaveChanges();
            }
        }

    }
}

