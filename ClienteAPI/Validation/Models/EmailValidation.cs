using ClienteAPI.Domain.Models;
using FluentValidation;

namespace ClienteAPI.Validation.Models
{
    public class EmailValidation : AbstractValidator<Email>
    {
        public EmailValidation()
        {
            RuleFor(x => x.Id).SetValidator(new GuidValidator()).WithMessage("Id deve ser um Guid válido");
            RuleFor(x => x.Endereco).NotNull().NotEmpty().EmailAddress().WithMessage("Endereço do email é obrigatório");
        }
    }
}
