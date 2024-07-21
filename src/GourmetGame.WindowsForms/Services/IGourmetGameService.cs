namespace GourmetGame.WindowsForms.Services
{
    public interface IGourmetGameService
    {
        Task IniciarJogo(CancellationToken cancellationToken);
    }
}
