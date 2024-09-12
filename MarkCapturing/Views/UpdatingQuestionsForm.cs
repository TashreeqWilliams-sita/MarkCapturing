using DataAccessLibrary;
using DTOs;
using MarkCapturing.Presenter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

            //selected exam number
           


        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        public void ShowListScoresheet(MarksheetDTO ScoresheetList)
        {
            //// Validate that eksamen and vraestelKode are not null
            //if (string.IsNullOrEmpty(selectedEksamen) || string.IsNullOrEmpty(selectedVraestelKode))
            //{
            //    // Handle the case where eksamen or vraestelKode is null
            //    return;
            //}
            //vraagleerDTO = presenter.GetQuestionPaperDetails(selectedEksamen, selectedVraestelKode);

            //for (int i = 1; i <= 30; i++)
            //{
            //    TextBox questionTextBox = Controls.Find($"question{i}", true).FirstOrDefault() as TextBox;
            //    TextBox maxMarkTextBox = Controls.Find($"VraagMaks{i}", true).FirstOrDefault() as TextBox;
            //    CheckBox telVirVraestelMaksCheckbox = Controls.Find($"TelVirVraestelMaks{i}", true).FirstOrDefault() as CheckBox;

            //    if (i <= vraagleerDTO.GetalVraeOpVraestel)
            //    {
            //        questionTextBox.Enabled = true;
            //        maxMarkTextBox.Enabled = true;
            //        telVirVraestelMaksCheckbox.Enabled = true;
            //    }
            //    else
            //    {
            //        questionTextBox.Enabled = false;
            //        maxMarkTextBox.Enabled = false;
            //        telVirVraestelMaksCheckbox.Enabled = false;
            //    }

            //    // Retrieve the VraagNaam and VraagMak values from the details object (VraagleerDTO)
            //    string vraagNaam = vraagleerDTO?.GetType().GetProperty($"VraagNaam{i}")?.GetValue(vraagleerDTO) as string;
            //    bool telVirVraestelMaks = (bool)vraagleerDTO?.GetType().GetProperty($"TelVirVraestelMaks{i}")?.GetValue(vraagleerDTO);
            //    float? vraagMaksValue = vraagleerDTO?.GetType().GetProperty($"VraagMaks{i}")?.GetValue(vraagleerDTO) as float?;
            //    string vraagMaks = vraagMaksValue.HasValue ? vraagMaksValue.Value.ToString() : string.Empty;

            //    questionTextBox.Text = vraagNaam ?? ""; // Use null-conditional operator to handle null values
            //    maxMarkTextBox.Text = vraagMaks.ToString() ?? "";
            //    telVirVraestelMaksCheckbox.Checked = telVirVraestelMaks;

            //    //questionTextBox.Enabled = true;
            //    //maxMarkTextBox.Enabled = true;
            //    //telVirVraestelMaksCheckbox.Enabled = true;

            //    // Set the radio button state (checked or unchecked) based on some logic
            //    // Example: You can check the radio button if vraagNaam or vraagMak meets certain conditions
            //    // bool shouldCheckRadioButton = /* Your logic here */;
            //    // telVirVraestelMaksRadioButton.Checked = shouldCheckRadioButton;
            //    // Validate that eksamen and vraestelKode are not null
            //    if (string.IsNullOrEmpty(selectedEksamen) || string.IsNullOrEmpty(selectedVraestelKode))
            //    {
            //        // Handle the case where eksamen or vraestelKode is null
            //        return;
            //    }

            //    // Get the updated details from the view
            //    Vraagleer updatedDetails = new Vraagleer(); // Replace with your actual DTO class

            //    // Save the updated details to the database

            //}
            //AttachTextBoxEvents();
        }
        #region KeyDown
        private void txtMarksheetNumber_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bool isValidMarksheetNumber = QuestionsPresenter.ValidateMarksheet(MarksheetNumber);
            //    //Updatepresenter.ValidateMarksheetNumber(MarksheetNumber);
            //    if (isValidMarksheetNumber)
            //    {
            //    MarksheetDTO dto = QuestionsPresenter.GetScoresheetRecords(MarksheetNumber);
            //    //examNumberList.Items.AddRange(QuestionsPresenter.GetScoresheetRecords(MarksheetNumber).);

            //    //Display paper code of the Exam year
            //    var idList = QuestionsPresenter.GetByMarksheet(MarksheetNumber);

            //    string firstExamNumber = "";

            //    if (idList != null && idList.Count > 0)
            //    {
            //        firstExamNumber = idList[0];
            //    }

            //    if (!string.IsNullOrEmpty(firstExamNumber))
            //    {
            //        int index = examNumberList.FindStringExact(firstExamNumber);

            //        if (index != -1)
            //        {
            //            examNumberList.SelectedIndex = index;
            //        }
            //        else
            //        {
            //            // Value not found in list
            //        }
            //    }

            //        //txtMarksheetNumber.Text = dto.PS_Msheet;
            //        subSystem.Text = dto.PS_KODE;
            //    examNumber.Text = dto.PS_ID_NO;
            //    examYear.Text = dto.PS_EKS_DAT.ToString();
            //    //paperCode.Text = dto.PS_VRAESTELKODE;
            //    //markQuestion1.Text = dto.PS_VRAAG_1.ToString();
            //    //markQuestion2.Text = dto.PS_VRAAG_2.ToString();
            //    //markQuestion3.Text = dto.PS_VRAAG_3.ToString();
            //    //markQuestion4.Text = dto.PS_VRAAG_4.ToString();
            //    //markQuestion5.Text = dto.PS_VRAAG_5.ToString();
            //    int hashedTotal = ((int)dto.PS_GEKONTROLEERDEPUNT) + dto.PS_MarksheetSort;
            //    textBox26.Text = hashedTotal.ToString();
            //    hashTotal.Text = dto.PS_KAFTOTAAL.ToString();
            //    total.Text = dto.PS_GEKONTROLEERDEPUNT.ToString();
            //    //UpdateQuestionMarkTextBoxes(dto);
            //}
            //    else
            //    {
            //        MessageBox.Show("Marksheet number does'nt exist. Please enter a valid marksheet number.");
            //    }
            //}

           
        }
        #endregion
        public void UpdateQuestionMarkTextBoxes(MarksheetDTO marksheetDTO)
        {
            var selectedExamNumber = examNumberList.SelectedItem?.ToString();
            // Validate that eksamen and vraestelKode are not null
            if (string.IsNullOrEmpty(selectedExamNumber))
            {
                // Handle the case where eksamen or vraestelKode is null
                return;
            }
            marksheetDTO = QuestionsPresenter.GetScoresheetRecords(selectedExamNumber);

            for (int i = 1; i <= 30; i++)
            {
                TextBox markTextBox = Controls.Find($"question{i}", true)[0] as TextBox;
               

                //if (i <= marksheetDTO.GetalVraeOpVraestel)
                //{
                    markTextBox.Enabled = true;
                   
                //}
                //else
                //{
                //    markTextBox.Enabled = false;
                    
                //}

                // Retrieve the VraagNaam and VraagMak values from the details object (VraagleerDTO)
                string marks = marksheetDTO?.GetType().GetProperty($"PS-VRAAG-{i}")?.GetValue(marksheetDTO) as string;
                //bool telVirVraestelMaks = (bool)vraagleerDTO?.GetType().GetProperty($"TelVirVraestelMaks{i}")?.GetValue(vraagleerDTO);
                //float? vraagMaksValue = vraagleerDTO?.GetType().GetProperty($"VraagMaks{i}")?.GetValue(vraagleerDTO) as float?;
                //string vraagMaks = vraagMaksValue.HasValue ? vraagMaksValue.Value.ToString() : string.Empty;

                markTextBox.Text = marks ?? ""; // Use null-conditional operator to handle null values
                //maxMarkTextBox.Text = vraagMaks.ToString() ?? "";
                //telVirVraestelMaksCheckbox.Checked = telVirVraestelMaks;

                //questionTextBox.Enabled = true;
                //maxMarkTextBox.Enabled = true;
                //telVirVraestelMaksCheckbox.Enabled = true;

                // Set the radio button state (checked or unchecked) based on some logic
                // Example: You can check the radio button if vraagNaam or vraagMak meets certain conditions
                // bool shouldCheckRadioButton = /* Your logic here */;
                // telVirVraestelMaksRadioButton.Checked = shouldCheckRadioButton;
                // Validate that eksamen and vraestelKode are not null
               

            }
           // AttachTextBoxEvents();
        }
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

        private void txtMarksheetNumber_TextChanged(object sender, EventArgs e)
        {
             string textBox = txtMarksheetNumber.Text;
            if (textBox.Contains("-"))
            {
                MessageBox.Show("Error: Number has '-' in it.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BtnClose_Click(sender, e);
        }

        private void btnShowMarksheetNumber_Click(object sender, EventArgs e)
        {

        }

        private void examNumberList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// Get the selected eksamen
            //selectedEksamen = examYear.SelectedItem?.ToString();
            //selectedVraestelKode = paperCode.SelectedItem?.ToString();

            //// Call the presenter to retrieve the corresponding maxMark and questionNo values from the database
            //var maxMarkValue = presenter.GetMaxMark(selectedEksamen, selectedVraestelKode);
            //var questionNoValue = presenter.GetQuestionNo(selectedEksamen, selectedVraestelKode);
            //var selectionAmountValue = presenter.GetSelectionAmount(selectedEksamen, selectedVraestelKode);

            //// Update the maxMark and questionNo textboxes with the retrieved values
            //maxMark.Text = maxMarkValue?.ToString() ?? ""; // Use null-conditional operator to handle null values
            //questionNo.Text = questionNoValue?.ToString() ?? "";
            //GetalKombinasiesVanKeuseVrae.Text = selectionAmountValue?.ToString() ?? "";

            //// Update the UI to enable/disable and populate the textboxes accordingly.
            //UpdateQuestionTextBoxes(vraagleerDTO);
            //UpdateCombinationTextboxes(vraagleerDTO);
            //maxMark.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button was clicked!");
            Console.WriteLine("Button was clicked!");
        }

        private void btnShowOutstandingMarks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Working!!");
        }

        private void markQuestion1_TextChanged(object sender, EventArgs e)
        {

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
//
//{
//    if (e.KeyCode == Keys.Enter)
//    {
//        TextBox txtQuestionMark = (TextBox)sender;
//        string subjectCode = txtQuestionMark.Tag as string;//This means we need a subject code stored in the Tag property, when we create our textboxes 
//        if (txtQuestionMark.Text.Trim() != "" && subjectCode != null)
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
