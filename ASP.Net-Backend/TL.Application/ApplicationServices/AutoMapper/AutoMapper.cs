using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL.Application.ApplicationServices.DTOs;
using TL.Domain.Entidades;
using TL.Domain.Relaciones;
using TL.Infrastructure.Identity;

namespace TL.Application.ApplicationServices.AutoMapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //Mapeo de Usuarios y Entidades Relacionadas
            //CreateMap<User, UserDto>();
            //CreateMap<RegisterDto, User>();
            //CreateMap<LoginDto, User>();

            CreateMap<Acepcion, AcepcionDTO>();
            CreateMap<AcepcionDTO, Acepcion>();

            CreateMap<DiccionarioDTO, Diccionario>();
            CreateMap<Diccionario, DiccionarioDTO>();

            CreateMap<DiccionarioTerminoDTO, DiccionarioTermino>();
            CreateMap<DiccionarioTermino, DiccionarioTerminoDTO>();

            CreateMap<EditorDTO, Editor>();
            CreateMap<Editor, EditorDTO>();

            CreateMap<MetadatosDTO, Metadatos>();
            CreateMap<Metadatos, MetadatosDTO>();

            CreateMap<SubEntrada, SubEntradaDTO>();
            CreateMap<SubEntradaDTO, SubEntrada>();

            CreateMap<Termino, TerminoDTO>();
            CreateMap<TerminoDTO, Termino>();

        }
    }
}
