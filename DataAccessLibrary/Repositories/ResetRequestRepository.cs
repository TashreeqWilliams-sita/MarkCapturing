using DataAccessLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repositories
{
    public class ResetRequestRepository : IResetRequestsRepositories
    {
        private readonly NSC_VraagpunteStelselEntities dbContext;
        public ResetRequestRepository()
        {
            dbContext = new NSC_VraagpunteStelselEntities();
        }
        public PasswordResetRequest GetUser(string username)
        {
            return dbContext.PasswordResetRequests.FirstOrDefault(u => u.UserName == username);
        }
        public bool DeleteResetRequest(string username)
        {
            PasswordResetRequest userToDelete = dbContext.PasswordResetRequests.FirstOrDefault(u => u.UserName == username);
            if (userToDelete != null)
            {
                dbContext.PasswordResetRequests.Remove(userToDelete);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
