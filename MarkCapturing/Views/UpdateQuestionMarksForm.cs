using System;
using System.Windows.Forms;

namespace MarkCapturing.Views
{
    public partial class UpdateQuestionMarksForm : Form
    {
        public UpdateQuestionMarksForm()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdateMarks_Click(object sender, EventArgs e)
        {
            UpdatingQuestionsForm updatingQuestions = new UpdatingQuestionsForm();
            updatingQuestions.Show();
        }

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
    }
}
