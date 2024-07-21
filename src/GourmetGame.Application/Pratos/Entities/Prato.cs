namespace GourmetGame.Application.Pratos.Entities
{
    public class Prato
    {
        public Prato(string nome, int? categoriaPratoId = null)
        {
            Nome = nome;
            CategoriaPratoId = categoriaPratoId;
        }
        public int Id { get; set; }
        public string Nome { get; set; }

        public int? CategoriaPratoId { get; set; }
        public CategoriaPrato? CategoriaPrato { get; set; }
    }
}
