using GourmetGame.Application.Core.Commands;
using GourmetGame.Application.Core.Results;
using GourmetGame.Application.Pratos.Entities;
using GourmetGame.Application.Pratos.Repositories;
using MediatR;

namespace GourmetGame.Application.Pratos.Commands.AdicionarCategoriaPratoCommand
{
    public class AdicionarCategoriaPratoCommand : ICommand<CommandResult<Unit>>
    {
        public int? CategoriaAssociadaId { get; set; }
        public required string NomeCategoria { get; set; }
        public required string NomePrato { get; set; }
    }

    public class AdicionarCategoriaPratoCommandHandler : ICommandHandler<AdicionarCategoriaPratoCommand, CommandResult<Unit>>
    {
        private readonly ICategoriaPratoRepository _repository;

        public AdicionarCategoriaPratoCommandHandler(ICategoriaPratoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult<Unit>> Handle(AdicionarCategoriaPratoCommand command, CancellationToken cancellationToken)
        {
            if (command.CategoriaAssociadaId is not null)
            {
                var categoriaExists = await _repository
                    .CategoriaPratoExistsAsync(command.CategoriaAssociadaId.Value,
                    cancellationToken);

                if (!categoriaExists)
                {
                    return CommandResult<Unit>
                        .Fail("A Categoria Informada não é valida.", nameof(command.CategoriaAssociadaId));
                }
            }          
            return await Task.FromResult(CommandResult<Unit>.Success(Unit.Value));
        }
    }
}
