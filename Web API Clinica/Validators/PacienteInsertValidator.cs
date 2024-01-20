using FluentValidation;
using Web_API_Clinica.DTOs.PacientesAcciones;

namespace Web_API_Clinica.Validators
{
    public class PacienteInsertValidator: AbstractValidator<PacienteInsertDto>
    {
        public PacienteInsertValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty();
        }


    }
}
