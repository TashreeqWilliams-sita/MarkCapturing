using MarkCapturing.Presenter;
using System;
using System.Windows.Forms;
using MarkCapturing.Views;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Repositories;
using MarkCapturing.Views.Interfaces;

namespace MarkCapturing
{
    public partial class FrmLogin : Form, ILoginView
    {
        private readonly LogInPresenter loginPresenter;
        public ILoginView loginView;

        public event EventHandler ForgotPasswordClicked;

        //public string username;
        //public string userRole;

        public string Username => txtUsername.Text.Trim();
        public string Password => txtPassword.Text.Trim();
        public string Role => loginPresenter.Roles();

        public FrmLogin()
        {
            InitializeComponent();
            loginView = this;
            loginPresenter = new LogInPresenter(this);
        }

        #region ButtonLoginClickEvent
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //username = /*"Abbas, Tasmeer";/**/txtUsername.Text.Trim();
            //username = txtUsername.Text.Trim();
            //userRole = loginPresenter.Roles(username);
            /*string password = "Summer@02"; *//*txtPassword.Text.Trim();*/
            loginPresenter.OnLoginButtonClicked();

        }
        #endregion

        #region Messages
        public void ShowInvalidCredentialsError()
        {
            MessageBox.Show("Invalid credentials. Please try again.\nNB: If you've forgotten your login details kindly contact your administrator", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowLoginSuccess()
        {
            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            //username = txtUsername.Text.Trim();
            //var userRole = repository.GetUserRole(username);
            //ShowForm();

        }
        //public string GetUserRole()
        //{
            
        //    return userRole;
        //}
        public void ShowForm()
        {
            //MenuForm menuForm = new MenuForm(this);
            //menuForm.Show();
        }

        public void ShowLoginError()
        {
            MessageBox.Show("An error occurred during login. Please try again later", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region chkPasswordEvent
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                //show password
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                //Hide the password
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        #endregion

        #region FormLoadEvent
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
        #endregion

        #region FormClosingEvent
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        public void ShowSuccess(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowUsernameRequiredDialog()
        {
            throw new NotImplementedException();
        }

        public Form ShowResetPasswordForm()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
