using GourmetGame.Application.Pratos.Entities;

namespace GourmetGame.Application.Data.Contexts
{
    public class ApplicationContext : IApplicationContext
    {
        private bool IsSeeded { get; set; }
        public ICollection<CategoriaPrato> CategoriasPratos { get; }

        public ICollection<Prato> Pratos { get; }

        public ApplicationContext()
        {
            CategoriasPratos = new List<CategoriaPrato>();
            Pratos = new List<Prato>();
            IsSeeded = false;
            Seed();
        }

        public void Seed()
        {
            if (IsSeeded) return;
            
            var lasanha = new Prato("Lasanha", 1) { Id = 1 };
            var massas = new CategoriaPrato("massa", lasanha) { Id = 1};
            Pratos.Add(lasanha);
            CategoriasPratos.Add(massas);
            IsSeeded = true;
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => { /*Simulando um SaveChanges do EntityFramework*/}, cancellationToken);
        }
    }
    public static class ApplicationContextExtensions {
        // Simula o Entity Framework adicionado os objetos no banco
        public static async Task AddAsyncToFakeDb(this ICollection<CategoriaPrato> dbSet, IApplicationContext context,  CategoriaPrato obj, CancellationToken cancellationToken) {
            await Task.Run(() => {
                // Simulando um Id do Banco
                obj.Id = context.CategoriasPratos.Count + 1;
                obj.Prato.Id = context.Pratos.Count + 1;
                
                obj.Prato.CategoriaPratoId = obj.Id;

                context.CategoriasPratos.Add(obj);
                context.Pratos.Add(obj.Prato);

                // Gerenciando Dependencias
                if (obj.CategoriaAssociadaId is not null)
                {
                    var categoriaAssociada = context.CategoriasPratos.FirstOrDefault(c => c.Id == obj.CategoriaAssociadaId);
                    if (categoriaAssociada is not null)
                    {
                        categoriaAssociada.SubCategorias.Add(obj);
                    }
                }
            });
        }

        public static async Task<bool> AnyAsyncFakeDb<T>(this ICollection<T> dbSet, Func<T, bool> predicate, CancellationToken cancellationToken)
        {
            return await Task.Run(() => dbSet.Any(predicate), cancellationToken);
        }

        public static async Task<List<T>> ToListAsync<T>(this IEnumerable<T> dbSet, CancellationToken cancellationToken)
        {
            return await Task.Run(() => dbSet.ToList(), cancellationToken);
        }
    }   
}
