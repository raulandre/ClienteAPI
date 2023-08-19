using AutoMapper;
using ClienteAPI.Domain.Commands.Requests;
using ClienteAPI.Domain.Commands.Responses;
using ClienteAPI.Domain.Models;

namespace ClienteAPI.Mappings
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoSecundarioRequest, Endereco>()
                .ReverseMap();

            CreateMap<CreateEnderecoSecundarioResponse, Endereco>()
                .ReverseMap();
        }
    }
}
