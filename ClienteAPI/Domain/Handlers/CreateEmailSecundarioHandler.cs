using AutoMapper;
using ClienteAPI.Data.Repositories;
using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Domain.Commands.Responses;
using ClienteAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Domain.Handlers
{
    public class CreateEmailSecundarioHandler : IRequestHandler<CreateEmailSecundarioRequest, CreateEmailSecundarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Email> _emailRepository;
        private readonly IBaseRepository<Cliente> _clienteRepository;

        public CreateEmailSecundarioHandler(
            [FromServices] IMapper mapper,
            [FromServices] IBaseRepository<Email> emailRepository,
            [FromServices] IBaseRepository<Cliente> clienteRepository
        )
        {
            _mapper = mapper;
            _emailRepository = emailRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<CreateEmailSecundarioResponse> Handle(CreateEmailSecundarioRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.Get(request.ClienteId);

            if (cliente is null)
                throw new Exception($"Cliente {request.ClienteId} não encontrado");

            var email = _mapper.Map<Email>(request);
            await _emailRepository.Add(email);
            await _emailRepository.Commit();

            return _mapper.Map<CreateEmailSecundarioResponse>(email);
        }
    }
}
