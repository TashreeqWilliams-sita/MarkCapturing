using MarkCapturing.Presenter;
using MarkCapturing.Views.FormsBasedOnRoles;
using MarkCapturing.Views.Interfaces;
using MarkCapturing.Views.Security;
using System;
using System.Windows.Forms;

namespace MarkCapturing.Views
{
    public partial class FormMenu : Form, IMenuView
    {
        private readonly MenuPresenter _presenter;
        private readonly ILoginView loginView;
        public string Username => loginView.Username;

        public string Role => loginView.Role;

        public FormMenu(ILoginView _loginView)
        {
            InitializeComponent();
            loginView = _loginView;
            _presenter = new MenuPresenter(this);
            LblUserLoggedin.Text = loginView.Username;
        }
        private void BtnSecurity_Click(object sender, EventArgs e)
        {
            //FormResetPasswordRequests formResetPasswordRequests = new FormResetPasswordRequests(Username);
            //formResetPasswordRequests.Show();
            FormSecuritySystemParameters formResetPassword = new FormSecuritySystemParameters(this);
            formResetPassword.Show();
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            BtnClose_Click(sender, e);
        }

        private void BtnUpdateQuestion_Click(object sender, EventArgs e)
        {

        }

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
        public void GetForm()
        {
            _presenter.InitializeView();
        }
        public void ShowMenuForm()
        {
            this.Show();
        }

        public void ShowCapturerForm()
        {
            FormCapturer formCapturer = new FormCapturer();
            formCapturer.Show();
        }

        public void ShowSuperuserForm()
        {
            FormSuperuser formSuperuser = new FormSuperuser();
            formSuperuser.Show();
        }

        public void ShowVerifierForm()
        {
            FormVerifier formVerifier = new FormVerifier();
            formVerifier.Show();
        }

        public void ShowScriptsForm()
        {
            FormScripts formScripts = new FormScripts();
            formScripts.Show();
        }

        public void ShowBoxerForm()
        {
            FormBoxer formBoxer = new FormBoxer();
            formBoxer.Show();
        }

        public void ShowScriptInForm()
        {
            FormScriptIn formScriptIn = new FormScriptIn();
            formScriptIn.Show();
        }

        public void ShowScriptOutForm()
        {
            FormScriptOut formScriptOut = new FormScriptOut();
            formScriptOut.Show();
        }

        public void showErrorMessage(string message)
        {
            MessageBox.Show(message, "Login Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //#region ButtonMouseHoverEvents
        //private void BtnUpdateQuestion_MouseHover(object sender, EventArgs e)
        //{
        //    //Color of the current button when hovering
        //    BtnUpdateQuestion.ForeColor = Color.White;
        //    BtnUpdateQuestion.BackColor = Color.FromArgb(41, 128, 185);

        //    //Color of other buttons
        //    BtnSecurity.BackColor = SystemColors.Control;
        //    BtnSecurity.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnReports.ForeColor = Color.FromArgb(41, 128, 185);
        //    BtnReports.BackColor = Color.White;

        //    BtnExit.BackColor = SystemColors.Control;
        //    BtnExit.ForeColor = Color.FromArgb(41, 128, 185);
        //}

        //private void BtnReports_MouseHover(object sender, EventArgs e)
        //{
        //    //Color of the current button when hovering
        //    BtnReports.BackColor = Color.FromArgb(41, 128, 185);
        //    BtnReports.ForeColor = Color.White;

        //    //Color of other buttons
        //    BtnSecurity.BackColor = SystemColors.Control;
        //    BtnSecurity.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnUpdateQuestion.BackColor = SystemColors.Control;
        //    BtnUpdateQuestion.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnExit.BackColor = SystemColors.Control;
        //    BtnExit.ForeColor = Color.FromArgb(41, 128, 185);
        //}

        //private void BtnSecurity_MouseHover(object sender, EventArgs e)
        //{
        //    //Color of the current button when hovering
        //    BtnSecurity.BackColor = Color.FromArgb(41, 128, 185);
        //    BtnSecurity.ForeColor = Color.White;

        //    //Color of other buttons
        //    BtnReports.BackColor = SystemColors.Control;
        //    BtnReports.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnExit.BackColor = SystemColors.Control;
        //    BtnExit.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnUpdateQuestion.BackColor = SystemColors.Control;
        //    BtnUpdateQuestion.ForeColor = Color.FromArgb(41, 128, 185);
        //}

        //private void BtnExit_MouseHover(object sender, EventArgs e)
        //{
        //    //Color of the current button when hovering
        //    BtnExit.BackColor = Color.FromArgb(41, 128, 185);
        //    BtnExit.ForeColor = Color.White;

        //    //Color of other buttons
        //    BtnReports.BackColor = SystemColors.Control;
        //    BtnReports.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnUpdateQuestion.BackColor = SystemColors.Control;
        //    BtnUpdateQuestion.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnSecurity.BackColor = SystemColors.Control;
        //    BtnSecurity.ForeColor = Color.FromArgb(41, 128, 185);
        //}
        //#endregion
    }
}
