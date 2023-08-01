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
        public RegisterPresenter(IRegisterView view)
        {
            registeruserservice = new RegisterUserService();
            registerView = view;
            PopulateDropdown();
            registerView.ButtonRegisterClicked += RegisterView_ButtonRegisterClicked;
        }

        private void RegisterView_ButtonRegisterClicked(object sender, EventArgs e)
        {
            string username = registerView.Username;
            string password = registerView.UserPassword;
            string IDnumber = registerView.UserIDNumber;
            string Role = registerView.SelectedRole;

            if (registeruserservice.IsUserRegistered(username,password,IDnumber,Role))
            {
                registerView.ShowMessage($"{username} was successfully registered!!");
            }
            else
            {
                registerView.ShowMessage($"Failed to register!! {username}; User already exist\nPlease register a user that does not exist already!!");
            }
        }
        public void PopulateDropdown()
        {
            List<string> LstRoles = registeruserservice.GetListOfRoles();
            registerView.PopulateDropdown(LstRoles);
        }
    }
}
