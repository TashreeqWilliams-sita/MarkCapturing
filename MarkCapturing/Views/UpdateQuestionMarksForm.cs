using System;
using MarkCapturing.Views.Security;
using MarkCapturing.Views.Interfaces;
using DataAccessLibrary.Interfaces;
using System.Windows.Forms;
using MarkCapturing.Presenter;

namespace MarkCapturing.Views
{
    public partial class UpdateQuestionMarksForm : Form, DataAccessLibrary.Interfaces.IUpdateQuestionMarksView
    {
        private readonly IMenuView menuView;
        private readonly UpdateQuestionsMenuPresenter _presenter;
        //private readonly ILoginView loginView;
       

        //public string Role => loginView.Role;


        public UpdateQuestionMarksForm(IMenuView _menuView)
        {
            InitializeComponent();
            menuView = _menuView;
            LblUserLoggedin.Text = Username;
        }
        public string Username => menuView.Username;

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void BtnUpdateMarks_Click(object sender, EventArgs e)
        //{
        //    UpdatingQuestionsForm updatingQuestions = new UpdatingQuestionsForm();
        //    updatingQuestions.Show();
        //}

        private void UpdateQuestionMarksForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            BtnClose_Click(sender, e);
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
                this.Hide();
            }
        }

        private void lblUpdateMark_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdateQuestion_Click(object sender, EventArgs e)
        {
            UpdatingQuestionsForm updatingQuestionsForm = new UpdatingQuestionsForm();
            updatingQuestionsForm.Show();
        }

    }
}
