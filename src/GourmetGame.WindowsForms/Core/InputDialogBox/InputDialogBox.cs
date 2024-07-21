using GourmetGame.WindowsForms.Core.InputDialogBox;

namespace GourmetGame.WindowsForms
{
    public partial class InputDialogBox : Form, IInputDialogBox
    {
        public InputDialogBox()
        {
            InitializeComponent();
        }

        public InputDialogBoxResult ShowDialogBox(string captionText, string title = "Jogo Gourmet")
        {
            txtUserInput.Text = string.Empty;
            lblCaption.Text = captionText;
            Text = title;
            return new InputDialogBoxResult(ShowDialog(), txtUserInput.Text);
        }
        protected override void OnShown(EventArgs e)
        {
            txtUserInput.Focus();
            base.OnShown(e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
