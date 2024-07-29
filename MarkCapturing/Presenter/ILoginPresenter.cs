using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Presenter
{
    public interface ILoginPresenter
    {
        string Username { get; }
        event EventHandler ForgotPasswordClicked;
        void PopulateDropdown();
        string GenerateTempPassword();
        bool CheckPasswordReset();
        bool CheckResetToken();
        bool Delete();
        void OnLoginButtonClicked();
        string Roles();
    }
}
