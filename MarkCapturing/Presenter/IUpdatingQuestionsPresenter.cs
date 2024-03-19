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
        public void ShowList();

        public bool ValidateMarksheet(string MarksheetNo);

        public void SaveMarks(string subcode, string marks);

        public MarksheetDTO GetScoresheetRecords(string marksheetnumber);

        public void SearchMarksheet();
        List<string> GetByMarksheet(string marksheet);
    }


}
