using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;

namespace MarkCapturing
{
    public partial class CapturingOfQuestionsForm : Form
    {
        int leftcontrol = 1;
        int leftLabelcontrol = 1;
        public CapturingOfQuestionsForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MCAP0021\SQLEXPRESS01;Initial Catalog=NSC_VraagpunteStelsel;Integrated Security=True");
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int marksheet = Convert.ToInt32(txtMarksheetNumber.Text);

                try
                {
                    string subjectCode;
                    short? numberOfQuestions;

                    short? paperNoPUNTESTATE = 0;
                    short? paperNoVraagleers = 0;

                    int paperNumberVraagleers = (int)paperNoVraagleers;
                    int paperNumberPUNTESTATE = (int)paperNoPUNTESTATE;


                    NSC_VraagpunteStelselEntities DbContext = new NSC_VraagpunteStelselEntities();
                    var getRecord = DbContext.EKS_PUNTESTATE.Where(a => a.PS_Msheet == marksheet).ToList().FirstOrDefault();

                    subjectCode = getRecord.PS_VAKKODE;
                    paperNumberPUNTESTATE = getRecord.PS_VRSTEL_NO;
                    var getVraagleerRecord = DbContext.Vraagleers.Where(a => a.Vakkode == subjectCode && a.VraestelNommer == paperNumberPUNTESTATE).FirstOrDefault();

                    
                    paperNumberVraagleers = getVraagleerRecord.VraestelNommer;
                    int numberOfConvQuestions = 0;

                    if (paperNumberVraagleers == paperNumberPUNTESTATE)
                    {
                        numberOfQuestions = getVraagleerRecord.GetalVraeOpVraestel;
                        numberOfConvQuestions = (int)numberOfQuestions;
                    }

                       
                        CapturingOfQuestionsForm form4 = new CapturingOfQuestionsForm();

                   
                        const int textBoxWidth = 50;
                        const int textBoxHeight = 25;
                        const int spacing = 10;
                        const int startX = 16;
                        const int startY = 230;

                    const int labelWidth = 50;
                    const int labelHeight = 25;
                    const int startLabelY = 230;
                    //int controlsNo = form4.Controls.Count;0r

                    for (int i = 0; i < numberOfConvQuestions; i++)

                        {
                            //textbox
                            TextBox textBox = new TextBox();
                            this.Controls.Add(textBox);
                            textBox.Top = leftcontrol * 10;
                            textBox.Width = 50;
                            textBox.Location = new Point(startX, startY + (i * (textBoxHeight + spacing)));
                            //textBox.Location = new Point(startX + (i * (textBoxHeight + spacing)), startY );
                            textBox.Left = 100;
                            textBox.Text = "Textbox" + this.leftcontrol.ToString();
                            leftcontrol = leftcontrol + 1;
                            flowLayoutPanel1.Controls.Add(textBox);
                            flowLayoutPanel1.AutoScroll = true;

                            //label
                            Label labels = new Label();
                            this.Controls.Add(labels);
                            labels.Top = leftLabelcontrol * 10;
                            labels.Width = 100;
                            labels.Location = new Point(startX, startLabelY + (i * (textBoxHeight + spacing)));
                            //textBox.Location = new Point(startX + (i * (textBoxHeight + spacing)), startY );
                            labels.Left = 100;
                            labels.Text = "Question " + this.leftLabelcontrol.ToString();
                            leftLabelcontrol = leftLabelcontrol + 1;

                            flowLayoutPanel1.Controls.Add(labels);
                        if (flowLayoutPanel1.Controls.Count % 5 == 0)
                            {
                            flowLayoutPanel1.SetFlowBreak(textBox, true);
                            flowLayoutPanel1.SetFlowBreak(labels, true);

                            }
                        }


                    
                }
            catch
            {
                MessageBox.Show("Oops! That didnt work");
            }
            finally
            {
                conn.Close();
            }
        }
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            idNoEnquiry noEnquiry = new idNoEnquiry();
            noEnquiry.Show();
        }

        private void CapturingOfQuestionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
