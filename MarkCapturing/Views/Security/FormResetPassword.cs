using MarkCapturing.Helpers;
using MarkCapturing.Presenter;
using MarkCapturing.Services;
using MarkCapturing.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkCapturing.Views.Security
{
    public partial class FormResetPassword : Form, IResetPasswordView
    {
        private readonly AuthenticationService authenticationService;
        private readonly ResetPasswordPresenter resetPasswordPresenter;

        public event EventHandler ResetPasswordClicked;
        public event EventHandler ExitClicked;
        private string userName;

        public string Username 
        {
            get { return userName; }
            set 
            {
                if (value != null)
                {
                    userName = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Username");
                }
            } 
        }
        public string NewPassword
        {
            get => TxtPassword.Text.Trim();
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value cannot be empty.");
                }
                else
                {
                    NewPassword = value;
                }
            }
        }
        public string ConfirmPassword
        {
            get => TxtConfirmPassword.Text.Trim();
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value cannot be empty.");
                }
                else
                {
                    ConfirmPassword = value;
                }
            }
        }

        public FormResetPassword(string username)
        {
            userName = username;
            InitializeComponent();
            LblUserLoggedin.Text = Username;
            PnlUsername.BackColor = SystemColors.Control;
            //BtnResetPassword.Enabled = false;
            authenticationService = new AuthenticationService();
            resetPasswordPresenter = new ResetPasswordPresenter(this);
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {
            TxtConfirmPassword.BackColor = SystemColors.Control;
            PnlNewPassword.BackColor = Color.White;
            TxtPassword.BackColor = Color.White;
            PnlConfirmPassword.BackColor = SystemColors.Control;
        }

        private void TxtConfirmPassword_Click(object sender, EventArgs e)
        {
            TxtPassword.BackColor = SystemColors.Control;
            PnlNewPassword.BackColor = SystemColors.Control;
            TxtConfirmPassword.BackColor = Color.White;
            PnlConfirmPassword.BackColor = Color.White;
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            ExitClicked?.Invoke(this, EventArgs.Empty);
        }

        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.OK)
            {
                LogOut();
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }
        }

        public void LogOut()
        {
            this.Close();
        }

        public void Exit()
        {
            Close();
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            ResetPasswordClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
