using ClienteAPI.Domain.Models;
using ClienteAPI.Validation.Models;
using FluentValidation.TestHelper;

namespace ClienteAPI.Tests.Models
{
    public class EmailTests
    {
        private readonly EmailValidation _validator;

        public EmailTests()
        {
            _validator = new EmailValidation();
        }

        [Fact]
        public void EmailNulo_DeveRetornarErro()
        {
            var request = new Email { Endereco = null };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Endereco);
        }

        [Fact]
        public void EmailVazio_DeveRetornarErro()
        {
            var request = new Email { Endereco = string.Empty };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Endereco);
        }

        [Fact]
        public void EmailInvalido_DeveRetornarErro()
        {
            var request = new Email { Endereco = "もふもふ" };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Endereco);
        }

        [Fact]
        public void EmailValido_NaoDeveRetornarErro()
        {
            var request = new Email { Endereco = "gaben@valvesoftware.com" };

            var response = _validator.TestValidate(request);

            response.ShouldNotHaveValidationErrorFor(r => r.Endereco);
        }
    }
}
