using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarkCapturing.Presenter;
using MarkCapturing.Views.Interfaces;
using DataAccessLibrary.Interfaces;

namespace MarkCapturing.Views.Security
{
    public partial class FormResetPasswordRequests : Form, IResetRequestView
    {
        private readonly ResetPasswordRequestPresenter ResetPasswordPresenter;
        public event EventHandler PasswordRequestsClicked;
        public event EventHandler SaveClicked;

        public FormResetPasswordRequests()
        {
            InitializeComponent();
            ResetPasswordPresenter = new ResetPasswordRequestPresenter(this);
        }
        private void LstPasswordRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected username from the list box
            string selectedUsername = LstPasswordRequests.SelectedItem.ToString();

            // Enable the password reset checkbox
            EnablePasswordReset(true);

            // Show the selected user's details
            //ShowSelectedUserDetails(selectedUsername);
        }
        public void ShowPasswordRequests(List<string> resetRequests)
        {
            // Display the list of password reset requests in a list box
            /*LstPasswordRequests.DataSource = resetRequests*/
            // Clear the existing items in the list box
            LstPasswordRequests.Items.Clear();

            // Add the reset requests to the list box
            LstPasswordRequests.Items.AddRange(resetRequests.ToArray());
        }
        public void EnablePasswordReset(bool enable)
        {
            // Enable or disable the password reset checkbox based on the 'enable' parameter
            ChkResetPassword.Enabled = enable;
        }
        public string PromptTemporaryPassword()
        {
            // Generate a random temporary password
            string temporaryPassword = GenerateRandomPassword();

            // Return the generated temporary password
            return temporaryPassword;
        }

        private string GenerateRandomPassword()
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int passwordLength = 8;

            StringBuilder passwordBuilder = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = random.Next(0, allowedChars.Length);
                passwordBuilder.Append(allowedChars[randomIndex]);
            }

            return passwordBuilder.ToString();
        }

        public void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ChkResetPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            // Enable or disable controls based on the checkbox state
            bool enableReset = ChkResetPassword.Checked;
            BtnSave.Enabled = enableReset;
        }
        // Event handler for the "Password Requests" button click event
        private void BtnResetPasswordRequest_Click(object sender, EventArgs e)
        {
            // Raise the PasswordRequestsClicked event when the button is clicked
            PasswordRequestsClicked?.Invoke(this, EventArgs.Empty);
        }
        public string GetSelectedUsername()
        {
            return LstPasswordRequests.SelectedItem?.ToString();
        }

        public bool IsResetPasswordChecked()
        {
            return ChkResetPassword.Checked;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
