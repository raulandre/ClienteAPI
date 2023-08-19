using AutoMapper;
using ClienteAPI.Data.Repositories;
using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Domain.Commands.Responses;
using ClienteAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Domain.Handlers
{
    public class CreateEnderecoSecundarioHandler : IRequestHandler<CreateEnderecoSecundarioRequest, CreateEnderecoSecundarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Endereco> _enderecoRepository;
        private readonly IBaseRepository<Cliente> _clienteRepository;

        public CreateEnderecoSecundarioHandler(
            [FromServices] IMapper mapper,
            [FromServices] IBaseRepository<Endereco> enderecoRepository,
            [FromServices] IBaseRepository<Cliente> clienteRepository
        )
        {
            _mapper = mapper;
            _enderecoRepository = enderecoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<CreateEnderecoSecundarioResponse> Handle(CreateEnderecoSecundarioRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.Get(request.ClienteId);

            if (cliente is null)
                throw new Exception($"Cliente {request.ClienteId} não encontrado");

            var endereco = _mapper.Map<Endereco>(request);

            await _enderecoRepository.Add(endereco);
            await _enderecoRepository.Commit();

            return _mapper.Map<CreateEnderecoSecundarioResponse>(endereco);
        }
    }
}
