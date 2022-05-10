using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaMoedas2.Models
{
    public class Aluno : Participante
    {
        public string Rg { get; set; }
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public string Endereco { get; set; }

        //public virtual Endereco Endereco { get; set; }
    }
}
