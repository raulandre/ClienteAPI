namespace ClienteAPI.Domain.Models
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public ICollection<Email> Emails { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
