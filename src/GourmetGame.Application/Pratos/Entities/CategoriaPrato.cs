namespace GourmetGame.Application.Pratos.Entities
{
    public class CategoriaPrato
    {
        public CategoriaPrato(string nome, Prato prato, int? categoriaAssociadaId = null)
        {
            Nome = nome;
            Prato = prato;
            CategoriaAssociadaId = categoriaAssociadaId;
            SubCategorias = new List<CategoriaPrato>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        // Categoria a qual esta categoria esta associada (Categoria pai)
        public int? CategoriaAssociadaId { get; set; }
        public CategoriaPrato? CategoriaAssociada { get; set; }

        // Categorias associadas a esta categoria (Categorias filhas)
        public ICollection<CategoriaPrato> SubCategorias { get; set; }

        public Prato Prato { get; set; }
    }
}
