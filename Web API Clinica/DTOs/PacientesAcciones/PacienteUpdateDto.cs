namespace Web_API_Clinica.DTOs.PacientesAcciones
{
    public class PacienteUpdateDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int MedicoID { get; set; }
        public int ObraSocialID { get; set; }
    }
}
