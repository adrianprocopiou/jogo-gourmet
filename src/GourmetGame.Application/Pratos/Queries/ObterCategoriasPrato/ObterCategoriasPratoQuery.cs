using GourmetGame.Application.Core.Queries;
using GourmetGame.Application.Pratos.Entities;
using GourmetGame.Application.Pratos.Repositories;

namespace GourmetGame.Application.Pratos.Queries.ObterCategoriaPrato
{
    public class ObterCategoriasPratoQuery : IQuery<List<CategoriaPrato>>
    {
        /// <summary>
        /// Caso seja informado true, retorna apenas as categorias que não são associadas a outras categorias. Ou seja, que não são Subcategorias.
        /// </summary>
        public bool ApenasCategoriasPrincipais { get; set; }
    }

    public class ObterCategoriasPratoQueryHandler : IQueryHandler<ObterCategoriasPratoQuery, List<CategoriaPrato>>
    {
        private readonly ICategoriaPratoRepository _repository;

        public ObterCategoriasPratoQueryHandler(ICategoriaPratoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoriaPrato>> Handle(ObterCategoriasPratoQuery query, CancellationToken cancellationToken)
        {
            return await _repository
                .GetCategoriasPratoAsync(query.ApenasCategoriasPrincipais, cancellationToken);
        }
    }
}
