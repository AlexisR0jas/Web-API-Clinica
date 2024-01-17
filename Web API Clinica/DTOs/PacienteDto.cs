namespace Web_API_Clinica.DTOs
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }  
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }   
        public int MedicoID { get; set; }
    }
}
