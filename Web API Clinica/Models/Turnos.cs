using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Web_API_Clinica.Models
{
    public class Turnos
    {
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TurnoID { get; set; }
		public DateTime FechaHora { get; set; }
		public int MedicoID { get; set; }
		[ForeignKey("MedicoID")]
		public Medicos Medico { get; set; }
		public int PacienteID { get; set; }
		[ForeignKey("PacienteID")]
		public virtual Pacientes Pacientes { get; set; }
		public int Duracion { get; set; }


    }
}
