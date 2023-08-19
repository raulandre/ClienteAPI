using ClienteAPI.Domain.Models;

namespace ClienteAPI.Domain.Commands.Responses
{
    public class GetAllClientesResponse
    {
        public IEnumerable<Cliente> Clientes { get; set; }
    }
}
