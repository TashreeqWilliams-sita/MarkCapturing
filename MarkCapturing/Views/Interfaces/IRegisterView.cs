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
        string Username { get; set; }
        string UserPassword { get; set; }
        //int? UserLevel { get; set; }
        string UserIDNumber { get; set; }
        string SelectedRole { get; }
        //List<string> GetListOfRoles();
        //User User { get; set; }
        //void RegisterUser();
        void ShowMessage(string msg);
        void PopulateDropdown(List<string> Roles);






    }
}
