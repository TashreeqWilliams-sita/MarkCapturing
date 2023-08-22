using System;
using System.Collections.Generic;
using DataAccessLibrary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Views
{
    //In the views interface we get our users input in this case the marksheet number
    //We also declare some few methods
    //Once we finish with our interface we move to the presenter
    public interface IUpdatingMarksView
    {
        string MarksheetNumber { get; }
        void ShowErrorMessage(string message);
        void ShowListScoresheet(List<Scoresheets> ScoresheetList);
        void ShowRecords();
    }
}
