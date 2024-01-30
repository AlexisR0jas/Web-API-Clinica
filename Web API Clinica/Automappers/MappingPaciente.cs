using AutoMapper;
using Web_API_Clinica.DTOs;
using Web_API_Clinica.DTOs.PacientesAcciones;
using Web_API_Clinica.Models;

namespace Web_API_Clinica.Automappers
{
    public class MappingPaciente : Profile
    { 

        public MappingPaciente()
        {
            CreateMap<PacienteInsertDto, Paciente>();
            CreateMap<Paciente, PacienteDto>()
                .ForMember(dto => dto.Id,
                            m => m.MapFrom(p => p.PacienteID));
            CreateMap<PacienteUpdateDto, Paciente>();
        }

    }
}
