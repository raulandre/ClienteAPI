using AutoMapper;
using ClienteAPI.Data.Repositories;
using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Domain.Commands.Responses;
using ClienteAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Domain.Handlers
{
    public class GetClienteDetalheHandler : IRequestHandler<GetClienteDetalheRequest, GetClienteDetalheResponse>
    {
        private readonly IBaseRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;

        public GetClienteDetalheHandler(
            [FromServices] IBaseRepository<Cliente> clienteRepository,
            [FromServices] IMapper mapper
        )
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<GetClienteDetalheResponse> Handle(GetClienteDetalheRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository
                .List()
                .Include(c => c.Enderecos)
                .Include(c => c.Emails)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id.Equals(request.ClienteId));

            return _mapper.Map<GetClienteDetalheResponse>(cliente);
        }
    }
}
