using AutoMapper;
using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Domain.Commands.Responses;
using ClienteAPI.Domain.Models;

namespace ClienteAPI.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteRequest, Cliente>()
                .ForMember(c => c.Enderecos, o => o.MapFrom(r => new List<Endereco> { r.EnderecoPrincipal }))
                .ForMember(c => c.Emails, o => o.MapFrom(r => new List<Email> { new Email(r.EmailPrincipal) }))
                .ReverseMap();

            CreateMap<Cliente, CreateClienteResponse>()
                .ForMember(c => c.EmailPrincipal, o => o.MapFrom(r => r.Emails.FirstOrDefault(e => e.Principal)))
                .ForMember(c => c.EnderecoPrincipal, o => o.MapFrom(r => r.Enderecos.FirstOrDefault(e => e.Principal)))
                .ReverseMap();

            CreateMap<Cliente, GetClienteDetalheResponse>()
                .ForMember(c => c.EmailPrincipal, o => o.MapFrom(r => r.Emails.FirstOrDefault(e => e.Principal)))
                .ForMember(c => c.EnderecoPrincipal, o => o.MapFrom(r => r.Enderecos.FirstOrDefault(e => e.Principal)))
                .ReverseMap();
        }
    }
}
