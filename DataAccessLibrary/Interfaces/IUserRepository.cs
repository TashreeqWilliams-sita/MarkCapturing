using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserByUsername(string username);
        List<string> GetAllRoleNames();
        bool AssignUserRole(string username, string roleName);
        void UpdateUser(User user);
        void AddUser(User user);
        void DeleteUser(string username);
        void UpdatePassword(string newPassword, User user);
        void UpdateIsResetPassword(bool changeIsResetField, User user);
        void UpdateIsPasswordRequest(bool changeIsRequested, User user);
    }
}
