using MarkCapturing.Presenter;
using System;
using System.Windows.Forms;
using MarkCapturing.Views;
using DataAccessLibrary.Interfaces;

namespace MarkCapturing
{
    public partial class FrmLogin : Form, ILoginView
    {
        private readonly LogInPresenter loginPresenter;
        public FrmLogin()
        {
            InitializeComponent();
            loginPresenter = new LogInPresenter(this);
        }

        #region ButtonLoginClickEvent
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = "Abbas, Tasmeer";/*txtUsername.Text.Trim();*/
            string password = "Summer@02"; /*txtPassword.Text.Trim();*/
            loginPresenter.OnLoginButtonClicked(username, password);
        }
        #endregion

        #region Messages
        public void ShowInvalidCredentialsError()
        {
            MessageBox.Show("Invalid credentials. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowLoginSuccess()
        {
            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
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
        #endregion
    }
}
