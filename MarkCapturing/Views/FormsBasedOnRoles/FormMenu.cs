using DataAccessLibrary;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Repositories;
using DTOs;
using MarkCapturing.Presenter;
using MarkCapturing.Views.FormsBasedOnRoles;
using MarkCapturing.Views.Interfaces;
using MarkCapturing.Views.Security;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarkCapturing.Views
{
    public partial class FormMenu : Form, IMenuView
    {
        private readonly MenuPresenter _presenter;
        public string Username => DataStorage.UserLoggedIn;
        public string Role=>DataStorage.Role;

        private readonly MarksheetRepository _marksheetRepository;

        public FormMenu()
        {
            InitializeComponent();
            NSC_VraagpunteStelselEntities dbContext = new NSC_VraagpunteStelselEntities();
            _marksheetRepository = new MarksheetRepository(dbContext);
            _presenter = new MenuPresenter(this);
            LblUserLoggedin.Text = Username;
        }
        private void BtnSecurity_Click(object sender, EventArgs e)
        {
            //FormResetPasswordRequests formResetPasswordRequests = new FormResetPasswordRequests(Username);
            //formResetPasswordRequests.Show();
            FormSecuritySystemParameters formResetPassword = new FormSecuritySystemParameters();
            Program.FormNavController.ShowForm(formResetPassword);
            //formResetPassword.Show();
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            //VraagleerDTO vraagleerDTO = new VraagleerDTO();
            NSC_VraagpunteStelselEntities dbContext = new NSC_VraagpunteStelselEntities();

            QuestionPaperRepository repository = new QuestionPaperRepository(dbContext/*, vraagleerDTO*/);
            QuestionPaperPresenter presenter = new QuestionPaperPresenter(repository);
            
            IQuestionPaperPresenter presenterInterface = (IQuestionPaperPresenter)presenter;


            // Pass the presenter to the view constructor
            QuestionPaperView questionPaperView = new QuestionPaperView(presenterInterface/*, vraagleerDTO*/);
            questionPaperView.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            BtnClose_Click(sender, e);
        }

        private void BtnUpdateQuestion_Click(object sender, EventArgs e)
        {
            UpdateQuestionMarksForm updateQuestionMarksForm = new UpdateQuestionMarksForm(this);
            updateQuestionMarksForm.Show();
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
                Application.Exit();
            }
        }
        public void GetForm()
        {
            _presenter.InitializeView();
        }
        public void ShowMenuForm()
        {
            this.Show();
        }

        public void ShowCapturerForm()
        {
            FormCapturer formCapturer = new FormCapturer();
            formCapturer.Show();
        }

        public void ShowSuperuserForm()
        {
            FormSuperuser formSuperuser = new FormSuperuser();
            formSuperuser.Show();
        }

        public void ShowVerifierForm()
        {
            FormVerifier formVerifier = new FormVerifier();
            formVerifier.Show();
        }

        public void ShowScriptsForm()
        {
            FormScripts formScripts = new FormScripts();
            formScripts.Show();
        }

        public void ShowBoxerForm()
        {
            FormBoxer formBoxer = new FormBoxer();
            formBoxer.Show();
        }

        public void ShowScriptInForm()
        {
            FormScriptIn formScriptIn = new FormScriptIn();
            formScriptIn.Show();
        }

        public void ShowScriptOutForm()
        {
            FormScriptOut formScriptOut = new FormScriptOut();
            formScriptOut.Show();
        }

        public void showErrorMessage(string message)
        {
            MessageBox.Show(message, "Login Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            NSC_VraagpunteStelselEntities DbContext = new NSC_VraagpunteStelselEntities();
            QuestionPaperRepository questionPaperRepository = new QuestionPaperRepository(DbContext);
            QuestionPaperPresenter questionPaperPresenter = new QuestionPaperPresenter(questionPaperRepository);
            MarksheetRepository marksheetRepository = new MarksheetRepository(DbContext);
            QuestionsPresenter questionsPresenter = new QuestionsPresenter(marksheetRepository);
            // Create an instance of the UserForm
            CaptureMarksUserControl captureMarksUserControl = new CaptureMarksUserControl(questionsPresenter);
            UpdateQuestionPaperUserControl updateQuestionPaperUserControl = new UpdateQuestionPaperUserControl(questionPaperPresenter);
            // Dock the userForm to fill the entire client area of FormMenu
            captureMarksUserControl.Dock = DockStyle.Fill;
            updateQuestionPaperUserControl.Dock = DockStyle.Fill;
            // Add the userForm to the Controls collection of FormMenu
            CaptureMarks.Controls.Add(captureMarksUserControl);
            UpdateQuestionPaper.Controls.Add(updateQuestionPaperUserControl);
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void PnlRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_MarkSheetTextBox(object sender, EventArgs e)
        {
            //if textbox takes marksheet number, then call relevent methods to get your info
        }

      
        private void label14_Click(object sender, EventArgs e)
        {
           
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        
        {
            string inputText = textBox1.Text;
            string result = null;
            textBox1.MaxLength = 11;

            if (inputText.Length == 11 && inputText[9] == '-') { 
                
                result = _marksheetRepository.GetMarksheetNum(inputText);

                label14.Text = result;
                textBox1.Clear();
            }
            
        }



        //#region ButtonMouseHoverEvents
        //private void BtnUpdateQuestion_MouseHover(object sender, EventArgs e)
        //{
        //    //Color of the current button when hovering
        //    BtnUpdateQuestion.ForeColor = Color.White;
        //    BtnUpdateQuestion.BackColor = Color.FromArgb(41, 128, 185);

        //    //Color of other buttons
        //    BtnSecurity.BackColor = SystemColors.Control;
        //    BtnSecurity.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnReports.ForeColor = Color.FromArgb(41, 128, 185);
        //    BtnReports.BackColor = Color.White;

        //    BtnExit.BackColor = SystemColors.Control;
        //    BtnExit.ForeColor = Color.FromArgb(41, 128, 185);
        //}

        //private void BtnReports_MouseHover(object sender, EventArgs e)
        //{
        //    //Color of the current button when hovering
        //    BtnReports.BackColor = Color.FromArgb(41, 128, 185);
        //    BtnReports.ForeColor = Color.White;

        //    //Color of other buttons
        //    BtnSecurity.BackColor = SystemColors.Control;
        //    BtnSecurity.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnUpdateQuestion.BackColor = SystemColors.Control;
        //    BtnUpdateQuestion.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnExit.BackColor = SystemColors.Control;
        //    BtnExit.ForeColor = Color.FromArgb(41, 128, 185);
        //}

        //private void BtnSecurity_MouseHover(object sender, EventArgs e)
        //{
        //    //Color of the current button when hovering
        //    BtnSecurity.BackColor = Color.FromArgb(41, 128, 185);
        //    BtnSecurity.ForeColor = Color.White;

        //    //Color of other buttons
        //    BtnReports.BackColor = SystemColors.Control;
        //    BtnReports.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnExit.BackColor = SystemColors.Control;
        //    BtnExit.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnUpdateQuestion.BackColor = SystemColors.Control;
        //    BtnUpdateQuestion.ForeColor = Color.FromArgb(41, 128, 185);
        //}

        //private void BtnExit_MouseHover(object sender, EventArgs e)
        //{
        //    //Color of the current button when hovering
        //    BtnExit.BackColor = Color.FromArgb(41, 128, 185);
        //    BtnExit.ForeColor = Color.White;

        //    //Color of other buttons
        //    BtnReports.BackColor = SystemColors.Control;
        //    BtnReports.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnUpdateQuestion.BackColor = SystemColors.Control;
        //    BtnUpdateQuestion.ForeColor = Color.FromArgb(41, 128, 185);

        //    BtnSecurity.BackColor = SystemColors.Control;
        //    BtnSecurity.ForeColor = Color.FromArgb(41, 128, 185);
        //}
        //#endregion
    }
}
