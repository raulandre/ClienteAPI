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
    public class GetAllClientesHandler : IRequestHandler<GetAllClientesRequest, GetAllClientesResponse>
    {
        private readonly IBaseRepository<Cliente> _clienteRepository;

        public GetAllClientesHandler(
            [FromServices] IBaseRepository<Cliente> clienteRepository
        )
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<GetAllClientesResponse> Handle(GetAllClientesRequest request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository
                .List()
                .AsNoTracking()
                .Include(c => c.Emails)
                .Include(c => c.Enderecos)
                .ToListAsync();

            return new GetAllClientesResponse { Clientes = clientes };
        }
    }
}
