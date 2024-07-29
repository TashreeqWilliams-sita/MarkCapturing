using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Views.Interfaces
{
    public interface IUpdateQuestionMarksView
    {
        string MarksheetNumber { get; }
        void ShowErrorMessage(string message);
        void ShowListScoresheet(List<Scoresheets> ScoresheetList);
        void ClearMarkTextBoxes();
        string[] GetEnteredData();

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
        
    }
}
