using DataAccessLibrary;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkCapturing.Views.Interfaces
{
    public interface IQuestionPaperView
    {


        void examYear_SelectedIndexChanged(object sender, EventArgs e);

        void paperCode_SelectedIndexChanged(object sender, EventArgs e);

        //void TextBox_KeyDown(object sender, KeyEventArgs e);
        void TextBox_KeyDown(object sender, KeyEventArgs e);

        void UpdateQuestionTextBoxes(VraagleerDTO vraagleerDTO);

        //void GetQuestionPaper(VraagleerDTO vraagleerDTO);

        void ShowMessage(string message);
          
        void CreateOrUpdateQuestionPaper();
           
        void label4_Click(object sender, EventArgs e);
        
        void maxMark_KeyDown(object sender, KeyEventArgs e);

        void questionNo_KeyDown(object sender, KeyEventArgs e);

        void GetalKombinasiesVanKeuseVrae_KeyDown(object sender, KeyEventArgs e);




    }

}
