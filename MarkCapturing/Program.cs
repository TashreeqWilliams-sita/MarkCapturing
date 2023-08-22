using MarkCapturing.Presenter;
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
        /// 
        public static FormNavigationController FormNavController = new FormNavigationController();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormNavController.ShowForm(new FormLogin());
            Application.Run();
        }
    }
}
