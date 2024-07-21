using GourmetGame.WindowsForms.Core.InputDialogBox;

namespace GourmetGame.WindowsForms.Core.DisplayMessage
{
    public class DisplayMessageService : IDisplayMessageService
    {
        private readonly IInputDialogBox _inputDialogBox;

        public DisplayMessageService(IInputDialogBox inputDialogBox)
        {
            _inputDialogBox = inputDialogBox;
        }

        public InputDialogBoxResult GetInputString(string captionText, string title = "Jogo Gourmet")
        {
            return _inputDialogBox.ShowDialogBox(captionText, title);
        }

        public DialogResult ShowInformation(string informationText, string title = "Jogo Gourmet")
        {
            return MessageBox.Show(informationText, "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult ShowQuestion(string questionText, string title = "Confirm")
        {
            return MessageBox.Show(questionText, "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }
    }
}
