using FluentValidation;
using Web_API_Clinica.DTOs.PacientesAcciones;

namespace Web_API_Clinica.Validators
{
    public class PacienteInsertValidator: AbstractValidator<PacienteInsertDto>
    {
        public PacienteInsertValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Nombre).Length(2, 20).WithMessage("El nombre debe medir de 2 a 20 caracteres");
            RuleFor(x => x.ObraSocialID).NotNull().WithMessage("La obra social es obligatoria");
            RuleFor(x => x.Sexo).NotEmpty().WithMessage("El {PropertyName} debe ser M o F");
            
        } 


    }
}
