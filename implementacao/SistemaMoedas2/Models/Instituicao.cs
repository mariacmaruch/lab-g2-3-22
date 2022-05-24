namespace SistemaMoedas2.Models
{
    public class Instituicao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Professor> Professores { get; set; }
    }
}
