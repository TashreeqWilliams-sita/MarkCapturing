using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarkCapturing.Presenter;
using DataAccessLibrary.Repositories;
using MarkCapturing.Views.Interfaces;
using DataAccessLibrary;
using DTOs;

namespace MarkCapturing
{
    public partial class UpdateQuestionPaperUserControl : UserControl, IQuestionPaperView
    {
        string selectedEksamen;
        string selectedVraestelKode;
        private IQuestionPaperPresenter presenter;
        private bool allCheckboxesProcessed = false;
        private bool isUserControlLoaded = false;
        private CheckBox lastEnabledCheckBox = null;
        //int total = 0;

        VraagleerDTO vraagleerDTO = new VraagleerDTO();
        private short? maxQuestions; // Store the maximum number of questions allowed
        int? firstQuestionNo, selectionAmount;
        public UpdateQuestionPaperUserControl(IQuestionPaperPresenter presenter)
        {
            InitializeComponent();
            this.Load += UpdateQuestionPaperUserControl_Load;
            // Initialize the presenter with the repository and the view
            this.presenter = presenter;
            examYear.Items.AddRange(presenter.GetEksamenList().ToArray());
            paperCode.Items.AddRange(presenter.GetVraestelKodeList().ToArray());

            //Display Exam year
            var firstExamYear = presenter.GetEksamenList().FirstOrDefault();
            if (!string.IsNullOrEmpty(firstExamYear))
            {
                int index = examYear.FindStringExact(firstExamYear);
                if (index != -1)
                {
                    examYear.SelectedIndex = index;
                }
            }
            //Display paper code of the Exam year
            var firstPaperCode = presenter.GetVraestelKodeList().FirstOrDefault();
            if (!string.IsNullOrEmpty(firstPaperCode))
            {
                int index = paperCode.FindStringExact(firstPaperCode);
                if (index != -1)
                {
                    paperCode.SelectedIndex = index;
                }
            }
            //Display maximum mark of the paper code of the Exam year
            var selectedExamYear = examYear.SelectedItem?.ToString();
            var selectedPaperCode = paperCode.SelectedItem?.ToString();
            vraagleerDTO = presenter.GetQuestionPaperDetails(selectedEksamen, selectedVraestelKode);

            var firstMaxMark = presenter.GetMaxMark(selectedExamYear, selectedPaperCode);

            if (firstMaxMark.HasValue)
            {
                maxMark.Text = firstMaxMark.Value.ToString();
            }
            //Display number of questions on the paper code of the Exam year

            firstQuestionNo = presenter.GetQuestionNo(selectedExamYear, selectedPaperCode); // Assuming GetMaxMark() method in presenter retrieves the value.

            if (firstQuestionNo.HasValue)
            {
                questionNo.Text = firstQuestionNo.Value.ToString();
            }
            selectionAmount = presenter.GetSelectionAmount(selectedExamYear, selectedPaperCode); // Assuming GetMaxMark() method in presenter retrieves the value.

            if (selectionAmount.HasValue)
            {
                GetalKombinasiesVanKeuseVrae.Text = selectionAmount.Value.ToString();
            }
            // Initialize maxQuestions
            maxQuestions = vraagleerDTO.GetalVraeOpVraestel;
            // Attach KeyDown event handler to relevant controls (e.g., textboxes)  ***** This has to be changed
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.KeyDown += maxMark_KeyDown;
                }
            }
            UpdateQuestionTextBoxes(vraagleerDTO);
            UpdateCombinationTextboxes(vraagleerDTO);
            //ValidateContinuousSequence();
        }
        private void UpdateQuestionPaperUserControl_Load(object sender, EventArgs e)
        {
            isUserControlLoaded = true;
            // Call any other necessary methods or logic here
        }
        public void examYear_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Get the selected eksamen
                string selectedEksamen = examYear.Text;

                // Retrieve a list of unique vraestelKode values for the selected eksamen from the database
                var eksamenList = presenter.GetEksamenList();

                // Populate the paperCode ComboBox with the retrieved vraestelKode values
                examYear.DataSource = eksamenList;

                // Update the UI to enable/disable and populate the textboxes accordingly.
                UpdateQuestionTextBoxes(vraagleerDTO);
                UpdateCombinationTextboxes(vraagleerDTO);
                paperCode.Focus();
            }

            public void paperCode_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Get the selected eksamen
                selectedEksamen = examYear.SelectedItem?.ToString();
                selectedVraestelKode = paperCode.SelectedItem?.ToString();

                // Call the presenter to retrieve the corresponding maxMark and questionNo values from the database
                var maxMarkValue = presenter.GetMaxMark(selectedEksamen, selectedVraestelKode);
                var questionNoValue = presenter.GetQuestionNo(selectedEksamen, selectedVraestelKode);
                var selectionAmountValue = presenter.GetSelectionAmount(selectedEksamen, selectedVraestelKode);

                // Update the maxMark and questionNo textboxes with the retrieved values
                maxMark.Text = maxMarkValue?.ToString() ?? ""; // Use null-conditional operator to handle null values
                questionNo.Text = questionNoValue?.ToString() ?? "";
                GetalKombinasiesVanKeuseVrae.Text = selectionAmountValue?.ToString() ?? "";

            vraagleerDTO = presenter.GetQuestionPaperDetails(selectedEksamen, selectedVraestelKode);

            // Update the UI to enable/disable and populate the textboxes accordingly.
            UpdateQuestionTextBoxes(vraagleerDTO);
                UpdateCombinationTextboxes(vraagleerDTO);
                maxMark.Focus();
        }

            // Method to update the question textboxes based on the selected VraestelKode and maxQuestions
            public void UpdateQuestionTextBoxes(VraagleerDTO vraagleerDTO)
            {
                // Validate that eksamen and vraestelKode are not null
                if (string.IsNullOrEmpty(selectedEksamen) || string.IsNullOrEmpty(selectedVraestelKode))
                {
                    // Handle the case where eksamen or vraestelKode is null
                    return;
                }
                //vraagleerDTO = presenter.GetQuestionPaperDetails(selectedEksamen, selectedVraestelKode);

                for (int i = 1; i <= 30; i++)
                {
                    TextBox questionTextBox = Controls.Find($"question{i}", true).FirstOrDefault() as TextBox;
                    TextBox maxMarkTextBox = Controls.Find($"VraagMaks{i}", true).FirstOrDefault() as TextBox;
                    CheckBox telVirVraestelMaksCheckbox = Controls.Find($"TelVirVraestelMaks{i}", true).FirstOrDefault() as CheckBox;

                    if (i <= vraagleerDTO.GetalVraeOpVraestel)
                    {
                        questionTextBox.Enabled = true;
                        maxMarkTextBox.Enabled = true;
                        telVirVraestelMaksCheckbox.Enabled = true;
                    }
                    else
                    {
                        questionTextBox.Enabled = false;
                        maxMarkTextBox.Enabled = false;
                        telVirVraestelMaksCheckbox.Enabled = false;
                    }

                    // Retrieve the VraagNaam and VraagMak values from the details object (VraagleerDTO)
                    string vraagNaam = vraagleerDTO?.GetType().GetProperty($"VraagNaam{i}")?.GetValue(vraagleerDTO) as string;
                    bool telVirVraestelMaks = (bool)vraagleerDTO?.GetType().GetProperty($"TelVirVraestelMaks{i}")?.GetValue(vraagleerDTO);
                    float? vraagMaksValue = vraagleerDTO?.GetType().GetProperty($"VraagMaks{i}")?.GetValue(vraagleerDTO) as float?;
                    string vraagMaks = vraagMaksValue.HasValue ? vraagMaksValue.Value.ToString() : string.Empty;

                    questionTextBox.Text = vraagNaam ?? ""; // Use null-conditional operator to handle null values
                    maxMarkTextBox.Text = vraagMaks.ToString() ?? "";
                    telVirVraestelMaksCheckbox.Checked = telVirVraestelMaks;
 
                    if (string.IsNullOrEmpty(selectedEksamen) || string.IsNullOrEmpty(selectedVraestelKode))
                    {
                        // Handle the case where eksamen or vraestelKode is null
                        return;
                    }

                    // Get the updated details from the view
                    //Vraagleer updatedDetails = new Vraagleer(); // Replace with your actual DTO class
                }
                AttachTextBoxEvents();
            }

            public void TextBox_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Move focus to the next MaxMark TextBox
                    TextBox currentTextBox = sender as TextBox;
                    string propertyName = currentTextBox.Name;
                    //float? vraagMaksValue = vraagleerDTO?.GetType().GetProperty($"VraagMaks{i}")?.GetValue(vraagleerDTO) as float?;
                    var property = vraagleerDTO.GetType().GetProperty(propertyName);
                    if (property != null && property.CanWrite)
                    {
                        string value = currentTextBox.Text;
                        float? floatValue = null;
                        short? shortValue = null;

                        if (currentTextBox.Name.Contains("Keuse"))
                        {
                            // Attempt to parse the string to a short
                            if (short.TryParse(value, out short result))
                            {
                                shortValue = result;
                            }
                            property.SetValue(vraagleerDTO, shortValue);

                        }
                        else
                        {
                            // Attempt to parse the string to a float
                            if (float.TryParse(value, out float result))
                            {
                                floatValue = result;
                            }
                            property.SetValue(vraagleerDTO, floatValue);
                        }
                    }

                    if (currentTextBox != null && currentTextBox.Enabled != false && currentTextBox.Name.Contains("Vraag"))
                    {
                        TextBox nextMaxMarkTextBox = GetNextMaxMarkTextBox(currentTextBox);
                        nextMaxMarkTextBox?.Focus();

                        //if (!AreThereMoreEnabledTextboxes(currentTextBox))
                        //{
                        //    // If it's the last enabled textbox, set focus to the exit button
                        //    exitButton.Focus();
                        //}
                    }
                    else if (currentTextBox != null && currentTextBox.Enabled != false && currentTextBox.Name.Contains("Keuse"))
                    {
                        TextBox nextMaxMarkTextBox = GetNextCombinationTextBox(currentTextBox);
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
                    presenter.SaveQuestionPaperDetails(selectedEksamen, selectedVraestelKode, vraagleerDTO);
                }

            }
            private bool AreThereMoreEnabledTextboxes(TextBox currentTextBox)
            {
                // Logic to determine if there are more enabled textboxes
                // For example, you can iterate through the Controls collection and check if any other textbox is enabled after the current one
                foreach (Control control in Controls)
                {
                    if (control is TextBox textBox && textBox.Enabled && textBox.TabIndex > currentTextBox.TabIndex)
                    {
                        return true;
                    }
                }
                return false;
            }

            private TextBox GetNextMaxMarkTextBox(TextBox currentTextBox)
            {
                // Assuming i represents the current question number (e.g., 1, 2, 3...)
                int currentQuestionNumber = int.Parse(currentTextBox.Name.Substring("VraagMaks".Length, currentTextBox.Name.Length - "VraagMaks".Length));
                int nextQuestionNumber = currentQuestionNumber + 1;

                // Construct the name of the next MaxMark TextBox
                string nextMaxMarkTextBoxName = $"VraagMaks{nextQuestionNumber}";

                // Find the next MaxMark TextBox directly
                TextBox nextMaxMarkTextBox = Controls.Find(nextMaxMarkTextBoxName, true).FirstOrDefault() as TextBox;

                return nextMaxMarkTextBox;
            }

            private TextBox GetNextCombinationTextBox(TextBox currentTextBox)
            {
                string[] prefixes = { "KeuseVraeEersteVrgNo", "KeuseVraeLaasteVrgNo", "KeuseVraeGetalVrae" };

                // Extract the current prefix and question number
                string currentPrefix = null;
                int currentQuestionNumber = 0;
                foreach (string prefix in prefixes)
                {
                    if (currentTextBox.Name.StartsWith(prefix))
                    {
                        currentPrefix = prefix;
                        currentQuestionNumber = int.Parse(currentTextBox.Name.Substring(prefix.Length));
                        break;
                    }
                }

                // Find the index of the current prefix in the array
                int currentIndex = Array.IndexOf(prefixes, currentPrefix);

                // Calculate the index of the next prefix
                int nextIndex = (currentIndex + 1) % prefixes.Length;

                // Determine the next question number
                int nextQuestionNumber = currentQuestionNumber;
                if (nextIndex == 0)
                {
                    // If the next prefix is the first one, increment the question number
                    nextQuestionNumber++;
                }

                // Construct the name of the next textbox
                string nextTextBoxName = $"{prefixes[nextIndex]}{nextQuestionNumber}";

                // Find the next textbox by name
                TextBox nextTextBox = Controls.Find(nextTextBoxName, true).FirstOrDefault() as TextBox;

                return nextTextBox;
            }
            private int GetMaxMarkTextBoxIndex(TextBox currentTextBox)
            {
                // This method may not be needed anymore with the direct naming approach
                return 0; // or some other logic based on your naming convention
            }
            // Attach the TextBox_KeyDown event handler to each TextBox in your form
            private void AttachTextBoxEvents()
            {
                for (int i = 1; i <= 30; i++)
                {
                    TextBox questionTextBox = Controls.Find($"question{i}", true).FirstOrDefault() as TextBox;
                    TextBox maxMarkTextBox = Controls.Find($"VraagMaks{i}", true).FirstOrDefault() as TextBox;
                    CheckBox telVirVraestelMaksCheckbox = Controls.Find($"TelVirVraestelMaks{i}", true).FirstOrDefault() as CheckBox;

                    if (questionTextBox != null)
                    {
                        questionTextBox.KeyDown += TextBox_KeyDown;
                    }

                    if (maxMarkTextBox != null)
                    {
                        maxMarkTextBox.KeyDown += TextBox_KeyDown;
                    }

                }
            }

            // Attach the TextBox_KeyDown event handler to each TextBox in your form
            private void AttachCombinationTextBoxEvents()
            {
                for (int i = 1; i <= 18; i++)
                {
                    TextBox fromTextbox = Controls.Find($"KeuseVraeEersteVrgNo{i}", true).FirstOrDefault() as TextBox;
                    TextBox toTextbox = Controls.Find($"KeuseVraeLaasteVrgNo{i}", true).FirstOrDefault() as TextBox;
                    TextBox maxQuestionsTextBox = Controls.Find($"KeuseVraeGetalVrae{i}", true).FirstOrDefault() as TextBox;

                    if (fromTextbox != null)
                    {
                        fromTextbox.KeyDown += TextBox_KeyDown;
                    }

                    if (toTextbox != null)
                    {
                        toTextbox.KeyDown += TextBox_KeyDown;
                    }
                    if (maxQuestionsTextBox != null)
                    {
                        maxQuestionsTextBox.KeyDown += TextBox_KeyDown;
                    }

                }
            }

            public void UpdateCombinationTextboxes(VraagleerDTO vraagleerDTO)
            {
                // Validate that eksamen and vraestelKode are not null
                if (string.IsNullOrEmpty(selectedEksamen) || string.IsNullOrEmpty(selectedVraestelKode))
                {
                    // Handle the case where eksamen or vraestelKode is null
                    return;
                }
                //vraagleerDTO = presenter.GetQuestionPaperDetails(selectedEksamen, selectedVraestelKode);
                //presenter.UpdateCombinationTotalTextboxes(selectedEksamen, selectedVraestelKode);
                
                for (int i = 1; i <= 6; i++)
                {
                    TextBox fromTextbox = Controls.Find($"KeuseVraeEersteVrgNo{i}", true).FirstOrDefault() as TextBox;
                    TextBox toTextbox = Controls.Find($"KeuseVraeLaasteVrgNo{i}", true).FirstOrDefault() as TextBox;
                    TextBox maxQuestionsTextBox = Controls.Find($"KeuseVraeGetalVrae{i}", true).FirstOrDefault() as TextBox;
                    TextBox combinationTotalTextbox = Controls.Find($"combinationTotal{i}", true).FirstOrDefault() as TextBox;


                if (i <= vraagleerDTO.GetalKombinasiesVanKeuseVrae)
                    {
                        fromTextbox.Enabled = true;
                        toTextbox.Enabled = true;
                        maxQuestionsTextBox.Enabled = true;
                        combinationTotalTextbox.Enabled = true;
                        // Set the combination total if available
                        if (vraagleerDTO.CombinationMaxMarks.Count >= i)
                        {
                            combinationTotalTextbox.Text = vraagleerDTO.CombinationMaxMarks[i - 1]?.ToString() ?? "";
                        }
                        else
                        {
                            combinationTotalTextbox.Text = ""; // Clear if no data
                        }
                }
                    else
                    {
                        fromTextbox.Enabled = false;
                        toTextbox.Enabled = false;
                        maxQuestionsTextBox.Enabled = false;
                        combinationTotalTextbox.Enabled = false;
                        combinationTotalTextbox.Text = "";
                }

                    // Retrieve the VraagNaam and VraagMak values from the details object (VraagleerDTO)
                    Int16? keuseVraeEersteVrgNo = vraagleerDTO?.GetType().GetProperty($"KeuseVraeEersteVrgNo{i}")?.GetValue(vraagleerDTO) as Int16?;
                    Int16? keuseVraeLaasteVrgNo = vraagleerDTO?.GetType().GetProperty($"KeuseVraeLaasteVrgNo{i}")?.GetValue(vraagleerDTO) as Int16?;
                    Int16? keuseVraeGetalVrae = vraagleerDTO?.GetType().GetProperty($"KeuseVraeGetalVrae{i}")?.GetValue(vraagleerDTO) as Int16?;


                    fromTextbox.Text = keuseVraeEersteVrgNo.ToString() ?? ""; // Use null-conditional operator to handle null values
                    toTextbox.Text = keuseVraeLaasteVrgNo.ToString() ?? "";
                    maxQuestionsTextBox.Text = keuseVraeGetalVrae.ToString() ?? "";


                }
                ValidateContinuousSequence();
                AttachCombinationTextBoxEvents();
        }

            // Implementation of IQuestionPaperView methods

            public void GetQuestionPaper(Vraagleer questionPaper)
            {
                // Implement logic to display the question paper details in the UI.
            }

            public void ShowMessage(string message)
            {
                // Implement logic to show a message or notification to the user.
            }
            // Method to create or update the question paper
            public void CreateOrUpdateQuestionPaper()
            {
                // Get the values from the UI
                string eksamen = examYear.Text;
                string vraestelKode = paperCode.Text;
                int vraestelMaksimum = int.Parse(maxMark.Text);
                short? getalVraeOpVraestel = short.Parse(questionNo.Text);

                // Notify the presenter to create or update the question paper
                presenter.CreateOrUpdateQuestionPaper(eksamen, vraestelKode, vraestelMaksimum, getalVraeOpVraestel);
            }
            public void button1_Click(object sender, EventArgs e)
            {
                BtnClose_Click(sender, e);
            }
            public void BtnClose_Click(object sender, EventArgs e)
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

            public void maxMark_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Get the values from the UI
                    string eksamen = examYear.Text;
                    string vraestelKode = paperCode.Text;
                    int vraestelMaksimum = int.Parse(maxMark.Text);

                    // Notify the presenter to update the VraestelMaksimum in the database
                    presenter.UpdateVraestelMaksimum(eksamen, vraestelKode, vraestelMaksimum);

                    // Move the cursor to the questionNo textbox
                    questionNo.Focus();
                    UpdateQuestionTextBoxes(vraagleerDTO);

                    // Mark the key event as handled
                    e.Handled = true;
                }
            }

            public void questionNo_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Get the values from the UI
                    string eksamen = examYear.Text;
                    string vraestelKode = paperCode.Text;
                    short? getalVraeOpVraestel = short.Parse(questionNo.Text);
                    // Notify the presenter to update the VraestelMaksimum in the database
                    presenter.UpdateGetalVraeOpVraestel(eksamen, vraestelKode, getalVraeOpVraestel);

                    // Move the cursor to the questionNo textbox
                    VraagMaks1.Focus();
                    UpdateQuestionTextBoxes(vraagleerDTO);
                    //UpdateCombinationTextboxes(vraagleerDTO);

                    // Mark the key event as handled
                    e.Handled = true;
                }
            }

            private void examYear_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    paperCode.Focus();

                    // Mark the key event as handled
                    e.Handled = true;
                }
            }
        //private bool ValidateTotalMarks()
        //{
        //ValidateContinuousSequence();
        //int total = 0;
        //    if (vraagleerDTO.GetalKombinasiesVanKeuseVrae >= 1)
        //    {
        //        for (int i = 1; i <= 6; i++)
        //        {
        //            TextBox combinationTotalTextbox = Controls.Find($"combinationTotal{i}", true).FirstOrDefault() as TextBox;
        //            for (short? j = vraagleerDTO.GetalKombinasiesVanKeuseVrae; j >= 1; j--)
        //            {
        //                total += int.TryParse(combinationTotalTextbox.Text, out int value) ? value : 0;
        //            }
        //        }
        //    }
        //        for (int i = 1; i <= vraagleerDTO.GetalVraeOpVraestel; i++)
        //        {
        //            if (vraagleerDTO.GetalKombinasiesVanKeuseVrae < 1)
        //            {
        //                TextBox maxMarkTextBox = Controls.Find($"VraagMaks{i}", true).FirstOrDefault() as TextBox;
        //                if (maxMarkTextBox != null && maxMarkTextBox.Enabled && !string.IsNullOrEmpty(maxMarkTextBox.Text))
        //                {
        //                    total += int.Parse(maxMarkTextBox.Text);
        //                }
        //            }
        //        }
        //        // Assuming there is a TextBox or Label to display the total
        //        TextBox totalMarksTextBox = Controls.Find("currentMark", true).FirstOrDefault() as TextBox;
        //        if (totalMarksTextBox != null)
        //        {
        //            currentMark.Text = total.ToString();
        //            //total = 0;
        //        }
        //        //UpdateTotalMarks();
        //        int maxMarkValue = int.Parse(maxMark.Text);
        //            if (total != maxMarkValue)
        //            {
        //                MessageBox.Show($"The sum of all marks ({total}) does not equal the total max mark ({maxMarkValue}).", "Total Marks Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            total = 0;
        //            return false;
        //            }

        //        total = 0;
        //return true;
        //}

        public bool ValidateContinuousSequence()
        {
            int expectedNextStart = 1;
            int highestNumber = 0;
            int total = 0;

            for (int i = 1; i <= 6; i++)
            {
                TextBox fromTextbox = Controls.Find($"KeuseVraeEersteVrgNo{i}", true).FirstOrDefault() as TextBox;
                TextBox toTextbox = Controls.Find($"KeuseVraeLaasteVrgNo{i}", true).FirstOrDefault() as TextBox;
                CheckBox questionCheckbox = Controls.Find($"TelVirVraestelMaks{expectedNextStart}", true).FirstOrDefault() as CheckBox;

                if (fromTextbox != null && toTextbox != null && fromTextbox.Enabled)
                {
                    int fromNumber = int.Parse(fromTextbox.Text);
                    int toNumber = int.Parse(toTextbox.Text);

                    // Check for continuity
                    if (fromNumber != expectedNextStart)
                    {
                        HandleMissingQuestion(expectedNextStart, ref total);
                        questionCheckbox.CheckState = CheckState.Checked;

                    }

                    expectedNextStart = toNumber + 1;
                    highestNumber = Math.Max(highestNumber, toNumber);
                }
            }

            if (vraagleerDTO.GetalKombinasiesVanKeuseVrae >= 1)
            {
                for (int i = 1; i <= 6; i++)
                {
                    AddCombinationTotals(i, vraagleerDTO.GetalKombinasiesVanKeuseVrae, ref total);
                }
            }
            else
            {
                AddIndividualQuestionMarks(vraagleerDTO.GetalVraeOpVraestel, ref total);
            }

            UpdateTotalMarksTextBox(total);

            int maxMarkValue = int.Parse(maxMark.Text);
            if (total != maxMarkValue)
            {
                MessageBox.Show($"The sum of all marks ({total}) does not equal the total max mark ({maxMarkValue}).", "Total Marks Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                total = 0;
                return false;
            }

            // Final check for the end of the sequence
            TextBox maxQuestionsTextBox = Controls.Find("maxQuestionNumber", true).FirstOrDefault() as TextBox;

            if (maxQuestionsTextBox != null)
            {
                int totalQuestions = int.Parse(maxQuestionsTextBox.Text);

                if (highestNumber != totalQuestions)
                {
                    MessageBox.Show($"The sequence does not include all questions up to the total {totalQuestions}. Last covered question is {highestNumber}.", "Sequence Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            total = 0;
            return true;
        }
        private void HandleMissingQuestion(int expectedNextStart, ref int total)
        {
            CheckBox questionCheckbox = Controls.Find($"TelVirVraestelMaks{expectedNextStart}", true).FirstOrDefault() as CheckBox;

            if (questionCheckbox != null && !questionCheckbox.Checked)
            {
                MessageBox.Show($"Question {expectedNextStart} is a compulsory question and must be answered. It will be automatically selected.", "Compulsory Question Missed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                questionCheckbox.Checked = true;
            }

            string indexStr = questionCheckbox.Name.Replace("TelVirVraestelMaks", "");
            TextBox maxMarkTextBox = Controls.Find($"VraagMaks{indexStr}", true).FirstOrDefault() as TextBox;
            if (maxMarkTextBox != null && int.TryParse(maxMarkTextBox.Text, out int maxMark))
            {
                total += maxMark;
            }
        }

        private void AddCombinationTotals(int combinationIndex, short? getalKombinasiesVanKeuseVrae, ref int total)
        {
            //for (short? j = getalKombinasiesVanKeuseVrae; j >= 1; j--)
            //{
                TextBox combinationTotalTextbox = Controls.Find($"combinationTotal{combinationIndex}", true).FirstOrDefault() as TextBox;
                if (combinationTotalTextbox != null && int.TryParse(combinationTotalTextbox.Text, out int value))
                {
                    total += value;
                }
            //}
        }

        private void AddIndividualQuestionMarks(short? getalVraeOpVraestel, ref int total)
        {
            for (int p = 1; p <= getalVraeOpVraestel; p++)  //maybe remove this
            {
                TextBox maxMarkTextBox = Controls.Find($"VraagMaks{p}", true).FirstOrDefault() as TextBox;
                if (maxMarkTextBox != null && maxMarkTextBox.Enabled && !string.IsNullOrEmpty(maxMarkTextBox.Text))
                {
                    total += int.Parse(maxMarkTextBox.Text);
                }
            }
        }

        private void UpdateTotalMarksTextBox(int total)
        {
            TextBox totalMarksTextBox = Controls.Find("currentMark", true).FirstOrDefault() as TextBox;
            if (totalMarksTextBox != null)
            {
                totalMarksTextBox.Text = total.ToString();
            }
        }


        private void paperCode_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    maxMark.Focus();

                    // Mark the key event as handled
                    e.Handled = true;
                }
            }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int f = 1; f <= vraagleerDTO.GetalVraeOpVraestel; f++) { 
                CheckBox checkBox = sender as CheckBox;
            // Extracting the numeric part of the checkbox's name to find associated controls
            string index = checkBox.Name.Replace("TelVirVraestelMaks", "");
            int currentIndex = int.Parse(index);
            if (checkBox != null)
            {
                
                TextBox questionTextBox = Controls.Find($"question{index}", true).FirstOrDefault() as TextBox;
                TextBox maxMarkTextBox = Controls.Find($"VraagMaks{index}", true).FirstOrDefault() as TextBox;

                bool isChecked = checkBox.Checked;
                questionTextBox.Enabled = isChecked;
                maxMarkTextBox.Enabled = isChecked;

                // Optionally reset the text boxes when unchecked
                if (!isChecked)
                {
                    //questionTextBox.Text = string.Empty;
                    maxMarkTextBox.Text = string.Empty;
                }
                else
                {
                    UpdateQuestionTextBoxes(vraagleerDTO);
                }

                // Recalculate total marks
                //ValidateTotalMarks();
            }
            }
            // Check if the UserControl has finished loading
            if (isUserControlLoaded)
            {
                allCheckboxesProcessed = true;
                UpdateCombinationTextboxes(vraagleerDTO);
            }
        }

        private void combinationTotal1_TextChanged(object sender, EventArgs e)
        {

        }

        //public void UpdateTotalMarks()
        //{
        //int total = 0;
        //for (int i = 1; i <= vraagleerDTO.GetalVraeOpVraestel; i++)
        //{ 
        //    if (vraagleerDTO.GetalKombinasiesVanKeuseVrae < 1) 
        //    { 
        //        TextBox maxMarkTextBox = Controls.Find($"VraagMaks{i}", true).FirstOrDefault() as TextBox;
        //        if (maxMarkTextBox != null && maxMarkTextBox.Enabled && !string.IsNullOrEmpty(maxMarkTextBox.Text))
        //        {
        //            total += int.Parse(maxMarkTextBox.Text);
        //        }
        //    }
        //}
        //// Assuming there is a TextBox or Label to display the total
        //TextBox totalMarksTextBox = Controls.Find("currentMark", true).FirstOrDefault() as TextBox;
        //if (totalMarksTextBox != null)
        //{
        //    currentMark.Text = total.ToString();
        //    //total = 0;
        //}
        //total = 0;
        //}



        public void GetalKombinasiesVanKeuseVrae_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    // Get the values from the UI
                    string eksamen = examYear.Text;
                    string vraestelKode = paperCode.Text;
                    short? getalKombinasiesVanKeuseVrae = short.Parse(GetalKombinasiesVanKeuseVrae.Text);
                    // Notify the presenter to update the VraestelMaksimum in the database
                    presenter.UpdateGetalKombinasiesTeBeantwoord(eksamen, vraestelKode, getalKombinasiesVanKeuseVrae);

                    // Move the cursor to the questionNo textbox
                    KeuseVraeEersteVrgNo1.Focus();
                    UpdateCombinationTextboxes(vraagleerDTO);

                    // Mark the key event as handled
                    e.Handled = true;
                }

        }
        }
    }


