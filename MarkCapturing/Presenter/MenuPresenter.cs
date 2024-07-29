using MarkCapturing.Views.Interfaces;
using MarkCapturing.Services;

namespace MarkCapturing.Presenter
{
    public class MenuPresenter
    {
        private readonly IMenuView _view;
        private readonly AssigningRolesService rolesService;

        public MenuPresenter(IMenuView view)
        {
            _view = view;
            rolesService = new AssigningRolesService();
        }
        public void InitializeView()
        {
            if (rolesService.IsRoleAssigned(_view.Username))
            {
                //get assigned roles
                string UserRole = rolesService.AssignRoles(_view.Username);

                //Show or hide buttons based on user role
                if (UserRole == "Admin" || UserRole == "Supervisor")
                {
                    _view.ShowMenuForm();
                }
                else if (UserRole == "Capturer")
                {
                    _view.ShowCapturerForm();
                }
                else if (UserRole == "Superuser")
                {
                    _view.ShowSuperuserForm();
                }
                else if (UserRole == "Verifier")
                {
                    _view.ShowVerifierForm();
                }
                else if (UserRole == "Scripts")
                {
                    _view.ShowScriptsForm();
                }
                else if (UserRole == "Boxer")
                {
                    _view.ShowBoxerForm();
                }
                else if (UserRole == "ScriptIn")
                {
                    _view.ShowScriptInForm();
                }
                else if (UserRole == "ScriptOut")
                {
                    _view.ShowScriptOutForm();
                }
            }
            else
            {
                _view.showErrorMessage("User is empty, kindly type your username and password correctly;\nContact admin for more information");
            }
        }
    }
}
