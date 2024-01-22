using Microsoft.EntityFrameworkCore;
using Web_API_Clinica.DTOs;
using Web_API_Clinica.DTOs.PacientesAcciones;
using Web_API_Clinica.Models;
using Web_API_Clinica.Repository;

namespace Web_API_Clinica.Services
{
    public class PacienteService : ICommonService<PacienteDto, PacienteInsertDto, PacienteUpdateDto>
    {
        private IRepository<Paciente> _pacienteRepository; 
        public PacienteService(
            IRepository<Paciente> pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<PacienteDto>> Get()
        {
            var pacientes = await _pacienteRepository.Get();

            return pacientes.Select(p => new PacienteDto()
            {
                Id = p.PacienteID,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Sexo = p.Sexo,
                FechaNacimiento = p.FechaNacimiento,
                ObraSocialID = p.ObraSocialID
            });
        }

        public async Task<PacienteDto> GetById(int id)
        {
            var paciente = await _pacienteRepository.GetById(id);

            if(paciente!=null)
            {
                var pacienteDto = new PacienteDto
                {
                    Id = paciente.PacienteID,
                    Nombre = paciente.Nombre,
                    Apellido = paciente.Apellido,
                    Sexo = paciente.Sexo,
                    FechaNacimiento = paciente.FechaNacimiento,
                    ObraSocialID = paciente.ObraSocialID
                };

                return pacienteDto;
            }

            return null;
        }

        public async Task<PacienteDto> Add(PacienteInsertDto pacienteInsertDto)
        {
            var paciente = new Paciente()
            {
                Nombre = pacienteInsertDto.Nombre,
                Apellido = pacienteInsertDto.Apellido,
                Sexo = pacienteInsertDto.Sexo,
                FechaNacimiento = pacienteInsertDto.FechaNacimiento,
                ObraSocialID = pacienteInsertDto.ObraSocialID
            };

            await _pacienteRepository.Add(paciente);
            await _pacienteRepository.Save(); 

            var pacienteDto = new PacienteDto()
            {
                Id = paciente.PacienteID,
                Nombre = pacienteInsertDto.Nombre,
                Apellido = pacienteInsertDto.Apellido,
                Sexo = pacienteInsertDto.Sexo,
                FechaNacimiento = pacienteInsertDto.FechaNacimiento,
                ObraSocialID = pacienteInsertDto.ObraSocialID
            };

            return pacienteDto;
        }
        public async Task<PacienteDto> Update(int id, PacienteUpdateDto pacienteUpdateDto)
        {
            var paciente = await _pacienteRepository.GetById(id);

            if(paciente!=null)
            { 
                paciente.Nombre = pacienteUpdateDto.Nombre;
                paciente.Apellido = pacienteUpdateDto.Apellido;
                paciente.Sexo = pacienteUpdateDto.Sexo;
                paciente.FechaNacimiento = pacienteUpdateDto.FechaNacimiento;
                paciente.ObraSocialID = pacienteUpdateDto.ObraSocialID;

                _pacienteRepository.Update(paciente);
                await _pacienteRepository.Save();

                var pacienteDto = new PacienteDto()
                {
                    Id = paciente.PacienteID,
                    Nombre = paciente.Nombre,
                    Apellido = paciente.Apellido,
                    Sexo = paciente.Sexo,
                    FechaNacimiento = paciente.FechaNacimiento,
                    ObraSocialID = paciente.ObraSocialID
                };

                return pacienteDto;
            }

            return null;
        }

        public async Task<PacienteDto> Delete(int id)
        {
            var paciente = await _pacienteRepository.GetById(id);

            if (paciente != null)
            {
                var pacienteDto = new PacienteDto()
                {
                    Id = paciente.PacienteID,
                    Nombre = paciente.Nombre,
                    Apellido = paciente.Apellido,
                    Sexo = paciente.Sexo,
                    FechaNacimiento = paciente.FechaNacimiento,
                    ObraSocialID = paciente.ObraSocialID
                };

                _pacienteRepository.Delete(paciente);
                await _pacienteRepository.Save();

                return pacienteDto;
            }

            return null;
        }

        
       
    }
}
