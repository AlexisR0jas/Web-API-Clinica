using Microsoft.EntityFrameworkCore;
using Web_API_Clinica.DTOs;
using Web_API_Clinica.DTOs.PacientesAcciones;
using Web_API_Clinica.Models;

namespace Web_API_Clinica.Services
{
    public class PacienteService : ICommonService<PacienteDto, PacienteInsertDto, PacienteUpdateDto>
    {
        private ClinicaContext _context;
        public PacienteService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PacienteDto>> Get() =>
            await _context.Pacientes.Select(p => new PacienteDto
            {
                Id = p.PacienteID,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Sexo = p.Sexo,
                FechaNacimiento = p.FechaNacimiento,
                ObraSocialID = p.ObraSocialID
            }).ToListAsync();

        public async Task<PacienteDto> GetById(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

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

            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();

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
            var paciente = await _context.Pacientes.FindAsync(id);

            if(paciente!=null)
            { 
                paciente.Nombre = pacienteUpdateDto.Nombre;
                paciente.Apellido = pacienteUpdateDto.Apellido;
                paciente.Sexo = pacienteUpdateDto.Sexo;
                paciente.FechaNacimiento = pacienteUpdateDto.FechaNacimiento;
                paciente.ObraSocialID = pacienteUpdateDto.ObraSocialID;

                await _context.SaveChangesAsync();

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
            var paciente = await _context.Pacientes.FindAsync(id);

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

                _context.Remove(paciente);
                await _context.SaveChangesAsync();

                return pacienteDto;
            }

            return null;
        }

        
       
    }
}
