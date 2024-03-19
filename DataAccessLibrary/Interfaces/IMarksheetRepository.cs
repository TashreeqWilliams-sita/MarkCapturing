using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interfaces
{
    public interface IMarksheetRepository
    {
        List<Scoresheets> GetScoresheetsByMarksheetNumber(string studentNumber);

        EKS_PUNTESTATE GetDetailsByMNoFromPunte(string marksheetno);

        Vraagleer GetVragRec(string subcode, short? pNumberPunte, string marksheet);

        MarksheetDTO GetScoresheetRecords(string marksheetnumber);

        string RemoveDots(string input);

        bool CheckMarksheetNumber(string MarksheetNumber);

        EKS_PUNTESTATE GetByMarksheeet(string marksheet);

        void SaveMarks(string subCode, string SubMarks);
    }
}



