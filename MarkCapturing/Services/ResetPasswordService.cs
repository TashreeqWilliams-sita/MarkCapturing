using DataAccessLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
===================================================================================
1. This service class is responsible for communicating with our repository for reseting passwords
2. It will also communicate with our presenter
3. It is the middleman between database and presenter 
4. It is only responsible for reseting password only
===================================================================================
*/
namespace MarkCapturing.Services
{
    public class ResetPasswordService
    {
        private readonly ResetPasswordRepository resetPasswordRepository;

        public ResetPasswordService()
        {
            resetPasswordRepository = new ResetPasswordRepository();
        }
        public List<string> GetResetPasswordRequests()
        {
            return resetPasswordRepository.GetResetPasswordRequests();
        }
        public bool IsUpdateUserResetPassword(string username)
        {
            return resetPasswordRepository.UpdateUserResetPassword(username);
        }
        public void Clear(string username)
        {
            resetPasswordRepository.Clear(username);
        }
    }
}
