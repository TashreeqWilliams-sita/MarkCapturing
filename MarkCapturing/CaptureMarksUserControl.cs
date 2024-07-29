using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLibrary;
using DTOs;
using MarkCapturing.Presenter;
using MarkCapturing.Views;

namespace MarkCapturing
{
   
    public partial class CaptureMarksUserControl : UserControl, IUpdatingMarksView
    {
        private readonly QuestionsPresenter _questionsPresenter;
        MarksheetDTO marksheetDTO = new MarksheetDTO();
        string selectedExamNo;

        public CaptureMarksUserControl(QuestionsPresenter questionsPresenter)
        {
            InitializeComponent();
            _questionsPresenter = questionsPresenter;
            MarksheetNumberTextbox.KeyDown += MarksheetNumberTextbox_KeyDown;
            var marksheetNumber = MarksheetNumberTextbox.Text;
            //marksheetDTO = _questionsPresenter.GetMarksheetMarks(marksheetNumber);
            //examNumberList.SelectedIndexChanged += examNumberList_SelectedIndexChanged;

        }
        private void MarksheetNumberTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent sound on pressing Enter
                e.SuppressKeyPress = true;

                var marksheetNumber = MarksheetNumberTextbox.Text;

                if (!string.IsNullOrWhiteSpace(marksheetNumber))
                {
                    var data = _questionsPresenter.GetScoresheetRecords(marksheetNumber);
                    var additionalData = _questionsPresenter.GetMarksheetMarks(marksheetNumber);

                    if (data != null && additionalData != null)
                    {
                        var combinedDTO = new MarksheetDTO
                        {
                            GetalVraeOpVraestel = data.GetalVraeOpVraestel,
                            Hash = data.Hash,
                            PS_GEKONTROLEERDEPUNT = data.PS_GEKONTROLEERDEPUNT,
                            PS_KAFTOTAAL = data.PS_KAFTOTAAL,
                            PS_VRAESTELPUNT = data.PS_VRAESTELPUNT,
                            PS_ID_NO = data.PS_ID_NO,
                            PS_KODE = data.PS_KODE,
                            PS_Msheet = data.PS_Msheet,
                            VraestelKode = data.VraestelKode,
                            PS_EKS_DAT = data.PS_EKS_DAT,
                            PS_MarksheetSort = data.PS_MarksheetSort,
                            Status = data.Status,
                            Sentrum = data.Sentrum,
                            VraestelNaam = data.VraestelNaam,
                            PS_VRAAG_1 = additionalData.PS_VRAAG_1,
                            PS_VRAAG_2 = additionalData.PS_VRAAG_2,

                        };

                        if (!string.IsNullOrEmpty(combinedDTO.PS_ID_NO))
                        {
                            combinedDTO.StoreQuestionMarksForPSIDNO(combinedDTO.PS_ID_NO);
                        }

                        LoadMarksheetDetails();

                        if (!string.IsNullOrEmpty(combinedDTO.PS_ID_NO))
                        {
                            PopulateExamNumberList();
                        }

                        markQuestion1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Data not found for the provided Marksheet Number.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Marksheet Number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PopulateExamNumberList()
        {
            string marksheetNumber = MarksheetNumberTextbox.Text;
            List<MarksheetDTO> marksheetList = _questionsPresenter.GetExamNumberList(marksheetNumber);

            // Clear the examNumberList before populating it
            examNumberList.Items.Clear();

            foreach (var item in marksheetList)
            {
                Console.WriteLine(item.PS_ID_NO);
                examNumberList.Items.Add(item.PS_ID_NO);
            }

            if (examNumberList.Items.Count > 0)
            {
                examNumberList.DrawMode = DrawMode.OwnerDrawVariable;
                examNumberList.SelectedIndex = 0;
                examNumberList.DrawMode = DrawMode.Normal;
                examNumberList.DropDownStyle = ComboBoxStyle.DropDownList;
                examNumberList.MaxDropDownItems = 30; 
                examNumberList.SelectedIndexChanged += examNumberList_SelectedIndexChanged;
            }
        }

        private void LoadMarksheetMarksPerID(string selectedExamNo)
        {
            List<MarksheetDTO> marksheetList = _questionsPresenter.GetExamNumberList(MarksheetNumberTextbox.Text);

            var selectedMarksheet = marksheetList.FirstOrDefault(m => m.PS_ID_NO == selectedExamNo);

            if (selectedMarksheet != null)
            {
                int totalMark = 0;

                for (int q = 1; q <= 30; q++)
                {
                    TextBox questionTextBox = Controls.Find($"markQuestion{q}", true).FirstOrDefault() as TextBox;

                    if (q <= selectedMarksheet.GetalVraeOpVraestel)
                    {
                        questionTextBox.Enabled = true;
                        string propertyName = $"PS_VRAAG_{q}";
                        object questionValue = selectedMarksheet.GetType().GetProperty(propertyName)?.GetValue(selectedMarksheet, null);
                        string stringValue = questionValue?.ToString() ?? string.Empty;
                        questionTextBox.Text = stringValue;
                    }
                    else
                    {
                        questionTextBox.Enabled = false;
                        questionTextBox.Text = string.Empty;
                    }
                }

                // Calculate and set the total mark for the marksheet
                AddIndividualQuestionMarks(selectedMarksheet.GetalVraeOpVraestel, ref totalMark);
                selectedMarksheet.PS_VRAESTELPUNT = totalMark;

                // Display the total mark in the total TextBox
                total.Text = selectedMarksheet.PS_VRAESTELPUNT.ToString();
                // Display the value in the total.Text TextBox
                
                string lastFourDigitsOfExamNo = selectedMarksheet.PS_ID_NO.Substring(selectedMarksheet.PS_ID_NO.Length - 4);
                int convertedValue = int.Parse(lastFourDigitsOfExamNo);
                selectedMarksheet.PS_KAFTOTAAL = totalMark + convertedValue;
                hashTotal.Text = selectedMarksheet.PS_KAFTOTAAL.ToString();
            }
            else
            {
                // Handle case where the selected marksheet is not found
                // You can display an error message or perform appropriate error handling here
            }

            // Perform additional actions related to hashTotal if needed
        }


        

        private void examNumberList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedExamNo = examNumberList.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedExamNo))
            {
                LoadMarksheetMarksPerID(selectedExamNo);
            }

            markQuestion1.Focus();
        }




        private void LoadMarksheetMarks()
        {
            string marksheetNumber = MarksheetNumberTextbox.Text;
            
            List<MarksheetDTO> marksheetList = _questionsPresenter.GetExamNumberList(marksheetNumber);

            foreach (var item in marksheetList)
            {
                if (!examNumberList.Items.Contains(item.PS_ID_NO))
                {
                    examNumberList.Items.Add(item.PS_ID_NO);
                }
            }

            // Highlight the first item in the examNumberList
            if (examNumberList.Items.Count > 0)
            {
                examNumberList.DrawMode = DrawMode.OwnerDrawVariable;
                examNumberList.SelectedIndex = 0;
            }

            // Attach the SelectedIndexChanged event handler
            examNumberList.SelectedIndexChanged += examNumberList_SelectedIndexChanged;

            var firstExamNumberOnTheList = marksheetDTO.PS_ID_NO;
            int index = examNumberList.FindStringExact(firstExamNumberOnTheList);
            if (index != -1)
            {
                examNumberList.SelectedIndex = index;
            }


            foreach (var record in marksheetList)
            {
                int totalMark = 0;
                //marksheetDTO = _questionsPresenter.GetMarksheetMarks(record.PS_Msheet);
                for (int q = 1; q <= 30; q++)
                {
                    TextBox questionTextBox = Controls.Find($"markQuestion{q}", true).FirstOrDefault() as TextBox;

                    if (q <= record.GetalVraeOpVraestel)
                    {
                        questionTextBox.Enabled = true;
                        string propertyName = $"PS_VRAAG_{q}";
                        object questionValues = record.GetType().GetProperty(propertyName)?.GetValue(record, null);
                        string stringValue = questionValues?.ToString() ?? string.Empty;
                        questionTextBox.Text = stringValue;
                    }
                    else
                    {
                        questionTextBox.Enabled = false;
                        questionTextBox.Text = string.Empty;
                    }

                }

                AddIndividualQuestionMarks(record.GetalVraeOpVraestel, ref totalMark);

                // Set the value of marksheetDTO.PS_VRAESTELPUNT
                record.PS_VRAESTELPUNT = totalMark;
 
                // Display the value in the total.Text TextBox
                total.Text = record.PS_VRAESTELPUNT.ToString();
                string lastFourDigitsOfExamNo = record.PS_ID_NO.Substring(record.PS_ID_NO.Length - 4);
                int convertedValue = int.Parse(lastFourDigitsOfExamNo);
                record.PS_KAFTOTAAL = totalMark + convertedValue;
                hashTotal.Text = record.PS_KAFTOTAAL.ToString();

            }

           

            //hashTotal
        }
        //private void LoadMarksheetMarksPerID(string psIdNo)
        //{
        //    string marksheetNumber = MarksheetNumberTextbox.Text;
        //    List<MarksheetDTO> marksheetList = _questionsPresenter.GetExamNumberList(marksheetNumber);

        //    // Filter the marksheetList based on the psIdNo
        //    marksheetList = marksheetList.Where(m => m.PS_ID_NO == psIdNo).ToList();

        //    // Clear the examNumberList before populating it
        //    examNumberList.Items.Clear();

        //    foreach (var item in marksheetList)
        //    {
        //        examNumberList.Items.Add(item.PS_ID_NO);
        //    }

        //    //// Find the index of the psIdNo in the examNumberList
        //    //int index = examNumberList.Items.IndexOf(psIdNo);

        //    //// Select the item in the examNumberList based on the found index
        //    //if (index != -1)
        //    //{
        //    //    examNumberList.SelectedIndex = index;
        //    //}

        //    foreach (var record in marksheetList)
        //    {
        //        int totalMark = 0;
        //        //marksheetDTO = _questionsPresenter.GetMarksheetMarks(record.PS_Msheet);

        //        for (int q = 1; q <= 30; q++)
        //        {
        //            TextBox questionTextBox = Controls.Find($"markQuestion{q}", true).FirstOrDefault() as TextBox;
        //            if (q <= record.GetalVraeOpVraestel)
        //            {
        //                questionTextBox.Enabled = true;
        //                string propertyName = $"PS_VRAAG_{q}";
        //                object questionValues = record.GetType().GetProperty(propertyName)?.GetValue(record, null);
        //                string stringValue = questionValues?.ToString() ?? string.Empty;
        //                questionTextBox.Text = stringValue;
        //            }
        //            else
        //            {
        //                questionTextBox.Enabled = false;
        //                questionTextBox.Text = string.Empty;
        //            }
        //        }

        //        AddIndividualQuestionMarks(record.GetalVraeOpVraestel, ref totalMark);

        //        // Set the value of marksheetDTO.PS_VRAESTELPUNT
        //        record.PS_VRAESTELPUNT = totalMark;

        //        // Display the value in the total.Text TextBox
        //        total.Text = record.PS_VRAESTELPUNT.ToString();
        //    }

        //    //hashTotal
        //}
        private void AttachTextBoxEvents()
        {
            for (int i = 1; i <= 30; i++)
            {
                TextBox questionTextBox = Controls.Find($"markQuestion{i}", true).FirstOrDefault() as TextBox;

                if (questionTextBox != null)
                {
                    questionTextBox.KeyDown += TextBox_KeyDown;
                }

            }
        }
        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Move focus to the next MaxMark TextBox
                TextBox currentTextBox = sender as TextBox;
                string propertyName = currentTextBox.Name;
                //float? vraagMaksValue = vraagleerDTO?.GetType().GetProperty($"VraagMaks{i}")?.GetValue(vraagleerDTO) as float?;
                var property = marksheetDTO.GetType().GetProperty(propertyName);
                if (property != null && property.CanWrite)
                {
                    string value = currentTextBox.Text;
                    float? floatValue = null;
                    short? shortValue = null;

                    if (currentTextBox.Name.Contains("markQuestion"))
                    {
                        // Attempt to parse the string to a short
                        if (short.TryParse(value, out short result))
                        {
                            shortValue = result;
                        }
                        property.SetValue(marksheetDTO, shortValue);

                    }
                }

                if (currentTextBox != null && currentTextBox.Enabled != false && currentTextBox.Name.Contains("markQuestion"))
                {
                    TextBox nextMaxMarkTextBox = GetNextMaxMarkTextBox(currentTextBox);
                    nextMaxMarkTextBox?.Focus();

                    //if (!AreThereMoreEnabledTextboxes(currentTextBox))
                    //{
                    //    // If it's the last enabled textbox, set focus to the exit button
                    //    exitButton.Focus();
                    //}
                }

                // Consume the Enter key event to prevent it from being processed further
                e.Handled = true;
                e.SuppressKeyPress = true;
                //presenter.SaveQuestionPaperDetails(selectedEksamen, selectedVraestelKode, vraagleerDTO);
            }

        }
        private TextBox GetNextMaxMarkTextBox(TextBox currentTextBox)
        {
            // Assuming i represents the current question number (e.g., 1, 2, 3...)
            int currentQuestionNumber = int.Parse(currentTextBox.Name.Substring("markQuestion".Length, currentTextBox.Name.Length - "markQuestion".Length));
            int nextQuestionNumber = currentQuestionNumber + 1;

            // Construct the name of the next MaxMark TextBox
            string nextMaxMarkTextBoxName = $"markQuestion{nextQuestionNumber}";

            // Find the next MaxMark TextBox directly
            TextBox nextMaxMarkTextBox = Controls.Find(nextMaxMarkTextBoxName, true).FirstOrDefault() as TextBox;
            if (nextQuestionNumber > marksheetDTO.GetalVraeOpVraestel)
            {
                total.Focus();
            }

            return nextMaxMarkTextBox;
        }
        private void AddIndividualQuestionMarks(short? getalVraeOpVraestel, ref int totalMark)
        {
            for (int p = 1; p <= getalVraeOpVraestel; p++)  //maybe remove this
            {
                TextBox maxMarkTextBox = Controls.Find($"markQuestion{p}", true).FirstOrDefault() as TextBox;
                if (maxMarkTextBox != null && maxMarkTextBox.Enabled && !string.IsNullOrEmpty(maxMarkTextBox.Text))
                {
                    totalMark += int.Parse(maxMarkTextBox.Text);
                }
            }
        }

        private void LoadMarksheetDetails()
        {
            string marksheetNumber = MarksheetNumberTextbox.Text;
            MarksheetDTO marksheetDTO = _questionsPresenter.GetScoresheetRecords(marksheetNumber);

            if (marksheetDTO != null)
            {
                MarksheetNumberTextbox.Text = marksheetDTO.PS_Msheet;
                Status.Text = marksheetDTO.Status.ToString();
                subSystem.Text = marksheetDTO.PS_KODE;
                paperCode.Text = marksheetDTO.VraestelKode;
                centreNumber.Text = marksheetDTO.Sentrum.ToString();
                subjectName.Text = marksheetDTO.VraestelNaam;
                examYear.Text = marksheetDTO.PS_EKS_DAT.ToString();
            }
        }

            //private void ClearTextBoxes()
            //{
            //    MarksheetNumberTextbox.Clear();
            //    Status.Clear();
            //    subSystem.Clear();
            //    paperCode.Clear();
            //    centreNumber.Clear();
            //    subjectName.Text = "Name";
            //}

            //markQuestion1.Focus();
            //}



            public void ShowListScoresheet(MarksheetDTO ScoresheetList)
            {

            }
            #region KeyDown
            private void txtMarksheetNumber_KeyDown(object sender, KeyEventArgs e)
            {

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
                //marksheetDTO = QuestionsPresenter.GetScoresheetRecords(selectedExamNumber);

                for (int i = 1; i <= 30; i++)
                {
                    TextBox markTextBox = Controls.Find($"question{i}", true)[0] as TextBox;


                    // Retrieve the VraagNaam and VraagMak values from the details object (VraagleerDTO)

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

            private void BtnClose_Click(object sender, EventArgs e)
            {

            }
            private void button1_Click(object sender, EventArgs e)
            {
                BtnClose_Click(sender, e);
            }

            private void MarksheetNumberTextbox_TextChanged(object sender, EventArgs e)
            {

            }

            private void PnlRight_Paint(object sender, PaintEventArgs e)
            {

            }

            private void examNumberList_SelectedIndexChanged_1(object sender, EventArgs e)
            {
                //// Get the selected eksamen
                //selectedEksamen = examYear.SelectedItem?.ToString();
                //selectedVraestelKode = examNumberList.SelectedItem?.ToString();

                //// Call the presenter to retrieve the corresponding maxMark and questionNo values from the database
                //var maxMarkValue = presenter.GetMaxMark(selectedEksamen, selectedVraestelKode);
                //var questionNoValue = presenter.GetQuestionNo(selectedEksamen, selectedVraestelKode);
                //var selectionAmountValue = presenter.GetSelectionAmount(selectedEksamen, selectedVraestelKode);

                //// Update the maxMark and questionNo textboxes with the retrieved values
                //maxMark.Text = maxMarkValue?.ToString() ?? ""; // Use null-conditional operator to handle null values
                //questionNo.Text = questionNoValue?.ToString() ?? "";
                //GetalKombinasiesVanKeuseVrae.Text = selectionAmountValue?.ToString() ?? "";

                //vraagleerDTO = presenter.GetQuestionPaperDetails(selectedEksamen, selectedVraestelKode);

                //// Update the UI to enable/disable and populate the textboxes accordingly.
                //UpdateQuestionTextBoxes(vraagleerDTO);
                //UpdateCombinationTextboxes(vraagleerDTO);
                //maxMark.Focus();
            }

        private void btnShowOutstandingMarks_Click(object sender, EventArgs e)
        {
            bool isMessageAdded = false;
            string marksheetNumber = MarksheetNumberTextbox.Text;

            List<MarksheetDTO> marksheetDTOList = _questionsPresenter.GetExamNumberList(marksheetNumber);

            listBox1.Items.Clear(); // Clear the existing items in the CheckedListBox

            foreach (MarksheetDTO marksheetDTO in marksheetDTOList)
            {
                string idNo = marksheetDTO.PS_ID_NO;
                string changedBy = marksheetDTO.PS_ChangedBy;
                string dateLastChanged = marksheetDTO.PS_DateLastChanged;

                // Check if PS_ChangedBy and PS_DateLastChanged are null or empty
                if (string.IsNullOrWhiteSpace(changedBy) && string.IsNullOrWhiteSpace(dateLastChanged))
                {
                    listBox1.Items.Add(idNo);
                }
                else if (!isMessageAdded)
                {
                    // Add the message only if it hasn't been added before
                    listBox1.Items.Add("Marks all captured!");
                    isMessageAdded = true;
                }
            }
        }

        private void innerPanel4_Paint(object sender, PaintEventArgs e)
            {

            }
        }
    }
  