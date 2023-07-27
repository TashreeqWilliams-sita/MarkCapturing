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
    public partial class ResetPasswordForm : Form
    {
        private readonly SystemSecurityForm systemSecurityForm;
        public ResetPasswordForm()
        {
            systemSecurityForm = new SystemSecurityForm();
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            //When Succeded on reseting password go back to the previous form
            systemSecurityForm.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            systemSecurityForm.Show();
        }
    }
}
