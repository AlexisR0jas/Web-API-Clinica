using Microsoft.EntityFrameworkCore;

namespace Web_API_Clinica.Models
{
    public class ClinicaContext:DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options)
        {
            
        }

        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Factura> Facturas { get; set;}
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<ObraSocial> ObrasSociales{ get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Turno> Turnos{ get; set; }
    }
}
