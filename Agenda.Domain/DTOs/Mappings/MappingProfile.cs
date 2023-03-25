using Agenda.Domain.Models;
using AutoMapper;

namespace Agenda.Domain.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, PessoaEntradaDto>().ReverseMap();
            CreateMap<DocumentoTipo, DocumentoTipoEntradaDto>().ReverseMap();
            CreateMap<PessoaTipo, PessoaTipoEntradaDto>().ReverseMap();
            CreateMap<Usuario, UsuarioEntradaDto>().ReverseMap();
        }

    }
}
