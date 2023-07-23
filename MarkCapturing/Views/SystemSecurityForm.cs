using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkCapturing.Views
{
    public partial class SystemSecurityForm : Form
    {
        public SystemSecurityForm()
        {
            InitializeComponent();
        }

        private void LblSystemSecurity_Click(object sender, EventArgs e)
        {

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
                this.Close();
            }
        }

        private void BtnRegisterUser_Click(object sender, EventArgs e)
        {

        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResetPasswordForm resetPasswordForm = new ResetPasswordForm();
            resetPasswordForm.Show();

        }
    }
}
