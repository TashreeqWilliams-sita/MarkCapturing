using MarkCapturing.Helpers;
using MarkCapturing.Services;
using MarkCapturing.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Presenter
{
    public class ResetPasswordPresenter : IResetPasswordPresenter
    {
        private readonly IResetPasswordView resetPassword;
        private readonly AuthenticationService authenticationService;
        public ResetPasswordPresenter(IResetPasswordView resetPasswordView)
        {
            resetPassword = resetPasswordView;
            authenticationService = new AuthenticationService();
            resetPassword.ResetPasswordClicked += ResetPassword_ResetPasswordClicked;
            resetPassword.ExitClicked += ResetPassword_ExitClicked;
        }

        private void ResetPassword_ExitClicked(object sender, EventArgs e)
        {
            resetPassword.Exit();
        }

        private void ResetPassword_ResetPasswordClicked(object sender, EventArgs e)
        {
            HandlePasswordReset();
        }

        public void HandlePasswordReset()
        {
            if (resetPassword.NewPassword != "" && resetPassword.ConfirmPassword != "")
            {
                //check if new password and confirm password match
                if (resetPassword.NewPassword == resetPassword.ConfirmPassword)
                {
                    // Retrieve the new password from the reset password form
                    string newPassword = resetPassword.ConfirmPassword;
                    // Encrypt the new password using the encryption helper
                    string encryptedPassword = EncryptionHelper.HashPassword(newPassword);
                    // Update the user's password in the database
                    bool isPasswordUpdated = authenticationService.IsPasswordUpdated(encryptedPassword,resetPassword.Username);

                    if (isPasswordUpdated)
                    {
                        // Reset the IsPasswordReset flag
                        bool isResetFlagUpdated = authenticationService.IsPasswordReset(false,resetPassword.Username);

                        if (isResetFlagUpdated)
                        {
                            bool isResetRequestChanged = authenticationService.IsPasswordResetRequested(false,resetPassword.Username);
                            if (isResetRequestChanged)
                            {
                                // Delete the corresponding reset request from the table
                                bool isResetRequestDeleted = authenticationService.IsResetRequestDeleted(resetPassword.Username);

                                if (isResetRequestDeleted)
                                {
                                    // Log out the user
                                    resetPassword.SuccessMessage("Password reset successfully. Please log in again with your new password.");
                                    resetPassword.LogOut();
                                }
                                else
                                {
                                    resetPassword.ErrorMessage("Failed to delete reset request. Please contact the administrator.");
                                }
                            }
                            else
                            {
                                resetPassword.ErrorMessage("Failed to change reset request");
                            }
                        }
                        else
                        {
                            resetPassword.ErrorMessage("Failed to update IsPasswordReset flag. Please contact the administrator.");
                        }
                    }
                    else
                    {
                        resetPassword.ErrorMessage("Failed to update password. Please contact the administrator.");
                    }
                }
                else
                {
                    resetPassword.ErrorMessage("Passwords do not match");
                }
            }
            else
            {
                resetPassword.ErrorMessage("Please enter password, Password is empty");
            }
        }
    }
}
