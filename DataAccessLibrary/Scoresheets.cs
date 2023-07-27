using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Scoresheets
    {
        public string MarksheetNumber { get; set; }
        public string SubjectCode { get; set; }
        public short? PaperNumber { get; set; }
        public short? PaperNumberPunte { get; set; }
        public short? NumberOfQuestions { get; set; }
        public string ID_NO { get; set; }
    }
}
