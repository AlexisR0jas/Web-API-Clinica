using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Web_API_Clinica.DTOs;
using Web_API_Clinica.DTOs.PacientesAcciones;
using Web_API_Clinica.Models;
using Web_API_Clinica.Services;
using Web_API_Clinica.Validators;

namespace Web_API_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IValidator<PacienteInsertDto> _pacienteInsertValidator;
        private IValidator<PacienteUpdateDto> _pacienteUpdateValidator; 
        private ICommonService<PacienteDto, PacienteInsertDto, PacienteUpdateDto> _pacienteService;

        public PacienteController(
            IValidator<PacienteInsertDto> pacienteInsertValidator,
            IValidator<PacienteUpdateDto> pacienteUpdateValidator,
            [FromKeyedServices("pacienteService")]ICommonService<PacienteDto, PacienteInsertDto, PacienteUpdateDto> pacienteService)
        {
            _pacienteInsertValidator = pacienteInsertValidator;
            _pacienteUpdateValidator = pacienteUpdateValidator;
            _pacienteService =  pacienteService;
        }

        [HttpGet]
        public async Task<IEnumerable<PacienteDto>> Get() =>
           await _pacienteService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDto>> GetById(int id)
        {
            var pacientoDto = await _pacienteService.GetById(id);

            return pacientoDto == null ? NotFound() : Ok(pacientoDto);
        }

        [HttpPost]
        public async Task<ActionResult<PacienteDto>> Add(PacienteInsertDto pacienteInsertDto)
        {
            var validationResult= await _pacienteInsertValidator.ValidateAsync(pacienteInsertDto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var pacienteDto = await _pacienteService.Add(pacienteInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = pacienteDto.Id }, pacienteDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PacienteDto>>Update(int id, PacienteUpdateDto pacienteUpdateDto)
        {
            var validationResult = await _pacienteUpdateValidator.ValidateAsync(pacienteUpdateDto);
            if(!validationResult.IsValid)
            { 
                return BadRequest(validationResult.Errors);
            }

            var pacienteDto = await _pacienteService.Update(id, pacienteUpdateDto);
            return pacienteDto == null ? NotFound() : Ok(pacienteDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PacienteDto>>Delete(int id)
        {
            var pacienteDto = await _pacienteService.Delete(id);
            return pacienteDto == null ? NotFound() : Ok(pacienteDto);   
        }
        
        
    }
}
