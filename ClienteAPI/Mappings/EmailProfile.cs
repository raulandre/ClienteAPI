using AutoMapper;
using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Domain.Commands.Responses;
using ClienteAPI.Domain.Models;

namespace ClienteAPI.Mappings
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<CreateEmailSecundarioRequest, Email>()
                .ForMember(c => c.Endereco, o => o.MapFrom(r => r.Email));

            CreateMap<Email, CreateEmailSecundarioResponse>()
                .ForMember(c => c.Email, o => o.MapFrom(r => r.Endereco));
        }
    }
}
