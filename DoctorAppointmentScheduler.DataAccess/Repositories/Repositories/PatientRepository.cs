using DoctorAppointmentScheduler.DataAccess.Contexts;
using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllByContactNumber(string ContactNumber)
        {
            return await _context.Patients.Where(p => p.ContactNumber == ContactNumber).ToListAsync();
        }

        public async Task AddAsync(Patient patient)
        {
            _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

    }
}
