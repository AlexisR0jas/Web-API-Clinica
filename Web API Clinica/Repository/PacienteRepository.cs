using Microsoft.EntityFrameworkCore;
using Web_API_Clinica.Models;

namespace Web_API_Clinica.Repository
{
    public class PacienteRepository : IRepository<Paciente>
    {
        private ClinicaContext _context;

        public PacienteRepository(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> Get() =>
            await _context.Pacientes.ToListAsync();

        public async Task<Paciente> GetById(int id) =>
            await _context.Pacientes.FindAsync(id);
        public async Task Add(Paciente paciente) =>
            await _context.Pacientes.AddAsync(paciente);

        public void Update(Paciente paciente)
        {
            _context.Pacientes.Attach(paciente);
            _context.Pacientes.Entry(paciente).State =  EntityState.Modified;  
        }

        public void Delete(Paciente paciente) =>
            _context.Pacientes.Remove(paciente);

        

        public async Task Save() =>
            await _context.SaveChangesAsync();
        
    }
}
