using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Domain.Commands.Responses;
using ClienteAPI.Domain.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("v1/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController([FromServices] IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Busca todos os clientes cadastrados
        /// </summary>
        /// <returns>Lista com todos os clientes cadastrados com todos os emails e endereços</returns>
        [HttpGet]
        public async Task<ActionResult<GetAllClientesResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetAllClientesRequest());

            if (response.Clientes.Count() is 0)
                return NotFound();

            return Ok(response.Clientes);
        }

        /// <summary>
        /// Busca por um cliente específico
        /// </summary>
        /// <param name="clienteId">Id do cliente para busca</param>
        /// <returns>
        /// Quando o cliente existe: cliente cadastrado com o email principal e endereço principal
        /// Quando o cliente não existe: NotFound()
        /// </returns>
        [HttpGet("{clienteId}")]
        public async Task<ActionResult<GetClienteDetalheResponse>> GetDetalhe(
            Guid clienteId
        )
        {
            var cliente = await _mediator.Send(new GetClienteDetalheRequest(clienteId));

            if (cliente is null)
                return NotFound();

            return Ok(cliente);
        }

        /// <summary>
        /// Cria um cliente com email principal e endereço principal
        /// </summary>
        /// <returns>
        /// Quando criado com sucesso: cliente criado
        /// Caso ocorra erro: BadRequest()
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<CreateClienteResponse>> Create(
            [FromBody] CreateClienteRequest command
        )
        {
            var response = await _mediator.Send(command);

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        /// <summary>
        /// Atualiza o cliente, adicionando um email secundário
        /// </summary>
        /// <param name="clienteId">Id do cliente a ser atualizado</param>
        /// <returns>Email secundário cadastrado</returns>
        [HttpPut("{clienteId}/email-secundario")]
        public async Task<ActionResult<CreateEmailSecundarioResponse>> CreateEmailSecundario(
            [FromRoute] string clienteId,
            [FromBody] CreateEmailSecundarioRequest command
        )
        {
            command.ClienteId = Guid.Parse(clienteId);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        /// <summary>
        /// Atualiza o cliente, adicionando um endereço secundário
        /// </summary>
        /// <param name="clienteId">Id do cliente a ser atualizado</param>
        /// <returns>Endereço secundário cadastrado</returns>
        [HttpPut("{clienteId}/endereco-secundario")]
        public async Task<ActionResult<CreateEnderecoSecundarioResponse>> CreateEnderecoSecundario(
            [FromRoute] string clienteId,
            [FromBody] CreateEnderecoSecundarioRequest command
        )
        {
            command.ClienteId = Guid.Parse(clienteId);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
