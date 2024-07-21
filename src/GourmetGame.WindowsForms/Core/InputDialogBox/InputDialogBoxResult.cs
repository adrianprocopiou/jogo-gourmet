namespace GourmetGame.WindowsForms.Core.InputDialogBox
{
    public class InputDialogBoxResult
    {
        public InputDialogBoxResult(DialogResult result, string inputText)
        {
            Result = result;
            InputText = inputText;
        }

        public string? InputText { get; set; }
        public DialogResult Result { get; set; }
    }
}
