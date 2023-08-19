using AutoMapper;
using ClienteAPI.Data.Repositories;
using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Domain.Commands.Responses;
using ClienteAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Domain.Handlers
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteRequest, CreateClienteResponse>
    {
        private readonly IBaseRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;

        public CreateClienteHandler(
            [FromServices] IBaseRepository<Cliente> clienteRepository,
            [FromServices] IMapper mapper
        )
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<CreateClienteResponse> Handle(CreateClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Cliente>(request);

            cliente.Enderecos.First().Principal = true;
            cliente.Emails.First().Principal = true;

            await _clienteRepository.Add(cliente);
            await _clienteRepository.Commit();

            return _mapper.Map<CreateClienteResponse>(cliente);
        }
    }
}
