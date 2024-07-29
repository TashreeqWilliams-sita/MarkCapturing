using DataAccessLibrary;
using MarkCapturing.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace MarkCapturing.Presenter
{

    public class QuestionPaperPresenter : IQuestionPaperPresenter
    {
        private readonly QuestionPaperRepository repository;
        //private readonly QuestionPaperRepository repository;
        private readonly IQuestionPaperView view;

        public QuestionPaperPresenter(QuestionPaperRepository repository/*, IQuestionPaperView view*/)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
           
        }

        public void CreateOrUpdateQuestionPaper(string eksamen, string vraestelKode, int vraestelMaksimum, short? getalVraeOpVraestel)
        {
            repository.CreateOrUpdateQuestionPaper(eksamen, vraestelKode, vraestelMaksimum, getalVraeOpVraestel);
        }

        public List<string> GetEksamenList()
        {
            return repository.GetEksamenList();
        }

        public List<string> GetVraestelKodeList()
        {
            return repository.GetVraestelKodeList();
        }
        public VraagleerDTO GetQuestionPaperDetails(string eksamen, string vraestelKode)
        {
            return repository.GetQuestionPaperDetails(eksamen, vraestelKode);
        }

        public int? GetMaxMark(string eksamen, string vraestelKode)
        {

            return repository.GetMaxMark(eksamen, vraestelKode);
        }
        public int? GetQuestionNo(string eksamen, string vraestelKode)
        {

            return repository.GetQuestionNo(eksamen, vraestelKode);
        }
        public int? GetSelectionAmount(string eksamen, string vraestelKode)
        {
            return repository.GetSelectionAmount(eksamen, vraestelKode);
        }
        public void UpdateVraestelMaksimum(string eksamen, string vraestelKode, int newMaxMark)
        {
            repository.UpdateVraestelMaksimum(eksamen, vraestelKode, newMaxMark);
        }
        public void UpdateGetalVraeOpVraestel(string eksamen, string vraestelKode, short? getalVraeOpVraestel)
        {
            repository.UpdateGetalVraeOpVraestel(eksamen, vraestelKode, getalVraeOpVraestel);
        }
        public void UpdateGetalKombinasiesTeBeantwoord(string eksamen, string vraestelKode, short? getalKombinasiesTeBeantwoord)
        {
            repository.UpdateGetalKombinasiesTeBeantwoord(eksamen, vraestelKode, getalKombinasiesTeBeantwoord);
        }
        
        public void SaveQuestionPaperDetails(string eksamen, string vraestelKode, VraagleerDTO vraagleerDTO) 
        {
            repository.SaveQuestionPaperDetails(eksamen, vraestelKode, vraagleerDTO);
        }
        public VraagleerDTO UpdateCombinationTotalTextboxes(string eksamen, string vraestelKode)
        {
            return repository.UpdateCombinationTotalTextboxes(eksamen, vraestelKode);
        }
        //public Vraagleer GetQuestionPaperDetails(string eksamen, string vraestelKode)
        //{
        //    try
        //    {
        //        Vraagleer questionPaper = repository.GetQuestionPaperDetails(eksamen, vraestelKode);

        //        if (questionPaper != null)
        //        {
        //            // Assuming IQuestionPaperView has methods to display the data.
        //            //view.DisplayQuestionPaperDetails(questionPaper);
        //            // Return the question paper or a collection containing the question paper.
        //            return  questionPaper;
        //        }
        //        else
        //        {
        //            // If questionPaper is null, you need to decide what to return or throw an exception.
        //            // You can return an empty collection or throw an exception.
        //            // Return an empty collection as an example.
        //            return new List<Vraagleer>();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception or rethrow it.
        //        throw; // Rethrow the exception.
        //    }
        //}


    }
}
