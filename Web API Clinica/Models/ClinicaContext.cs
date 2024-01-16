using Microsoft.EntityFrameworkCore;

namespace Web_API_Clinica.Models
{
    public class ClinicaContext:DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext>options):base(options)
        {

        }
    }
}
