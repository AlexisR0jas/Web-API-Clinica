using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Web_API_Clinica.Models
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacturaID { get; set; }
        public int PacienteID { get; set; }
        [ForeignKey("PacienteID")]
        public virtual Paciente Paciente { get; set; }
        public int MedicoID { get; set; }
        [ForeignKey("MedicoID")]
        public virtual Medico Medico { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Costo { get; set; }
        public DateTime FechaEmision { get; set; }

//        Create Table Facturas(
//    ID_Factura bigint primary key identity(1,1) not null,
//	ID_Paciente bigint foreign key references Pacientes(ID_Paciente),
//	ID_Medico bigint foreign key references Medicos(ID_Medico),
//	Costo money not null,
//	FecheEmision datetime not null
//)
    }
}
