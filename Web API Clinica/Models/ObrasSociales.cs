using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_Clinica.Models
{
    public class ObrasSociales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObraSocialID { get;set; }
        public string? Nombre { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Cobertura {  get; set; }

 //       Create Table ObrasSociales(
 //   ID_ObraSocial bigint primary key identity(1,1) not null,
	//Nombre varchar(100) not null,
	//Cobertura decimal (10,2) not null

    }
}
