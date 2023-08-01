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
        public FormRegister()
        {
            view = this;
            registerPresenter = new RegisterPresenter(this);
            InitializeComponent();
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
            get
            {
                return ComboBoxRoles.SelectedItem?.ToString();
            }
        }

        public event EventHandler ButtonRegisterClicked;

        public void PopulateDropdown(List<string> Roles)
        {
            //ComboBoxRoles.Items.Clear();
            ComboBoxRoles.SelectedIndex = 0;
            ComboBoxRoles.Items.AddRange(Roles.ToArray());
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg,"Message!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            ButtonRegisterClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
