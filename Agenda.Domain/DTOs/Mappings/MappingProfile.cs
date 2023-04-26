using Agenda.Domain.DTOs.DocumentoTipoDTO;
using Agenda.Domain.DTOs.PessoaDTO;
using Agenda.Domain.DTOs.RecadoDTO;
using Agenda.Domain.DTOs.RecadoStatusDTO;
using Agenda.Domain.DTOs.RecadoTipoDTO;
using Agenda.Domain.DTOs.UsuarioDTO;
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
            CreateMap<Usuario, UsuarioSaidaDto>().ReverseMap();
            CreateMap<RecadoTipo, RecadoTipoEntradaDto>().ReverseMap();
            CreateMap<RecadoStatus, RecadoStatusEntradaDto>().ReverseMap();
            CreateMap<Recado, RecadoEntradaDto>().ReverseMap();
        }

    }
}
