using DataAccessLibrary;
using DataAccessLibrary.Interfaces;
using MarkCapturing.Services;
using MarkCapturing.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Presenter
{
    public class RegisterPresenter
    {
        private readonly IRegisterView registerView;
        private readonly RegisterUserService registeruserservice;
        public string username;
        public string password;
        public string IDnumber;
        public string Role;
        public short Level;
        public Guid GetGuid = Guid.NewGuid();
        public RegisterPresenter(IRegisterView view)
        {
            registeruserservice = new RegisterUserService();
            registerView = view;
            registerView.ButtonRegisterClicked += RegisterView_ButtonRegisterClicked;
            PopulateDropdown();
        }

        private void RegisterView_ButtonRegisterClicked(object sender, EventArgs e)
        {
            if (!IsEmptyValues())
            {
                if (!IsExistingUser())
                {
                    registerView.ShowMessage($"{username} was successfully registered!!");
                    registerView.ClearControls();
                }
                else
                {
                    registerView.ShowMessage($"Failed to register!! {username}; User already exist\nPlease register a user that does not exist already!!");
                    registerView.ClearControls();
                }
            }
            else
            {
                registerView.ShowMessage("Some values are empty please check and try again!!");
            }

        }

        public bool IsEmptyValues()
        {
            username = registerView.Username;
            password = registerView.UserPassword;
            IDnumber = registerView.UserIDNumber;
            Role = registerView.SelectedRole;
            if (string.IsNullOrWhiteSpace(username))
            {
                registerView.ShowMessage("Username entered is not a valid username, choose a correct username");
                return true;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                registerView.ShowMessage("Password is empty");
                return true;
            }
            else if (string.IsNullOrWhiteSpace(IDnumber))
            {
                registerView.ShowMessage("ID number is empty");
                return true;
            }
            else if (string.IsNullOrWhiteSpace(Role))
            {
                registerView.ShowMessage("Please select a role");
                return true;
            }
            else
                return false;
        }
        public bool IsExistingUser()
        {
            username = registerView.Username;
            password = registerView.UserPassword;
            IDnumber = registerView.UserIDNumber;
            Role = registerView.SelectedRole;
            Level = registerView.UserLevel;
            if (registeruserservice.IsUserRegistered(username, password, IDnumber, Level, GetGuid))
                return false;
            else
                return true;
        }
        public void PopulateDropdown()
        {
            //List<string> LstRoles = registeruserservice.GetListOfRoles();
            //registerView.PopulateDropdown(LstRoles);

            List<string> LstLevels = new List<string>
            {
                "1","2","4","5","6","7"
            };
            registerView.PopulateDropdown(LstLevels);
        }
    }
}
