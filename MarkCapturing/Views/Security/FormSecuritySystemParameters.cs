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
        private readonly IMenuView menuView;
        public FormSecuritySystemParameters(IMenuView _menuView)
        {
            InitializeComponent();
            menuView = _menuView;
            LblUserLoggedin.Text = Username;
        }

        public string Username => menuView.Username;

        private void BtnResetPasswordRequest_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormResetPasswordRequests formResetPasswordRequests = new FormResetPasswordRequests();
            formResetPasswordRequests.Show();
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            FormResetPassword formResetPassword = new FormResetPassword(Username);
            formResetPassword.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRegisterNewUser_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
        }
    }
}
