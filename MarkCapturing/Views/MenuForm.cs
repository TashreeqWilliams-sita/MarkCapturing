using System;
using System.Windows.Forms;
using MarkCapturing.Views;

namespace MarkCapturing.Views
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BtnUpdateQuestionMarks_Click(object sender, EventArgs e)
        {
            UpdateQuestionMarksForm updateForm = new UpdateQuestionMarksForm();
            updateForm.Show();
        }

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
    }
}
