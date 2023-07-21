using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkCapturing.Views.Interfaces
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }
        string Role { get; }
        event EventHandler ForgotPasswordClicked;
        void ShowInvalidCredentialsError();
        void ShowSuccess(string message);
        void ShowUsernameRequiredDialog();
        void ShowLoginError();
        void ShowForm();
        Form ShowResetPasswordForm();
    }
}
