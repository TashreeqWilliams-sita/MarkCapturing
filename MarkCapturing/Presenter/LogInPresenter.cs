using DataAccessLibrary.Interfaces;
using MarkCapturing.Services;
using System.Linq;
using MarkCapturing.Views.Interfaces;
using DataAccessLibrary;
using DataAccessLibrary.Repositories;
using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace MarkCapturing.Presenter
{
    public class LogInPresenter
    {
        private readonly ILoginView loginView;
        private readonly AuthenticationService authenticationService;
        private readonly AssigningRolesService rolesService;
        private readonly NSC_VraagpunteStelselEntities dbContext;

        public LogInPresenter(ILoginView view)
        {
            loginView = view;
            rolesService = new AssigningRolesService();
            authenticationService = new AuthenticationService();
            //dbContext = new NSC_VraagpunteStelselEntities();
            PopulateDropdown();

            // Subscribe to the ForgotPasswordClicked event
            loginView.ForgotPasswordClicked += LoginView_ForgotPasswordClicked;
        }
        public void PopulateDropdown()
        {
            List<string> usernames = authenticationService.GetListOfUsernames();

            loginView.PopulateUsernameDropdown(usernames);
        }
        private void LoginView_ForgotPasswordClicked(object sender, EventArgs e)
        {
            string username = loginView.Username;
            string role = Roles();

            if (role != "Admin" && role != "Supervisor")
            {
                string resetToken = GenerateResetToken();

                DateTime resetTokenExpiry = DateTime.Now.AddDays(1);

                // Add the username to the PasswordResetRequests table
                var resetRequest = new PasswordResetRequest
                {
                    UserName = username,
                    RequestDateTime = DateTime.Now,
                    ResetToken = resetToken,
                    ResetTokenExpiry = resetTokenExpiry
                };

                dbContext.PasswordResetRequests.Add(resetRequest);
                dbContext.SaveChanges();

                // Show a message to the user indicating that their password reset request has been received
                loginView.ShowSuccess("Your password reset request has been received. Please wait for further instructions.");
            }
        }
        private string GenerateResetToken()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var token = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
            return token;
        }
        public bool CheckPasswordReset()
        {
            return authenticationService.IsResetPassword(loginView.Username);
        }
        public bool CheckResetToken()
        {
            return authenticationService.IsResetToken(loginView.Username, loginView.Password);
        }
        //public bool Update()
        //{
        //    return authenticationService.IsUpdated(loginView.Username);
        //}
        public bool Delete()
        {
            return authenticationService.IsResetRequestDeleted(loginView.Username);
        }
       
        public void OnLoginButtonClicked()
        {
            //We need to check if the entered username has requested a login or not
            if (authenticationService.IsResetPassword(loginView.Username))
            {
                if (CheckPasswordReset())
                {
                    // Compare the entered password with the reset token
                    if (CheckResetToken())
                    {
                        // Show reset password form to enter new password
                        var resetPasswordForm = loginView.ShowResetPasswordForm();
                        resetPasswordForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show($"{loginView.Username} Requested a reset password; \nPlease use your reset token as the password or contact the administrator.");
                    }
                }
            }
            else
            {
                //Authenticate
                bool isValid = authenticationService.AuthenticateUser(loginView.Username, loginView.Password);
                if (isValid)
                {
                    loginView.ShowSuccess("Login Success");
                    loginView.ShowForm();
                }
                else
                {
                    loginView.ShowInvalidCredentialsError();
                }

            }
        }
        public string Roles()
        {
            return rolesService.AssignRoles(loginView.Username);
        }
        private void BtnForgetPassword_Click(object sender, EventArgs e)
        {
        }
    }
}
