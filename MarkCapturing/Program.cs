using MarkCapturing.Views;
using System;
using System.Windows.Forms;

namespace MarkCapturing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
            Application.Run(new MenuForm());
            Application.Run(new UpdateQuestionMarksForm());
            Application.Run(new UpdatingQuestionsForm());
        }
    }
}
