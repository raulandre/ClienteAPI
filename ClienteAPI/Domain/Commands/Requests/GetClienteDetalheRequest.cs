using ClienteAPI.Domain.Commands.Responses;
using MediatR;

namespace ClienteAPI.Domain.Commands.Requests
{
    public class GetClienteDetalheRequest : IRequest<GetClienteDetalheResponse>
    {
        public Guid ClienteId { get; set; }

        public GetClienteDetalheRequest(Guid clienteId)
        {
            ClienteId = clienteId;
        }
    }
}
