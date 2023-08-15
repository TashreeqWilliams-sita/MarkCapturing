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
            if (userRepository.GetUserByUsername(username) != null)
                return true;
            else
                return false;
        }
        public List<string> GetListOfRoles()
        {
            return userRepository.GetAllRoles().Select(r => r.RoleName).ToList();
            //return userRepository.GetAllRoleNames();
        }
        public bool IsUserRegistered(string Username, string Password, string IDNumber, short Level, Guid guid)
        {
            if (UserExists(Username))
            {
                return true;
            }
            else
            {
                User user = new User
                {
                    UserName = Username,
                    Password = Password,
                    ID_Number = IDNumber,
                    Level = Level,
                    rowguid = guid
                };
                userRepository.AddUser(user);
                return true;
            }
        }
    }
}
