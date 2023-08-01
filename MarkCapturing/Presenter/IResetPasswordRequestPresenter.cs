using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Presenter
{
    public interface IResetPasswordRequestPresenter
    {
        void HandlePasswordRequests();
        //void HandleSelectedUser(string username);
        void HandleGenerateTemporaryPassword(string username);
        void GetTempPassword(string temp);
    }
}
