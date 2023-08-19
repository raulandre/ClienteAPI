using ClienteAPI.Domain.Commands.Requests;

namespace ClienteAPI.Domain.Commands.Responses
{
    public class GetClienteDetalheResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string EmailPrincipal { get; set; }
        public EnderecoInfo EnderecoPrincipal { get; set; }
    }
}
