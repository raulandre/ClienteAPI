using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Validation.Commands.Requests;
using FluentValidation.TestHelper;

namespace ClienteAPI.Tests.Commands
{
    public class CreateClienteRequestTests
    {
        private readonly CreateClienteRequestValidation _validator;

        public CreateClienteRequestTests()
        {
            _validator = new CreateClienteRequestValidation();
        }

        [Fact]
        public void EmailNulo_DeveRetornarErro()
        {
            var request = new CreateClienteRequest { EmailPrincipal = null };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.EmailPrincipal);
        }

        [Fact]
        public void EmailVazio_DeveRetornarErro()
        {
            var request = new CreateClienteRequest { EmailPrincipal = string.Empty };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.EmailPrincipal);
        }

        [Fact]
        public void EmailInvalido_DeveRetornarErro()
        {
            var request = new CreateClienteRequest { EmailPrincipal = "もふもふ" };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.EmailPrincipal);
        }

        [Fact]
        public void EmailValido_NaoDeveRetornarErro()
        {
            var request = new CreateClienteRequest { EmailPrincipal = "gaben@valvesoftware.com" };

            var response = _validator.TestValidate(request);

            response.ShouldNotHaveValidationErrorFor(r => r.EmailPrincipal);
        }

        [Fact]
        public void TelefoneNulo_DeveRetornarErro()
        {
            var request = new CreateClienteRequest { Telefone = null };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Telefone);
        }

        [Fact]
        public void TelefoneVazio_DeveRetornarErro()
        {
            var request = new CreateClienteRequest { Telefone = string.Empty };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Telefone);
        }

        [Fact]
        public void TelefoneFormatoInvalido_DeveRetornarErro()
        {
            var request = new CreateClienteRequest { Telefone = "40028922" };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Telefone);
        }

        [Fact]
        public void TelefoneFormatoValido_NaoDeveRetornarErro()
        {
            var request = new CreateClienteRequest { Telefone = "(11) 94002-8922" };

            var response = _validator.TestValidate(request);

            response.ShouldNotHaveValidationErrorFor(r => r.Telefone);
        }
    }
}
