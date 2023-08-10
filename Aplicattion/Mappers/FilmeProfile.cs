using AutoMapper;
using Domain.DTOs.DTOsRequest;
using Domain.DTOs.DTOsResponse;
using Domain.Entities;

namespace Aplicattion.Mappers
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>(); // Cria o mapeamento conforme necessário
            CreateMap<UpdateFilmeDTO, Filme>();
            CreateMap<DeleteFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
