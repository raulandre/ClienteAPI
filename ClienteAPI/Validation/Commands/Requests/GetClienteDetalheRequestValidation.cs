using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Domain.Commands.Responses;
using FluentValidation;

namespace ClienteAPI.Validation.Commands.Requests
{
    public class GetClienteDetalheRequestValidation : AbstractValidator<GetClienteDetalheRequest>
    {
        public GetClienteDetalheRequestValidation()
        {
            RuleFor(x => x.ClienteId).SetValidator(new GuidValidator());
        }
    }
}
