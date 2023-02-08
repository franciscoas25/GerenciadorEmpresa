using AutoMapper;
using Gerenciador.Domain.Models;
using GerenciadorEmpresa.ViewModel;

namespace GerenciadorEmpresa
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<Colaborador, ColaboradorViewModel>()
                .ForMember(dst => dst.NomeEmpresa, map => map.MapFrom(src => src.Empresa.NomeEmpresa));

            CreateMap<Tarefa, TarefaViewModel>()
                .ForMember(dst => dst.NomeColaborador, map => map.MapFrom(src => src.Colaborador.NomeColaborador));
        }
    }
}
