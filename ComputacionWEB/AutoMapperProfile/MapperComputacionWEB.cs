using AutoMapper;
using CapaDato.Models;
using CapaDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputacionWEB.AutoMapperProfile
{
    public class MapperComputacionWEB : Profile
    {
        public MapperComputacionWEB()
        {
            CreateMap<DetalleEstudianteTelefono, DetalleEstudianteTelefonoDTO>()
                .ForMember(d => d.DescripcionOperadora, d => d.MapFrom(o => o.OperadoraTelefono.Descripcion));

            CreateMap<Estudiante, EstudianteDTO>()
                .ForMember(d => d.DescripcionCarrera, d => d.MapFrom(o => o.Carrera.Descripcion))
                .ForMember(d => d.NumerosTelofonos, d => d.MapFrom(o => string.Join(" | ", o.DetalleEstudianteTelefonos.Select(x => (x.OperadoraTelefono.Descripcion + ": " + x.Numero))) ));

            CreateMap<Facultad, FacultadDTO>();

            CreateMap<Carrera, CarreraDTO>()
                .ForMember(d => d.DescripcionFacultad, d => d.MapFrom(o => o.Facultad.Descripcion));
        }
    }
}