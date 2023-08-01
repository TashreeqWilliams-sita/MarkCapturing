using DataAccessLibrary;
using DataAccessLibrary.Repositories;
using MarkCapturing.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Services
{
    public class RegisterUserService
    {
        private readonly UserRepository userRepository;
        public RegisterUserService()
        {
            userRepository = new UserRepository();
        }

        public bool UserExists(string username)//Check if user exists
        {
            userRepository.GetUserByUsername(username);
            return true;
        }
        public List<string> GetListOfRoles()
        {
            return userRepository.GetAllRoles().Select(r => r.RoleName).ToList();
            //return userRepository.GetAllRoleNames();
        }
        public bool IsUserRegistered(string Username, string Password, string IDNumber, string Role)
        {
            if (UserExists(Username))
            {
                return false;
            }
            else
            {
                User user = new User
                {
                    UserName = Username,
                    Password = Password,
                    ID_Number = IDNumber,
                    Role = Role
                };
                userRepository.AddUser(user);
                return true;
            }
        }
    }
}
