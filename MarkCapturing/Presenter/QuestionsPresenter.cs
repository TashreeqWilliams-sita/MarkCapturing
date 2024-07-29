using DataAccessLibrary.Interfaces;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCapturing.Presenter
{
    public class QuestionsPresenter
    {
        private readonly IMarksheetRepository _marksheetRepository;

        public QuestionsPresenter(IMarksheetRepository marksheetRepository)
        {
            _marksheetRepository = marksheetRepository;
        }
        public MarksheetDTO GetMarksheetMarks(string psMsheet)
        {
            return _marksheetRepository.GetMarksheetDetails(psMsheet); 
        }
        public List<MarksheetDTO> GetExamNumberList(string psMsheet)
        {
           // List<MarksheetDTO> marksheetDTOs = new List<MarksheetDTO>(); // List to hold all MarksheetDTOs

            // Assuming _marksheetRepository.GetMarksheetDetails(psMsheet) returns a single MarksheetDTO
            List <MarksheetDTO> multipleMarksheetDTO = _marksheetRepository.GetExamNumberList(psMsheet);

            return multipleMarksheetDTO;
        }
        public MarksheetDTO GetScoresheetRecords(string marksheetNumber)
        {
            return _marksheetRepository.GetMarksheetTopDetails(marksheetNumber);
        }
    }
}
