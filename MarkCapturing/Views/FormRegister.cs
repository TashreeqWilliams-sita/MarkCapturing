using DataAccessLibrary.Interfaces;
using MarkCapturing.Presenter;
using MarkCapturing.Views.Interfaces;
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
    public partial class FormRegister : Form, IRegisterView
    {
        private readonly RegisterPresenter registerPresenter;
        private readonly IRegisterView view;
        public string UserLoggedInName = DataStorage.UserLoggedIn;
        public FormRegister()
        {
            InitializeComponent();
            view = this;
            registerPresenter = new RegisterPresenter(this);
            LblUserLoggedin.Text = UserLoggedInName;
        }

        public string Username
        {
            get => TxtNewUsername.Text.Trim();
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    ShowMessage("Invalid username");
                }
                else
                {
                    Username = value;
                }
            }
        }
        public string UserPassword 
        { 
            get => TxtConfirmNewPassword.Text.Trim(); 
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (TxtNewPassword.Text.Trim() == TxtConfirmNewPassword.Text.Trim())
                    {
                        UserPassword = value;
                    }
                    else
                    {
                        ShowMessage("Passwords do not match");
                    }
                }
                else
                {
                    ShowMessage("Password field is empty please input password");
                }
            }
        }
        public string UserIDNumber
        {
            get => TxtIDNumber.Text.Trim();
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    UserIDNumber = value;
                }
                else
                {
                    ShowMessage("Invalid ID Number");
                }
            }
        }

        public string SelectedRole
        {
            get => ComboBoxRoles.SelectedItem?.ToString();
            set
            {
                if (value != null)
                {
                    SelectedRole = value;
                }
                else
                {
                    ShowMessage("Select Role!!");
                }
            }
        }
        private short Level;
        public short UserLevel
        {
            get
            {
                if (SelectedRole == "1")
                {
                    return Level = 1;
                }
                else if (SelectedRole == "2")
                {
                    return Level = 2;
                }
                else if (SelectedRole == "4")
                {
                    return Level = 4;
                }
                else if (SelectedRole == "5")
                {
                    return Level = 5;
                }
                else if (SelectedRole == "6")
                {
                    return Level = 6;
                }
                else if (SelectedRole == "7")
                {
                    return Level = 7;
                }
                else return Level;
            }
            set
            {
                Level = value;
            }
        }

        public event EventHandler ButtonRegisterClicked;

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg,"Message!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            FormSecuritySystemParameters formSecuritySystem = new FormSecuritySystemParameters();
            Program.FormNavController.ShowForm(formSecuritySystem);
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            ButtonRegisterClicked?.Invoke(this, EventArgs.Empty);
        }
        public void PopulateDropdown(List<string> Roles)
        {
            ComboBoxRoles.Items.Clear();
            ComboBoxRoles.Items.AddRange(Roles.ToArray());
        }

        public void ClearControls()
        {
            TxtConfirmNewPassword.Clear();
            TxtIDNumber.Clear();
            TxtNewPassword.Clear();
            TxtNewUsername.Clear();
            ComboBoxRoles.SelectedIndex = -1;
        }
    }
}
