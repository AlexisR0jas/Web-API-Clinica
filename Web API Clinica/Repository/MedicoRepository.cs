using Microsoft.EntityFrameworkCore;
using Web_API_Clinica.Models;

namespace Web_API_Clinica.Repository
{
    public class MedicoRepository : IRepositoryMedico<Medico>
    {
        private ClinicaContext _context;

        public MedicoRepository(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> Get() =>
            await _context.Medicos.ToListAsync();

        public async Task<Medico> GetById(int id) =>
            await _context.Medicos.FindAsync(id);
        public async Task Add(Medico medico) =>
            await _context.Medicos.AddAsync(medico);

        public void Update(Medico medico)
        {
            _context.Medicos.Attach(medico);
            _context.Medicos.Entry(medico).State = EntityState.Modified;
        }

        public void Delete(Medico medico) =>
            _context.Medicos.Remove(medico);



        public async Task Save() =>
            await _context.SaveChangesAsync();
    }
}
