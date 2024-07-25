using GourmetGame.WindowsForms.Core.DisplayMessage;
using GourmetGame.WindowsForms.Core.InputDialogBox;
using GourmetGame.WindowsForms.Entities;

namespace GourmetGame.WindowsForms.Services
{
    public class GourmetGameService : IGourmetGameService
    {
        private readonly IDisplayMessageService _displayMessageService;
        private readonly List<Prato> _pratosEmMemoria;
        public GourmetGameService(IDisplayMessageService displayMessageService)
        {
            _displayMessageService = displayMessageService;
            _pratosEmMemoria = new List<Prato>()
            {
                new Prato("Lasanha", "massa")
            };
        }

        public void IniciarJogo()
        {
            var nomeDoPratoEscolhido = "Bolo de Chocolate";
            var listaParaAdicaoDoNovoPrato = _pratosEmMemoria;

            var pratoEscolhidoPeloUsuario = ObterPratoDeEscolhaDoUsuario(_pratosEmMemoria);
            if(pratoEscolhidoPeloUsuario is not null)
            {
                nomeDoPratoEscolhido = pratoEscolhidoPeloUsuario.Nome;
                listaParaAdicaoDoNovoPrato = pratoEscolhidoPeloUsuario.PratosAssociados;
            }
            
            if (IsPratoSelecionadoPeloUsuario(nomeDoPratoEscolhido))
                _displayMessageService.ShowInformation("Acertei de novo!", "Jogo Gourmet");
            else
                AdicionarNovoPratoEmMemoria(listaParaAdicaoDoNovoPrato, nomeDoPratoEscolhido);
            
                
        }
        private Prato? ObterPratoDeEscolhaDoUsuario(ICollection<Prato> pratos)
        {
            foreach (var prato in pratos)
            {
                if (IsPratoSelecionadoPeloUsuario(prato.Descricao))
                {
                    var pratoAssociadoEscolhido = ObterPratoDeEscolhaDoUsuario(prato.PratosAssociados);
                    return pratoAssociadoEscolhido ?? prato;
                }
            }
            return null;
        }

        private void AdicionarNovoPratoEmMemoria(List<Prato> lista, string nomePratoReferencia)
        {
            var resultadoNomePrato = SolicitarEntradaUsuario("Qual prato você pensou?", "Desisto");
            if (resultadoNomePrato.Result != DialogResult.OK || string.IsNullOrWhiteSpace(resultadoNomePrato.InputText)) return;

            var resultadoDescricaoPrato = SolicitarEntradaUsuario($"{resultadoNomePrato.InputText} é ______ mas {nomePratoReferencia} não.", "Complete");
            if (resultadoDescricaoPrato.Result != DialogResult.OK || string.IsNullOrWhiteSpace(resultadoDescricaoPrato.InputText)) return;

            var novoPrato = new Prato(resultadoNomePrato.InputText, resultadoDescricaoPrato.InputText);
            lista.Add(novoPrato);
        }
        private InputDialogBoxResult SolicitarEntradaUsuario(string mensagem, string titulo)
        {
            return _displayMessageService.GetInputString(mensagem, titulo);
        }

        private bool IsPratoSelecionadoPeloUsuario(string text)
        {
            return _displayMessageService.ShowQuestion($"O prato que você pensou é {text}?") == DialogResult.Yes;
        }
    }
}
