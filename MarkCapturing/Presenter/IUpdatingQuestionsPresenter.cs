using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Presenter
{
    public interface IUpdatingQuestionsPresenter
    {
        void ShowList();

        //public bool ValidateMarksheet(string MarksheetNo);
        MarksheetDTO GetScoresheetRecords(string marksheetNumber);
        
       

        //public void SaveMarks(string subcode, string marks);

        //public MarksheetDTO GetScoresheetRecords(string marksheetnumber);

        //public void SearchMarksheet();
        //List<string> GetByMarksheet(string marksheet);
    }


}
