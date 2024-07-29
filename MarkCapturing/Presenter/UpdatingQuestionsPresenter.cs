 using MarkCapturing.Views;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Repositories;
using DataAccessLibrary;
using System;
using System.Collections.Generic;
using DTOs;

namespace MarkCapturing.Presenter
{
    public class UpdatingQuestionsPresenter : IUpdatingQuestionsPresenter
    {
        private readonly MarksheetRepository marksheetRepository;
        private readonly IUpdatingMarksView view;

        public UpdatingQuestionsPresenter(IUpdatingMarksView _view)
        {
            this.view = _view;
            this.marksheetRepository = new MarksheetRepository(new DataAccessLibrary.NSC_VraagpunteStelselEntities());
        }
        #region NumOfQ
        //public int NumberOfQ()
        //{
        //        string marksheetnumber = view.MarksheetNumber;
        //        string subjectCode = "";
        //        short? numberOfQuestions;

        //        short? paperNoPUNTESTATE = 0;
        //        short? paperNoVraagleers = 0;

        //        int paperNumberVraagleers = (int)paperNoVraagleers;
        //        int paperNumberPUNTESTATE = (int)paperNoPUNTESTATE;

        //        var PunteRec = marksheetRepository.GetDetailsByMNoFromPunte(marksheetnumber);
        //        var VragRec = marksheetRepository.GetVragRec(subjectCode, paperNoPUNTESTATE, marksheetnumber);

        //        subjectCode = PunteRec.PS_VAKKODE;
        //        paperNumberPUNTESTATE = PunteRec.PS_VRSTEL_NO;

        //        paperNumberVraagleers = VragRec.VraestelNommer;

        //        int numberOfConvQuestions = 0;
        //        if (paperNumberVraagleers == paperNumberPUNTESTATE)
        //        {
        //            numberOfQuestions = VragRec.GetalVraeOpVraestel;
        //            numberOfConvQuestions = (int)numberOfQuestions;
        //        }
        //        return numberOfConvQuestions;
        //}
        #endregion


        public void ShowList()
        {
            //view.ShowRecords();
        }

        #region NewValidation
        //public bool ValidateMarksheet(string MarksheetNo)
        //{
        //    return marksheetRepository.CheckMarksheetNumber(MarksheetNo);
        //}
        #endregion
        //public void SaveMarks(string subcode, string marks)
        //{
        //    marksheetRepository.SaveMarks(subcode, marks);
        //}

        //private List<Scoresheets> RetrieveRecords(string MarksheetNo)
        //{
        //    List<Scoresheets> Scoresheets = new List<Scoresheets>();
        //    try
        //    {
        //        Scoresheets = marksheetRepository.GetScoresheetRecords(MarksheetNo);
        //    }
        //    catch (Exception ex)
        //    {
        //        view.ShowErrorMessage(ex.Message);
        //    }
        //    return Scoresheets;
        //}
        public MarksheetDTO GetScoresheetRecords(string marksheetNumber)
        {
            return marksheetRepository.GetMarksheetDetails(marksheetNumber);
        }
        public List<MarksheetDTO> GetExamNumberList(string psMsheet)
        {
            return marksheetRepository.GetExamNumberList(psMsheet);
        }
        //public MarksheetDTO GetScoresheetRecords(string marksheetnumber)
        //{
        //    return marksheetRepository.GetScoresheetRecords(marksheetnumber);
        //}
        //public List<string> GetByMarksheet(string marksheet)
        //{
        //    return marksheetRepository.GetByMarksheet(marksheet);
        //}
        //public void SearchMarksheet()
        //{
        //    string marksheetNumber = view.MarksheetNumber;
        //    //EKS_PUNTESTATE eKS_PUNTESTATE = marksheetRepository.GetByMarksheeet(marksheetNumber);
        //    //ValidateMarksheet(marksheetNumber);
        //    /*List<Scoresheets> scoresheets = RetrieveRecords(marksheetNumber);*/
        //    MarksheetDTO scoresheets = marksheetRepository.GetScoresheetRecords(marksheetNumber);
        //    view.ShowListScoresheet(scoresheets);
        //}
        //public void SaveMarkData()//will implement at a later stage
        //{
        //    string[] enteredData = view.GetEnteredData();
        //}
    }
}
