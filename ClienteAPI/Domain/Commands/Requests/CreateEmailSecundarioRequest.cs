using ClienteAPI.Domain.Commands.Responses;
using MediatR;

namespace ClienteAPI.Domain.Commands.Requests
{
    public class CreateEmailSecundarioRequest : IRequest<CreateEmailSecundarioResponse>
    {
        public Guid ClienteId { get; set; }
        public string Email { get; set; }
    }
}
