using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLibrary.Interfaces;

namespace DataAccessLibrary.Repositories
{
    public class ResetPasswordRepository : IResetPasswordRepository
    {
        private readonly NSC_VraagpunteStelselEntities dbContext;
        public ResetPasswordRepository()
        {
            dbContext = new NSC_VraagpunteStelselEntities();
        }
        public bool UpdateFields(string username)
        {
            // In this method let's get the reset token and make it a password 
            var user = dbContext.Users.FirstOrDefault(u => u.UserName == username);
            //var ResetTokenExpiry = dbContext.PasswordResetRequests.FirstOrDefault(t => t.ResetTokenExpiry == t.ResetTokenExpiry);

            if (user != null)
            {
                // Set the temporary password and update the password reset flags
                //user.Password = temporaryPassword;
                user.IsPasswordResetRequested = true;
                user.IsPasswordReset = true;
                user.ResetToken = GetResetToken(username);
                //user.ResetTokenExpiry = (DateTime)ResetTokenExp;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        //public List<string> GetPasswordRequests()
        //{
        //    // Retrieve the list of password reset requests from the PasswordResetRequests table
        //    return dbContext.PasswordResetRequests.Select(r => r.UserName).ToList();
        //}

        public List<string> GetResetPasswordRequests()
        {
            return dbContext.PasswordResetRequests.Select(r => r.UserName).ToList();
        }
        public string GetResetToken(string username)
        {
            var user = dbContext.PasswordResetRequests.FirstOrDefault(u => u.UserName == username);
            if (user != null)
                return dbContext.PasswordResetRequests.Select(t => t.ResetToken).FirstOrDefault();
            else
                return null;
        }
        public bool UpdateUserResetPassword(string username)
        {
            // Retrieve the user from the database based on the username
            var user = dbContext.Users.FirstOrDefault(u => u.UserName == username);
            DateTime resetExpiry = dbContext.PasswordResetRequests.Select(e => e.ResetTokenExpiry).FirstOrDefault();

            if (user != null)
            {
                // Update the user's isPasswordReset field to true
                user.IsPasswordReset = true;
                user.IsPasswordResetRequested = true;
                user.ResetTokenExpiry = resetExpiry;
                
                if (resetExpiry < DateTime.Now)//check if the reset token has expired if it has reset it
                {
                    resetExpiry = DateTime.Now.AddDays(1);
                    user.ResetTokenExpiry = resetExpiry;
                    user.Password = GetResetToken(username);
                    dbContext.SaveChanges();
                }
                else
                {
                    user.ResetTokenExpiry = resetExpiry;
                    user.Password = GetResetToken(username);
                    dbContext.SaveChanges();
                }
                return true;
            }
            return false;
        }
        public void Clear(string username)
        {
            var GetUserToClear = dbContext.PasswordResetRequests.FirstOrDefault(u => u.UserName == username);
            if (GetUserToClear != null)
            {
                dbContext.PasswordResetRequests.Remove(GetUserToClear);
                dbContext.SaveChanges();
            }
        }
    }
}
