using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web_API_Clinica.DTOs;
using Web_API_Clinica.DTOs.PacientesAcciones;
using Web_API_Clinica.Models;
using Web_API_Clinica.Repository;

namespace Web_API_Clinica.Services
{
    public class PacienteService : ICommonServicePaciente<PacienteDto, PacienteInsertDto, PacienteUpdateDto>
    {
        private IRepository<Paciente> _pacienteRepository;
        private IMapper _mapper;
        public PacienteService(
            IRepository<Paciente> pacienteRepository,
            IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PacienteDto>> Get()
        {
            var pacientes = await _pacienteRepository.Get();

            return pacientes.Select(p => _mapper.Map<PacienteDto>(p));
        }

        public async Task<PacienteDto> GetById(int id)
        {
            var paciente = await _pacienteRepository.GetById(id);

            if(paciente!=null)
            {
                var pacienteDto = _mapper.Map<PacienteDto>(paciente);

                return pacienteDto;
            }

            return null;
        }

        public async Task<PacienteDto> Add(PacienteInsertDto pacienteInsertDto)
        {
            var paciente = _mapper.Map<Paciente>(pacienteInsertDto);

            await _pacienteRepository.Add(paciente);
            await _pacienteRepository.Save();

            var pacienteDto = _mapper.Map<PacienteDto>(paciente);

            return pacienteDto;
        }
        public async Task<PacienteDto> Update(int id, PacienteUpdateDto pacienteUpdateDto)
        {
            var paciente = await _pacienteRepository.GetById(id);

            if(paciente!=null)
            {
                paciente = _mapper.Map<PacienteUpdateDto, Paciente>(pacienteUpdateDto, paciente);

                _pacienteRepository.Update(paciente);
                await _pacienteRepository.Save();

                var pacienteDto = _mapper.Map<PacienteDto>(paciente);

                return pacienteDto;
            }

            return null;
        }

        public async Task<PacienteDto> Delete(int id)
        {
            var paciente = await _pacienteRepository.GetById(id);

            if (paciente != null)
            {
                var pacienteDto = _mapper.Map<PacienteDto>(paciente);

                _pacienteRepository.Delete(paciente);
                await _pacienteRepository.Save();

                return pacienteDto;
            }

            return null;
        }

        
       
    }
}
