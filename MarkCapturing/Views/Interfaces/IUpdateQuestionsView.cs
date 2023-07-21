using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Views.Interfaces
{
    public interface IUpdateQuestionsView
    {
        string MarksheetNumber { get; }
        void ShowErrorMessage(string message);
        void ShowListScoresheet(List<Scoresheets> ScoresheetList);
        void ClearMarkTextBoxes();
        string[] GetEnteredData();
    }
}
