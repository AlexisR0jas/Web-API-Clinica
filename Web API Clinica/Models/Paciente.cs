using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_Clinica.Models
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacienteID { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [RegularExpression("^[MFmf]$")]
        public string? Sexo { get; set; }
        public int ObraSocialID { get; set; }
        [ForeignKey("ObraSocialID")]
        public virtual ObraSocial ObraSocial { get; set; }

    }
}
