using GourmetGame.Application.Core.Errors;
using GourmetGame.Application.Core.Senders;
using GourmetGame.Application.Pratos.Commands.AdicionarCategoriaPrato;
using GourmetGame.Application.Pratos.Entities;
using GourmetGame.Application.Pratos.Queries.ObterCategoriaPrato;
using GourmetGame.WindowsForms.Core.DisplayMessage;
using GourmetGame.WindowsForms.Core.InputDialogBox;

namespace GourmetGame.WindowsForms.Services
{
    public class GourmetGameService : IGourmetGameService
    {
        private readonly IDispatcher _dispatcher;
        private readonly IDisplayMessageService _displayMessageService;

        public GourmetGameService(IDispatcher dispatcher, IDisplayMessageService displayMessageService)
        {
            _dispatcher = dispatcher;
            _displayMessageService = displayMessageService;
        }

        public async Task IniciarJogo(CancellationToken cancellationToken)
        {
            var pratoPadrao = new Prato("Bolo de Chocolate");
            var categoriaPadrao = new CategoriaPrato("Doce", pratoPadrao);
            
            var categoriaEscolhida = await ObterCategoriaDeEscolhaDoUsuarioAsync(null, cancellationToken)
                ?? categoriaPadrao;

            if (IsPratoSelecionadoPeloUsuario(categoriaEscolhida.Prato))
                _displayMessageService.ShowInformation("Acertei de novo!");
            else
                await AdicionarNovaCategoriaAsync(categoriaEscolhida.Prato.Nome, categoriaEscolhida.Id);

        }

        private async Task<CategoriaPrato?> ObterCategoriaDeEscolhaDoUsuarioAsync(ICollection<CategoriaPrato>? categorias, CancellationToken cancellationToken)
        {
            categorias ??= await _dispatcher.SendQuery(new ObterCategoriasPratoQuery()
            {
                // Buscando apenas as categorias principais removendo da busca as subcategorias
                ApenasCategoriasPrincipais = true
            }, cancellationToken);

            foreach (var categoria in categorias)
            {
                if (!IsCategoriaSelecionadaPeloUsuario(categoria)) continue;

                // Caso o usuário tenha escolhido a categoria, verificaremos (de forma recursiva) se o usuário irá escolher
                // alguma das categorias associadas a categoria escolhida (subCategorias)
                var subCategoriaEscolhida = await ObterCategoriaDeEscolhaDoUsuarioAsync(categoria.SubCategorias, cancellationToken);

                // Caso o usuário tenha escolhido uma subCategoria, retornamos a subCategoria escolhida
                if (subCategoriaEscolhida is not null) return subCategoriaEscolhida;

                // Caso o usuário não tenha escolhido uma subCategoria, após escolher uma categoria
                // retornamos a categoria escolhida anteriormente
                return categoria;
            }
            // Caso o usuário não tenha escolhido nenhuma das categorias
            return null;
        }

        private async Task AdicionarNovaCategoriaAsync(string nomePratoReferencia, int categoriaAssociadaId)
        {
            var resultadoNomePrato = SolicitarEntradaUsuario("Qual prato você pensou?", "Desisto");
            if (resultadoNomePrato.Result != DialogResult.OK || string.IsNullOrWhiteSpace(resultadoNomePrato.InputText)) return;

            var resultadoNomeCategoria = SolicitarEntradaUsuario($"{resultadoNomePrato.InputText} é ______ mas {nomePratoReferencia} não.", "Complete");
            if (resultadoNomeCategoria.Result != DialogResult.OK || string.IsNullOrWhiteSpace(resultadoNomeCategoria.InputText)) return;

            var comando = new AdicionarCategoriaPratoCommand
            {
                NomeCategoria = resultadoNomeCategoria.InputText,
                NomePrato = resultadoNomePrato.InputText,
                CategoriaAssociadaId =
                    categoriaAssociadaId != default ? categoriaAssociadaId : null
            };
            var result = await _dispatcher.SendCommand(comando);
            
            if(!result.HasSuccess) ExibirErrosAoAdicionarNovaCategoria(result.Errors);
        }

        private void ExibirErrosAoAdicionarNovaCategoria(List<BusinessError> errors)
        {
            _displayMessageService.ShowWarnings(errors);
        }

        private InputDialogBoxResult SolicitarEntradaUsuario(string mensagem, string titulo)
        {
            return _displayMessageService.GetInputString(mensagem, titulo);
        }

        private bool IsPratoSelecionadoPeloUsuario(Prato prato)
        {
            return _displayMessageService.ShowQuestion($"O prato que você pensou é {prato.Nome}?") == DialogResult.Yes;
        }

        private bool IsCategoriaSelecionadaPeloUsuario(CategoriaPrato categoria)
        {
            return _displayMessageService.ShowQuestion($"O prato que você pensou é {categoria.Nome}?") == DialogResult.Yes;
        }
    }
}
