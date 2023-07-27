using DataAccessLibrary.Repositories;
using DataAccessLibrary.Interfaces;
using System.Collections.Generic;
using DataAccessLibrary;

/// <summary>
/// This class is responsible for assigning roles to users
/// </summary>
namespace MarkCapturing.Services
{
    public class AssigningRolesService
    {
        private readonly IUserRepository userRepository;
        public AssigningRolesService()
        {
            userRepository = new UserRepository();
        }
        private User GetUser(string username)
        {
            return userRepository.GetUserByUsername(username);
        }
        public string AssignRoles(string username)
        {
            User user = GetUser(username);
            if (user != null)
            {
                List<string> roles = userRepository.GetAllRoleNames();
                if (user.Level == 7)
                {
                    return user.Role = roles.Find(r => r == "Supervisor");
                }
                else if (user.Level == 6)
                {
                    return user.Role = roles.Find(r => r == "Admin");
                }
                else if (user.Level == 5)
                {
                    return user.Role = roles.Find(r => r == "Superuser");
                }
                else if (user.Level == 4)
                {
                    return user.Role = roles.Find(r => r == "Capturer");
                }
                else if (user.Level == 2)
                {
                    return user.Role = roles.Find(r => r == "Verifier");
                }
                else if (user.Level == 1)
                {
                    return user.Role = roles.Find(r => r == "Scripts");
                }
                else if (string.IsNullOrEmpty(user.Role))
                {
                    return user.Role = roles.Find(r => r == "Capturer");
                }
                //return null for a role if the user is not there
                return null;
            }
            else
            {
                return null;
            }
        }
        public bool IsRoleAssigned(string username)
        {
            User user = GetUser(username);
            string role = AssignRoles(username);
            if (user != null)
                return !string.IsNullOrWhiteSpace(role);
            else
                return false;

            //if (string.IsNullOrWhiteSpace(role))
            //{
            //    return false;
            //}
            //else 
            //    return true;
        }
    }
}
