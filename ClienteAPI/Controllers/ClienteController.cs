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

        [HttpGet]
        public async Task<ActionResult<GetAllClientesResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetAllClientesRequest());

            if (response.Clientes.Count() is 0)
                return NotFound();

            return Ok(response.Clientes);
        }

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
    }
}
