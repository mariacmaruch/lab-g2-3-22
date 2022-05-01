namespace SistemaMoedas.Models
{
    public class Aluno : Participante
    {
        public string Rg { get; set; }
        public Instituicao Instituicao { get; set; }
        public Endereco Endereco { get; set; }
    }
}
