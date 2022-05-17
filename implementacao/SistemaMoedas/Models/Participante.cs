namespace SistemaMoedas.Models
{
    public class Participante : Usuario
    {
        public string Cpf { get; set; }
        public Conta Conta { get; set; }
    }
}
