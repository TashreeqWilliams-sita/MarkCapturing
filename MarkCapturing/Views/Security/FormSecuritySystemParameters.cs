using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLibrary;
using MarkCapturing.Views.Security;
using MarkCapturing.Views.Interfaces;
using DataAccessLibrary.Interfaces;

namespace MarkCapturing.Views
{
    public partial class FormSecuritySystemParameters : Form, DataAccessLibrary.Interfaces.IUpdateQuestionMarksView
    {
        public string Username = DataStorage.UserLoggedIn;
        public FormSecuritySystemParameters()
        {
            InitializeComponent();
            LblUserLoggedin.Text = Username;
        }
        
        private void BtnResetPasswordRequest_Click(object sender, EventArgs e)
        {
            //Hide();
            FormResetPasswordRequests formResetPasswordRequests = new FormResetPasswordRequests(Username);
            Program.FormNavController.ShowForm(formResetPasswordRequests);
            //formResetPasswordRequests.Show();
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            FormResetPassword formResetPassword = new FormResetPassword();
            Program.FormNavController.ShowForm(formResetPassword);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            Program.FormNavController.ShowForm(formMenu);
            //Close();
        }

        private void BtnRegisterNewUser_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            Program.FormNavController.ShowForm(formRegister);
            //formRegister.Show();
        }
    }
}
