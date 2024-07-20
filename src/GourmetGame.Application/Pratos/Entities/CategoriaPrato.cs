namespace GourmetGame.Application.Pratos.Entities
{
    public class CategoriaPrato
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        // Categoria a qual esta categoria esta associada (Categoria pai)
        public int? CategoriaAssociadaId { get; set; }
        public CategoriaPrato CategoriaAssociada { get; set; }

        // Categorias associadas a esta categoria (Categorias filhas)
        public ICollection<CategoriaPrato> SubCategorias { get; set; }

        public ICollection<Prato> Pratos { get; set; }
    }
}
