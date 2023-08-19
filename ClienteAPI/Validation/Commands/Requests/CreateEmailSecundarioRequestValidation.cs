using ClienteAPI.Domain.Commands.Requests;
using FluentValidation;

namespace ClienteAPI.Validation.Commands.Requests
{
    public class CreateEmailSecundarioRequestValidation : AbstractValidator<CreateEmailSecundarioRequest>
    {
        public CreateEmailSecundarioRequestValidation()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email inválido");
        }
    }
}
