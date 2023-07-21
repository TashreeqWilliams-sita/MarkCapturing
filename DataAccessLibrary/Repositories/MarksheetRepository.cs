using System.Collections.Generic;
using System.Linq;

namespace DataAccessLibrary.Repositories
{
    //In the repository we will handle database operations related to our EKS_PUNTESTATE and Vraagleer tables
    //We need to get by marksheet number
    //get all records based on our marksheet number
    //get  subject code, number of questions and paper number from two tables second table is Vraagleer
    // Note PUNTESTATE is SCORESHEET
    //Once we finish with our repository we move to the Views and implement interfaces

    public class MarksheetRepository
    {
        #region PrivateProperties
        private readonly NSC_VraagpunteStelselEntities dbContext;
        #endregion

        #region Constructor
        public MarksheetRepository(NSC_VraagpunteStelselEntities context)
        {
            this.dbContext = context;
        }
        #endregion

        #region QueryOption1
        public EKS_PUNTESTATE GetDetailsByMNoFromPunte(string marksheetno)
        {
            return dbContext.EKS_PUNTESTATE.Where(a => a.PS_Msheet == marksheetno).ToList().FirstOrDefault();
        }
        public Vraagleer GetVragRec(string subcode, short? pNumberPunte, string marksheet)
        {
            var PunteRecords = GetDetailsByMNoFromPunte(marksheet);
            subcode = PunteRecords.PS_VAKKODE;
            pNumberPunte = PunteRecords.PS_VRSTEL_NO;
            return dbContext.Vraagleers.Where(a => a.Vakkode == subcode && a.VraestelNommer == pNumberPunte).ToList().FirstOrDefault();
        }
        #endregion

        #region Option2List
        //We will use LINQ and EF Core to join our two tables and get records from them
        public List<Scoresheets> GetScoresheetRecords(string marksheetnumber)
        {
            var ScoresheetRecords = (from p in dbContext.EKS_PUNTESTATE
                                     join v in dbContext.Vraagleers on p.PS_VAKKODE equals v.Vakkode
                                     where p.PS_Msheet == marksheetnumber
                                     select new Scoresheets
                                     {
                                         MarksheetNumber = p.PS_Msheet,
                                         SubjectCode = p.PS_VAKKODE,
                                         ID_NO = p.PS_ID_NO,
                                         PaperNumberPunte = p.PS_VRSTEL_NO,
                                         PaperNumber = v.VraestelNommer,
                                         NumberOfQuestions = v.GetalVraeOpVraestel
                                     }).ToList();

            return ScoresheetRecords;
        }
        //Let's check if the marksheet number exists?
        public bool CheckMarksheetNumber(string MarksheetNumber)
        {
            bool marksheetExists = dbContext.EKS_PUNTESTATE.Any(m => m.PS_Msheet == MarksheetNumber);
            return marksheetExists;
        }

        //Get by marksheet number
        public EKS_PUNTESTATE GetByMarksheeet(string marksheet)
        {
            return dbContext.EKS_PUNTESTATE.FirstOrDefault(m => m.PS_Msheet == marksheet);
        }
        #endregion

        #region SaveMarks
        public void SaveMarks(string subCode, string SubMarks)
        {
            using (dbContext)
            {
                //Find the subject with the given subject code
                var subject = dbContext.Vraagleers.FirstOrDefault(s => s.Vakkode == subCode);
                if (subject != null)
                {
                    //Check first the next available mark column
                    int nextMarkNo = 1;
                    while (nextMarkNo <= 30)
                    {
                        string markColumnName = $"VraagMaks{nextMarkNo}";

                        //check to see if the mark column is empty
                        if (string.IsNullOrEmpty(subject.GetType().GetProperty(markColumnName)?.GetValue(subject) as string))
                        {
                            //Update the mark Column with the new mark
                            subject.GetType().GetProperty(markColumnName)?.SetValue(subject, SubMarks);
                            break;

                        }
                        nextMarkNo++;
                    }
                    //save changes
                    dbContext.SaveChanges();
                }
                else
                {
                    //error messages when module is not found will implement this later on
                }
            }
        }
        #endregion

    }
}
