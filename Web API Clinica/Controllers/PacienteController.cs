using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Web_API_Clinica.DTOs;
using Web_API_Clinica.DTOs.PacientesAcciones;
using Web_API_Clinica.Models;
using Web_API_Clinica.Validators;

namespace Web_API_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private ClinicaContext _context;
        private IValidator<PacienteInsertDto> _pacienteInsertValidator;

        public PacienteController(ClinicaContext context,
            IValidator<PacienteInsertDto> pacienteInsertValidator)
        {
            _context = context;
            _pacienteInsertValidator = pacienteInsertValidator;
        }
        [HttpGet]
        public async Task<IEnumerable<PacienteDto>> Get() =>
           await _context.Pacientes.Select(p => new PacienteDto
            {
                Id=p.PacienteID,
                Nombre=p.Nombre,
                Apellido=p.Apellido,
                Sexo=p.Sexo,
                FechaNacimiento=p.FechaNacimiento,
                ObraSocialID=p.ObraSocialID
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDto>> GetById(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            var pacienteDto = new PacienteDto
            {
                Id = paciente.PacienteID,
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                Sexo = paciente.Sexo,
                FechaNacimiento = paciente.FechaNacimiento,
                ObraSocialID = paciente.ObraSocialID
            };
            return Ok(pacienteDto);
        }

        [HttpPost]
        public async Task<ActionResult<PacienteDto>> Add(PacienteInsertDto pacienteInsertDto)
        {
            var validationResult= await _pacienteInsertValidator.ValidateAsync(pacienteInsertDto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

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

            return CreatedAtAction(nameof(GetById), new { id = paciente.PacienteID }, pacienteDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PacienteDto>>Update(int id, PacienteUpdateDto pacienteUpdateDto)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if(paciente==null)
            {
                return NotFound();
            }

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

            return Ok(pacienteDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult>Delete(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        
    }
}
