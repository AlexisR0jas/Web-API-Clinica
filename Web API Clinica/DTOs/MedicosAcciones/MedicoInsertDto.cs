using System.ComponentModel.DataAnnotations.Schema;
using Web_API_Clinica.Models;

namespace Web_API_Clinica.DTOs.MedicosAcciones
{
    public class MedicoInsertDto
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int EspecialidadID { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public decimal CostoConsulta { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
