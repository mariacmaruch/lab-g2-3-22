namespace SistemaMoedas2.Models
{
    public class Vantagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Custo { get; set; }
        public byte[] Dados { get; set; }
        public string ContentType { get; set; }
    }
}
