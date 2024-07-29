using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Presenter
{
    public interface IQuestionPaperPresenter
    {
        void CreateOrUpdateQuestionPaper(string eksamen, string vraestelKode, int vraestelMaksimum, short? getalVraeOpVraestel);


        //void GetQuestionPaper(string eksamen, string vraestelKode);

        List<string> GetEksamenList();


        List<string> GetVraestelKodeList();

        VraagleerDTO GetQuestionPaperDetails(string eksamen, string vraestelKode);


        int? GetMaxMark(string eksamen, string vraestelKode);

        int? GetQuestionNo(string eksamen, string vraestelKode);
        int? GetSelectionAmount(string eksamen, string vraestelKode);

        void UpdateVraestelMaksimum(string eksamen, string vraestelKode, int newMaxMark); 

        void UpdateGetalVraeOpVraestel(string eksamen, string vraestelKode, short? getalVraeOpVraestel);

        void UpdateGetalKombinasiesTeBeantwoord(string eksamen, string vraestelKode, short? getalKombinasiesTeBeantwoord);

        void SaveQuestionPaperDetails(string eksamen, string vraestelKode, VraagleerDTO vraagleerDTO);
        VraagleerDTO UpdateCombinationTotalTextboxes(string eksamen, string vraestelKode);

       //Vraagleer GetQuestionPaperDetails(string eksamen, string vraestelKode);




    }


}
