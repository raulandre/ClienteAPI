using ClienteAPI.Domain.Commands.Responses;
using MediatR;

namespace ClienteAPI.Domain.Commands.Requests
{
    public class GetAllClientesRequest : IRequest<GetAllClientesResponse>
    { }
}
