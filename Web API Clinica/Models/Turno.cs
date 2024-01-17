using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Web_API_Clinica.Models
{
    public class Turno
    {
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TurnoID { get; set; }
		public DateTime FechaHora { get; set; }
		public int MedicoID { get; set; }
		[ForeignKey("MedicoID")]
		public Medico Medico { get; set; }
		public int PacienteID { get; set; }
		[ForeignKey("PacienteID")]
		public virtual Paciente Paciente { get; set; }
		public int Duracion { get; set; }


    }
}
