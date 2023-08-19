using ClienteAPI.Domain.Commands.Requests;
using FluentValidation;

namespace ClienteAPI.Validation.Commands.Requests
{
    public class CreateEnderecoSecundarioRequestValidation : AbstractValidator<CreateEnderecoSecundarioRequest>
    {
        public CreateEnderecoSecundarioRequestValidation()
        {
            RuleFor(x => x.Rua).NotNull().NotEmpty().MinimumLength(3).WithMessage("Rua deve ter no mínimo 3 caracteres");
            RuleFor(x => x.Estado).NotNull().NotEmpty().Length(2).WithMessage("Estado obrigatório (UF)");
            RuleFor(x => x.Cidade).NotNull().NotEmpty().MinimumLength(3).WithMessage("Cidade deve ter no mínimo 3 caracteres");
            RuleFor(x => x.CodigoPostal).NotNull().NotEmpty().Length(8).WithMessage("Código postal deve ter 8 caracteres");
            RuleFor(x => x.Pais).NotNull().NotEmpty().MinimumLength(4).WithMessage("País deve ter pelo menos 4 caracteres");
        }
    }
}
