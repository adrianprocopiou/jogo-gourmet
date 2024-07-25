using GourmetGame.WindowsForms.Services;

namespace GourmetGame.WindowsForms
{
    public partial class FrmPrincipal : Form
    {
        private readonly IGourmetGameService _service;
        public FrmPrincipal(IGourmetGameService service)
        {
            _service = service;
            InitializeComponent();
        }
        private void btnInicioJogo_ClickAsync(object sender, EventArgs e)
        {
            _service.IniciarJogo();
        }
    }
}
