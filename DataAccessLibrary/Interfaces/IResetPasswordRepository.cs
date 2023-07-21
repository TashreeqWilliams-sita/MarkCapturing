using System.Collections.Generic;

namespace DataAccessLibrary.Interfaces
{
    public interface IResetPasswordRepository
    {
        //List<string> GetPasswordRequests();
        List<string> GetResetPasswordRequests();
        bool UpdateFields(string username);
        string GetResetToken(string username);
        bool UpdateUserResetPassword(string username);
        void Clear(string username);
    }
}
