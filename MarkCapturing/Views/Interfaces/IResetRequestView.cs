using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This interface will handle all the Reset Request functionalities
namespace MarkCapturing.Views.Interfaces
{
    public interface IResetRequestView
    {
        // Event to handle the "Password Requests" button click
        event EventHandler PasswordRequestsClicked;
        // Event to handle the "Generate Password" button click
        event EventHandler SaveClicked;

        // Method to get the selected username
        string GetSelectedUsername();
        bool IsResetPasswordChecked();

        // Method to display the list of password reset requests
        void ShowPasswordRequests(List<string> resetRequests);

        // Method to enable/disable the password reset checkbox
        void EnablePasswordReset(bool enable);

        // Method to prompt the admin for the user's new temporary password
        string PromptTemporaryPassword();

        // Method to display success/failure messages
        void ShowSuccessMessage(string message);
        void ShowErrorMessage(string message);
    }
}
