using DataAccessLibrary.Interfaces;
using MarkCapturingSystem.Services;

namespace MarkCapturing.Presenter
{
    class LogInPresenter
    {
        private readonly ILoginView loginView;
        private readonly AuthenticationService authenticationService;

        public LogInPresenter(ILoginView view)
        {
            loginView = view;
            authenticationService = new AuthenticationService();
        }
        public void OnLoginButtonClicked(string username, string password)
        {
            bool isValid = authenticationService.AuthenticateUser(username, password);

            if (isValid)
            {
                loginView.ShowLoginSuccess();
            }
            else
            {
                loginView.ShowInvalidCredentialsError();
            }
        }
    }
}
