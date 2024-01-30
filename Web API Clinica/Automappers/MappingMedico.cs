using AutoMapper;
using Web_API_Clinica.DTOs.PacientesAcciones;
using Web_API_Clinica.DTOs;
using Web_API_Clinica.Models;
using Web_API_Clinica.DTOs.MedicosAcciones;

namespace Web_API_Clinica.Automappers
{
    public class MappingMedico : Profile
    {
        public MappingMedico()
        {
            CreateMap<MedicoInsertDto, Medico>();
            CreateMap<Medico, MedicoDto>()
                .ForMember(dto => dto.Id,
                            m => m.MapFrom(p => p.MedicoID));
            CreateMap<MedicoUpdateDto, Medico>();
        }
    }
}
