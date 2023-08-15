using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Views.Interfaces
{
    public interface IRegisterView
    {
        event EventHandler ButtonRegisterClicked;
        string LoggedInUser { get; }
        string Username { get; set; }
        string UserPassword { get; set; }
        short UserLevel { get; set; }
        string UserIDNumber { get; set; }
        string SelectedRole { get; set; }
        void ShowMessage(string msg);
        void ClearControls();
        void PopulateDropdown(List<string> Roles);






    }
}
