using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interfaces
{
    public interface IUpdateQuestionsView
    {
        string MarksheetNumber { get; }
        void ShowErrorMessage(string message);
        void ShowListScoresheet(List<Scoresheets> ScoresheetList);
        //void ShowRecords();
        //string GetMarksheetNumber();
        //void DisplayInformation(Vraagleer vag);
        void ClearMarkTextBoxes();
        string[] GetEnteredData();
        //void ShowNoInformationFound();
        //void ShowSubjectsProcessed();
    }
}
