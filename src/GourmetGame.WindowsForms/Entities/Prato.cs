namespace GourmetGame.WindowsForms.Entities
{
    public class Prato
    {
        public Prato(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            PratosAssociados = new List<Prato>();
        }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<Prato> PratosAssociados { get; set; }
    }
}
