using MarkCapturing.Views.Interfaces;
using MarkCapturing.Services;

namespace MarkCapturing.Presenter
{
    public class UpdateQuestionsMenuPresenter
    {
        private readonly IUpdateQuestionMarksView view;


        public UpdateQuestionsMenuPresenter(IUpdateQuestionMarksView _view)
        {
            this.view = _view;
        }
    }
}
