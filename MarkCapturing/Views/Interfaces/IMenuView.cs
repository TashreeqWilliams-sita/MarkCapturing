namespace MarkCapturing.Views.Interfaces
{
    public interface IMenuView
    {
        string Username { get; }
        string Role { get; }
        void ShowMenuForm();
        void ShowCapturerForm();
        void ShowSuperuserForm();
        void ShowVerifierForm();
        void ShowScriptsForm();
        void ShowBoxerForm();
        void ShowScriptInForm();
        void GetForm();
        void ShowScriptOutForm();
        void showErrorMessage(string message);
    }
}
