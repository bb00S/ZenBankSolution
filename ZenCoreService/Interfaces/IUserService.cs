using System.Collections.Generic;
using ZenCoreService.Models;

namespace ZenCoreService.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        User CreateUser(User user);
        User UpdateUser(int userId, User updatedUser);
        void DeleteUser(int userId);
    }
}


