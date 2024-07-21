using GourmetGame.Application.Pratos.Entities;

namespace GourmetGame.Application.Pratos.Repositories
{
    public interface ICategoriaPratoRepository
    {
        Task<bool> CategoriaPratoExistsAsync(int categoriaPratoId, CancellationToken cancellationToken);
        Task AddAsync(CategoriaPrato categoriaPrato, CancellationToken cancellationToken);

        Task<List<CategoriaPrato>> GetCategoriasPratoAsync(bool apenasCategoriasPrincipais, CancellationToken cancellationToken);
    }
}
