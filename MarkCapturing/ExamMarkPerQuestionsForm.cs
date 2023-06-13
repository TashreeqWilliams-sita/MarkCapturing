using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkCapturing
{
    public partial class ExamMarkPerQuestionsForm : Form
    {
        public ExamMarkPerQuestionsForm()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CapturingOfQuestionsForm frm4 = new CapturingOfQuestionsForm();
            frm4.Show();
        }
    }
}
