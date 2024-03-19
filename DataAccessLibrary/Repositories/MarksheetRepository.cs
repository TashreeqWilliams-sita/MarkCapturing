using DTOs;
using System.Collections.Generic;
using System;
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
		MarksheetDTO marksheetDTO = new MarksheetDTO();
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
        public MarksheetDTO GetScoresheetRecords(string marksheetnumber)
        {
			var tables = new List<Func<NSC_VraagpunteStelselEntities, IQueryable<dynamic>>> {
				dbContext => dbContext.EKS_VraagPunte_A_ACCN10,
				dbContext => dbContext.EKS_VraagPunte_A_ACCN20,
				dbContext => dbContext.EKS_VraagPunte_A_ACCNZ10,
				dbContext => dbContext.EKS_VraagPunte_A_AFRFA10,
				dbContext => dbContext.EKS_VraagPunte_A_AFRFA20,
				dbContext => dbContext.EKS_VraagPunte_A_AFRFA30,
				dbContext => dbContext.EKS_VraagPunte_A_AFRHL10,
				dbContext => dbContext.EKS_VraagPunte_A_AFRHL20,
				dbContext => dbContext.EKS_VraagPunte_A_AFRHL30,
				dbContext => dbContext.EKS_VraagPunte_A_AFRSA10,
				dbContext => dbContext.EKS_VraagPunte_A_AFRSA20,
				dbContext => dbContext.EKS_VraagPunte_A_AFRSA30,
				dbContext => dbContext.EKS_VraagPunte_A_AGRM10,
				dbContext => dbContext.EKS_VraagPunte_A_AGRS10,
				dbContext => dbContext.EKS_VraagPunte_A_AGRS20,
				dbContext => dbContext.EKS_VraagPunte_A_AGRT10,
				dbContext => dbContext.EKS_VraagPunte_A_ARBSA10,
				dbContext => dbContext.EKS_VraagPunte_A_ARBSA20,
				dbContext => dbContext.EKS_VraagPunte_A_BSTD10,
				dbContext => dbContext.EKS_VraagPunte_A_BSTD20,
				dbContext => dbContext.EKS_VraagPunte_A_BSTDZ10,
				dbContext => dbContext.EKS_VraagPunte_A_CATN10,
				dbContext => dbContext.EKS_VraagPunte_A_CATN20,
				dbContext => dbContext.EKS_VraagPunte_A_CHNSA10,
				dbContext => dbContext.EKS_VraagPunte_A_CNST10,
				dbContext => dbContext.EKS_VraagPunte_A_CVTC10,
				dbContext => dbContext.EKS_VraagPunte_A_CVTV10,
				dbContext => dbContext.EKS_VraagPunte_A_CVTW10,
				dbContext => dbContext.EKS_VraagPunte_A_DNCE10,
				dbContext => dbContext.EKS_VraagPunte_A_DRMA10,
				dbContext => dbContext.EKS_VraagPunte_A_DSGN10,
				dbContext => dbContext.EKS_VraagPunte_A_ECON10,
				dbContext => dbContext.EKS_VraagPunte_A_ECON20,
				dbContext => dbContext.EKS_VraagPunte_A_ELTD10,
				dbContext => dbContext.EKS_VraagPunte_A_ELTE10,
				dbContext => dbContext.EKS_VraagPunte_A_ELTP10,
				dbContext => dbContext.EKS_VraagPunte_A_ENGFA10,
				dbContext => dbContext.EKS_VraagPunte_A_ENGFA20,
				dbContext => dbContext.EKS_VraagPunte_A_ENGFA30,
				dbContext => dbContext.EKS_VraagPunte_A_ENGHL10,
				dbContext => dbContext.EKS_VraagPunte_A_ENGHL20,
				dbContext => dbContext.EKS_VraagPunte_A_ENGHL30,
				dbContext => dbContext.EKS_VraagPunte_A_ENGSA10,
				dbContext => dbContext.EKS_VraagPunte_A_ENGSA20,
				dbContext => dbContext.EKS_VraagPunte_A_ENGSA30,
				dbContext => dbContext.EKS_VraagPunte_A_EQNS10,
				dbContext => dbContext.EKS_VraagPunte_A_FRHSA10,
				dbContext => dbContext.EKS_VraagPunte_A_FRHSA20,
				dbContext => dbContext.EKS_VraagPunte_A_GEOG10,
				dbContext => dbContext.EKS_VraagPunte_A_GEOG20,
				dbContext => dbContext.EKS_VraagPunte_A_GRDS10,
				dbContext => dbContext.EKS_VraagPunte_A_GRDS20,
				dbContext => dbContext.EKS_VraagPunte_A_GRMSA10,
				dbContext => dbContext.EKS_VraagPunte_A_GRMSA20,
				dbContext => dbContext.EKS_VraagPunte_A_HBRSA10,
				dbContext => dbContext.EKS_VraagPunte_A_HBRSA20,
				dbContext => dbContext.EKS_VraagPunte_A_HIST10,
				dbContext => dbContext.EKS_VraagPunte_A_HIST20,
				dbContext => dbContext.EKS_VraagPunte_A_HOSP10,
				dbContext => dbContext.EKS_VraagPunte_A_INFT10,
				dbContext => dbContext.EKS_VraagPunte_A_INFT20,
				dbContext => dbContext.EKS_VraagPunte_A_LFSC10,
				dbContext => dbContext.EKS_VraagPunte_A_LFSC20,
				dbContext => dbContext.EKS_VraagPunte_A_MANSA10,
				dbContext => dbContext.EKS_VraagPunte_A_MANSA20,
				dbContext => dbContext.EKS_VraagPunte_A_MATH10,
				dbContext => dbContext.EKS_VraagPunte_A_MATH20,
				dbContext => dbContext.EKS_VraagPunte_A_MCTA10,
				dbContext => dbContext.EKS_VraagPunte_A_MCTF10,
				dbContext => dbContext.EKS_VraagPunte_A_MCTW10,
				dbContext => dbContext.EKS_VraagPunte_A_MLIT10,
				dbContext => dbContext.EKS_VraagPunte_A_MLIT20,
				dbContext => dbContext.EKS_VraagPunte_A_MRSC10,
				dbContext => dbContext.EKS_VraagPunte_A_MRSC20,
				dbContext => dbContext.EKS_VraagPunte_A_MRTE10,
				dbContext => dbContext.EKS_VraagPunte_A_MUSC10,
				dbContext => dbContext.EKS_VraagPunte_A_RLGS10,
				dbContext => dbContext.EKS_VraagPunte_A_RLGS20,
				dbContext => dbContext.EKS_VraagPunte_A_RLGSZ10,
				dbContext => dbContext.EKS_VraagPunte_A_RLGSZ20,
				dbContext => dbContext.EKS_VraagPunte_A_SASHL10,
				dbContext => dbContext.EKS_VraagPunte_A_SASHL20,
				dbContext => dbContext.EKS_VraagPunte_A_SASHL30,
				dbContext => dbContext.EKS_VraagPunte_A_SESHL10,
				dbContext => dbContext.EKS_VraagPunte_A_SESHL20,
				dbContext => dbContext.EKS_VraagPunte_A_SESHL30,
				dbContext => dbContext.EKS_VraagPunte_A_SPES10,
				dbContext => dbContext.EKS_VraagPunte_A_SPNSA10,
				dbContext => dbContext.EKS_VraagPunte_A_SPNSA20,
				dbContext => dbContext.EKS_VraagPunte_A_TMAT10,
				dbContext => dbContext.EKS_VraagPunte_A_TMAT20,
				dbContext => dbContext.EKS_VraagPunte_A_TRNP710,
				dbContext => dbContext.EKS_VraagPunte_A_TRSM10,
				dbContext => dbContext.EKS_VraagPunte_A_TSCE10,
				dbContext => dbContext.EKS_VraagPunte_A_TSCE20,
				dbContext => dbContext.EKS_VraagPunte_A_URDFA10,
				dbContext => dbContext.EKS_VraagPunte_A_URDFA20,
				dbContext => dbContext.EKS_VraagPunte_A_URDFA30,
				dbContext => dbContext.EKS_VraagPunte_A_URDSA10,
				dbContext => dbContext.EKS_VraagPunte_A_URDSA20,
				dbContext => dbContext.EKS_VraagPunte_A_VSLA10,
				dbContext => dbContext.EKS_VraagPunte_A_XHOFA10,
				dbContext => dbContext.EKS_VraagPunte_A_XHOFA20,
				dbContext => dbContext.EKS_VraagPunte_A_XHOFA30,
				dbContext => dbContext.EKS_VraagPunte_A_XHOHL10,
				dbContext => dbContext.EKS_VraagPunte_A_XHOHL20,
				dbContext => dbContext.EKS_VraagPunte_A_XHOHL30,
				dbContext => dbContext.EKS_VraagPunte_A_XHOSA10,
				dbContext => dbContext.EKS_VraagPunte_A_XHOSA20,
				dbContext => dbContext.EKS_VraagPunte_A_XHOSA30,
				dbContext => dbContext.EKS_VraagPunte_A_ZULFA10,
				dbContext => dbContext.EKS_VraagPunte_A_ZULFA20,
				dbContext => dbContext.EKS_VraagPunte_A_ZULFA30,
				dbContext => dbContext.EKS_VraagPunte_A_ZULHL10,
				dbContext => dbContext.EKS_VraagPunte_A_ZULHL20,
				dbContext => dbContext.EKS_VraagPunte_A_ZULHL30,
};

			IEnumerable<dynamic> result = null;

			foreach (var tableFunc in tables)
			{
				var tableData = tableFunc(dbContext);
				var puntestate = dbContext.Puntestates.ToList(); // Materialize the Puntestate table

				foreach (var v in tableData)
				{
					var matchedP = puntestate.FirstOrDefault(p =>
					RemoveDots(p.VraestelKode) == RemoveDots(v.PS_VRAESTELKODE) &&
					p.Puntestaat == marksheetnumber);


					if (matchedP != null)
					{
						result = new List<dynamic> { v };
						goto EndOfLoop;
					}
				}
			}

		EndOfLoop:

			if (result != null)
			{
				var resultList = result.ToList();
				if (resultList.Count > 0)
                {
					dynamic firstResult = (dynamic)resultList[0];

					marksheetDTO = new MarksheetDTO();
					
					marksheetDTO.PS_GEKONTROLEERDEPUNT = GetValueOrDefault<float>(firstResult, "PS_GEKONTROLEERDEPUNT");
					marksheetDTO.Hash = GetValueOrDefault <double>(firstResult, "Hash");
					marksheetDTO.PS_ID_NO = GetValueOrDefault <string>(firstResult, "PS_ID_NO");
					marksheetDTO.PS_KODE = GetValueOrDefault <string>(firstResult, "PS_KODE");
					marksheetDTO.PS_Msheet = GetValueOrDefault <string>(firstResult, "PS_Msheet");
					marksheetDTO.PS_KAFTOTAAL = GetValueOrDefault <float?>(firstResult, "PS_KAFTOTAAL");
					marksheetDTO.PS_VRAESTELKODE = GetValueOrDefault<string>(firstResult, "PS_VRAESTELKODE");
					marksheetDTO.PS_EKS_DAT = GetValueOrDefault<int>(firstResult, "PS_EKS_DAT");
					marksheetDTO.PS_VRAAG_1 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_1");
					marksheetDTO.PS_VRAAG_2 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_2");
					marksheetDTO.PS_VRAAG_3 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_3");
					marksheetDTO.PS_VRAAG_4 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_4");
					marksheetDTO.PS_VRAAG_5 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_5");
					marksheetDTO.PS_VRAAG_6 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_6");
					marksheetDTO.PS_VRAAG_7 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_7");
					marksheetDTO.PS_VRAAG_8 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_8");
					marksheetDTO.PS_VRAAG_9 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_9");
					marksheetDTO.PS_VRAAG_10 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_10");
					marksheetDTO.PS_VRAAG_11 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_11");
					marksheetDTO.PS_VRAAG_12 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_12");
					marksheetDTO.PS_VRAAG_13 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_13");
					marksheetDTO.PS_VRAAG_14 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_14");
					marksheetDTO.PS_VRAAG_15 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_15");
					marksheetDTO.PS_MarksheetSort = GetValueOrDefault<Int32>(firstResult, "PS_MarksheetSort");
					
				}
				

            }
			return marksheetDTO;
		}
		// Method to safely retrieve property value or return default value if property doesn't exist
		T GetValueOrDefault<T>(dynamic obj, string propertyName)
		{
			if (obj.GetType().GetProperty(propertyName) != null)
			{
				return (T)obj.GetType().GetProperty(propertyName).GetValue(obj, null);
			}
			else
			{
				return default(T);
			}
		}
		string RemoveDots(string input)
		{
			return input.Replace(".", "");
		}

		//Let's check if the marksheet number exists?
		public bool CheckMarksheetNumber(string MarksheetNumber)
        {
            bool marksheetExists = dbContext.EKS_PUNTESTATE.Any(m => m.PS_Msheet == MarksheetNumber);
            return marksheetExists;
        }

		//Get by marksheet number

		public List<string> GetByMarksheet(string marksheet)
		{
			return dbContext.EKS_PUNTESTATE
			  .Where(x => x.PS_Msheet == marksheet)
			  .Select(x => x.PS_ID_NO)
			  .ToList();
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
