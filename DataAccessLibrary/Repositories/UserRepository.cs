using System.Collections.Generic;
using System.Linq;
using DataAccessLibrary.Interfaces;

namespace DataAccessLibrary.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly NSC_VraagpunteStelselEntities dbContext;

        public UserRepository()
        {
            dbContext = new NSC_VraagpunteStelselEntities();
        }
        public List<User> GetAllUsers()
        {
            return dbContext.Users.ToList();
        }
        public List<string> GetListOfUsernames()
        {
            return GetAllUsers().Select(u => u.UserName).ToList();
        }
        public User GetUserByUsername(string username)
        {
            return dbContext.Users.FirstOrDefault(u => u.UserName == username);
        }
        public List<string> GetAllRoleNames()
        {
            return dbContext.Roles.Select(r => r.RoleName).ToList();
        }

        public bool AssignUserRole(string username, string roleName)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.UserName == username);
            string role = dbContext.Roles.FirstOrDefault(r => r.RoleName == roleName).ToString();

            if (user != null && role != null)
            {
                // Assign the role to the user
                user.Role = role;

                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void AddUser(User user) //For later purposes when we want to add new users
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
        // Update Individually
        public void UpdatePassword(string newPassword, User user)
        {
            var existingUser = dbContext.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (existingUser != null)
            {
                existingUser.Password = newPassword;
                dbContext.SaveChanges();
            }
        }
        public void UpdateIsResetPassword(bool IsChanged, User user)
        {
            var existingUser = dbContext.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (existingUser != null)
            {
                existingUser.IsPasswordReset = IsChanged;
                dbContext.SaveChanges();
            }
        }

        public void UpdateIsPasswordRequest(bool IsChanged, User user)
        {
            var existingUser = dbContext.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (existingUser != null)
            {
                existingUser.IsPasswordResetRequested = IsChanged;
                dbContext.SaveChanges();
            }
        }
        public void UpdateUser(User user)
        {
            var existingUser = dbContext.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
                existingUser.IsPasswordReset = user.IsPasswordReset;
                existingUser.IsPasswordResetRequested = user.IsPasswordResetRequested;
                //We can Update other User properties if we want

                dbContext.SaveChanges();
            }
        }
        public void DeleteUser(string username)
        {
            User userToDelete = dbContext.Users.FirstOrDefault(u => u.UserName == username);
            if (userToDelete != null)
            {
                dbContext.Users.Remove(userToDelete);
                dbContext.SaveChanges();
            }
        }
        //public List<string> GetPasswordResetUsernames()
        //{
        //    // Retrieve the list of usernames that have requested a password reset
        //    // from the data source
        //    //List<string> usernames = _users.Where(u => u.ResetPasswordRequested).Select(u => u.Username).ToList();
        //    return usernames;
        //}

        //public void ResetPassword(string username, string newPassword)
        //{
        //    // Update the password for the specified username in the data source
        //    User user = _users.FirstOrDefault(u => u.Username == username);
        //    if (user != null)
        //    {
        //        user.Password = newPassword;
        //        user.ResetPasswordRequested = false; // Reset the reset password flag
        //    }
        //}
    }
}

