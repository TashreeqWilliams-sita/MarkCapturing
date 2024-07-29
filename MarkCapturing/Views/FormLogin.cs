using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MarkCapturing.Presenter;
using MarkCapturing.Views.Interfaces;
using MarkCapturing.Views.Security;

namespace MarkCapturing.Views
{
    public partial class FormLogin : Form, ILoginView
    {
        private readonly LogInPresenter loginPresenter;
        public ILoginView loginView;
        public string Username
        {
            get
            {
                return ComboBoxUsernames.SelectedItem?.ToString();
            }
        }
        public string Password => TxtPassword.Text.Trim();
        public string Role => loginPresenter.Roles();
        public event EventHandler ForgotPasswordClicked;

        public FormLogin()
        {
            InitializeComponent();
            loginView = this;
            loginPresenter = new LogInPresenter(this);
        }
        #region BtnClose
        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }
        #endregion
        #region TextboxClick
        private void TxtUsername_Click(object sender, EventArgs e)
        {
            TxtUsername.BackColor = Color.White;
            PnlUsername.BackColor = Color.White;
            PnlPassword.BackColor = SystemColors.Control;
            TxtPassword.BackColor = SystemColors.Control;
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {
            TxtUsername.BackColor = SystemColors.Control;
            PnlUsername.BackColor = SystemColors.Control;
            PnlPassword.BackColor = Color.White;
            TxtPassword.BackColor = Color.White;
        }
        #endregion
        #region Messages
        public void ShowInvalidCredentialsError()
        {
            MessageBox.Show("Invalid credentials. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccess(string message)
        {
            //message = "Login successful!";
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowForm()
        {
            FormMenu formMenu = new FormMenu();
            Program.FormNavController.ShowForm(formMenu);
            //this.Hide();
        }

        public void ShowLoginError()
        {
            MessageBox.Show("An error occurred during login. Please try again later", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
        #region ButtonLoginClickEvent
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            loginPresenter.OnLoginButtonClicked();
        }
        private void FormLogin_Enter(object sender, EventArgs e)
        {

            BtnLogin_Click(sender, e);
        }
        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }
        #endregion
        #region ChkPasswordEvent
        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkShowPassword.Checked)
            {
                //show password
                TxtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                //Hide the password
                TxtPassword.UseSystemPasswordChar = true;
            }
        }
        #endregion


        // Event handler for the "Forgot Password" button click event
        private void BtnForgetPassword_Click(object sender, EventArgs e)
        {
            // Check if the username is empty
            if (string.IsNullOrWhiteSpace(Username))
            {
                // Show the "Username Required" dialog
                ShowUsernameRequiredDialog();
            }
            else
            {
                // Raise the ForgotPasswordClicked event when the button is clicked
                ForgotPasswordClicked?.Invoke(this, EventArgs.Empty);
            }
        }
        public void ShowUsernameRequiredDialog()
        {
            MessageBox.Show("Please enter your username.", "Username Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public Form ShowResetPasswordForm()
        {
            FormResetPassword resetPasswordForm = new FormResetPassword();
            return resetPasswordForm;
        }

        public void PopulateUsernameDropdown(List<string> usernames)
        {
            ComboBoxUsernames.Items.Clear();
            ComboBoxUsernames.Items.AddRange(usernames.ToArray());
        }
    }
}