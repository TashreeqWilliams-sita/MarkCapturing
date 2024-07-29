using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTOs
{
    public class MarksheetDTO
    {
        public MarksheetDTO() {
			
				QuestionMarks = new Dictionary<string, float?>();
			StoredQuestionMarksForPSIDNO = new Dictionary<string, Dictionary<string, float?>>();


		}
		public Int16? GetalVraeOpVraestel { get; set; }
		public double Hash { get; set; }
		public Single? PS_GEKONTROLEERDEPUNT { get; set; }
		public Single? PS_KAFTOTAAL { get; set; }
		public Single? PS_VRAAG_1 { get; set; }
		public Single? PS_VRAAG_2 { get; set; }
		public Single? PS_VRAAG_3 { get; set; }
		public Single? PS_VRAAG_4 { get; set; }
		public Single? PS_VRAAG_5 { get; set; }
		public Single? PS_VRAAG_6 { get; set; }
		public Single? PS_VRAAG_7 { get; set; }
		public Single? PS_VRAAG_8 { get; set; }
		public Single? PS_VRAAG_9 { get; set; }
		public Single? PS_VRAAG_10 { get; set; }
		public Single? PS_VRAAG_11 { get; set; }
		public Single? PS_VRAAG_12 { get; set; }
		public Single? PS_VRAAG_13 { get; set; }
		public Single? PS_VRAAG_14 { get; set; }
		public Single? PS_VRAAG_15 { get; set; }
		public Single? PS_VRAAG_16 { get; set; }
		public Single? PS_VRAAG_17 { get; set; }
		public Single? PS_VRAAG_18 { get; set; }
		public Single? PS_VRAAG_19 { get; set; }
		public Single? PS_VRAAG_20 { get; set; }
		public Single? PS_VRAAG_21 { get; set; }
		public Single? PS_VRAAG_22 { get; set; }
		public Single? PS_VRAAG_23 { get; set; }
		public Single? PS_VRAAG_24 { get; set; }
		public Single? PS_VRAAG_25 { get; set; }
		public Single? PS_VRAAG_26 { get; set; }
		public Single? PS_VRAAG_27 { get; set; }
		public Single? PS_VRAAG_28 { get; set; }
		public Single? PS_VRAAG_29 { get; set; }
		public Single? PS_VRAAG_30 { get; set; }
		public Single? PS_VRAESTELPUNT { get; set; }
		public string PS_ID_NO { get; set; }
		public string PS_KODE { get; set; }
        public string PS_Msheet { get; set; }
        public string PS_ChangedBy { get; set; }
        public string PS_DateLastChanged { get; set; }
		public string VraestelKode { get; set; }
		public int PS_EKS_DAT { get; set; }
		public Int32 PS_MarksheetSort { get; set; }
		public byte? Status { get; set; }
		public int Sentrum { get; set; }
		public string VraestelNaam { get; set; }
		public Int16? GetalKombinasiesVanKeuseVrae { get; set; }

		public Int16? KeuseVraeEersteVrgNo1 { get; set; }
		public Int16? KeuseVraeEersteVrgNo2 { get; set; }
		public Int16? KeuseVraeEersteVrgNo3 { get; set; }
		public Int16? KeuseVraeEersteVrgNo4 { get; set; }
		public Int16? KeuseVraeEersteVrgNo5 { get; set; }
		public Int16? KeuseVraeEersteVrgNo6 { get; set; }

		public Int16? KeuseVraeLaasteVrgNo1 { get; set; }
		public Int16? KeuseVraeLaasteVrgNo2 { get; set; }
		public Int16? KeuseVraeLaasteVrgNo3 { get; set; }
		public Int16? KeuseVraeLaasteVrgNo4 { get; set; }
		public Int16? KeuseVraeLaasteVrgNo5 { get; set; }
		public Int16? KeuseVraeLaasteVrgNo6 { get; set; }

		public Int16? KeuseVraeGetalVrae1 { get; set; }
		public Int16? KeuseVraeGetalVrae2 { get; set; }
		public Int16? KeuseVraeGetalVrae3 { get; set; }
		public Int16? KeuseVraeGetalVrae4 { get; set; }
		public Int16? KeuseVraeGetalVrae5 { get; set; }
		public Int16? KeuseVraeGetalVrae6 { get; set; }
		public Dictionary<string, float?> QuestionMarks { get; set; }
		public Dictionary<string, Dictionary<string, float?>> StoredQuestionMarksForPSIDNO { get; private set; }

		public void StoreQuestionMarksForPSIDNO(string psIdNo)
		{
			// Create a dictionary to store question marks for the specified PS_ID_NO
			Dictionary<string, float?> questionMarksForPSIDNO = new Dictionary<string, float?>();

			// Populate the dictionary with question marks for the specified PS_ID_NO
			for (int q = 1; q <= 30; q++)
			{
				string questionPropertyName = $"PS_VRAAG_{q}";
				object questionMarkObject = GetType().GetProperty(questionPropertyName)?.GetValue(this);

				// Convert the question mark object to float? or assign null if the string is empty
				float? questionMark = null;
				if (!string.IsNullOrEmpty(questionMarkObject?.ToString()))
				{
					questionMark = float.Parse(questionMarkObject.ToString());
				}

				questionMarksForPSIDNO[questionPropertyName] = questionMark;
			}

			// Check if the dictionary already contains the PS_ID_NO
			if (!StoredQuestionMarksForPSIDNO.ContainsKey(psIdNo))
			{
				// If not, add a new entry with the PS_ID_NO and its corresponding question marks
				StoredQuestionMarksForPSIDNO[psIdNo] = questionMarksForPSIDNO;
			}
			else
			{
				// If it already exists, update the question marks for the PS_ID_NO
				StoredQuestionMarksForPSIDNO[psIdNo] = questionMarksForPSIDNO;
			}
		}



	}
}
