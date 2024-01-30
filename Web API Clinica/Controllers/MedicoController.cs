using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Clinica.DTOs;
using Web_API_Clinica.DTOs.MedicosAcciones;
using Web_API_Clinica.Models;
using Web_API_Clinica.Services.CommonServices;
using Web_API_Clinica.Validators;

namespace Web_API_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private IValidator<MedicoUpdateValidator> _medicoUpdateValidator;
        private IValidator<MedicoInsertValidator> _medicoInsertValidator;
        private ICommonServiceMedico<MedicoDto, MedicoInsertDto, MedicoUpdateDto> _medicoService;

        public MedicoController(IValidator<MedicoUpdateValidator> medicoUpdateValidator,
                                IValidator<MedicoInsertValidator> medicoInsertValidator,
                                [FromKeyedServices("medicoService")]ICommonServiceMedico<MedicoDto, MedicoInsertDto, MedicoUpdateDto> medicoService)
        {
            _medicoUpdateValidator = medicoUpdateValidator;
            _medicoInsertValidator = medicoInsertValidator;
            _medicoService = medicoService;
        }

        [HttpGet]
        public async Task<IEnumerable<MedicoDto>> Get() =>
            await _medicoService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicoDto>>GetById(int id)
        {
            var medicoDto = await _medicoService.GetById(id);

            return medicoDto == null ? NotFound() : Ok(medicoDto);
        }
        [HttpPost]
        public async Task<ActionResult<MedicoDto>> Add(MedicoInsertDto medicoInsertDto)
        {

            var validationResult = await _medicoInsertValidator.ValidateAsync(medicoInsertDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var medicoDto = _medicoService.Add(medicoInsertDto);

            return CreatedAtAction(nameof(GetById), new {id = medicoDto.Id},medicoDto);
        }
    }
}
