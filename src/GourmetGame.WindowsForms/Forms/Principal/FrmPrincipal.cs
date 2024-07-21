using GourmetGame.WindowsForms.Services;

namespace GourmetGame.WindowsForms
{
    public partial class FrmPrincipal : Form
    {
        private readonly IGourmetGameService _service;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        public FrmPrincipal(IGourmetGameService service)
        {
            _service = service;
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
        }
        private async void btnInicioJogo_ClickAsync(object sender, EventArgs e)
        {
            _cancellationToken = _cancellationTokenSource.Token;
            await _service.IniciarJogo(_cancellationToken);
        }
    }
}
