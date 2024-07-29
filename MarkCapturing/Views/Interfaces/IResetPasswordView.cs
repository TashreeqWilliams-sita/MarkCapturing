using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Views.Interfaces
{
    public interface IResetPasswordView
    {
        string Username { get; set; }
        string NewPassword { get; set; }
        string ConfirmPassword { get; set; }
        void ErrorMessage(string message);
        void SuccessMessage(string message);
        void LogOut();
        event EventHandler ResetPasswordClicked;
        event EventHandler ExitClicked;
        void Exit();
    }
}
