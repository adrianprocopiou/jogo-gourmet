using GourmetGame.Application.Core.Errors;
using GourmetGame.WindowsForms.Core.InputDialogBox;

namespace GourmetGame.WindowsForms.Core.DisplayMessage
{
    public interface IDisplayMessageService
    {
        InputDialogBoxResult GetInputString(string captionText, string title = "Jogo Gourmet");
        DialogResult ShowQuestion(string questionText, string title = "Confirm");
        DialogResult ShowInformation(string informationText, string title = "Jogo Gourmet");
        DialogResult ShowWarnings(List<BusinessError> errors, string title = "Atenção");
    }
}
