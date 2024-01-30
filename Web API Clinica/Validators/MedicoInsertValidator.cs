using FluentValidation;
using Web_API_Clinica.DTOs.MedicosAcciones;

namespace Web_API_Clinica.Validators
{
    public class MedicoInsertValidator : AbstractValidator<MedicoInsertDto>
    {
        public MedicoInsertValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Nombre).Length(2, 20).WithMessage("El nombre debe medir de 2 a 20 caracteres");
            RuleFor(x => x.EspecialidadID).NotNull().WithMessage("La especialidad es obligatoria");
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("El apellido es obligatorio");
        }
    }
}
