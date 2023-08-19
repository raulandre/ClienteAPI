using ClienteAPI.Domain.Commands.Requests;
using FluentValidation;

namespace ClienteAPI.Validation.Commands.Requests
{
    public class CreateClienteRequestValidation : AbstractValidator<CreateClienteRequest>
    {
        public CreateClienteRequestValidation()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(3).WithMessage("Nome precisa ter pelo menos 3 caracteres");
            RuleFor(x => x.Telefone).NotNull().NotEmpty().Matches("^\\([1-9]{2}\\) (?:[2-8]|9[1-9])[0-9]{3}\\-[0-9]{4}$").WithMessage("Telefone deve ser no formato (xx) xxxxx-xxxx");
            RuleFor(x => x.EmailPrincipal).NotNull().NotEmpty().EmailAddress().WithMessage("Email principal inválido");
            RuleFor(x => x.EnderecoPrincipal).NotNull().WithMessage("Endereço principal é obrigatório");

            RuleFor(x => x.EnderecoPrincipal.Rua).NotNull().NotEmpty().MinimumLength(3).WithMessage("Rua deve ter no mínimo 3 caracteres").When(x => x.EnderecoPrincipal is not null);
            RuleFor(x => x.EnderecoPrincipal.Estado).NotNull().NotEmpty().Length(2).WithMessage("Estado obrigatório (UF)").When(x => x.EnderecoPrincipal is not null);
            RuleFor(x => x.EnderecoPrincipal.Cidade).NotNull().NotEmpty().MinimumLength(3).WithMessage("Cidade deve ter no mínimo 3 caracteres").When(x => x.EnderecoPrincipal is not null);
            RuleFor(x => x.EnderecoPrincipal.CodigoPostal).NotNull().NotEmpty().Length(8).WithMessage("Código postal deve ter 8 caracteres").When(x => x.EnderecoPrincipal is not null);
            RuleFor(x => x.EnderecoPrincipal.Pais).NotNull().NotEmpty().MinimumLength(4).WithMessage("País deve ter pelo menos 4 caracteres").When(x => x.EnderecoPrincipal is not null);
        }
    }
}
