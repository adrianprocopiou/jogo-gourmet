namespace GourmetGame.Application.Pratos.Entities
{
    public class Prato
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        public int CategoriaPratoId { get; set; }
        public CategoriaPrato CategoriaPrato { get; set; }
    }
}
