using ClienteAPI.Domain.Commands.Requests;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteAPI.Domain.Models
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public bool Principal { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        public static implicit operator EnderecoInfo(Endereco endereco)
        {
            return new EnderecoInfo
            {
                Rua = endereco.Rua,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                CodigoPostal = endereco.CodigoPostal,
                Pais = endereco.Pais
            };
        }
    }
}