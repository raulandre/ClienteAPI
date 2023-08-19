using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteAPI.Domain.Models
{
    public class Email
    {
        public Email()
        { }

        public Email(string endereco)
        {
            Endereco = endereco;
        }

        public Guid Id { get; set; }
        public string Endereco { get; set; }
        public bool Principal { get; set; } = false;

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        public override string ToString()
        {
            return Endereco;
        }
    }
}