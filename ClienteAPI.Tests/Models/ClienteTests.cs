using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Domain.Models;
using ClienteAPI.Validation.Commands.Requests;
using ClienteAPI.Validation.Models;
using FluentValidation.TestHelper;

namespace ClienteAPI.Tests.Models
{

    public class ClienteTests
    {
        private readonly ClienteValidation _validator;

        public ClienteTests()
        {
            _validator = new ClienteValidation();
        }

        [Fact]
        public void NomeNulo_DeveRetornarErro()
        {
            var request = new Cliente { Nome = null };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Nome);
        }

        [Fact]
        public void NomeVazio_DeveRetornarErro()
        {
            var request = new Cliente { Nome = string.Empty };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Nome);
        }

        [Fact]
        public void NomeMenorQueTresCaracteres_DeveRetornarErro()
        {
            var request = new Cliente { Nome = "xd" };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Nome);
        }

        [Fact]
        public void NomeValido_NaoDeveRetornarErro()
        {
            var request = new Cliente { Nome = "raul" };

            var response = _validator.TestValidate(request);

            response.ShouldNotHaveValidationErrorFor(r => r.Nome);
        }

        [Fact]
        public void TelefoneNulo_DeveRetornarErro()
        {
            var request = new Cliente { Telefone = null };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Telefone);
        }

        [Fact]
        public void TelefoneVazio_DeveRetornarErro()
        {
            var request = new Cliente { Telefone = string.Empty };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Telefone);
        }

        [Fact]
        public void TelefoneFormatoInvalido_DeveRetornarErro()
        {
            var request = new Cliente { Telefone = "40028922" };

            var response = _validator.TestValidate(request);

            response.ShouldHaveValidationErrorFor(r => r.Telefone);
        }

        [Fact]
        public void TelefoneFormatoValido_NaoDeveRetornarErro()
        {
            var request = new Cliente { Telefone = "(11) 94002-8922" };

            var response = _validator.TestValidate(request);

            response.ShouldNotHaveValidationErrorFor(r => r.Telefone);
        }
    }
}
