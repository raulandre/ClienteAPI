using ClienteAPI.Domain.Commands.Responses;
using ClienteAPI.Domain.Models;
using MediatR;

namespace ClienteAPI.Domain.Commands.Requests
{
    public class CreateClienteRequest : IRequest<CreateClienteResponse>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string EmailPrincipal { get; set; }
        public EnderecoInfo EnderecoPrincipal { get; set; }
    }

    public class EnderecoInfo
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }

        public static implicit operator Endereco(EnderecoInfo enderecoInfo)
        {
            return new Endereco
            {
                Rua = enderecoInfo.Rua,
                Cidade = enderecoInfo.Cidade,
                Estado = enderecoInfo.Estado,
                CodigoPostal = enderecoInfo.CodigoPostal,
                Pais = enderecoInfo.Pais
            };
        }
    }
}