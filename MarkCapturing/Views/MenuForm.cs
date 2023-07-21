using System;
using System.Windows.Forms;
using MarkCapturing.Presenter;
using DataAccessLibrary.Interfaces;
using MarkCapturing.Views.Interfaces;

namespace MarkCapturing.Views
{
    public partial class MenuForm : Form, IMenuView
    {
        private readonly MenuPresenter _presenter;
        private readonly ILoginView loginView;
        public string Username => loginView.Username;
        public string Role => loginView.Role;

        public MenuForm(ILoginView _loginView)
        {
            InitializeComponent();
            loginView = _loginView;
            _presenter = new MenuPresenter(this); 
            _presenter.InitializeView();
        }
        public void HideExitButton()
        {
            btnExit.Visible = false;
        }

        public void HideReportsButton()
        {
            btnReports.Visible = false;
        }

        public void HideSecurityButton()
        {
            btnSecurity.Visible = false;
        }

        public void HideUpdateQuestionMarksButton()
        {
            btnUpdateQuestionMarks.Visible = false;
        }

        public void ShowExitButton()
        {
            btnExit.Visible = true;
        }

        public void ShowReportsButton()
        {
            btnReports.Visible = true;
        }

        public void ShowSecurityButton()
        {
            btnSecurity.Visible = true;
        }

        public void ShowUpdateQuestionMarksButton()
        {
            btnSecurity.Visible = true;
        }

        private void BtnExit_Click(object sender, EventArgs e)
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

        private void BtnUpdateQuestionMarks_Click(object sender, EventArgs e)
        {
            UpdateQuestionMarksForm updateForm = new UpdateQuestionMarksForm();
            updateForm.Show();
        }

        #region FormClosing
        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            SystemSecurityForm systemSecurityForm = new SystemSecurityForm();
            systemSecurityForm.Show();
        }

        public void ShowMenuForm()
        {
            throw new NotImplementedException();
        }

        public void ShowCapturerForm()
        {
            throw new NotImplementedException();
        }

        public void ShowSuperuserForm()
        {
            throw new NotImplementedException();
        }

        public void ShowVerifierForm()
        {
            throw new NotImplementedException();
        }

        public void ShowScriptsForm()
        {
            throw new NotImplementedException();
        }

        public void ShowBoxerForm()
        {
            throw new NotImplementedException();
        }

        public void ShowScriptInForm()
        {
            throw new NotImplementedException();
        }

        public void GetForm()
        {
            throw new NotImplementedException();
        }

        public void ShowScriptOutForm()
        {
            throw new NotImplementedException();
        }

        public void showErrorMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
