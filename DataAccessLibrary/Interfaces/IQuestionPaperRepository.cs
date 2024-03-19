using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interfaces
{
    interface IQuestionPaperRepository
    {
       void CreateOrUpdateQuestionPaper(string eksamen, string vraestelKode, int vraestelMaksimum, short? getalVraeOpVraestel);
       Vraagleer GetQuestionPaper(string eksamen, string vraestelKode);
       List<string> GetEksamenList();
       List<string> GetVraestelKodeList();
       
    }
}
