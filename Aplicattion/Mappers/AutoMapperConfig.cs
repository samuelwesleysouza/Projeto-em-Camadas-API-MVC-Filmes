using AutoMapper; 
using Domain.DTOs.DTOsRequest;
using Domain.DTOs.DTOsResponse;
using Domain.Entities;

namespace Aplicattion.Mappers 
{
    public class AutoMapperConfig : Profile // Declara a classe FilmeProfile que herda da classe Profile do AutoMapper
    {
        public AutoMapperConfig() // Inicia o construtor da classe FilmeProfile
        {
            CreateMap<CreateFilmeDTO, Filme>(); // Cria um mapeamento entre CreateFilmeDTO e Filme
            CreateMap<UpdateFilmeDTO, Filme>();
            CreateMap<DeleteFilmeDTO, Filme>(); // O código acima define como o AutoMapper deve mapear as propriedades de CreateFilmeDTO para Filme
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
