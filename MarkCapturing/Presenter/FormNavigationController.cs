using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkCapturing.Presenter
{
    //This class will serve as central navigation to control our forms and which ones are displayed or not
    public class FormNavigationController
    {
        private Form _currentForm;

        public void ShowForm(Form newform)
        {
            if (_currentForm != null)
            {
                _currentForm.Hide();
                _currentForm.Dispose();
            }
            _currentForm = newform;
            _currentForm.Closed += (s, args) => _currentForm = null;
            _currentForm.Show();
        }
    }
}
