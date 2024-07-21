using GourmetGame.Application.Pratos.Entities;

namespace GourmetGame.Application.Data.Contexts
{
    public interface IApplicationContext
    {
        public ICollection<CategoriaPrato> CategoriasPratos { get; }
        public ICollection<Prato> Pratos { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
