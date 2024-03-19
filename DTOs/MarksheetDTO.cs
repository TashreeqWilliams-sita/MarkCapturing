using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTOs
{
    public class MarksheetDTO
    {
        public MarksheetDTO() { }
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
		
		public string PS_ID_NO { get; set; }
        public string PS_KODE { get; set; }
        public string PS_Msheet { get; set; }
		public string PS_VRAESTELKODE { get; set; }
		public int PS_EKS_DAT { get; set; }
		public Int32 PS_MarksheetSort { get; set; }

	}
}
