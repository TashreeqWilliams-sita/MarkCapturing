using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interfaces
{
    public interface IResetRequestsRepositories
    {
        PasswordResetRequest GetUser(string username);
        bool DeleteResetRequest(string UserName);
    }
}
