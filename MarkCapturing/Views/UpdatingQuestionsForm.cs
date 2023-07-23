using System;
using MarkCapturing.Presenter;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLibrary;

namespace MarkCapturing.Views
{
    public partial class UpdatingQuestionsForm : Form, IUpdatingMarksView
    {
        private UpdatingQuestionsPresenter QuestionsPresenter;
        public string MarksheetNumber => txtMarksheetNumber.Text.Trim();
        public UpdatingQuestionsForm()
        {
            InitializeComponent();
            QuestionsPresenter = new UpdatingQuestionsPresenter(this);

        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowListScoresheet(List<Scoresheets> ScoresheetList)
        {

            // Suspend layout while adding controls
            tableLayoutPanel.SuspendLayout();

            // Clear any existing controls in the table layout panel
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowCount = 0;
            tableLayoutPanel.ColumnCount = 5;

            Label lblHeading = new Label();
            lblHeading.Text = "Mark Details";
            lblHeading.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
            tableLayoutPanel.Controls.Add(lblHeading, 0, 0);
            tableLayoutPanel.SetColumnSpan(lblHeading, 5);

            int row = 1;
            int column = 0;
            int NumOfQ = 0;
            for (int i = 0; i < ScoresheetList.Count; i++)
            {
                if (ScoresheetList[i].PaperNumber == ScoresheetList[i].PaperNumberPunte)
                {
                    NumOfQ = (int)ScoresheetList[i].NumberOfQuestions;
                }
                for (int j = 0; j < NumOfQ; j++)
                {
                    Panel panel = new Panel();

                    Label lblQuestion = new Label
                    {
                        Text = $"Q{ScoresheetList[j].NumberOfQuestions}",
                        Dock = DockStyle.Top
                    };
                    panel.Controls.Add(lblQuestion);

                    TextBox txtMark = new TextBox
                    {
                        Name = $"txtMark_{ScoresheetList[j].NumberOfQuestions}",
                        Dock = DockStyle.Bottom,
                        Margin = new Padding(0, 2, 0, 2),
                        Width = 50
                    };


                    panel.Padding = new Padding(2);

                    panel.Controls.Add(txtMark);

                    tableLayoutPanel.Controls.Add(panel, column, row);
                    tableLayoutPanel.SetRowSpan(panel, 2);
                    tableLayoutPanel.SetColumnSpan(panel, 1);

                    tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                    column++;

                    if (column == 5)
                    {
                        column = 0;
                        row += 2;
                    }
                }
                
            }
            // Resume layout and perform layout logic
            tableLayoutPanel.ResumeLayout(true);

            //tableLayoutPanel.SuspendLayout();

            //tableLayoutPanel.Controls.Clear();
            //tableLayoutPanel.RowStyles.Clear();
            //tableLayoutPanel.ColumnStyles.Clear();
            //tableLayoutPanel.RowCount = 0;
            //tableLayoutPanel.ColumnCount = 5;
            //tableLayoutPanel.AutoScroll = true;

            //Label lblHeading = new Label
            //{
            //    Text = "Paper Number - Question number!!",
            //    Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold)
            //};
            //tableLayoutPanel.Controls.Add(lblHeading, 0, 0);
            //tableLayoutPanel.SetColumnSpan(lblHeading, 5);

            //int row = 1;
            //int column = 0;
            //for (int i = 0; i < ScoresheetList.Count(); i++)
            //{
            //    Scoresheets scoresheets = ScoresheetList[i];
            //    Label lblSubHeading = new Label
            //    {
            //        Text = $"{scoresheets.SubjectCode}{scoresheets.PaperNumber}",
            //        Font = new Font(FontFamily.GenericSansSerif, 5, FontStyle.Bold)
            //    };
            //    int numOfQ = (int)ScoresheetList[i].NumberOfQuestions;

            //    for (int j = 0; j < numOfQ; j++)
            //    {
            //        Panel panel = new Panel();
            //        Scoresheets scoresheet = ScoresheetList[j];
            //        Label lblQuestions = new Label
            //        {
            //            Text = $"Q {j++}{scoresheet.NumberOfQuestions}:",
            //            Dock = DockStyle.Top
            //        };
            //        panel.Controls.Add(lblQuestions);

            //        TextBox txtQuestionMark = new TextBox
            //        {
            //            Name = $"txtQuestionMark_{j}",
            //            /*Width = 80,*/
            //            Dock = DockStyle.Bottom,
            //            //Margin = new Padding(0,60,0,60)

            //        };

            //        panel.Controls.Add(txtQuestionMark);

            //        panel.Padding = new Padding(10, 20, 10, 20);
            //        panel.Width = 50;

            //        tableLayoutPanel.Controls.Add(panel, column, row);

            //        tableLayoutPanel.SetRowSpan(panel, 2);
            //        tableLayoutPanel.SetColumnSpan(panel, 1);

            //        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            //        column++;

            //        if (column == 5)
            //        {
            //            column = 0;
            //            row += 2;
            //        }
            //    }
            //    tableLayoutPanel.Controls.Add(lblSubHeading);

            //}
        }
        #region KeyDown
        private void txtMarksheetNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool isValidMarksheetNumber = QuestionsPresenter.ValidateMarksheet(MarksheetNumber);
                //Updatepresenter.ValidateMarksheetNumber(MarksheetNumber);
                if (isValidMarksheetNumber)
                {
                    QuestionsPresenter.SearchMarksheet();
                }
                else
                {
                    MessageBox.Show("Invalid marksheet number. Please rnter a valid marksheet number.");
                }
            }
        }
        #endregion

        #region FormClosing
        private void UpdatingQuestionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        #endregion
        public void ShowRecords()
        {
            throw new NotImplementedException();
        }
    }
}
//    #region OldCode
//    private UpdatingQuestionsPresenter Updatepresenter;
//    public string MarksheetNumber => txtMarksheetNumber.Text.Trim();
//    private int currIndex;

//    public UpdatingQuestionsForm()
//    {
//        InitializeComponent();
//        currIndex = 0;
//        Updatepresenter = new UpdatingQuestionsPresenter(this);
//    }

//    #region FormClosing
//    private void UpdatingQuestionsForm_FormClosing(object sender, FormClosingEventArgs e)
//    {
//        if (e.CloseReason == CloseReason.UserClosing)
//        {
//            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//            if (result == DialogResult.No)
//            {
//                e.Cancel = true;
//            }
//            else
//            {
//                Application.Exit();
//            }
//        }
//    }
//    #endregion

//    #region ShowErrorMessage
//    public void ShowErrorMessage(string message)
//    {
//        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//    #endregion

//    #region prevCode
//    //private void UpdatingQuestionsForm_Enter(object sender, EventArgs e)
//    //{
//    //    Updatepresenter.ValidateMarksheetNumber(MarksheetNumber);
//    //    Updatepresenter.ShowList();
//    //    #region CommentedPreviousCode
//    //    //using (var context = new NSC_VraagpunteStelselEntities())
//    //    //{
//    //    //    var query = from EKS_PUNTESTATE in context.EKS_PUNTESTATE
//    //    //                join Vraagleers in context.Vraagleers on EKS_PUNTESTATE.PS_VAKKODE equals Vraagleers.Vakkode
//    //    //                select new
//    //    //                {
//    //    //                    PS_VAKKODE = EKS_PUNTESTATE.PS_VAKKODE,
//    //    //                    PS_VRSTEL_NO = EKS_PUNTESTATE.PS_VRSTEL_NO
//    //    //                };
//    //    //}
//    //    /
//    //    //Updatepresenter.SearchMarksheet();
//    //    //string marksheetnumber = txtMarksheetNumber.Text;

//    //    //try
//    //    //{
//    //    //    string subjectCode;
//    //    //    short? numberOfQuestions;

//    //    //    short? paperNoPUNTESTATE = 0;
//    //    //    short? paperNoVraagleers = 0;

//    //    //    int paperNumberVraagleers = (int)paperNoVraagleers;
//    //    //    int paperNumberPUNTESTATE = (int)paperNoPUNTESTATE;


//    //    //    NSC_VraagpunteStelselEntities DbContext = new NSC_VraagpunteStelselEntities();
//    //    //    var getRecord = DbContext.EKS_PUNTESTATE.Where(a => a.PS_Msheet == marksheetnumber).ToList().FirstOrDefault();

//    //    //    subjectCode = getRecord.PS_VAKKODE;
//    //    //    paperNumberPUNTESTATE = getRecord.PS_VRSTEL_NO;
//    //    //    var getVraagleerRecord = DbContext.Vraagleers.Where(a => a.Vakkode == subjectCode && a.VraestelNommer == paperNumberPUNTESTATE).FirstOrDefault();

//    //    //    var NumberOfQ = DbContext.Vraagleers.Count(v => v.Vakkode == subjectCode && v.VraestelNommer == paperNumberPUNTESTATE);

//    //    //    paperNumberVraagleers = getVraagleerRecord.VraestelNommer;
//    //    //    int numberOfConvQuestions = 0;

//    //    //    if (paperNumberVraagleers == paperNumberPUNTESTATE)
//    //    //    {
//    //    //        numberOfQuestions = getVraagleerRecord.GetalVraeOpVraestel;
//    //    //        numberOfConvQuestions = (int)numberOfQuestions;
//    //    //    }

//    //    //UpdateQuestionMarksForm updateQuestionMarksForm = new UpdateQuestionMarksForm();


//    //    //const int textBoxHeight = 25;
//    //    //const int spacing = 10;
//    //    //const int startX = 16;
//    //    //const int startY = 240;

//    //    //const int startLabelY = 230;
//    //    ////int controlsNo = form4.Controls.Count;

//    //    //for (int i = 0; i < NumberOfQ; i++)

//    //    //{
//    //    //    //textbox
//    //    //    TextBox textBox = new TextBox();
//    //    //    this.Controls.Add(textBox);
//    //    //    textBox.Top = leftcontrol * 10;
//    //    //    textBox.Width = 50;
//    //    //    textBox.Location = new Point(startX, startY + (i * (textBoxHeight + spacing)));
//    //    //    //textBox.Location = new Point(startX + (i * (textBoxHeight + spacing)), startY );
//    //    //    textBox.Left = 100;
//    //    //    textBox.Text = "Textbox" + this.leftcontrol.ToString();
//    //    //    leftcontrol = leftcontrol + 1;
//    //    //    pnlEnterQuestionMarks.Controls.Add(textBox);
//    //    //    pnlEnterQuestionMarks.AutoScroll = true;

//    //    //    //label
//    //    //    Label label = new Label();
//    //    //    this.Controls.Add(label);
//    //    //    label.Top = leftLabelcontrol * 10;
//    //    //    label.Width = 50;
//    //    //    label.Location = new Point(startX, startLabelY + (i * (textBoxHeight + spacing)));
//    //    //    //textBox.Location = new Point(startX + (i * (textBoxHeight + spacing)), startY );
//    //    //    label.Left = 100;
//    //    //    label.Text = "Question " + this.leftLabelcontrol.ToString();
//    //    //    leftLabelcontrol = leftLabelcontrol + 1;

//    //    //    pnlEnterQuestionMarks.Controls.Add(label);
//    //    //    if (pnlEnterQuestionMarks.Controls.Count %5 ==0)
//    //    //    {
//    //    //        pnlEnterQuestionMarks.SetFlowBreak(textBox, true);
//    //    //    }
//    //    //}
//    //    #endregion
//    //}
//    #endregion

//    #region KeyDown
//    private void txtMarksheetNumber_KeyDown(object sender, KeyEventArgs e)
//    {
//        if (e.KeyCode == Keys.Enter)
//        {
//            bool isValidMarksheetNumber = Updatepresenter.ValidateMarksheet(MarksheetNumber);
//            //Updatepresenter.ValidateMarksheetNumber(MarksheetNumber);
//            if (isValidMarksheetNumber)
//            {
//                Updatepresenter.SearchMarksheet();
//            }
//            else
//            {
//                MessageBox.Show("Invalid marksheet number. Please rnter a valid marksheet number.");
//            }
//        }
//    }
//    #endregion

//    #region ShowingTextboxes
//    public void ShowRecords()
//    {
//        #region OldCode
//        //try
//        //{
//        //    const int textBoxHeight = 25;
//        //    const int spacing = 10;
//        //    const int startX = 16;
//        //    const int startY = 240;

//        //    const int startLabelY = 230;

//        //    for (int i = 0; i < Updatepresenter.NumberOfQ(); i++)
//        //    {
//        //        //textbox
//        //        TextBox textBox = new TextBox();
//        //        this.Controls.Add(textBox);
//        //        textBox.Top = leftcontrol * 10;
//        //        textBox.Width = 50;
//        //        textBox.Location = new Point(startX, startY + (i * (textBoxHeight + spacing)));
//        //        //textBox.Location = new Point(startX + (i * (textBoxHeight + spacing)), startY );
//        //        textBox.Left = 100;
//        //        textBox.Text = "Textbox" + this.leftcontrol.ToString();
//        //        leftcontrol = leftcontrol + 1;
//        //        pnlEnterQuestionMarks.Controls.Add(textBox);
//        //        pnlEnterQuestionMarks.AutoScroll = true;

//        //        //label
//        //        Label label = new Label();
//        //        this.Controls.Add(label);
//        //        label.Top = leftLabelcontrol * 10;
//        //        label.Width = 50;
//        //        label.Location = new Point(startX, startLabelY + (i * (textBoxHeight + spacing)));
//        //        //textBox.Location = new Point(startX + (i * (textBoxHeight + spacing)), startY );
//        //        label.Left = 100;
//        //        label.Text = "Question " + this.leftLabelcontrol.ToString();
//        //        leftLabelcontrol = leftLabelcontrol + 1;

//        //        pnlEnterQuestionMarks.Controls.Add(label);
//        //        if (pnlEnterQuestionMarks.Controls.Count % 5 == 0)
//        //        {
//        //            pnlEnterQuestionMarks.SetFlowBreak(textBox, true);
//        //        }
//        //    }
//        //}
//        //catch (Exception ex)
//        //{
//        //    ShowErrorMessage(ex.Message);
//        //}
//        #endregion

//        #region UpdatedCode

//        tableLayoutPanel.SuspendLayout();

//        tableLayoutPanel.Controls.Clear();
//        tableLayoutPanel.RowStyles.Clear();
//        tableLayoutPanel.ColumnStyles.Clear();
//        tableLayoutPanel.RowCount = 0;
//        tableLayoutPanel.ColumnCount = 5;
//        tableLayoutPanel.AutoScroll = true;

//        Label lblHeading = new Label
//        {
//            Text = "Paper Number - Question number!!",
//            Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold)
//        };
//        tableLayoutPanel.Controls.Add(lblHeading, 0, 0);
//        tableLayoutPanel.SetColumnSpan(lblHeading, 5);

//        int row = 1;
//        int column = 0;

//        for (int i = 0; i < Updatepresenter.NumberOfQ(); i++)
//        {
//            Panel panel = new Panel();

//            var lblText = Updatepresenter.NumberOfQ().ToString();
//            Label lblQuestions = new Label
//            {
//                Text = lblText,
//                Dock = DockStyle.Top
//            };
//            panel.Controls.Add(lblQuestions);

//            TextBox txtQuestionMark = new TextBox
//            {
//                Name = "txtQuestionMark_" + Updatepresenter.NumberOfQ(),
//                /*Width = 80,*/
//                Dock = DockStyle.Bottom,
//                //Margin = new Padding(0,60,0,60)

//            };

//            panel.Controls.Add(txtQuestionMark);

//            panel.Padding = new Padding(13, 25, 13, 25);
//            panel.Width = 50;

//            tableLayoutPanel.Controls.Add(panel, column, row);

//            tableLayoutPanel.SetRowSpan(panel, 2);
//            tableLayoutPanel.SetColumnSpan(panel, 1);

//            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

//            column++;

//            if (column == 5)
//            {
//                column = 0;
//                row += 2;
//            }
//        }
//        ////Adding the event handler for our textboxes
//        //foreach (Control control in tableLayoutPanel.Controls)
//        //{
//        //    if (control is TextBox txtQuestionMark)
//        //    {
//        //        txtQuestionMark.KeyDown += txtQuestionMark_KeyDown;
//        //    }
//        //}

//        tableLayoutPanel.ResumeLayout(true);
//        #endregion
//    }

//    public void ShowListScoresheet(List<Scoresheets> ScoresheetList)
//    {
//        tableLayoutPanel.SuspendLayout();

//        tableLayoutPanel.Controls.Clear();
//        tableLayoutPanel.RowStyles.Clear();
//        tableLayoutPanel.ColumnStyles.Clear();
//        tableLayoutPanel.RowCount = 0;
//        tableLayoutPanel.ColumnCount = 5;
//        tableLayoutPanel.AutoScroll = true;

//        Label lblHeading = new Label
//        {
//            Text = "Enter Marks",
//            Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold),
//            AutoSize = true
//        };
//        tableLayoutPanel.Controls.Add(lblHeading);
//        tableLayoutPanel.SetColumnSpan(lblHeading, 5);

//        int row = 1;
//        int column = 0;
//        if (currIndex >= 0 && currIndex < ScoresheetList.Count)
//        {
//            Scoresheets scoresheets = ScoresheetList[currIndex];
//            Label subjectLabel = new Label
//            {
//                Text = $"Subject:{scoresheets.SubjectCode}",
//                /*Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)*/
//                AutoSize = true,
//                Padding = new Padding(0, 10, 0, 0)
//            };
//            tableLayoutPanel.Controls.Add(subjectLabel);
//            for (int i = 1; i < scoresheets.NumberOfQuestions; i++)
//            {
//                Panel panel = new Panel();
//                //Scoresheets scoresheet = ScoresheetList[j];
//                Label lblQuestions = new Label
//                {
//                    Text = $"Q {i++}:",
//                    AutoSize = true,
//                    Padding = new Padding(0, 5, 5, 0),
//                    Dock = DockStyle.Top
//                };
//                panel.Controls.Add(lblQuestions);

//                TextBox txtQuestionMark = new TextBox
//                {
//                    Name = $"txtQuestionMark_{scoresheets.SubjectCode}{scoresheets.PaperNumber}",
//                    ////Width = 80,
//                    Dock = DockStyle.Bottom
//                    //Margin = new Padding(0,60,0,60)

//                };

//                panel.Controls.Add(txtQuestionMark);

//                panel.Padding = new Padding(10, 20, 10, 20);
//                panel.Width = 50;

//                tableLayoutPanel.Controls.Add(panel, column, row);

//                tableLayoutPanel.SetRowSpan(panel, 2);
//                tableLayoutPanel.SetColumnSpan(panel, 1);

//                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

//                column++;

//                if (column == 5)
//                {
//                    column = 0;
//                    row += 2;
//                }
//                //tableLayoutPanel.Controls.Add(panel, column, row);
//            }

//        }

//    }

//    //for (int i = 0; i < ScoresheetList.Count(); i++)
//    //{
//    //    Label lblSubHeading = new Label
//    //    {
//    //        Text = $"{scoresheets.SubjectCode}{scoresheets.PaperNumber}",
//    //        Font = new Font(FontFamily.GenericSansSerif, 5, FontStyle.Bold)
//    //    };
//    //    int numOfQ = (int)ScoresheetList[i].NumberOfQuestions;

//    //    for (int j = 0; j < numOfQ; j++)
//    //    {
//    //        Panel panel = new Panel();
//    //        Scoresheets scoresheet = ScoresheetList[j];
//    //        Label lblQuestions = new Label
//    //        {
//    //            Text = $"Q {j++}{scoresheet.NumberOfQuestions}:",
//    //            Dock = DockStyle.Top
//    //        };
//    //        panel.Controls.Add(lblQuestions);

//    //        TextBox txtQuestionMark = new TextBox
//    //        {
//    //            Name = $"txtQuestionMark_{j}",
//    //            /*Width = 80,*/
//    //            Dock = DockStyle.Bottom,
//    //            //Margin = new Padding(0,60,0,60)

//    //        };

//    //        panel.Controls.Add(txtQuestionMark);

//    //        panel.Padding = new Padding(10, 20, 10, 20);
//    //        panel.Width = 50;

//    //        tableLayoutPanel.Controls.Add(panel, column, row);

//    //        tableLayoutPanel.SetRowSpan(panel, 2);
//    //        tableLayoutPanel.SetColumnSpan(panel, 1);

//    //        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

//    //        column++;

//    //        if (column == 5)
//    //        {
//    //            column = 0;
//    //            row += 2;
//    //        }
//    //    }
//    //    tableLayoutPanel.Controls.Add(lblSubHeading);

//    //}

//    ////Adding the event handler for our textboxes
//    //foreach (Control control in tableLayoutPanel.Controls)
//    //{
//    //    if (control is TextBox txtQuestionMark)
//    //    {
//    //        txtQuestionMark.KeyDown += txtQuestionMark_KeyDown;
//    //    }
//    //}

//    //tableLayoutPanel.ResumeLayout(true);
//}
//#endregion

//#endregion
#region SaveMarks
//Saving the marks, still need some updating
//private void txtQuestionMark_KeyDown(object sender, KeyEventArgs e)
//{
//    if (e.KeyCode == Keys.Enter)
//    {
//        TextBox txtQuestionMark = (TextBox)sender;
//        string subjectCode = txtQuestionMark.Tag as string;//This means we need a subject code stored in the Tag property, when we create our textboxes 
//        if (txtQuestionMark.Text.Trim()!=""&&subjectCode!=null)
//        {
//            string QMark = txtQuestionMark.Text;
//            Updatepresenter.SaveMarks(subjectCode, QMark);
//            MessageBox.Show($"Marks for subject {subjectCode} saved successfully");

//            //clear textboxes after saving grade
//            txtQuestionMark.Clear();  
//        }
//        else
//        {
//            MessageBox.Show("Please enter a mark.");
//        }
//        e.Handled = true;
//        e.SuppressKeyPress = true;
//    }
//}
#endregion
