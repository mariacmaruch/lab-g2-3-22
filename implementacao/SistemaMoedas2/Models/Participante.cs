using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaMoedas2.Models
{
    public class Participante : Usuario
    {
        public string Cpf { get; set; }

        //public virtual Conta Conta { get; set; }
    }
}
