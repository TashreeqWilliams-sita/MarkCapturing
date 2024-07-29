using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Repositories;
using DataAccessLibrary;
using MarkCapturing.Views.Interfaces;
using MarkCapturing.Services;

namespace MarkCapturing.Presenter
{
    public class ResetPasswordRequestPresenter
    {
        private readonly IResetRequestView resetPasswordView;
        private readonly ResetPasswordService resetPasswordService;
        public ResetPasswordRequestPresenter(IResetRequestView resetRequestView)
        {
            resetPasswordService = new ResetPasswordService();
            resetPasswordView = resetRequestView;
            resetRequestView.PasswordRequestsClicked += ResetRequestView_PasswordRequestsClicked;
            resetPasswordView.SaveClicked += ResetPasswordView_SaveClicked;
        }

        private void ResetPasswordView_SaveClicked(object sender, EventArgs e)
        {
            HandleSave();
        }

        private void ResetRequestView_PasswordRequestsClicked(object sender, EventArgs e)
        {
            HandlePasswordRequests();
        }
        public void HandleSave()
        {
            // Check if the reset password checkbox is checked
            bool isResetPasswordChecked = resetPasswordView.IsResetPasswordChecked();

            if (isResetPasswordChecked)
            {
                // Update the user's isPasswordReset field to true
                bool isResetPasswordUpdated = UpdateUserResetPassword(resetPasswordView.GetSelectedUsername());

                if (isResetPasswordUpdated)
                {
                    // Show a success message in the form
                    resetPasswordView.ShowSuccessMessage($"Reset password was successfull!! \nuser: {resetPasswordView.GetSelectedUsername()}. \nTemporal password: {resetPasswordView.PromptTemporaryPassword()}");

                    resetPasswordView.Clear(resetPasswordView.GetSelectedUsername());
                }
                else
                {
                    // Show an error message in the form
                    resetPasswordView.ShowErrorMessage("Failed to update the reset password setting.");
                }
            }
            else
            {
                // Show a success message in the form without resetting the password
                resetPasswordView.ShowSuccessMessage($"Note you did note check password reset for: {resetPasswordView.GetSelectedUsername()}. No changes will be made for the user!");
            }
        }
        public void HandlePasswordRequests()
        {
            List<string> resetRequests = resetPasswordService.GetResetPasswordRequests();

            // Display the list of password reset requests in the admin form
            resetPasswordView.ShowPasswordRequests(resetRequests);
        }
        private bool UpdateUserResetPassword(string username)
        {
            try
            {
                return resetPasswordService.IsUpdateUserResetPassword(username);
            }
            catch (Exception ex)
            {
                resetPasswordView.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        //private bool GenerateTemporaryPassword(string username, string temporaryPassword)
        //{
        //    try
        //    {
        //        return resetPasswordRepository.GenerateTemporaryPassword(username, temporaryPassword);
        //    }
        //    catch (Exception ex)
        //    {
        //        resetPasswordView.ShowErrorMessage(ex.Message);
        //        return false;
        //    }
        //}

        //public void HandleSelectedUser(string username)
        //{
        //    // Show the selected user's details in the admin form
        //    resetPasswordView.ShowPasswordRequests()
        //}

        //public void HandleGenerateTemporaryPassword(string username)
        //{
        //    // Prompt the admin for the new temporary password
        //    string temporaryPassword = resetPasswordView.PromptTemporaryPassword();

        //    // Update the user's password with the temporary password
        //    bool isTemporaryPasswordGenerated = GenerateTemporaryPassword(username, temporaryPassword);

        //    if (isTemporaryPasswordGenerated)
        //    {
        //        resetPasswordView.ShowSuccessMessage("Temporary password generated successfully.");
        //    }
        //    else
        //    {
        //        resetPasswordView.ShowErrorMessage("Failed to generate the temporary password.");
        //    }
        //}
    }
}
