using ClienteAPI.Domain.Models;
using FluentValidation;

namespace ClienteAPI.Validation.Models
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(x => x.Id).SetValidator(new GuidValidator()).WithMessage("Id deve ser um Guid válido");
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres");
            RuleFor(x => x.Telefone).NotNull().NotEmpty().Matches("^\\([1-9]{2}\\) (?:[2-8]|9[1-9])[0-9]{3}\\-[0-9]{4}$").WithMessage("Telefone deve ser no formato (xx) xxxxx-xxxx");
        }
    }
}
