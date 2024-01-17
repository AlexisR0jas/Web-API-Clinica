using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace Web_API_Clinica.Models
{
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicoID { get; set; } 
        public string? Nombre { get; set; }  
        public string? Apellido { get; set; }
        public int EspecialidadID { get; set; }
        [ForeignKey("EspecialidadID")]
        public virtual Especialidad Especialidad { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal CostoConsulta { get; set; }
        public Date FechaIngreso { get; set; }

        public virtual ICollection<Turno> Turno { get; set; }

    }
}
