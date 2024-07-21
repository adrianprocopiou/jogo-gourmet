using GourmetGame.Application.Data.Contexts;
using GourmetGame.Application.Pratos.Entities;

namespace GourmetGame.Application.Pratos.Repositories
{
    public class CategoriaPratoRepository : ICategoriaPratoRepository
    {
        private readonly IApplicationContext _context;

        public CategoriaPratoRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CategoriaPrato categoriaPrato, CancellationToken cancellationToken)
        {
            // Simulando uma operação assincrona no banco de dados
            await _context
                .CategoriasPratos
                .AddAsyncToFakeDb(_context,categoriaPrato, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> CategoriaPratoExistsAsync(int categoriaPratoId, CancellationToken cancellationToken)
        {
            // Simulando uma operação assincrona no banco de dados
            return await _context
                .CategoriasPratos
                .AnyAsyncFakeDb(c => c.Id == categoriaPratoId, cancellationToken);
        }

        public async Task<List<CategoriaPrato>> GetCategoriasPratoAsync(bool apenasCategoriasPrincipais, CancellationToken cancellationToken)
        {
            // Simulando uma operação assincrona no banco de dados o AsEnumerable() é para simular o AsQueryable() do EntityFramework
            var query = _context
                .CategoriasPratos
                .AsEnumerable();

            if (apenasCategoriasPrincipais)
            {
                query = query
                    .Where(c => c.CategoriaAssociadaId is null);
            }

            return await query
                .ToListAsync(cancellationToken);
        }
    }
}
