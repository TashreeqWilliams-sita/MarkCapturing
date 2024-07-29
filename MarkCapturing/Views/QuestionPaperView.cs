using MarkCapturing.Presenter;
using DataAccessLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarkCapturing.Views.Interfaces;
using DataAccessLibrary;
using DTOs;

namespace MarkCapturing.Views
{
    public partial class QuestionPaperView : Form, IQuestionPaperView
    {
        string selectedEksamen;
        string selectedVraestelKode;
        private IQuestionPaperPresenter presenter;
        
        VraagleerDTO vraagleerDTO = new VraagleerDTO();
        //private readonly VraagleerDTO _vraagleerDTO;
        private int maxQuestions; // Store the maximum number of questions allowed
        int? firstQuestionNo, selectionAmount;

        public QuestionPaperView(IQuestionPaperPresenter presenter/*, VraagleerDTO vraagleerDTO*/)
        {
            //_vraagleerDTO = vraagleerDTO;

            InitializeComponent();
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
            maxQuestions = 0;
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

            // Update the UI to enable/disable and populate the textboxes accordingly.
            UpdateQuestionTextBoxes(vraagleerDTO);
            UpdateCombinationTextboxes(vraagleerDTO);
            maxMark.Focus();

        }
        //public bool HasData(VraagleerDTO vraagleerDTO)
        //{
        //    // Check if the DTO itself is null
        //    if (vraagleerDTO == null)
        //    {
        //        return false;
        //    }
            
        //    // Check individual properties for null or empty values
        //    for (int i = 1; i <= 30; i++)
        //    {
        //        string vraagNaam = vraagleerDTO?.GetType().GetProperty($"VraagNaam{i}")?.GetValue(vraagleerDTO) as string;
        //        bool telVirVraestelMaks = (bool)vraagleerDTO?.GetType().GetProperty($"TelVirVraestelMaks{i}")?.GetValue(vraagleerDTO);
        //        float? vraagMaksValue = vraagleerDTO?.GetType().GetProperty($"VraagMaks{i}")?.GetValue(vraagleerDTO) as float?;

        //        // Check if any property has a value
        //        if (!string.IsNullOrEmpty(vraagNaam) || telVirVraestelMaks || vraagMaksValue.HasValue)
        //        {
        //            return true; // DTO has data
        //        }
        //    }

        //    // If no properties have data
        //    return false;
        //}


        // Method to update the question textboxes based on the selected VraestelKode and maxQuestions
        public void UpdateQuestionTextBoxes(VraagleerDTO vraagleerDTO)
        {
            // Validate that eksamen and vraestelKode are not null
            if (string.IsNullOrEmpty(selectedEksamen) || string.IsNullOrEmpty(selectedVraestelKode))
            {
                // Handle the case where eksamen or vraestelKode is null
                return;
            }
            vraagleerDTO = presenter.GetQuestionPaperDetails(selectedEksamen, selectedVraestelKode);

            for (int i = 1; i <= 30 ; i++)
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

                //questionTextBox.Enabled = true;
                //maxMarkTextBox.Enabled = true;
                //telVirVraestelMaksCheckbox.Enabled = true;

                // Set the radio button state (checked or unchecked) based on some logic
                // Example: You can check the radio button if vraagNaam or vraagMak meets certain conditions
                // bool shouldCheckRadioButton = /* Your logic here */;
                // telVirVraestelMaksRadioButton.Checked = shouldCheckRadioButton;
                // Validate that eksamen and vraestelKode are not null
                if (string.IsNullOrEmpty(selectedEksamen) || string.IsNullOrEmpty(selectedVraestelKode))
                {
                    // Handle the case where eksamen or vraestelKode is null
                    return;
                }

                // Get the updated details from the view
                Vraagleer updatedDetails = new Vraagleer(); // Replace with your actual DTO class

                // Save the updated details to the database

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

                    if (currentTextBox.Name.Contains("Keuse")){
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

                // Attach the event handler for the checkbox if needed
                // telVirVraestelMaksCheckbox.KeyDown += TextBox_KeyDown;
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
        public int GetCombinationMaxMark(string eksamen, string vraestelKode, int firstQuestion, int lastQuestion, int maxQuestions)
        {
            // This function will execute a SQL query similar to the one we discussed, tailored to the parameters provided
            // Database access code (e.g., using ADO.NET, Entity Framework, Dapper, etc.) goes here
            // Placeholder return statement
            return 0; // This should actually return the sum from the database query
        }

        public void UpdateCombinationTextboxes(VraagleerDTO vraagleerDTO)
        {
            if (string.IsNullOrEmpty(selectedEksamen) || string.IsNullOrEmpty(selectedVraestelKode))
            {
                return;
            }

            vraagleerDTO = presenter.GetQuestionPaperDetails(selectedEksamen, selectedVraestelKode);

            bool allCombinationsValid = true; // Track if all combinations are valid

            for (int i = 1; i <= 6; i++)
            {
                TextBox fromTextbox = Controls.Find($"KeuseVraeEersteVrgNo{i}", true).FirstOrDefault() as TextBox;
                TextBox toTextbox = Controls.Find($"KeuseVraeLaasteVrgNo{i}", true).FirstOrDefault() as TextBox;
                TextBox maxQuestionsTextBox = Controls.Find($"KeuseVraeGetalVrae{i}", true).FirstOrDefault() as TextBox;

                if (i <= vraagleerDTO.GetalKombinasiesVanKeuseVrae)
                {
                    fromTextbox.Enabled = true;
                    toTextbox.Enabled = true;
                    maxQuestionsTextBox.Enabled = true;
                }
                else
                {
                    fromTextbox.Enabled = false;
                    toTextbox.Enabled = false;
                    maxQuestionsTextBox.Enabled = false;
                }

                Int16? firstQuestion = vraagleerDTO?.GetType().GetProperty($"KeuseVraeEersteVrgNo{i}")?.GetValue(vraagleerDTO) as Int16?;
                Int16? lastQuestion = vraagleerDTO?.GetType().GetProperty($"KeuseVraeLaasteVrgNo{i}")?.GetValue(vraagleerDTO) as Int16?;
                Int16? maxQuestions = vraagleerDTO?.GetType().GetProperty($"KeuseVraeGetalVrae{i}")?.GetValue(vraagleerDTO) as Int16?;

                fromTextbox.Text = firstQuestion.ToString() ?? "";
                toTextbox.Text = lastQuestion.ToString() ?? "";
                maxQuestionsTextBox.Text = maxQuestions.ToString() ?? "";

                if (firstQuestion.HasValue && lastQuestion.HasValue && maxQuestions.HasValue)
                {
                    int combinationMaxMark = GetCombinationMaxMark(selectedEksamen, selectedVraestelKode, firstQuestion.Value, lastQuestion.Value, maxQuestions.Value);
                    // Assume we retrieve maxMark for the current combination from somewhere in VraagleerDTO
                    int maxMark = vraagleerDTO?.GetType().GetProperty($"MaxMark{i}")?.GetValue(vraagleerDTO) as int? ?? 0;

                    if (combinationMaxMark != maxMark)
                    {
                        allCombinationsValid = false;
                        MessageBox.Show($"Error: Combination {i} max mark does not match expected max mark.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            AttachCombinationTextBoxEvents();
            // If all combinations are valid, possibly proceed to other actions or focus the exit button
            if (allCombinationsValid)
            {
                //exitButton.Focus(); // Enable this line if necessary
            }
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

        public void label4_Click(object sender, EventArgs e)
        {

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

        private void paperCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                maxMark.Focus();

                // Mark the key event as handled
                e.Handled = true;
            }
        }
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

        private void PnlRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void question8Max_TextChanged(object sender, EventArgs e)
        {

        }

        private void question23Max_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void KeuseVraeEersteVrgNo1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void KeuseVraeEersteVrgNo1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }
    }
}
