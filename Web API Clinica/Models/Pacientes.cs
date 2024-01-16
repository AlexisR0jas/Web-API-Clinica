using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_Clinica.Models
{
    public class Pacientes
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
        public virtual ObrasSociales ObraSocial { get; set; }
        public virtual ICollection<Turnos> Turno{ get; set; }
//        Create Table Pacientes(
//    ID_Paciente bigint primary key identity(1,1) not null,
//	Apellido varchar(100) not null,
//	Nombre varchar(100) not null,
//	FechaNacimiento date not null,
//	Sexo char (1) check(Sexo in ('M','F'))not null,
//	ID_ObraSocial bigint foreign key references ObrasSociales(ID_ObraSocial)
//)
    }
}
