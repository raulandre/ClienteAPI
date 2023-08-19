using ClienteAPI.Domain.Commands.Responses;
using MediatR;

namespace ClienteAPI.Domain.Commands.Requests
{
    public class CreateEnderecoSecundarioRequest : IRequest<CreateEnderecoSecundarioResponse>
    {
        public Guid ClienteId { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
    }
}
